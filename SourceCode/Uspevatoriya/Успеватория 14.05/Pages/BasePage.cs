
using Dna;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{

    /// <summary>
    /// Основа функционала всех страниц
    /// </summary>
    public class BasePage : UserControl
    {
        #region Private Member

        /// <summary>
        /// Модлеь представления ассоциирующаяся со страницей
        /// </summary>
        private object mViewModel;
        #endregion

        #region Public Properties

        /// <summary>
        /// Анимация проигрывающаяся при первой загрузке
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Анимация для выгрузки страницы
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// Время продолжительности анимации
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// Флаг индикации нужна ли анимироваться страница при выгрузке
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        /// <summary>
        /// Свойство ViewModelObject для установки и получения объекта представления модели.
        /// </summary>
        public object ViewModelObject
        {
            get => mViewModel;
            set
            {
                if (mViewModel == value) return;

                mViewModel = value;

                // Вызов события при изменении представления модели
                OnViewModelChanged();

                // Установка DataContext равным новому представлению модели
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public BasePage()
        {

            //Не стоит анимировать во время разработки
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // Если анимация скрыта
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            // Слушаем страницу зугрузки
            Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// При загрузке страницы выполнить необходимую анимацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            // Если настроено анимировать выход при загрузке
            if (ShouldAnimateOut)
                //  Анимировать выход со страницы
                await AnimateOutAsync();
            // В противном случае...
            else
                // Анимировать вход на страницу
                await AnimateInAsync();
        }

        /// <summary>
        /// Анимирует вход на страницу
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            // Убедиться, что есть что-то для выполнения
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    // Запустить анимацию
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);

                    break;
            }
        }

        /// <summary>
        /// Анимирует выход со страницы
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            // Убедиться, что есть что-то для выполнения
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    // Запустить анимацию
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, SlideSeconds);

                    break;
            }
        }

        #endregion
        /// <summary>
        /// Вызывается при изменении представления модели
        /// </summary>
        protected virtual void OnViewModelChanged()
        {

        }
    }

    /// <summary>
    /// Базовая страница с моделью представления
    /// </summary>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {

        #region Public Properties

        /// <summary>
        /// Модель представления, связанная с этой страницей
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public BasePage() : base()
        {
            //Если в режиме времени разработки...
            if (DesignerProperties.GetIsInDesignMode(this))
                // Создём стандартную модель представления
                ViewModel = new VM();
            else
                // Создайте модель представления по умолчанию
                ViewModel = Framework.Service<VM>() ?? new VM();
        }
        /// <summary>
        /// Конструктор с конкретной моделью представления
        /// </summary>
        /// <param name="specificViewModel">Конкретная модель представления, которую следует использовать, если таковая имеется</param>
        public BasePage(VM specificViewModel = null) : base()
        {
            // Установить конкретную модель представления
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
            {
                if (DesignerProperties.GetIsInDesignMode(this))
                    ViewModel = new VM();
                else
                {
                    // Создайте модель представления по умолчанию
                    ViewModel = Framework.Service<VM>() ?? new VM();
                }
            }

        }

        #endregion
    }
}
