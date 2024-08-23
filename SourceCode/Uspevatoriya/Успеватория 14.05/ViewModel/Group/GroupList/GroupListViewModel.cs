using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Успеватория
{
    /// <summary>
    /// Модель представления для списка чатов снаружи
    /// </summary>
    public class GroupListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastSearchText;

        protected List<GroupListItemViewModel> mItems;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;
        #endregion

        #region Public Properties
        public List<GroupListItemViewModel> Items
        {
            get => mItems;
            set
            {
                if (mItems == value) { return; }

                mItems = value;

                FilteredItems = new List<GroupListItemViewModel>(mItems);
            }
        }
        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public List<GroupListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Check value is different
                if (mSearchText == value)
                    return;

                // Update value
                mSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchText))
                    // Search to restore messages
                    Search();
            }
        }
        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GroupListViewModel()
        {
            // Create commands
            SearchCommand = new RelayCommand(Search);


        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            // Make sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            // If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                // Make filtered list the same
                FilteredItems = new List<GroupListItemViewModel>(Items ?? Enumerable.Empty<GroupListItemViewModel>());

                // Set last search text

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search

            // Set last search text
        }

        #endregion

    }
}
