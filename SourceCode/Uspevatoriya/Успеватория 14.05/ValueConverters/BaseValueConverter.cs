using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Успеватория
{
    /// <summary>
    /// Базовый конвертер значений
    /// </summary>
    /// <typeparam name="T">Тип значения конвертера</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        /// <summary>
        /// Статическая ссылка на преобразователь
        /// </summary>
        private static T Converter = null;

        #endregion

        #region Markup Extension Methods

        /// <summary>
        /// Предоставляет статический экземпляр преобразователя значений. 
        /// </summary>
        /// <param name="serviceProvider">Передача услуги</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter ?? (Converter = new T());
        }
        #endregion

        #region Value Converter Methods

        /// <summary>
        /// Метод конвертации одного типа в другой
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Метод конвертации значения назад в исходный тип
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
