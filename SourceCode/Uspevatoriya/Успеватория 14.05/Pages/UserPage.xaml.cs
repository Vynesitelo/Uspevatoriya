namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class UserPage : BasePage<UserPageViewModel>
    {
        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public UserPage()
        {
            InitializeComponent();
        }
        public UserPage(UserPageViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
        #endregion

        #region Перегруженные методы
        protected override void OnViewModelChanged()
        {
        }
        #endregion

    }
}
