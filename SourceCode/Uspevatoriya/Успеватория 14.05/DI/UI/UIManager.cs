using System.Threading.Tasks;

namespace Успеватория
{
    /// <summary>
    /// Внедрение пользовательского интерфейса<see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Вывод просто окна сообщения
        /// </summary>
        /// <param name="viewModel">Модель представления</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);

        }
    }
}
