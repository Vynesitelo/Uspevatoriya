using System;
using System.Windows;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }

        private void AppWindow_Deactivated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
        }
    }
}
