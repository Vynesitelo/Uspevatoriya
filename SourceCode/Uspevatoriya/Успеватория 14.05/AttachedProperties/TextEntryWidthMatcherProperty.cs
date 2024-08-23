using System;
using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Получите панель
            var panel = (sender as Panel);

            // Сначала вызовите SetWidths (это также помогает сократить время разработки)
            SetWidths(panel);

            // Ожидание загрузки панели
            RoutedEventHandler onLoaded = null;
            onLoaded = (s, ee) =>
            {
                // Отвязка
                panel.Loaded -= onLoaded;

                // Установка ширины
                SetWidths(panel);

                // Зациклим детей
                foreach (var child in panel.Children)
                {
                    // Установите для поля заданное значение

                    // Игнорируйте любые элементы управления нетекстовым вводом
                    if (!(child is TextEntryControl))
                        continue;

                    // Получите метку из ввода текста или ввода пароля
                    var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as TextEntryControl).Label;

                    label.SizeChanged += (ss, eee) =>
                    {
                        // Обновляем ширину
                        SetWidths(panel);
                    };
                }
            };

            // Подключитесь к событию Loaded
            panel.Loaded += onLoaded;
        }


        /// <summary>
        /// Обновляем все дочерние элементы управления вводом текста, чтобы их ширина соответствовала наибольшей ширине группы
        /// </summary>
        /// <param name="panel">Панель с элементами управления вводом текста</param>
        private void SetWidths(Panel panel)
        {
            // Следим за максимальной шириной
            var maxSize = 0d;

            // Перечисляем детей...
            foreach (var child in panel.Children)
            {
                // Игнорируйте любые элементы управления нетекстовым вводом
                if (!(child is TextEntryControl))
                    continue;

                // Получите метку из ввода текста или ввода пароля
                var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as TextEntryControl).Label;

                // Найдите, больше ли это значение, чем другие элементы управления.
                maxSize = Math.Max(maxSize, label.RenderSize.Width + label.Margin.Left + label.Margin.Right);
            }

            // Создайте преобразователь длины сетки
            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());

            // Перечисляем детей...
            foreach (var child in panel.Children)
            {
                if (child is TextEntryControl text)
                    // Установите для каждого элемента управления значение LabelWidth на максимальный размер
                    text.LabelWidth = gridLength;

            }

        }
    }
}
