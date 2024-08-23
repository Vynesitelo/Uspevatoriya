namespace Успеватория
{
    /// <summary>
    /// Время дизайна для <see cref="UserListItemDesignModel"/>
    /// </summary>
    public class UserListItemDesignModel : UserListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// Одиночный экземпляр для модели
        /// </summary>
        public static UserListItemDesignModel Instance => new UserListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            GroupSize = "This group app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}
