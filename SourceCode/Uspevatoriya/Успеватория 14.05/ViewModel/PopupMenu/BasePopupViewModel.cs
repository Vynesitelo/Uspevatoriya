using Успеватория.Ядро;

namespace Успеватория
{
    public class BasePopupViewModel : BaseViewModel

    {
        #region Public Properties
        /// <summary>
        /// Цвет фона для пузыря АРГБ значение 
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// Выравнивание стрелки пузырька
        /// </summary>
        public ElementHorizontalAligment ArrowAlignment { get; set; }

        /// <summary>
        /// Содержимое внутри всплывающего меню
        /// </summary>
        public BaseViewModel Content { get; set; }
        #endregion
        #region Constructor

        //конструктор
        public BasePopupViewModel()
        {
            //Устанавливаем стандартное значение
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAligment.Right;

        }
        #endregion

    }
}
