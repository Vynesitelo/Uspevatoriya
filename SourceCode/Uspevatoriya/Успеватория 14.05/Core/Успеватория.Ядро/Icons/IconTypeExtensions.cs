
namespace Успеватория.Ядро
{
    /// <summary>
    /// Помощник для функции <see cref="IconType"/>
    /// </summary>
    public static class IconTypeExtensions
    {
        /// <summary>
        /// Конвертирует <see cref="IconType"/> в FontAwesome строку
        /// </summary>
        /// <param name="type">Тип конврета</param>
        /// <returns></returns>
        public static string ToFontAwesome(this IconType type)
        {
            // Вернуть FontAwesome строку основанную на типе
            switch (type)
            {
                case IconType.File:
                    return "\uf0f6";

                case IconType.Picture:
                    return "\uf1c5";

                // Если не найдет вернуть нулл
                default:
                    return null;
            }
        }
    }
}
