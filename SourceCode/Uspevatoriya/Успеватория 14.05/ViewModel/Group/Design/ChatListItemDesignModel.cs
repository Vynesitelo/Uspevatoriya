using System.Xml.Linq;

namespace Успеватория.Ядро
{
    /// <summary>
    /// Время дизайна для <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// Одиночный экземпляр для модели
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            GroupSize = "This chat app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}
