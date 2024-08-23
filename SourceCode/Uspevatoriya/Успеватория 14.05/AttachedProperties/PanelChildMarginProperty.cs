using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Дать панель
            var panel = (sender as Panel);

            panel.Loaded += (s, ee) =>
            {
                //Круг детей
                foreach (var child in panel.Children)
                {
                    (child as FrameworkElement).Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));
                }
            };
        }
    }
}
