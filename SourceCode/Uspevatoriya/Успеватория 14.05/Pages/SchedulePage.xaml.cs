using System.Windows.Media.Animation;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для Schedule
    /// .xaml
    /// </summary>
    public partial class SchedulePage : BasePage<SchedulePageViewModel>
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        public SchedulePage(SchedulePageViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
        protected override void OnViewModelChanged()
        {
            if (ScheduleItemList == null) return;

            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ScheduleItemList);
        }
    }
}
