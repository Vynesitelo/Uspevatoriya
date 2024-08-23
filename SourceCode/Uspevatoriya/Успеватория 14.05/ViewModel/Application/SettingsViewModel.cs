using System.Threading.Tasks;
using System.Windows.Input;
using Успеватория.Ядро;

namespace Успеватория
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properies

        /// <summary>
        /// Текст для кнопки логаута
        /// </summary>
        public string LogoutButtonText { get; set; }

        /// <summary>
        /// Проверка на запуск логаута
        /// </summary>
        public bool LogoutIsRunning { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Команда открытия меню настройки
        /// </summary>
        public ICommand OpenCommand { get; set; }

        /// <summary>
        /// Команда закрытия меню настроек
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Команда логаута приложения
        /// </summary>
        public ICommand LogoutCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public SettingsViewModel()
        {
            //Создание команд
            OpenCommand = new RelayCommand(Open);
            CloseCommand = new RelayCommand(Close);
            LogoutCommand = new RelayParameterizedCommand(async (parameter) => await LogoutAsync());

            //Присваивание значения тексту
            LogoutButtonText = "Выйти из учётной записи";
        }

        #endregion

        #region Command Methods

        //Открытие меню настроек
        public void Open()
        {
            DI.ViewModelApplication.SettingsMenuVisible = true;
        }
        //Закрытие меню настроек
        public void Close()
        {
            DI.ViewModelApplication.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Логаут
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task LogoutAsync()
        {
            await RunCommandAsync(() => LogoutIsRunning, async () =>
            {
                DI.ViewModelApplication.GoToPage(ApplicationPage.Login);

                await Task.Delay(1000);

                DI.ViewModelApplication.SettingsMenuVisible = false;
            });

        }

        /// <summary>
        /// Sets the settings view model properties based on the data in the client data store
        /// </summary>
        public async Task LoadAsync()
        {

        }
        #endregion
    }
}
