using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Модель представления group list айтема
    /// </summary>
    public class GroupListItemViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Имя курса
        /// </summary>
        public string mCourseName { get; set; }
        /// <summary>
        /// Айди курса
        /// </summary>
        public int mIDCourse { get; set; }

        /// <summary>
        /// Размер группы
        /// </summary>
        public string GroupSize { get; set; }

        /// <summary>
        /// Инициалы
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }
        #endregion

        #region Public Commands

        /// <summary>
        /// Открытие нужного потока таблицы оценок
        /// </summary>
        public ICommand OpenGradeContent { get; set; }
        #endregion

        #region Constructor
        public GroupListItemViewModel()
        {
            OpenGradeContent = new RelayCommand(OpenGrade);
        }
        #endregion

        #region Command Methods

        public void OpenGrade()
        {
            List<GroupTableItemViewModel> groupTableItemViewModels = new List<GroupTableItemViewModel>();

            List<AcademicPerfomance> academicPerfomances = new List<AcademicPerfomance>();
            List<User> users = new List<User>();
            List<Lesson> lessons = new List<Lesson>();
            List<Cours> cours = new List<Cours>();
            List<CourseName> courseNames = new List<CourseName>();
            List<CourseStudent> courseStudents = new List<CourseStudent>();
            using (var context = new sqlUspevatoriyaEntities())
            {
                users = context.Users.ToList();
                academicPerfomances = context.AcademicPerfomances.ToList();
                lessons = context.Lessons.ToList();
                cours = context.Courses.ToList();
                courseNames = context.CourseNames.ToList();
                courseStudents = context.CourseStudents.ToList();

            }
            var selectCourseName = courseNames.Where(t => t.Name == mCourseName).FirstOrDefault();
            var selectCourse = cours.Where(t => t.ID == mIDCourse).FirstOrDefault();

            List<GroupTableEditItemViewModel> groupEditList = new List<GroupTableEditItemViewModel>();
            storeUserData.idSelectedGroupSidePanel = selectCourse.ID;
            if (storeUserData.idRole == 1)
            {
                foreach (var item in courseStudents.Where(t => t.IDCourse == selectCourse.ID))
                {
                    var selectUser = users.Where(t => t.ID == item.IDStudent).FirstOrDefault();

                    groupEditList.Add(new GroupTableEditItemViewModel
                    {
                        DgName = selectUser.Name,
                        DgPatronymic = selectUser.Patronymic,
                        DgSurname = selectUser.Surname,
                        IdCourseStudent = item.ID.ToString(),
                        IdCourse = selectCourse.ID.ToString()
                    });
                }
                DI.ViewModelApplication.GoToPage(ApplicationPage.EditGroup, new GroupEditPageViewModel
                {
                    idCourse = selectCourse.ID,
                    DisplayTitle = Name,
                    Itemss = groupEditList,
                    DelButtonClick = new RelayCommand(DelButton),
                    strIDCourse = selectCourse.ID.ToString()
                });

            }
            if (storeUserData.idRole == 2)
            {

                foreach (var item in academicPerfomances.Where(t => t.CourseStudent.IDCourse == selectCourse.ID))
                {

                    var selectItem = academicPerfomances.Where(t => t.ID == item.ID).FirstOrDefault();
                    var selectUser = users.Where(t => t.ID == item.CourseStudent.IDStudent).FirstOrDefault();
                    var selectLessons = lessons.Where(t => t.ID == item.IDLessons).FirstOrDefault();

                    groupTableItemViewModels.Add(new GroupTableItemViewModel
                    {
                        dgInitials = selectUser.Surname + " " + selectUser.Name + " " + selectUser.Patronymic,
                        dgDateTime = Convert.ToDateTime(selectLessons.DateTime).ToShortDateString(),
                        dgGrade = item.Grade,
                        id = item.ID.ToString(),
                    });
                }
                DI.ViewModelApplication.GoToPage(ApplicationPage.Table, new GroupPageViewModel
                {
                    DisplayTitle = Name,

                    strIDCourse = selectCourse.ID.ToString(),


                    Items = groupTableItemViewModels

                });
            }


        }
        public void DelButton()
        {

        }
        #endregion
    }
}
