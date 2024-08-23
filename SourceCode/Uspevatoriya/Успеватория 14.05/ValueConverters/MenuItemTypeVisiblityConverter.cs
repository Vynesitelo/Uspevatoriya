using System;
using System.Globalization;
using System.Windows;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Конвертер берёт <see cref="MenuItemType"/> и возвращает <see cref="Visibility"/> 
    /// основывается на данном параметре
    /// </summary>
    public class MenuItemTypeVisiblityConverter : BaseValueConverter<MenuItemTypeVisiblityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Если параметра нет сделать видмым
            if (parameter == null)
                return Visibility.Collapsed;

            // Попытка преобразовать параметры в енум
            if (!Enum.TryParse(parameter as string, out MenuItemType type))
                return Visibility.Collapsed;

            // Если параметр совпадает с типом, вернуть видимость
            return (MenuItemType)value == type ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
