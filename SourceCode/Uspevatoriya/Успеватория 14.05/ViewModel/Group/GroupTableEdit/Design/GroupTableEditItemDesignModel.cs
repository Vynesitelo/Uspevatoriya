namespace Успеватория
{
    public class GroupTableEditItemDesignModel : GroupTableEditItemViewModel
    {
        #region Singleton
        /// <summary>
        /// Экземпляр
        /// </summary>
        public static GroupTableEditItemDesignModel Instance => new GroupTableEditItemDesignModel();
        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public GroupTableEditItemDesignModel()
        {
            DgName = "Иван";
            DgSurname = "Иванов";
            DgPatronymic = "Иванович";
        }
        #endregion
    }
}
