using System;
using System.Globalization;

namespace Успеватория
{
    /// <summary>
    /// конвертер, что принимает логические значения и возвращает определённый элемент ЮАй типа Модели Представления
    /// </summary>
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AttachmentPopupMenuViewModel basePopup)
                return new VerticalMenu { DataContext = basePopup.Content };
            if (value is AttachmentPopupMenuGroupViewModel groupPopup)
                return new VerticalMenu { DataContext = groupPopup.Content };
            if (value is AttachmentPopupMenuScheduleViewModel schedulePopup)
                return new VerticalMenu { DataContext = schedulePopup.Content };

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
