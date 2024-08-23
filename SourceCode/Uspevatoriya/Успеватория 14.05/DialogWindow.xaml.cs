using System.Windows;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для DialogMessageBox.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {

        #region Private Members
        /// <summary>
        /// Модель представления этого окна
        /// </summary>
        private DialogWindowViewModel mViewModel;
        #endregion
        #region Public Properties

        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                //Даём новое значение
                mViewModel = value;

                //Обновляем контекст данных
                DataContext = mViewModel;
            }
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public DialogWindow()
        {
            InitializeComponent();
        }
        #endregion
    }
}
