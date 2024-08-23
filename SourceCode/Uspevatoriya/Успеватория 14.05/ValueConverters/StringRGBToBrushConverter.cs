using System;
using System.Globalization;
using System.Windows.Media;

namespace Успеватория
{
    /// <summary>
    /// Конвертер берет и  RGB строку конвенртирует в FF00FF и в кисти WPF 
    /// </summary>
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
