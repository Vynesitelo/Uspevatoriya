 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Успеватория.Ядро
{
    public class BasePopupMenuViewModel : BaseViewModel

    {
        #region Public Properties
        /// <summary>
        /// Цвет фона для пузыря АРГБ значение 
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// Выравнивание стрелки пузырька
        /// </summary>
        public ElementHorizontalAligment ArrowAligment { get; set; }
        #endregion
        #region Constructor

        //конструктор
        public BasePopupMenuViewModel()
        {
            //Устанавливаем стандартное значение
            BubbleBackground = "ffffff";
            ArrowAligment = ElementHorizontalAligment.Left;

        }
        #endregion
    }
}
