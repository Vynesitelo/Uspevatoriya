using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {



        #region Свойство зависимостей
        /// <summary>
        /// CurrentPage показывает то, что находится в page host 
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);

        }

        /// <summary>
        /// Теекущая страница регистрируется как свойство зависимости
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));


        /// <summary>
        /// Текущая страница, отображаемая на хосте страниц

        /// </summary>
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        /// <summary>
        /// регистрация <see cref="CurrentPageViewModel"/> зависимостей
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel),
                typeof(BaseViewModel), typeof(PageHost),
                new UIPropertyMetadata());

        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            //Если мы находимся в режиме разработки показывать выбранную страницу
            //поскольку свойство зависимостей не срабатывает
            if (DesignerProperties.GetIsInDesignMode(this))
                NewPage.Content = DI.ViewModelApplication.CurrentPage.ToBasePage();

        }
        #endregion

        #region Событие изменения состояния свойства
        /// <summary>
        /// Сообщает об изменение <see cref="CurrentPage"/> и запускается
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {

            var currentPage = (ApplicationPage)value;
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            //Получеие страниц
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            if (newPageFrame.Content is BasePage page &&
                page.ToApplicationPage() == currentPage)
            {
                page.ViewModelObject = currentPageViewModel;

                return value;
            }

            //хранилище содержимого текущей страницы как старой
            var oldPageContent = newPageFrame.Content;

            //Убираем старницу из newPageFrame
            newPageFrame.Content = null;

            //Перемещаем нынещнюю страницу в старую
            newPageFrame.Content = oldPageContent;

            //Анимируем предыдущую страницу
            if (oldPageContent is BasePage oldPage)
            {
                //Говорим старой странице, чтоб она анимировалась
                oldPage.ShouldAnimateOut = true;

                //удаляем её сразу после анимации
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }

            //Устанавливаем контент новой страницы
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        }
        #endregion
    }
}
