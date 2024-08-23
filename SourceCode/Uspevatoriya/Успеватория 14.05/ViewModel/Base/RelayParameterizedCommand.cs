using System;
using System.Windows.Input;

namespace Успеватория
{
    /// <summary>
    /// Основная команда запускающая действия
    /// </summary>
    public class RelayParameterizedCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// Запускает действие
        /// </summary>
        private Action<object> mAction;

        #endregion

        #region Public Events

        /// <summary>
        /// Событие активируется если <see cref="CanExecute(object)"/> значение изменено
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public RelayParameterizedCommand(Action<object> action)
        {
            mAction = action;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Команда всегда может выполнится
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполняет команды Действие
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction(parameter);
        }

        #endregion
    }
}
