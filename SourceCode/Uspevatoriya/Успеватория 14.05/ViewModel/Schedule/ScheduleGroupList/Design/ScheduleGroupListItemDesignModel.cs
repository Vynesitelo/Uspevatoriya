using System;

namespace Успеватория
{
    public class ScheduleGroupListItemDesignModel : ScheduleGroupListItemViewModel
    {
        #region Singleton

        public static ScheduleGroupListItemDesignModel Instance => new ScheduleGroupListItemDesignModel();
        #endregion

        #region Constructor
        public ScheduleGroupListItemDesignModel()
        {
            Initials = "MA";
            Name = "Информационные системы";
            mDateBegin = DateTime.Now;
            mDateEnd = DateTime.Now;
            ProfilePictureRGB = "3099c5";
        }
        #endregion
    }
}
