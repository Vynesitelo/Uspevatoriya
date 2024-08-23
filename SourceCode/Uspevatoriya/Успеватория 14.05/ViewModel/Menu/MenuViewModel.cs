using System.Collections.Generic;

namespace Успеватория
{
    /// <summary>
    /// Модель представления элемента меню
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        /// <summary>
        /// Элемнты меню
        /// </summary>
        public List<MenuItemViewModel> Items { get; set; }

    }
}
