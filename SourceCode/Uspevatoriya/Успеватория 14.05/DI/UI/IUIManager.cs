using System.Threading.Tasks;

namespace Успеватория
{
    /// <summary>
    /// UI менеджер даёт возможность использовать интерфейсы во всём приложении
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Вывод просто окна сообщения
        /// </summary>
        /// <param name="viewModel">Модель представления</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}
