namespace Успеватория
{
    public class ScheduleElementItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Наименование группы
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Урок
        /// </summary>
        public string Lessons { get; set; }
        /// <summary>
        /// Дата урока
        /// </summary>
        public string DateLessons { get; set; }
    }
}
