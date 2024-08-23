namespace Успеватория
{
    public class ScheduleElementItemDesignModel : ScheduleElementItemViewModel
    {
        #region Singleton
        public static ScheduleElementItemDesignModel Instance => new ScheduleElementItemDesignModel();
        #endregion

        #region Constructor
        public ScheduleElementItemDesignModel()
        {
            GroupName = "Математика 1";
            Lessons = "Урок 1";
            DateLessons = "date";
        }
        #endregion
    }
}
