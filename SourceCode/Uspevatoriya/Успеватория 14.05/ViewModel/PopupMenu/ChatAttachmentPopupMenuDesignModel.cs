using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Успеватория.Ядро
{
    public class ChatAttachmentPopupMenuDesignModel: ChatAttachmentPopupMenuViewModel
    {
        //Единичный экземпляр модели
        public static ChatAttachmentPopupMenuDesignModel Instance => new ChatAttachmentPopupMenuDesignModel();

        #region Constructor
        //Конструктор
        public ChatAttachmentPopupMenuDesignModel() { }
        #endregion
    }
}
