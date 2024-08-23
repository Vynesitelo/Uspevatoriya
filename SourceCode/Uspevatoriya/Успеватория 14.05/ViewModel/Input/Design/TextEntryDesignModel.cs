namespace Успеватория
{
    public class TextEntryDesignModel : TextEntryViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Luke Malpass";
            EditedText = "Editing :)";
        }

        #endregion
    }
}
