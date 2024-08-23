using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Модель представления основанная на запуске изменения значения
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, которое вызывается, когда какое-либо дочернее свойство меняет свое значение.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Вызов события a <see cref="PropertyChanged"/> 
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Запускает команду, если флаг обновления не установлен.
        /// Если флаг равен true (что указывает на то, что функция уже запущена), действие не запускается.
        /// Если флаг имеет значение false (что указывает на отсутствие запущенной функции), действие запускается.
        /// После завершения действия, если оно было запущено, флаг сбрасывается на false.
        /// </summary>
        /// <param name="updatingFlag">Флаг логического свойства, определяющий, запущена ли команда.</param>
        /// <param name="action">Действие, которое нужно выполнить, если команда еще не запущена</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            lock (updatingFlag)
            {
                // Проверьте, истинно ли свойство flag (это означает, что функция уже запущена).
                if (updatingFlag.GetPropertyValue())
                    return;

                // флаг свойства имеет значение true, чтобы указать, что мы работаем
                updatingFlag.SetPropertyValue(true);
            }

            try
            {
                // Запустите переданное в действие
                await action();
            }
            finally
            {
                // Устанавливаем флаг свойства обратно на false
                updatingFlag.SetPropertyValue(false);
            }
        }

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (indicating the function is already running) then the action is not run.
        /// If the flag is false (indicating no running function) then the action is run.
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <typeparam name="T">The type the action returns</typeparam>
        /// <returns></returns>
        protected async Task<T> RunCommandAsync<T>(Expression<Func<bool>> updatingFlag, Func<Task<T>> action, T defaultValue = default(T))
        {
            // Lock to ensure single access to check
            lock (updatingFlag)
            {
                // Check if the flag property is true (meaning the function is already running)
                if (updatingFlag.GetPropertyValue())
                    return defaultValue;

                // Set the property flag to true to indicate we are running
                updatingFlag.SetPropertyValue(true);
            }

            try
            {
                // Run the passed in action
                return await action();
            }
            finally
            {
                // Set the property flag back to false now it's finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
