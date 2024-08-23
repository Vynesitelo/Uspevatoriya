using Успеватория.ViewModel.Input;

namespace Успеватория
{
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "********";
        }

        #endregion
    }
}
