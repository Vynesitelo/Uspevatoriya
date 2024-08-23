
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Успеватория
{
    /// <summary>
    /// Базовый класс для запуска анимации, когда тру и обратной анимации когда фолз
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Protected Properties

        /// <summary>
        /// Истинно, если это первый раз, когда значение обновляется
        /// Используется, чтобы убедиться, что мы запускаем логику хотя бы один раз во время первой загрузки
        /// </summary>
        protected Dictionary<WeakReference, bool> mAlreadyLoaded = new Dictionary<WeakReference, bool>();

        /// <summary>
        /// Самое последнее значение, используемое, если мы изменили значение до первой загрузки.
        /// </summary>
        protected Dictionary<WeakReference, bool> mFirstLoadValue = new Dictionary<WeakReference, bool>();

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Получаем framework element
            if (!(sender is FrameworkElement element))
                return;

            // Попробуйте получить уже загруженную ссылку
            var alreadyLoadedReference = mAlreadyLoaded.FirstOrDefault(f => f.Key.Target == sender);

            // Попробуйте получить первую ссылку на загрузку
            var firstLoadReference = mFirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);

            // Не запускать, если значение не изменится
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && alreadyLoadedReference.Key != null)
                return;

            // Первый запуск...
            if (alreadyLoadedReference.Key == null)
            {
                // Создать ссылку
                var weakReference = new WeakReference(sender);

                // Пометить, что мы находимся на первой загрузке, но еще не завершили ее
                mAlreadyLoaded[weakReference] = false;

                // Начнем со скрытого, прежде чем решим, как анимировать
                element.Visibility = Visibility.Hidden;

                // Создайте одно событие с возможностью самостоятельного отсоединения 
                // для события Loaded элементов
                RoutedEventHandler onLoaded = null;
                onLoaded = async (ss, ee) =>
                {
                    // Отвязываем
                    element.Loaded -= onLoaded;

                    // Небольшая задержка после загрузки необходима для размещения некоторых элементов
                    // их ширина/высота рассчитаны правильно
                    await Task.Delay(5);

                    // Обновите первое значение загрузки, если оно изменилось
                    // поскольку задержка 5 мс
                    firstLoadReference = mFirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);

                    // Сделайте желаемую анимацию
                    DoAnimation(element, firstLoadReference.Key != null ? firstLoadReference.Value : (bool)value, true);

                    // Flag that we have finished first load
                    mAlreadyLoaded[weakReference] = true;
                };

                // Подключитесь к событию Loaded элемента
                element.Loaded += onLoaded;
            }
            // Если мы начали первую загрузку, но еще не запустили анимацию, обновите свойство
            else if (alreadyLoadedReference.Value == false)
                mFirstLoadValue[new WeakReference(sender)] = (bool)value;
            else
                // Сделайте желаемую анимацию
                DoAnimation(element, (bool)value, false);
        }

        /// <summary>
        /// Метод анимации, который запускается при изменении значения
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <param name="value">Значение</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    /// <summary>
    /// Изображение исчезает при смене источника
    /// </summary>
    public class FadeInImageOnLoadProperty : AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
        }
    }

    /// <summary>
    /// Анимирует элемент фреймворка, сдвигая его слева на экране
    /// выдвигаемся влево при скрытии
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Анимация в
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Left, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Анимация из
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Анимирует элемент структуры, перемещая его справа на экране
    /// выдвижение вправо при скрытии
    /// </summary>
    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Анимация в
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Анимация из
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Анимирует элемент структуры, перемещая его справа на экране
    /// и прячем вправо
    /// </summary>
    public class AnimateSlideInFromRightMarginProperty : AnimateBaseProperty<AnimateSlideInFromRightMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Анимация в
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                // Анимация из
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Анимирует скольжение элемента каркаса сверху вниз на экране
    /// выскользнуть наверх, спрятавшись
    /// </summary>
    public class AnimateSlideInFromTopProperty : AnimateBaseProperty<AnimateSlideInFromTopProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Анимация в
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Top, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Анимация из
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Top, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Анимирует элемент каркаса, скользящий вверх снизу на экране
    /// Спрячем вниз
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Анимация в
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Анимация из
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Анимирует скольжение элемента каркаса снизу вверх при загрузке
    /// если значение истинно
    /// </summary>
    public class AnimateSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnLoadProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            // Анимация в
            await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, !value, !value ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Анимирует элемент каркаса, скользящий вверх снизу на экране
    /// и прячем вниз
    /// NOTE: Keeps the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Анимация в
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                // Анимация из
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Анимирует появление элемента структуры на экране
    /// и исчезает
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Анимация в
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            else
                // Анимация из
                await element.FadeOutAsync(firstLoad ? 0 : 0.3f);
        }
    }

    /// <summary>
    /// Анимирует элемент каркаса, перемещая его справа налево и повторяя бесконечное действие
    /// </summary>
    public class AnimateMarqueeProperty : AnimateBaseProperty<AnimateMarqueeProperty>
    {
        protected override void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            // Анимация в
            element.MarqueeAsync(firstLoad ? 0 : 3f);
        }
    }
}