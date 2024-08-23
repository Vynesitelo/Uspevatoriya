using System.Collections.Generic;
using System.Linq;
using Успеватория.DAL.Context;

namespace Успеватория
{
    /// <summary>
    /// Данные времени разработки <see cref="GroupListViewModel"/>
    /// </summary>
    public class GroupListDesignModel : GroupListViewModel
    {
        #region Singleton

        /// <summary>
        /// Единичный экземляр модели дизайна (порт)
        /// </summary>
        public static GroupListDesignModel Instance => new GroupListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public GroupListDesignModel()
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
            if (storeUserData.idRole == 1)
            {

                Items = new List<GroupListItemViewModel>();
                foreach (var item in cours)
                {

                    Items.Add(new GroupListItemViewModel
                    {
                        Name = item.CourseName.Name + item.ID.ToString(),
                        GroupSize = "Численность группы: " + courseStudents.Where(t => t.IDCourse == item.ID).Count(),
                        Initials = (item.CourseName.Name).Substring(0, 2).ToUpper(),
                        ProfilePictureRGB = "3099c5",
                        mCourseName = item.CourseName.Name,
                        mIDCourse = item.ID
                    });
                }
            }
            if (storeUserData.idRole == 2)
            {

                Items = new List<GroupListItemViewModel>();
                foreach (var item in cours.Where(t => t.IDTeacher == storeUserData.id))
                {

                    Items.Add(new GroupListItemViewModel
                    {
                        Name = item.CourseName.Name + item.ID.ToString(),
                        GroupSize = "Численность группы: " + courseStudents.Where(t => t.IDCourse == item.ID).Count(),
                        Initials = (item.CourseName.Name).Substring(0, 2).ToUpper(),
                        ProfilePictureRGB = "3099c5",
                        mCourseName = item.CourseName.Name,
                        mIDCourse = item.ID


                    });
                }
            }

        }
        #endregion
    }
}
