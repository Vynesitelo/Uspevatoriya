using System.Collections.Generic;

namespace Успеватория
{
    public class GrouptableListItemDesignModel : GroupPageViewModel
    {
        #region Singleton
        public static GrouptableListItemDesignModel Instance => new GrouptableListItemDesignModel();
        #endregion

        #region Constructor
        public GrouptableListItemDesignModel()
        {
            Items = new List<GroupTableItemViewModel>
            {
                new GroupTableItemViewModel
                {
                    dgDateTime = "21",
                    dgGrade ="5",
                    dgInitials = "ds"
                },
                new GroupTableItemViewModel
                {
                    dgDateTime = "21",
                    dgGrade ="5",
                    dgInitials = "ds"
                },
                new GroupTableItemViewModel
                {
                    dgDateTime = "21",
                    dgGrade ="5",
                    dgInitials = "ds"
                },
            };
        }
        #endregion
    }
}
