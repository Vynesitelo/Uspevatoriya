using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    public class GroupEditPageViewModel : BaseViewModel
    {
        #region Private Memberse
        private bool isButtonVisible;
        private readonly IRepository<Lesson> repositoryLesson;
        protected List<GroupTableEditItemViewModel> mItems = new List<GroupTableEditItemViewModel>();
        private readonly IRepository<ParentsChild> repositoryParentsChild;
        private readonly IRepository<CourseStudent> repositoryCS;
        private readonly IRepository<User> repositoryUsers;
        private string _textCB;
        private User _selectStudent;
        /// <summary>
        /// Последний текст поиска
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// Текст поиска
        /// </summary>
        protected string mSearchText;
        /// <summary>
        /// Флаг индикации открытия поисковой строки
        /// </summary>
        protected bool mSearchIsOpen;
        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        //protected List<UserListItemViewModel> mItems;
        #endregion

        #region Public Properties
        /// <summary>
        /// Тру показать, ложь спрятать
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }
        public bool IsButtonVisible
        {
            get { return isButtonVisible; }
            set
            {
                if (isButtonVisible != value)
                {
                    isButtonVisible = value;
                    OnPropertyChanged(nameof(IsButtonVisible));
                }
            }
        }

        /// <summary>
        /// Тру если всплывающее меню показываем
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;


        /// <summary>
        /// Модель представления для меню вложения
        /// </summary>
        public AttachmentPopupMenuGroupViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// Текст поиска
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Проверка значения
                if (mSearchText == value)
                    return;

                // Обновление
                mSearchText = value;

                // Если поиск пуст...
                if (string.IsNullOrEmpty(SearchText))
                    // перезапускаем поиск
                    Search();
            }
        }
        /// <summary>
        /// Флаг индикации открытия поиска
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                // Проверка значения
                if (mSearchIsOpen == value)
                    return;

                // Обновление
                mSearchIsOpen = value;

                // Если поиск закрыт...
                if (!mSearchIsOpen)
                    // Очистка текста
                    SearchText = string.Empty;
            }
        }
        public DateTime selectDate { get; set; } = DateTime.Today;
        public string strIDCourse { get; set; }

        /// <summary>
        /// Выбранный студент
        /// </summary>
        public User selectStudent
        {
            get { return _selectStudent; }
            set
            {
                _selectStudent = value;
                NotifyPropertyChangeds("selectStudent");

            }
        }
        public string textCB
        {
            get { return _textCB; }
            set
            {
                _textCB = value;
                NotifyPropertyChangeds("textCB");
            }
        }
        /// <summary>
        /// Список пользователей в comboBox
        /// </summary>
        public List<User> users { get; set; }
        public List<GroupTableEditItemViewModel> Itemss
        {
            get => mItems;
            set
            {
                if (mItems == null)
                    return;

                mItems.AddRange(value);

                FiltredItems = new List<GroupTableEditItemViewModel>(mItems);
            }
        }
        public List<GroupTableEditItemViewModel> FiltredItems { get; set; }
        /// <summary>
        /// Заголовок экрана
        /// </summary>
        public string DisplayTitle { get; set; }
        public int idCourse { get; set; }

        #endregion

        #region Public Commands
        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }
        /// <summary>
        /// Команда поиска
        /// </summary>
        public ICommand SearchCommand { get; set; }
        /// <summary>
        /// Команда когда пользователю нужно открыть строку поиска
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }
        /// <summary>
        /// Команда когда пользователю нужно закрыть строку поиска
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// Команда когда пользователю нужно очистить строку поиска
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }
        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }
        /// <summary>
        /// Команда сохранения изменений
        /// </summary>
        public ICommand SaveButtonClick { get; set; }
        /// <summary>
        /// Команда добавления урока
        /// </summary>
        public ICommand AddButtonClick { get; set; }
        public ICommand DelButtonClick { get; set; }
        public ICommand ComboBox_SelectionChangedCommand { get; set; }

        #endregion

        #region Constructor
        public GroupEditPageViewModel()
        {
            repositoryLesson = DI.RepositoryLesson;
            repositoryUsers = DI.RepositoryUser;
            repositoryCS = DI.RepositoryCourseStudent;
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SaveButtonClick = new RelayCommand(SaveButton);
            AddButtonClick = new RelayCommand(AddButton);
            DelButtonClick = new RelayCommand(DelButton);
            ComboBox_SelectionChangedCommand = new RelayCommand(ComboBox_SelectionChanged);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            // Создаём стандартное меню
            AttachmentMenu = new AttachmentPopupMenuGroupViewModel() { idUser = storeUserData.idSelectedGroupSidePanel };

            using (var context = new sqlUspevatoriyaEntities())
            {
                users = context.Users.Where(t => t.IDRoles == 3).ToList();
            }
        }
        #endregion

        #region CommandMethods
        private void ComboBox_SelectionChanged()
        {
            NotifyPropertyChangeds("selectStudent");

        }

        /// <summary>
        /// When the attachment button is clicked show/hide the attachment pop-up
        /// </summary>
        public void AttachmentButton()
        {
            // Toggle menu visibility
            AttachmentMenuVisible ^= true;
        }

        public void PopupClickaway()
        {
            // Hide attachment menu
            AttachmentMenuVisible = false;
        }

        public void SaveButton()
        {
            int i = 0;
            int idUser = 0;

            foreach (var item in users)
            {
                if (item.IndentificstionDocument == textCB)
                {
                    idUser = item.ID;
                }
                i++;
            }
            List<CourseStudent> Cstudents = new List<CourseStudent>();
            using (var context = new sqlUspevatoriyaEntities())
            {
                Cstudents = context.CourseStudents.ToList();
            }
            if ((Cstudents.Where(t => t.IDCourse == idCourse && t.IDStudent == idUser).FirstOrDefault()) != null)
            {
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Ошибка",
                    Message = "Ошибка, проверьте верность введёных значений",
                    OkText = "OK",
                });
            }
            else
            {
                DBCommand.ExecuteCommand($"insert into CourseStudent(IDCourse, IDStudent) Values('{Convert.ToInt32(idCourse)}','{idUser}')");
            }
        }

        /// <summary>
        /// При нажатии на кнопку добавить урок
        /// </summary>
        public void AddButton()
        {
            //Действие сохранить изменения
            DI.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "test",
                Message = $"{selectDate}",
                OkText = "OK",
            });
            repositoryLesson.Add(new Lesson
            {
                IDCourse = Convert.ToInt32(strIDCourse),
                DateTime = selectDate,
            });

        }

        public void DelButton()
        {
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
        }

        public event PropertyChangedEventHandler PropertyChangeds;

        private void NotifyPropertyChangeds(string propertyName)
        {
            int i = 0;
            int idUser = 0;
            PropertyChangeds?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (selectStudent != null)
            {
                textCB = selectStudent.IndentificstionDocument;

            }
        }

        /// <summary>
        /// Выполняет поиск по текущему списку пользователей
        /// </summary>
        public void Search()
        { }

        /// <summary>
        /// Очистка текста поиска
        /// </summary>
        public void ClearSearch()
        { }

        /// <summary>
        /// Открытие поиска
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;

        /// <summary>
        /// Закрытие поиска
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;

        #endregion
    }
}
