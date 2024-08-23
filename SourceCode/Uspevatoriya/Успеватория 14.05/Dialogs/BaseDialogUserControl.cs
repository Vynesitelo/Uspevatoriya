using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Успеватория
{
    /// <summary>
    /// Базовый класс для любого контента внутри диалогового окна <see cref="DialogMessageBox"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// Дочерний элемент создающий своего родителя
        /// </summary>
        private DialogWindow mDialogWindow;

        #endregion

        #region Public Commands

        /// <summary>
        /// Закрыть диалог
        /// </summary>
        public ICommand CloseCommand { get; private set; }


        #endregion

        #region Public Properties
        /// <summary>
        /// Минимальная ширина диалога
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// Минимальная высота диалога
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;

        /// <summary>
        /// Высота заголовка
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Создание нового экземпляра
                mDialogWindow = new DialogWindow();

                mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

                //создание команды закрытия
                CloseCommand = new RelayCommand(() => mDialogWindow.Close());
            }

        }
        #endregion

        #region Public Dialog Shows Methods

        /// <summary>
        /// Показ одного мэссейдж бокса для пользователя
        /// </summary>
        /// <typeparam name="T"> Модель представления тип контрола</typeparam>
        /// <param name="viewModel">Модель представления</param>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            //Создаём ожидание закрытия диалогового окна
            var tsc = new TaskCompletionSource<bool>();

            //Запускаем ЮАй в потоке
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    //Сопоставим размеры управления с размерами модели представления
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    //Установка контрола диалогового окна для контента
                    mDialogWindow.ViewModel.Content = this;

                    //Установим контрол для datacontext привязанному к модели представления
                    DataContext = viewModel;

                    //Показать диалог
                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    //Говорим о завершении
                    tsc.TrySetResult(true);
                }
            });

            return tsc.Task;
        }
        #endregion
    }
}
