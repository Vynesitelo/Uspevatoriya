namespace Успеватория
{
    /// <summary>
    /// Время дизайна для <see cref="GroupListItemViewModel"/>
    /// </summary>
    public class GroupListItemDesignModel : GroupListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// Одиночный экземпляр для модели
        /// </summary>
        public static GroupListItemDesignModel Instance => new GroupListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public GroupListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            GroupSize = "This group app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";

        }

        #endregion
    }
}
