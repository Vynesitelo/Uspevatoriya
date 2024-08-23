using static Успеватория.DI;

namespace Успеватория
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Единичный экземпляр локатора
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// модель представления приложения
        /// </summary>
        public ApplicationViewModel ApplicationViewModel => ViewModelApplication;

        /// <summary>
        /// Модель представления настроек
        /// </summary>
        public SettingsViewModel SettingsViewModel => ViewModelSettings;


        #endregion
    }
}
