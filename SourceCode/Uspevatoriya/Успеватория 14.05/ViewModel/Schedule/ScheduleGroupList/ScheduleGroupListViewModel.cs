using System.Collections.Generic;

namespace Успеватория
{
    public class ScheduleGroupListViewModel : BaseViewModel
    {
        #region Protected Members

        protected List<ScheduleGroupListItemViewModel> mItems;

        #endregion
        #region PublicProperies

        public List<ScheduleGroupListItemViewModel> Items
        {
            get => mItems;
            set
            {
                if (mItems == value) return;

                mItems = value;

            }
        }
        #endregion


        #region Public Commands
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ScheduleGroupListViewModel()
        {

        }
        #endregion
        #region Command Methods
        #endregion
    }
}
