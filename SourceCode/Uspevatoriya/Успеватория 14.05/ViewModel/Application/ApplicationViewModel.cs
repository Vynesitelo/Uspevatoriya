using System.Windows.Input;
using Успеватория.Ядро;
using static Успеватория.DI;
using static Успеватория.Ядро.CoreDI;

namespace Успеватория
{
    /// <summary>
    /// Состояние приложения в модели представления
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Private Members
        private bool isVisible;
        /// <summary>
        /// Тру если настройки нужно покказать
        /// </summary>
        private bool mSettingsMenuVisible;
        #endregion

        #region Public Properties
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }
        /// <summary>
        /// Выбранная страница приложения
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// Модель представления, которая будет использоваться для текущей страницы при изменении CurrentPage.
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// Тру если боковое меню нужно отобразить
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// Истинно, если нужно показать меню настроек
        /// </summary>

        public bool SettingsMenuVisible
        {
            get => mSettingsMenuVisible;
            set
            {
                if (mSettingsMenuVisible == value) return;
                mSettingsMenuVisible = value;
                if (value)
                    TaskManager.RunAndForget(ViewModelSettings.LoadAsync);
            }
        }
        /// <summary>
        /// Перелючение между выбраным пунктов для меню сбоку
        /// </summary>
        public SideMenuContent CurrentSideMenuContent { get; set; }
        #endregion

        #region Public Commands

        public ICommand OpenTableCommand { get; set; }
        public ICommand OpenScheduleCommand { get; set; }
        public ICommand OpenUserCommand { get; set; }
        #endregion

        #region Constructor
        public ApplicationViewModel()
        {
            if (storeUserData.idRole != 1)
            {
                isVisible = false;
            }
            OpenTableCommand = new RelayCommand(OpenTable);
            OpenScheduleCommand = new RelayCommand(OpenSchedule);
            OpenUserCommand = new RelayCommand(OpenUser);

            storeUserData.VariableChanged += OnVariableChanged;
            storeUserData.VariableChangedBool += OnVariableBoolChanged;
        }
        #endregion

        #region CommandMethods
        public void ChangeSideMenuContent(SideMenuContent newContent)
        {
            CurrentSideMenuContent = newContent;
        }
        public void OpenTable()
        {
            CurrentSideMenuContent = SideMenuContent.Table;
        }

        public void OpenSchedule()
        {
            CurrentSideMenuContent = SideMenuContent.Schedule;
        }
        public void OpenUser()
        {
            if (storeUserData.idRole != 1)
            {
                UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = $"У вас недостаточно прав, данная вкладка доступна только для админстрации",
                    OkText = "OK",
                });
            }
            else
            {
                CurrentSideMenuContent = SideMenuContent.User;
            }
        }
        public void cur()
        {
            CurrentSideMenuContent = SideMenuContent.Table;
            CurrentSideMenuContent = SideMenuContent.User;
        }

        private void OnVariableChanged(int newValue)
        {
            cur();
        }
        private void OnVariableBoolChanged(int newValue)
        {
            if (storeUserData.idRole == 1)
            {
                IsVisible = true;
            }
            else { IsVisible = false; }
        }

        #endregion

        /// <summary>
        /// Навигация по страницам
        /// </summary>
        /// <param name="page">Страница на которую мы переходим</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            SettingsMenuVisible = false;

            CurrentPageViewModel = viewModel;

            var different = CurrentPage != page;

            // Устанавливаем выбранную страницу
            CurrentPage = page;

            if (!different)
                OnPropertyChanged(nameof(CurrentPage));

            // Показываем боковую страницу или нет
            switch (page)
            {
                case ApplicationPage.Table:
                    SideMenuVisible = page == ApplicationPage.Table;
                    break;
                case ApplicationPage.Schedule:
                    SideMenuVisible = page == ApplicationPage.Schedule; break;
                case ApplicationPage.StartPage:
                    SideMenuVisible = page == ApplicationPage.StartPage; break;
                case ApplicationPage.Login:
                    SideMenuVisible = false; break;

            }

        }
    }
}
