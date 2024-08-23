using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;
using Успеватория.Ядроe;
using static Успеватория.DI;

namespace Успеватория
{
    /// <summary>
    /// Мдель представления окна входа
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private readonly IRepository<Role> repositoryRole;
        public bool IsVisible = true;
        private readonly IRepository<User> repositoryUser;


        #region Public Properties

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Флаг индикации запуска команды
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Команда входа
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public LoginViewModel()
        {
            // Создание команд
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));

            //Определение репозитория
            repositoryRole = RepositoryRole;
            repositoryUser = RepositoryUser;
        }

        #endregion

        /// <summary>
        /// Попытка входа в систему
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> передача из представления для пароля</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                var selected = repositoryUser.Items.Where(item => item.Login == Login && item.Password == pass).FirstOrDefault();

                pass = null;
                if (selected != null)
                {
                    //Сохраняем данные авторизированного пользователя
                    storeUserData.id = selected.ID;
                    storeUserData.idRole = (int)selected.IDRoles;
                    storeUserData.IsVisible = 1;
                    await UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        Title = "Успешно",
                        Message = $"Вы успешно авторизовались.\n Добро пожаловать в успеваторию!!!",
                        OkText = "OK",
                    });


                    // Переход на страницу
                    ViewModelApplication.GoToPage(ApplicationPage.StartPage);

                }
                else
                {
                    await UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        Title = "Ошибка",
                        Message = "Проверьте верность введёных данных :(",
                        OkText = "OK",
                    });
                }

                //// IMPORTANT: Never store unsecure password in variable like this

            });
        }

    }
}
