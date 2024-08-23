using System;
using System.Globalization;

namespace Успеватория
{
    /// <summary>
    /// Преобразователь, который принимает логическое значение и возвращает толщину 2, если это правда, что полезно для применения
    /// радиус границы истинного значения
    /// </summary>
    public class BooleanToBorderThicknessConverter : BaseValueConverter<BooleanToBorderThicknessConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? 2 : 0;
            else
                return (bool)value ? 0 : 2;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
