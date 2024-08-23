using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using static Успеватория.Ядро.CoreDI;

namespace Успеватория
{
    /// <summary>
    /// Помощник анимирования элемента фреймворккка специфичным методом
    /// </summary>
    public static class FrameworkElementAnimations
    {
        #region Slide In / Out

        /// <summary>
        /// Вдвигает элемент
        /// </summary>
        /// <param name="element">Элемент для анимации</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="seconds">Направление слайда</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        /// <param name="size">Ширина/высота анимации для анимации. Если не указано, используется размер элементов.</param>
        /// <param name="firstLoad">Указывает, является ли это первой загрузкой</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationSlideInDirection direction, bool firstLoad, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            //  Создание раскадровку
            var sb = new Storyboard();

            // Сдвиг по направлению
            switch (direction)
            {
                // Добавить слайд из левой анимации
                case AnimationSlideInDirection.Left:
                    sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Добавить слайд из правой анимации
                case AnimationSlideInDirection.Right:
                    sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Добавить слайд из верха анимации
                case AnimationSlideInDirection.Top:
                    sb.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Добавить слайд из низа анимации
                case AnimationSlideInDirection.Bottom:
                    sb.AddSlideFromBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }
            // Добавить затухание анимации
            sb.AddFadeIn(seconds);

            // Старт анимации
            sb.Begin(element);

            // Сделать страницу видимой только в том случае, если мы анимируем или это первая загрузка.
            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            // Подождите, пока это закончится
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out
        /// </summary>
        /// <param name="element">Элемент для анимации</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="seconds">Направление слайда</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        /// <param name="size">Ширина/высота анимации для анимации. Если не указано, используется размер элементов.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationSlideInDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            //  Создание раскадровку
            var sb = new Storyboard();

            // Сдвиг по направлению
            switch (direction)
            {
                // Добавить слайд в лево анимации
                case AnimationSlideInDirection.Left:
                    sb.AddSlideToLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Добавить слайд вправо анимации
                case AnimationSlideInDirection.Right:
                    sb.AddSlideToRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Добавить слайд вверх анимации
                case AnimationSlideInDirection.Top:
                    sb.AddSlideToTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Добавить слайд вниз Вторанимации
                case AnimationSlideInDirection.Bottom:
                    sb.AddSlideToBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }

            // Добавить затухание анимации
            sb.AddFadeOut(seconds);

            // Старт анимации
            sb.Begin(element);

            // Сделать страницу видимой, только если мы анимируем
            if (seconds != 0)
                element.Visibility = Visibility.Visible;

            // Ждём конца
            await Task.Delay((int)(seconds * 1000));

            // Сделать элемент невидимым
            if (element.Opacity == 0)
                element.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Fade In / Out

        /// <summary>
        /// Затухание элемента
        /// </summary>
        /// <param name="element">Элемент для анимации</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="firstLoad">Указывает, является ли это первой загрузкой</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement element, bool firstLoad, float seconds = 0.3f)
        {
            // Создайте раскадровку
            var sb = new Storyboard();

            // Добавить затухание анимации
            sb.AddFadeIn(seconds);

            // Старт
            sb.Begin(element);

            // Сделать страницу видимой только в том случае, если мы анимируем или это первая загрузка.
            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            // Ждём конца
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Затухание элемента
        /// </summary>
        /// <param name="element">Элемент для анимации</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            // Создайте раскадровку
            var sb = new Storyboard();

            // Добавить затухание анимации
            sb.AddFadeOut(seconds);

            // Старт
            sb.Begin(element);

            // Сделать страницу видимой только в том случае, если мы анимируем или это первая загрузка.
            if (seconds != 0)
                element.Visibility = Visibility.Visible;

            // Ждём конца
            await Task.Delay((int)(seconds * 1000));

            // Полностью скрыть элемент
            element.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Marquee

        /// <summary>
        /// Анимирует элемент стиля выделения
        /// Структура должна быть:
        /// [Border ClipToBounds="True"]
        ///   [Border local:AnimateMarqueeProperty.Value="True"]
        ///      [Content HorizontalAlignment="Left"]
        ///   [/Border]
        /// [/Border]
        /// </summary>
        /// <param name="element">Элемент для анимции</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <returns></returns>
        public static void MarqueeAsync(this FrameworkElement element, float seconds = 3f)
        {
            // Создаем раскадровку
            var sb = new Storyboard();

            // Запускать до тех пор, пока элемент не будет выгружен
            var unloaded = false;

            // Мониторинг выгрузки элемента
            element.Unloaded += (s, e) => unloaded = true;

            // Запуск цикла из потока вызывающего абонента
            TaskManager.Run(async () =>
            {
                // Пока элемент еще доступен, перепроверьте размер
                // после каждого цикла, если размер контейнера был изменен
                while (element != null && !unloaded)
                {
                    // Создание переменных ширины
                    var width = 0d;
                    var innerWidth = 0d;

                    try
                    {
                        // Проверьте, загружен ли элемент
                        if (element == null || unloaded)
                            break;

                        // Try and get current width
                        width = element.ActualWidth;
                        innerWidth = ((element as Border).Child as FrameworkElement).ActualWidth;
                    }
                    catch
                    {
                        break;
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        // Добавить анимацию выделения
                        sb.AddMarquee(seconds, width, innerWidth);

                        // старт
                        sb.Begin(element);

                        // Сделать страницу видимой
                        element.Visibility = Visibility.Visible;
                    });

                    // Ждём конца
                    await Task.Delay((int)seconds * 1000);

                    // Если это происходит при первой загрузке или при нулевой секундной анимации, не повторяйте.
                    if (seconds == 0)
                        break;
                }
            });
        }

        #endregion
    }
}
