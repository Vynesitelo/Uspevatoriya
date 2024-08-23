using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Успеватория.DAL.Context;

namespace Успеватория
{
    /// <summary>
    /// Данные времени разработки <see cref="UserListDesignModel"/>
    /// </summary>
    public class UserListDesignModel : UserListViewModel
    {
        #region Priveate members
        private bool _isAdminSelected;
        private bool _isParentSelected;
        private bool _isTeacherSelected;
        private bool _isStudentSelected;
        #endregion
        #region Public Properties
        public bool IsAdminSelected
        {
            get { return _isAdminSelected; }
            set
            {
                if (_isAdminSelected != value)
                {
                    _isAdminSelected = value;

                    OnPropertyChanged(nameof(IsAdminSelected));
                    storeUserData._isAdminSelected = _isAdminSelected;
                    FilterItemsCommand();
                }

            }
        }
        public bool IsTeacherSelected
        {
            get { return _isTeacherSelected; }
            set
            {
                if (_isTeacherSelected != value)
                {
                    _isTeacherSelected = value;

                    OnPropertyChanged(nameof(IsTeacherSelected));
                    storeUserData._isTeacherSelected = _isTeacherSelected;
                    FilterItemsCommand();
                }

            }
        }
        public List<UserListItemViewModel> _items = new List<UserListItemViewModel>();
        public bool IsStudentSelected
        {
            get { return _isStudentSelected; }
            set
            {
                if (_isStudentSelected != value)
                {
                    _isStudentSelected = value;

                    OnPropertyChanged(nameof(IsStudentSelected));
                    storeUserData._isStudentSelected = _isStudentSelected;
                    FilterItemsCommand();
                }

            }
        }
        public bool IsParentSelected
        {
            get { return _isParentSelected; }
            set
            {
                if (_isParentSelected != value)
                {
                    _isParentSelected = value;

                    OnPropertyChanged(nameof(IsParentSelected));
                    storeUserData._isParentSelected = _isParentSelected;
                    FilterItemsCommand();
                }

            }
        }

        #endregion

        #region Singleton
        /// <summary>
        /// Единичный экземляр модели дизайна (порт)
        /// </summary>
        public static UserListDesignModel Instance => new UserListDesignModel();

        #endregion

        #region Command
        public ICommand FilterCommand { get; set; }
        public ICommand SortByName { get; set; }
        public ICommand SortByNameRev { get; set; }
        public ICommand SortByRole { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserListDesignModel()
        {
            SortByName = new RelayCommand(SortByNameCommand);
            SortByNameRev = new RelayCommand(SortByNameRevCommand);
            SortByRole = new RelayCommand(SortByRoleCommand);
            FilterCommand = new RelayCommand(FilterItemsCommand);

            FillUserList(storeUserData.sortUser);
        }
        #endregion

        public void SortByNameCommand()
        {
            storeUserData.sortUser = 1;
            sortItems(storeUserData.sortUser);

        }
        public void SortByRoleCommand()
        {
            storeUserData.sortUser = 3;
            sortItems(storeUserData.sortUser);

        }
        public void SortByNameRevCommand()
        {
            storeUserData.sortUser = 2;
            sortItems(storeUserData.sortUser);

        }
        public void FillUserList(int a)
        {
            {
                List<User> users = new List<User>();
                List<Role> roles = new List<Role>();
                using (var context = new sqlUspevatoriyaEntities())
                {
                    users = context.Users.ToList();
                    roles = context.Roles.ToList();
                }
                Items = new List<UserListItemViewModel>();
                foreach (var item in users)
                {
                    Items.Add(new UserListItemViewModel
                    {
                        Name = item.Surname + " " + item.Name,
                        Initials = item.Name.Substring(0, 1) + item.Surname.Substring(0, 1),
                        GroupSize = roles.Where(t => t.ID == item.IDRoles).FirstOrDefault().Name,
                        ProfilePictureRGB = "3099c5",
                        idUser = item.ID
                    });
                }
                _items = Items;

                if (storeUserData._isAdminSelected != false || storeUserData._isParentSelected != false || storeUserData._isTeacherSelected != false || storeUserData._isStudentSelected != false)
                {
                    Items = _items.Where(i =>
            (storeUserData._isAdminSelected && i.GroupSize == "Администратор") ||
            (storeUserData._isTeacherSelected && i.GroupSize == "Преподаватель") ||
            (storeUserData._isStudentSelected && i.GroupSize == "Студент") ||
            (storeUserData._isParentSelected && i.GroupSize == "Родитель")).ToList();
                }
                switch (a)
                {
                    case 1:
                        Items = Items.OrderBy(i => i.Name).ToList();
                        break;
                    case 2:
                        Items = Items.OrderByDescending(i => i.Name).ToList();
                        break;
                    case 3:
                        Items = Items.OrderBy(i => i.GroupSize).ToList();
                        break;
                }


            }
        }
        public void sortItems(int a)
        {
            switch (a)
            {
                case 1:
                    Items = Items.OrderBy(i => i.Name).ToList();
                    break;
                case 2:
                    Items = Items.OrderByDescending(i => i.Name).ToList();
                    break;
                case 3:
                    Items = Items.OrderBy(i => i.GroupSize).ToList();
                    break;
            }
            OnPropertyChangedItem("Items");
            storeUserData.x = 1;

        }
        public void FilterItemsCommand()
        {
            storeUserData.x = 1;
        }
    }
}
