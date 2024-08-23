using System.Windows.Controls;
using static Успеватория.DI;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            //Устанавливаем контекст данных
            DataContext = ViewModelSettings;
        }
    }
}
