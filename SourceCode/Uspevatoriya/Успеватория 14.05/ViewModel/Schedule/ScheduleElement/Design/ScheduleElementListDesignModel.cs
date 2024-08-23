using System.Collections.Generic;

namespace Успеватория
{
    public class ScheduleElementListDesignModel : SchedulePageViewModel
    {
        #region Singleton
        public static ScheduleElementListDesignModel Instance => new ScheduleElementListDesignModel();
        #endregion

        #region Constructor

        public ScheduleElementListDesignModel()
        {
            Items = new List<ScheduleElementItemViewModel>
            {
                new ScheduleElementItemViewModel
                {
                    GroupName = "Математика 1",
                    Lessons = "Урок 1",
                    DateLessons = "date",
                },
                new ScheduleElementItemViewModel
                {
                    GroupName = "Математика 1",
                    Lessons = "Урок 1",
                    DateLessons = "date",
                },
                new ScheduleElementItemViewModel
                {
                    GroupName = "Математика 1",
                    Lessons = "Урок 1",
                    DateLessons = "date",
                },
            };
        }
        #endregion
    }
}
