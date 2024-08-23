using System.Windows.Media.Animation;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для GroupEditPage.xaml
    /// </summary>
    public partial class GroupEditPage : BasePage<GroupEditPageViewModel>
    {
        #region Construct
        public GroupEditPage()
        {
            InitializeComponent();
        }
        public GroupEditPage(GroupEditPageViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
        #endregion

        #region Перегруженные методы
        protected override void OnViewModelChanged()
        {
            if (dgEditGroup == null) return;

            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(dgEditGroup);

        }

        #endregion

    }

}
