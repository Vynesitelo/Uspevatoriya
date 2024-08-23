using System.Windows.Input;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Модель представления элемента меню
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Текст показываемый для элемента меню
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Иконка для элемента меню
        /// </summary>
        public IconType Icon { get; set; }

        /// <summary>
        /// Тип элемента меню
        /// </summary>
        public MenuItemType Type { get; set; }

        // Свойство для хранения команды элемента меню
        public ICommand Command { get; set; }
    }
}
