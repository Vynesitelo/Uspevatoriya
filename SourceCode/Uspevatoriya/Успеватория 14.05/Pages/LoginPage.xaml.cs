using System.Security;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        #region Constructor
        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Специальный конструктор
        /// </summary>
        /// <param name="specificViewModel"></param>
        public LoginPage(LoginViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Защищённый пароль со страницы логина
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;

    }
}
