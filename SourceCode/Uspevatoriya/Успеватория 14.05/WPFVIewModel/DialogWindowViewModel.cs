using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {

        #region Public Properties

        /// <summary>
        /// Заголовок диалогового окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Контент внутри диалога
        /// </summary>
        public Control Content { get; set; }

        #endregion
        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="window"></param>
        public DialogWindowViewModel(Window window) : base(window)
        {
            // Делаем минимальный размер окна
            WindowMinimumWidth = 250;
            WindowMinimumHeight = 100;

            //Делаем высоту заголовка
            TitleHeight = 30;
        }
        #endregion

    }
}

