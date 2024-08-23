
using System;
using System.Diagnostics;
using System.Globalization;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Конвертирование <see cref="ApplicationPage"/> в актуальное представление 
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Table:
                    return new GroupPage();
                case ApplicationPage.User:
                    return new UserPage();
                case ApplicationPage.Schedule:
                    return new SchedulePage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
