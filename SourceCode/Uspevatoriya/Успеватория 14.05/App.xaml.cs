using Dna;
using System.Threading.Tasks;
using System.Windows;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Пользовательский запуск IoC перед всем остальным
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            // ПУсть базовое приложение делает, что нужно
            base.OnStartup(e);

            await ApplicationSetupAsync();

            DI.ViewModelApplication.GoToPage(ApplicationPage.Login);
            // Показ главного окна 
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
        private async Task ApplicationSetupAsync()
        {
            //Установка IoC
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddFileLogger()
                .AddUspClientServices()
                .AddUspViewModels()
                .AddRepositories()
                .Build();

            //Привязка ЮАй менеджер
            CoreDI.TaskManager.RunAndForget(DI.ViewModelSettings.LoadAsync);
        }
    }
}
