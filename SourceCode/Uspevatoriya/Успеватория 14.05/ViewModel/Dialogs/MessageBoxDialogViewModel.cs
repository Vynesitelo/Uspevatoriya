namespace Успеватория
{
    /// <summary>
    /// Окно сообщения
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Текст используемый для кнопки ОК
        /// </summary>
        public string OkText { get; set; }
    }
}
