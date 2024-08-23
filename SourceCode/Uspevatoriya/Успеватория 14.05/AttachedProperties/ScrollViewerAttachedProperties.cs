using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{
    /// <summary>
    /// Скролл элемента вниз при изменении контекста данных
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Не делать этого во время разработки
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            // Если у нас нет контроля, вернёмся
            if (!(sender is ScrollViewer control))
                return;

            // Прокручивать содержимое вниз при изменении контекста
            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged;
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Прокрутить вниз
            (sender as ScrollViewer).ScrollToBottom();
        }
    }

    /// <summary>
    /// Автоматически удерживать прокрутку внизу экрана, когда мы уже близки к низу
    /// </summary>
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Не делать этого во время разработки
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            // Если у нас нет контроля, вернёмся
            if (!(sender is ScrollViewer control))
                return;

            // Прокручивать содержимое вниз при изменении контекста
            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            // Если мы будем достаточно близко к низу...
            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                // Прокрутить вниз
                scroll.ScrollToEnd();
        }
    }
}
