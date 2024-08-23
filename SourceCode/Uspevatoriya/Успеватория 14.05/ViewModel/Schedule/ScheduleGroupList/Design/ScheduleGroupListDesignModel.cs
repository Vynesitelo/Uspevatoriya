using System;
using System.Collections.Generic;
using System.Linq;
using Успеватория.DAL.Context;


namespace Успеватория
{
    public class ScheduleGroupListDesignModel : ScheduleGroupListViewModel
    {
        #region Singleton

        public static ScheduleGroupListDesignModel Instance => new ScheduleGroupListDesignModel();
        #endregion

        #region Constructor
        public ScheduleGroupListDesignModel()
        {
            List<Cours> cours;
            List<CourseName> courseNames;
            List<CourseStudent> courseStudents;
            using (var context = new sqlUspevatoriyaEntities())
            {
                cours = context.Courses.ToList();
                courseNames = context.CourseNames.ToList();
                courseStudents = context.CourseStudents.ToList();
            }
            Items = new List<ScheduleGroupListItemViewModel>();
            foreach (var item in cours)
            {
                Items.Add(new ScheduleGroupListItemViewModel
                {
                    Name = item.CourseName.Name + item.ID.ToString(),
                    mDateBegin = Convert.ToDateTime(item.DateBegin),
                    mDateEnd = Convert.ToDateTime(item.DateEnd),
                    Initials = (item.CourseName.Name).Substring(0, 2).ToUpper(),
                    ProfilePictureRGB = "3099c5",
                    mCourseName = item.CourseName.Name,
                    mIDCourse = item.ID
                });
            }

        }
        #endregion
    }
}
