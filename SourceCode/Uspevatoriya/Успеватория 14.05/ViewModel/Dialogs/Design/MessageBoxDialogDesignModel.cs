namespace Успеватория
{
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {

        #region Singleton
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();
        #endregion

        #region Constructor
        public MessageBoxDialogDesignModel()
        {
            OkText = "OK";
            Message = "OK";
        }
        #endregion

    }
}
