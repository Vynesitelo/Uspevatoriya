using System.Collections.Generic;

namespace Успеватория
{
    public class GroupTableEditListItemDesignModel : GroupEditPageViewModel
    {
        #region Singleton
        /// <summary>
        /// Экземпляр
        /// </summary>
        public static GroupTableEditListItemDesignModel Instance => new GroupTableEditListItemDesignModel();
        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        public GroupTableEditListItemDesignModel()
        {
            Itemss = new List<GroupTableEditItemViewModel>
            {
                new GroupTableEditItemViewModel()
                {
                    DgName = "Name",
                    DgPatronymic = "Patronymic",
                    DgSurname = "Surname",
                },
                new GroupTableEditItemViewModel()
                {
                    DgName = "Name",
                    DgPatronymic = "Patronymic",
                    DgSurname = "Surname",
                },
                 new GroupTableEditItemViewModel()
                {
                    DgName = "Name",
                    DgPatronymic = "Patronymic",
                    DgSurname = "Surname",
                },
            };
        }
        #endregion
    }
}
