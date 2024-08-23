using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Успеватория
{
    /// <summary>
    /// Модель представления для списка пользователей снаружи
    /// </summary>
    public class UserListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// Последний текст поиска
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// Текст поиска для команды
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// Индикатор открытия диалога поиска
        /// </summary>
        protected bool mSearchIsOpen;

        protected List<UserListItemViewModel> mItems;
        #endregion

        #region Public Properties
        public List<UserListItemViewModel> Items
        {
            get => mItems;

            set
            {
                if (mItems == value) { return; }

                mItems = value;
                OnPropertyChangedItem("Items");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

                FilteredItems = new List<UserListItemViewModel>(mItems);

            }
        }

        public List<UserListItemViewModel> FilteredItems { get; set; }

        #endregion

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

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                // Check value has changed
                if (mSearchIsOpen == value)
                    return;

                // Update value
                mSearchIsOpen = value;

                // If dialog closes...
                if (!mSearchIsOpen)
                    // Clear search text
                    SearchText = string.Empty;
            }
        }
        #region Public Commands

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to open the search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to close to search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to clear the search text
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserListViewModel()
        {
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);
        }

        #endregion

        #region Command Methods
        // Implement INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChangeds;
        //protected void OnPropertyChangeds(string propertyName)
        //{
        //    PropertyChangeds?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}



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
                FilteredItems = new List<UserListItemViewModel>(Items ?? Enumerable.Empty<UserListItemViewModel>());

                // Set last search text
                mLastSearchText = SearchText;

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search
            FilteredItems = new List<UserListItemViewModel>(
                Items.Where(item => item.Name.ToLower().Contains(SearchText)));

            // Set last search text
            mLastSearchText = SearchText;
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            // If there is some search text...
            if (!string.IsNullOrEmpty(SearchText))
                // Clear the text
                SearchText = string.Empty;
            // Otherwise...
            else
                // Close search dialog
                SearchIsOpen = false;
        }

        /// <summary>
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;

        /// <summary>
        /// Closes the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;
        #endregion

        public event PropertyChangedEventHandler PropertyChangedItem;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void OnPropertyChangedItem(string propertyName)
        {
            PropertyChangedItem?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }

}
