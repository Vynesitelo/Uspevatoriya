using System.Windows;
using System.Windows.Input;

namespace Успеватория
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {

        #region Private Member
        /// <summary>
        /// Контролы окна
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// Помощник изменения размера окна 
        /// </summary>
        private WindowResizer mWindowResizer;

        /// <summary>
        /// Маргин для окна, чтоб было место для тени
        /// </summary>
        private Thickness mOuterMarginSize = new Thickness(10);

        /// <summary>
        /// Радиус края окна
        /// </summary>
        private int mWindowRadius = 10;

        /// <summary>
        /// Последнее положение окна
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        /// <summary>
        /// Минимальная ширина окна
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// Минимальная высота окна
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// True if the window is currently being moved/dragged
        /// </summary>
        public bool BeingMoved { get; set; }


        /// <summary>
        /// Определить максимальный ли размер окна
        /// </summary>
        public bool Borderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);

        /// <summary>
        /// Изменение границ в зависимости от размера окна
        /// </summary>
        public int ResizeBorder => mWindow.WindowState == WindowState.Maximized ? 0 : 4;

        /// <summary>
        /// Размер границы изменения размера вокруг окна с учётом маргина
        /// </summary>     
        public Thickness ResizeBorderThickness => new Thickness(OuterMarginSize.Left + ResizeBorder,
            OuterMarginSize.Top + ResizeBorder,
            OuterMarginSize.Right + ResizeBorder,
            OuterMarginSize.Bottom + ResizeBorder);

        /// <summary>
        /// Заполнение внутреннего содержимого главного окна
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// Маргин вокруг окна для тени
        /// </summary>
        public Thickness OuterMarginSize
        {
            // Если он развёрнут или закреплён граница отсутствует
            get => mWindow.WindowState == WindowState.Maximized ? mWindowResizer.CurrentMonitorMargin : (Borderless ? new Thickness(0) : mOuterMarginSize);
            set => mOuterMarginSize = value;
        }

        /// <summary>
        /// Радиус края окна
        /// </summary>
        public int WindowRadius
        {
            // Если он развёрнут или закреплён, нет границы
            get => Borderless ? 0 : mWindowRadius;
            set => mWindowRadius = value;
        }

        /// <summary>
        /// The rectangle border around the window when docked
        /// </summary>
        public int FlatBorderThickness => Borderless && mWindow.WindowState != WindowState.Maximized ? 1 : 0;

        /// <summary>
        /// Радиус края окна
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// Высота тайтл бара
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        /// <summary>
        /// Высота тайтл бара
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// Истинно, если нужно затемнение на окне
        /// Когда всплывающее окно видно или не в фокусе
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Команда минимизации окна
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Команда максимизации окна
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Команда закрытия окна
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Команда показа системного меню окна
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///  Стандартный конструктор
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                WindowResized();
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fix window resize issue
            mWindowResizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };

            // On window being moved/dragged
            mWindowResizer.WindowStartedMove += () =>
            {
                // Update being moved flag
                BeingMoved = true;
            };

            // Fix dropping an undocked window at top which should be positioned at the
            // very top of screen
            mWindowResizer.WindowFinishedMove += () =>
            {
                // Update being moved flag
                BeingMoved = false;

                // Check for moved to top of window and not at an edge
                if (mDockPosition == WindowDockPosition.Undocked && mWindow.Top == mWindowResizer.CurrentScreenSize.Top)
                    // If so, move it to the true top (the border size)
                    mWindow.Top = -OuterMarginSize.Top;
            };
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Получаем позицию мыши на экране
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            return mWindowResizer.GetCursorPosition();
        }

        /// <summary>
        /// Если окно изменило размер до окна или прикреплено
        /// Обновляем все значения для изменения границ
        /// </summary>
        private void WindowResized()
        {
            // Отключить события для всех свойств, на которые влияет изменение размера.
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(FlatBorderThickness));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }


        #endregion
    }
}

