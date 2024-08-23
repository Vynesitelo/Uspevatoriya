namespace Успеватория
{
    public class GroupTableItemDesignModel : GroupTableItemViewModel
    {
        #region Singleton
        public static GroupTableItemDesignModel Instance => new GroupTableItemDesignModel();
        #endregion

        #region Constructor
        public GroupTableItemDesignModel()
        {
            dgInitials = "ds";
            dgGrade = "5";
            dgDateTime = "2020-21-12";
        }
        #endregion
    }
}
