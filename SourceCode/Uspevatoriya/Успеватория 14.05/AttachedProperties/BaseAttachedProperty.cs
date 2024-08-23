using System;
using System.Windows;


namespace Успеватория
{
    /// <summary>
    /// Свойство связанное с основой, родительское свойство
    /// </summary>
    /// <typeparam name="Parent">Родительский класс прикреплённое свойство</typeparam>
    /// <typeparam name="Property">Тип свойтсва</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        #region Public Events
        /// <summary>
        /// Запускается во время изменения значения
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// Запускается во время изменения значения, даже если значения одинаковы
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// Одинарный экземпляр родительского класса
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// Фактическое свойство присоединения для класса
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value", typeof(Property),
            typeof(BaseAttachedProperty<Parent, Property>),
            new UIPropertyMetadata(
                default(Property),
                new PropertyChangedCallback(OnValuePropertyChanged),
                new CoerceValueCallback(OnValuePropertyUpdated)
                ));

        /// <summary>
        /// Свойство обратного события где <see cref="ValueProperty"/> изменяется
        /// </summary>
        /// <param name="d">"Элемент UI с изменённым свойством</param>
        /// <param name="e">Аргумент события</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Вызов родительской функции
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);


            //Прослушиватели событий
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }
        /// <summary>
        /// Свойство обратного события где <see cref="ValueProperty"/> изменяется, даже если значение не изменено
        /// </summary>
        /// <param name="d">"Элемент UI с изменённым свойством</param>
        /// <param name="e">Аргумент события</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            //Вызов родительской функции
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);


            //Прослушиватели событий
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            //Возврат значения
            return value;
        }


        /// <summary>
        /// Функция возвращения свойтсва и получения его обратно
        /// </summary>
        /// <param name="d">Элемент получает значение</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Привязка свойства
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);


        #endregion

        #region Event Methods
        /// <summary>
        /// Метод вызывается при изменении значения любого присоединённого элемента этого типа
        /// </summary>
        /// <param name="sender">Элемент пользовательского интерфейса</param>
        /// <param name="e">Аргумент для события</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// Метод вызывается при изменении значения любого присоединённого элемента этого типа, даже если значение не изменено
        /// </summary>
        /// <param name="sender">Элемент пользовательского интерфейса</param>
        /// <param name="e">Аргумент для события</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        #endregion
    }
}
