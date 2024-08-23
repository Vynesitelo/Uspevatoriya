using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;


namespace Успеватория
{
    public class ScheduleGroupListItemViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// Имя группы для показа расписания
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Имя курса
        /// </summary>
        public string mCourseName { get; set; }
        /// <summary>
        /// код курса
        /// </summary>
        public int mIDCourse { get; set; }

        /// <summary>
        /// Дата начала курса
        /// </summary>
        public DateTime mDateBegin { get; set; }

        /// <summary>
        /// Дата начала курса
        /// </summary>
        public string DateBegin
        {
            get { return "Дата начала курса: " + mDateBegin.Date.ToShortDateString(); }
        }
        /// <summary>
        /// Дата конца курса
        /// </summary>
        public DateTime mDateEnd { get; set; }
        /// <summary>
        /// Дата конца урока
        /// </summary>
        public string DateEnd
        {
            get { return "Дата конца курса: " + mDateEnd.Date.ToShortDateString(); }
        }

        /// <summary>
        /// Инициалы для отображения в элементе списка
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// РГБ значение для превьюшки
        /// Для примера FF00FF 
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True если айтем выбран
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Открытие нужного потока расписания
        /// </summary>
        public ICommand OpenScheduleContent { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public ScheduleGroupListItemViewModel()
        {
            //Определение команд
            OpenScheduleContent = new RelayCommand(OpenSchedule);
        }
        #endregion

        #region CommandMethods
        /// <summary>
        /// Метод команды открытия расписания
        /// </summary>
        public void OpenSchedule()
        {
            List<ScheduleElementItemViewModel> scheduleElementItemViewModels = new List<ScheduleElementItemViewModel>();
            List<Lesson> lessons = new List<Lesson>();
            List<Cours> cours = new List<Cours>();
            List<CourseName> courseNames = new List<CourseName>();
            using (var context = new sqlUspevatoriyaEntities())
            {
                lessons = context.Lessons.ToList();
                courseNames = context.CourseNames.ToList();
                cours = context.Courses.ToList();
            }
            var selectCourseName = courseNames.Where(t => t.Name == mCourseName).FirstOrDefault();
            var selectCourse = cours.Where(t => t.ID == mIDCourse).FirstOrDefault();
            storeUserData.idSelectedGroupSidePanel = selectCourse.ID;
            foreach (var lesson in lessons.Where(t => t.IDCourse == selectCourse.ID))
            {
                scheduleElementItemViewModels.Add(new ScheduleElementItemViewModel
                {
                    GroupName = "Группа: " + Name,
                    Lessons = "Урок: " + lesson.ID.ToString(),
                    DateLessons = "Дата урока: " + lesson.DateTime.ToString()
                });
            }

            //Вызов и создания объектов и страницы расписания
            DI.ViewModelApplication.GoToPage(ApplicationPage.Schedule, new SchedulePageViewModel
            {
                DisplayTitle = Name,

                Items = scheduleElementItemViewModels
            });
        }
        #endregion
    }
}
