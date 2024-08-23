using System.Collections.Generic;
namespace Успеватория.Ядро
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "IP-421",
                    Initials = "IP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "IP-323",
                    Initials = "IP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Name = "IP-422",
                    Initials = "IP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "00d405",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Name = "IP-124",
                    Initials = "IP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Name = "UP-131",
                    Initials = "UP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Name = "UP-132",
                    Initials = "UP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "00d405"
                },
                new ChatListItemViewModel
                {
                    Name = "UP-233",
                    Initials = "UP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Name = "UP-235",
                    Initials = "UP",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Name = "Parnell",
                    Initials = "PL",
                    GroupSize = "Size: 25",
                    ProfilePictureRGB = "00d405"
                },
            };
        }

        #endregion
    }
}
