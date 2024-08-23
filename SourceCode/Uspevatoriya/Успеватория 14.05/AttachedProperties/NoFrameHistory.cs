using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{
    /// <summary>
    ///  NoFrameHistory прикреплённое свойство создаёт a <see cref="Frame"/> которая никогда не показывает навигацию
    /// и сохраняет историю навигации пустой
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Получаем страницу
            var frame = (sender as Frame);

            // Скрытваем навигацию
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            // Очистка истории навигации
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
