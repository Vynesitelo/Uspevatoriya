using System;
using System.Globalization;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Конвертер для преобразования содержимого бокового меню
    /// </summary>
    public class SideMenuContentConverter : BaseValueConverter<SideMenuContentConverter>
    {
        /// <summary>
        /// Преобразует значение в соответствующий элемент управления для бокового меню
        /// </summary>
        /// <param name="value">Тип содержимого бокового меню</param>
        /// <param name="targetType">Целевой тип</param>
        /// <param name="parameter">Параметр</param>
        /// <param name="culture">Культура</param>
        /// <returns>Элемент управления для выбранного типа содержимого бокового меню</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sideMenuType = (SideMenuContent)value;

            switch (sideMenuType)
            {
                case SideMenuContent.Table:
                    GroupListControl mGroupListControl = new GroupListControl();
                    return mGroupListControl;
                case SideMenuContent.User:
                    UserListControl mUserListControl = new UserListControl();
                    return mUserListControl;
                case SideMenuContent.Schedule:
                    ScheduleGroupListControl mScheduleListGroupControl = new ScheduleGroupListControl();
                    return mScheduleListGroupControl;
                default: return "Выберите вкладку сверху";
            }
        }
        /// <summary>
        /// Преобразует элемент управления обратно в тип содержимого бокового меню
        /// </summary>
        /// <param name="value">Элемент управления</param>
        /// <param name="targetType">Целевой тип</param>
        /// <param name="parameter">Параметр</param>
        /// <param name="culture">Культура</param>
        /// <returns>Тип содержимого бокового меню</returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
