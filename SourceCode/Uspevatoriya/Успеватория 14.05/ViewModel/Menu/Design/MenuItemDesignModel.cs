

using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Данные времени разработки <see cref="MenuItemViewModel"/>
    /// </summary>
    public class MenuItemDesignModel : MenuItemViewModel
    {
        #region Singleton

        /// <summary>
        /// Единичный экземляр модели дизайна (порт)
        /// </summary>
        public static MenuItemDesignModel Instance => new MenuItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public MenuItemDesignModel()
        {
            Text = "Hello world";
            Icon = IconType.File;
        }
        #endregion
    }
}
