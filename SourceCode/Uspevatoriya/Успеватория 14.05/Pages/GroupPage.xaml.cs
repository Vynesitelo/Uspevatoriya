using System.Windows.Media.Animation;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для Group
    /// .xaml
    /// </summary>
    public partial class GroupPage : BasePage<GroupPageViewModel>
    {
        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public GroupPage()
        {
            InitializeComponent();
        }
        public GroupPage(GroupPageViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
        #endregion

        #region Перегруженные методы
        protected override void OnViewModelChanged()
        {
            if (dgGroup == null) return;

            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(dgGroup);

        }
        #endregion

    }
}
