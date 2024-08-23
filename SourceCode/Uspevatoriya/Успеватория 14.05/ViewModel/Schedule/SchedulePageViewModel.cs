using System.Collections.Generic;
using System.Windows.Input;

namespace Успеватория
{
    public class SchedulePageViewModel : BaseViewModel
    {
        #region Protected Members


        private bool isButtonVisible;
        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        protected List<ScheduleElementItemViewModel> mItems;

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

        #region Public Properties
        /// <summary>
        /// Заголовок экрана
        /// </summary>
        public string DisplayTitle { get; set; }
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
        public AttachmentPopupMenuScheduleViewModel AttachmentMenu { get; set; }

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
        /// <summary>
        /// The chat thread items for the list
        /// NOTE: Do not call Items.Add to add messages to this list
        ///       as it will make the FilteredItems out of sync
        /// </summary>
        public List<ScheduleElementItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                FilteredItems = new List<ScheduleElementItemViewModel>(mItems);

            }
        }
        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public List<ScheduleElementItemViewModel> FilteredItems { get; set; }
        #endregion

        #region Public Commands

        /// <summary>
        /// Команда для нажатия кнопки вложения
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
        /// Команда для щелчка по области за всплвающим окном
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        /// <summary>
        /// Команда сохранения изменений
        /// </summary>
        public ICommand SaveButtonClick { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public SchedulePageViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SaveButtonClick = new RelayCommand(SaveButton);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            // Создаём стандартное меню
            AttachmentMenu = new AttachmentPopupMenuScheduleViewModel() { idUser = storeUserData.idSelectedGroupSidePanel };

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
            DI.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Title22222",
                Message = "test",
                OkText = "test",
            });
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
