using System;
using System.Globalization;
using System.Windows;

namespace Успеватория
{

    /// <summary>
    /// Конвертер значения ориентации с енум в ВПФ
    /// </summary>
    public class HorizontalAlignmentConverter : BaseValueConverter<HorizontalAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HorizontalAlignment)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
