using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Модель представления списка пользователей
    /// </summary>
    public class UserListItemViewModel : BaseViewModel
    {
        #region Public Properties
        public int idUser { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string Name { get; set; }

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
        public ICommand OpenUserContent { get; set; }
        #endregion

        #region Constructor
        public UserListItemViewModel()
        {
            OpenUserContent = new RelayCommand(OpenUser);
        }
        #endregion

        #region Command Methods

        public void OpenUser()
        {
            try
            {
                if (Name == "Jesse")
                {
                    DI.ViewModelApplication.GoToPage(ApplicationPage.User);
                    return;

                }
                List<User> users = new List<User>();
                using (var context = new sqlUspevatoriyaEntities())
                {
                    users = context.Users.ToList();
                }
                var selectUser = users.Where(t => t.ID == idUser).FirstOrDefault();
                bool vis;
                if (selectUser.IDRoles != 3)
                {
                    vis = false;
                }
                else
                {
                    vis = true;
                }
                storeUserData.idSelectedUserSidePanel = selectUser.ID;
                DI.ViewModelApplication.GoToPage(ApplicationPage.User, new UserPageViewModel
                {
                    DisplayTitle = Name,
                    Name = selectUser.Name,
                    Surname = selectUser.Surname,
                    Patronymic = selectUser.Patronymic,
                    Login = selectUser.Login,
                    Password = selectUser.Password,
                    Phone = selectUser.Phone,
                    Role = selectUser.IDRoles.ToString(),
                    IndentificationDocuments = selectUser.IndentificstionDocument,
                    idUser = selectUser.ID,
                    selectedItems = (selectUser.IDRoles - 1).ToString(),
                    IsButtonVisible = vis
                });
            }
            catch
            {
                DI.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Message = "Обновите данные, возможно данного пользователя уже не существует в базе данных",
                    OkText = "OK",
                    Title = "Ошибка",
                });
            }

        }
        #endregion
    }
}
