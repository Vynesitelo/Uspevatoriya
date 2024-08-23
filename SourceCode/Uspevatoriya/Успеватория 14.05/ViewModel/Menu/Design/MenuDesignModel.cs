

using System.Collections.Generic;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Данные времени разработки <see cref="MenuItemViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        /// <summary>
        /// Единичный экземляр модели дизайна (порт)
        /// </summary>
        public static MenuDesignModel Instance => new MenuDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel {Type = MenuItemType.Header, Text = "Design a file..."},
                new MenuItemViewModel { Text = "Design computer", Icon = IconType.File},
                new MenuItemViewModel { Text = "Design pictures", Icon = IconType.Picture},

            });
        }
        #endregion
    }
}
