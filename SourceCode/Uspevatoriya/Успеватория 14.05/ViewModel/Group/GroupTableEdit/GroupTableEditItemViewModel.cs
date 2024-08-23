using System;
using System.ComponentModel;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    public class GroupTableEditItemViewModel : BaseViewModel
    {
        private readonly IRepository<CourseStudent> courseStudentRepository;
        private string _IdCourseStudent;
        private string _DgName;
        private string _DgSurname;
        private string _DgPatronymic;
        public string IdCourse { get; set; }
        public string IdCourseStudent
        {
            get { return _IdCourseStudent; }
            set
            {
                _IdCourseStudent = value;
                OnPropertyChangeds("IdCourseStudent");
            }
        }
        public string DgName
        {
            get { return _DgName; }
            set
            {
                _DgName = value;
                OnPropertyChangeds("DgName");
            }
        }
        public string DgSurname
        {
            get { return _DgSurname; }
            set
            {
                _DgSurname = value;
                OnPropertyChangeds("DgSurname");
            }
        }
        public string DgPatronymic
        {
            get { return _DgPatronymic; }
            set
            {
                _DgPatronymic = value;
                OnPropertyChangeds("DgPatronymic");
            }
        }
        public string SelectCS { get; set; }

        #region Commands
        public ICommand DelButtonClick { get; set; }

        #endregion

        #region Constructor
        public GroupTableEditItemViewModel()
        {
            DelButtonClick = new RelayCommand(DelButton);

            courseStudentRepository = DI.RepositoryCourseStudent;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChangeds;

        protected void OnPropertyChangeds(string propertyName)
        {
            PropertyChangeds?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //Запись изменяемых данных
            if (!string.IsNullOrEmpty(IdCourseStudent))
            {
                SelectCS = IdCourseStudent.ToString();
            }
        }
        public void DelButton()
        {
            //Удаление пользователя из группы
            try
            {
                if (SelectCS != null)
                {
                    courseStudentRepository.Remove(Convert.ToInt32(SelectCS));
                }
            }
            catch
            {
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Данной записи в базе данных уже не существует, обновите таблицу",
                    OkText = "OK",
                });
                throw;
            }
        }
    }
}
