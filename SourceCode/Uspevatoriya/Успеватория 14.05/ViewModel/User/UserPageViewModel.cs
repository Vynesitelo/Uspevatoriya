using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    public class UserPageViewModel : BaseViewModel
    {
        #region Protected Properties
        private string _phone;
        private bool isButtonVisible;
        private readonly IRepository<AcademicPerfomance> repositoryAP;
        private readonly IRepository<CourseStudent> repositoryCS;
        private readonly IRepository<ParentsChild> repositoryParentsChild;
        private readonly IRepository<User> repositoryUser;
        private readonly IRepository<Cours> repositoryCours;

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

        #endregion

        #region Public Propeties

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
        public AttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public int MaxLenth { get; set; } = 12;



        /// <summary>
        /// The title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }
        public int idUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone
        {
            get => _phone;
            set
            {
                if (value == _phone) return;
                _phone = value;
                PhoneMask();
            }
        }

        public int PhoneLength { get; set; }

        public string IndentificationDocuments { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public List<Role> roles { get; set; }
        public ComboBox ComboBox { get; set; }
        public string selectedItems { get; set; }
        #endregion

        #region Public Commands

        /// <summary>
        /// Команда для нажатия кнопки вложения
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// Команда для щелчка по области за всплвающим окном
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }
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
        /// Команда сохранения изменений
        /// </summary>
        public ICommand SaveButtonClick { get; set; }
        public ICommand DeleteButtonClick { get; set; }
        public ICommand AddButtonClick { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserPageViewModel()
        {
            repositoryUser = DI.RepositoryUser;

            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SaveButtonClick = new RelayCommand(SaveButton);
            DeleteButtonClick = new RelayCommand(DeleteButton);
            AddButtonClick = new RelayCommand(AddButton);

            // Создаём стандартное меню
            AttachmentMenu = new AttachmentPopupMenuViewModel() { idUser = storeUserData.idSelectedUserSidePanel };

            using (var context = new sqlUspevatoriyaEntities())
            {
                roles = context.Roles.ToList();
            }
            repositoryAP = DI.RepositoryAcademicPerfomance;
            repositoryCours = DI.RepositoryCourse;
            repositoryCS = DI.RepositoryCourseStudent;
            repositoryParentsChild = DI.RepositoryParentsChild;
            repositoryUser = DI.RepositoryUser;

        }
        #endregion

        #region Command Methods

        /// <summary>
        /// При нажатии кнопки вложения показать/скрыть всплывающее окно.
        /// </summary>
        public void AttachmentButton()
        {
            // Перключаем видимость меню
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// Скрыть окно при нажатии вне всплывающего окна
        /// </summary>
        public void PopupClickaway()
        {
            //Скрыть всплывающее меню
            AttachmentMenuVisible = false;
        }

        /// <summary>
        /// При нажатии на кнопку сохранить изменения
        /// </summary>
        public void SaveButton()
        {
            //Действие сохранить изменения
            try
            {
                var selected = repositoryUser.Items.Where(item => item.ID == idUser).FirstOrDefault();
                selected.Name = Name;
                selected.Surname = Surname;
                selected.Patronymic = Patronymic;
                selected.Phone = Phone;
                selected.IndentificstionDocument = IndentificationDocuments;
                selected.Login = Login;
                selected.Password = Password;
                selected.IDRoles = (Convert.ToInt32(selectedItems) + 1);
                repositoryUser.Update(selected);
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = $"Успех",
                    Message = "Редактирование пользователя прошло успешно!",
                    OkText = "OK",
                });
            }
            catch
            {
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = $"Ошибка",
                    Message = "Редактирование пользователя не прошло, возможно проблемы в корректности введённых данных :(",
                    OkText = "OK",
                });
            }


        }
        /// <summary>
        /// При нажатии на кнопку сохранить изменения
        /// </summary>
        public void AddButton()
        {
            //Действие сохранить изменения

            try
            {
                var selected = repositoryUser.Items.Where(item => item.ID == idUser).FirstOrDefault();
                selected.Name = Name;
                selected.Surname = Surname;
                selected.Patronymic = Patronymic;
                selected.Phone = Phone;
                selected.IndentificstionDocument = IndentificationDocuments;
                selected.Login = Login;
                selected.Password = Password;
                selected.IDRoles = (Convert.ToInt32(selectedItems) + 1);
                repositoryUser.Add(selected);
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = $"Успех",
                    Message = "Добавление пользователя прошло успешно!",
                    OkText = "OK",
                });
            }
            catch
            {
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = $"Ошибка",
                    Message = "Добавление пользователя не прошло, возможно проблемы в корректности введённых данных :(\n Возможно данный логин либо документ привязан к другому пользователю ",
                    OkText = "OK",
                });
            }


        }
        public void DeleteButton()
        {
            //Действие удаления пользователя
            try
            {
                var selected = repositoryUser.Items.Where(item => item.ID == idUser).FirstOrDefault();
                List<CourseStudent> students = new List<CourseStudent>();
                List<AcademicPerfomance> ap = new List<AcademicPerfomance>();
                List<ParentsChild> parents = new List<ParentsChild>();
                List<Cours> cours = new List<Cours>();
                using (var context = new sqlUspevatoriyaEntities())
                {

                    students = context.CourseStudents.Where(t => t.IDStudent == selected.ID).ToList();
                    ap = context.AcademicPerfomances.ToList();
                    parents = context.ParentsChilds.ToList();
                }
                foreach (var item in students)
                {
                    foreach (var apItem in ap.Where(t => t.IDCousrseStudent == item.ID))
                    {
                        repositoryAP.Remove(apItem.ID);
                    }
                    repositoryCS.Remove(item.ID);
                }
                if (selected != null)
                {
                    foreach (var item in parents)
                    {
                        if (item.IDParent == selected.ID)
                        {
                            repositoryParentsChild.Remove(item.ID);
                        }
                        else if (item.IDChildren == selected.ID)
                        {
                            repositoryParentsChild.Remove(item.ID);
                        }
                    }
                }
                foreach (var item in cours)
                {
                    if (item.IDTeacher == selected.ID)
                    {
                        var updCours = repositoryCours.Items.Where(t => t.ID == item.ID).FirstOrDefault();
                        updCours.IDTeacher = null;
                        repositoryCours.Update(updCours);
                    }
                }
                repositoryUser.Remove(idUser);
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = $"Успех",
                    Message = "Удаление пользователя прошло успешно!",
                    OkText = "OK",
                });
            }
            catch (Exception ex)
            {
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = $"Ошибка",
                    Message = $"Удаление пользователя не прошло :( {ex}",
                    OkText = "OK",
                });
            }


        }

        #endregion

        public async Task PhoneMask()
        {
            var newVal = Regex.Replace(Phone, @"[^0-9]", "");
            if (PhoneLength != newVal.Length && !string.IsNullOrEmpty(newVal))
            {
                PhoneLength = newVal.Length;
                Phone = string.Empty;
                if (newVal.Length <= 1)
                {
                    Phone = Regex.Replace(newVal, @"(\d{1})", "+$1");
                }
                else if (newVal.Length <= 4)
                {
                    Phone = Regex.Replace(newVal, @"(\d{1})(\d{0,3})", "+$1($2)");
                }
                else if (newVal.Length <= 7)
                {
                    Phone = Regex.Replace(newVal, @"(\d{1})(\d{3})(\d{0,3})", "+$1($2)$3");
                }
                else if (newVal.Length <= 9)
                {
                    Phone = Regex.Replace(newVal, @"(\d{1})(\d{3})(\d{0,3})(\d{0,2})", "+$1($2)$3-$4");
                }
                else if (newVal.Length > 9)
                {
                    Phone = Regex.Replace(newVal, @"(\d{1})(\d{3})(\d{0,3})(\d{0,2})(\d{0,2})", "+$1($2)$3-$4-$5");
                }
            }
        }

    }
}
