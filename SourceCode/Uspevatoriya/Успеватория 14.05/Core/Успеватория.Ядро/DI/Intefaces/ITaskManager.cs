using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Успеватория.Ядро
{
    /// <summary>
    /// Выполняет все, что связано с задачами
    /// </summary>
    public interface ITaskManager
    {
        /// <summary>
        ///Ставит указанную работу в очередь для выполнения в пуле потоков и возвращает прокси-сервер для
        /// задача, возвращаемая функцией
        /// </summary>
        /// <param name="function">Работа, выполняемая асинхронно</param>
        /// <param name="origin">Метод/функция, в которой было зарегистрировано это сообщение</param>
        /// <param name="filePath">Имя файла кода, из которого было записано это сообщение</param>
        /// <param name="lineNumber">Строка кода в имени файла, из которого было записано это сообщение</param>
        /// <returns>Задача, представляющая собой прокси-сервер для задачи, возвращаемой функцией.</returns>
        /// <exception cref="ArgumentNullException">Параметром функции было значение null</exception>
        Task Run(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function">Работа, выполняемая асинхронно</param>
        /// <param name="origin">Метод/функция, в которой было зарегистрировано это сообщение</param>
        /// <param name="filePath">Имя файла кода, из которого было записано это сообщение</param>
        /// <param name="lineNumber">Строка кода в имени файла, из которого было записано это сообщение</param>
        /// <remarks>
        ///     The passed in Task cannot be awaited as it is to be run and forgotten.
        ///     Any errors thrown will get logged to the ILogger in the DI provider
        ///     and then swallowed and not re-thrown to the caller thread
        /// </remarks>
        /// <returns>A task that represents a proxy for the task returned by function.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        void RunAndForget(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// Task(TResult) returned by function.
        /// </summary>
        /// <typeparam name="TResult">The type of the result returned by the proxy task.</typeparam>
        /// <param name="function">Работа, выполняемая асинхронно</param>
        /// <param name="cancellationToken">Токен отмены, который следует использовать для отмены работы</param>
        /// <param name="origin">Метод/функция, в которой было зарегистрировано это сообщение</param>
        /// <param name="filePath">Имя файла кода, из которого было записано это сообщение</param>
        /// <param name="lineNumber">Строка кода в имени файла, из которого было записано это сообщение</param>
        /// <returns>A Task(TResult) that represents a proxy for the Task(TResult) returned by function.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
        /// <exception cref="ObjectDisposedException">The System.Threading.CancellationTokenSource associated with cancellationToken was disposed.</exception>
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// Task(TResult) returned by function.
        /// </summary>
        /// <typeparam name="TResult">The type of the result returned by the proxy task.</typeparam>
        /// <param name="function">Работа, выполняемая асинхронно</param>
        /// <param name="origin">Метод/функция, в которой было зарегистрировано это сообщение</param>
        /// <param name="filePath">Имя файла кода, из которого было записано это сообщение</param>
        /// <param name="lineNumber">Строка кода в имени файла, из которого было записано это сообщение</param>
        /// <returns>A Task(TResult) that represents a proxy for the Task(TResult) returned by function.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a Task(TResult)
        /// object that represents that work. A cancellation token allows the work to be
        /// canceled.
        /// </summary>
        /// <typeparam name="TResult">The result type of the task.</typeparam>
        /// <param name="function">The work to execute asynchronously</param>
        /// <param name="cancellationToken">A cancellation token that should be used to cancel the work</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        /// <returns>A Task(TResult) that represents the work queued to execute in the thread pool.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
        /// <exception cref="ObjectDisposedException">The System.Threading.CancellationTokenSource associated with cancellationToken was disposed.</exception>
        Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task`1
        /// object that represents that work.
        /// </summary>
        /// <typeparam name="TResult">The return type of the task.</typeparam>
        /// <param name="function">Работа, выполняемая асинхронно</param>
        /// <param name="origin">Метод/функция, в которой было зарегистрировано это сообщение</param>
        /// <param name="filePath">Имя файла кода, из которого было записано это сообщение</param>
        /// <param name="lineNumber">Строка кода в имени файла, из которого было записано это сообщение</param>
        /// <returns>A task object that represents the work queued to execute in the thread pool.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function">The work to execute asynchronously.</param>
        /// <param name="cancellationToken">A cancellation token that should be used to cancel the work.</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        /// <returns>A task that represents a proxy for the task returned by function.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
        /// <exception cref="ObjectDisposedException">The System.Threading.CancellationTokenSource associated with cancellationToken was disposed.</exception>
        Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function">The work to execute asynchronously.</param>
        /// <param name="cancellationToken">A cancellation token that should be used to cancel the work.</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        /// <remarks>
        ///     The passed in Task cannot be awaited as it is to be run and forgotten.
        ///     Any errors thrown will get logged to the ILogger in the DI provider
        ///     and then swallowed and not re-thrown to the caller thread
        /// </remarks>
        /// <returns>A task that represents a proxy for the task returned by function.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
        /// <exception cref="ObjectDisposedException">The System.Threading.CancellationTokenSource associated with cancellationToken was disposed.</exception>
        void RunAndForget(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work. A cancellation token allows the work to be
        /// canceled.
        /// </summary>
        /// <param name="action">The work to execute asynchronously</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        /// <returns>A task that represents the work queued to execute in the thread pool.</returns>
        /// <exception cref="ArgumentNullException">The action parameter was null.</exception>
        /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
        /// <exception cref="ObjectDisposedException">The System.Threading.CancellationTokenSource associated with cancellationToken was disposed.</exception>
        Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work. A cancellation token allows the work to be
        /// canceled.
        /// </summary>
        /// <param name="action">The work to execute asynchronously</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        /// <remarks>
        ///     The passed in Task cannot be awaited as it is to be run and forgotten.
        ///     Any errors thrown will get logged to the ILogger in the DI provider
        ///     and then swallowed and not re-thrown to the caller thread
        /// </remarks>
        /// <returns>A task that represents the work queued to execute in the thread pool.</returns>
        /// <exception cref="ArgumentNullException">The action parameter was null.</exception>
        /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
        /// <exception cref="ObjectDisposedException">The System.Threading.CancellationTokenSource associated with cancellationToken was disposed.</exception>
        void RunAndForget(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work.
        /// </summary>
        /// <param name="action">Работа, выполняемая асинхронно</param>
        /// <param name="origin">Метод/функция, в которой было зарегистрировано это сообщение</param>
        /// <param name="filePath">Имя файла кода, из которого было записано это сообщение</param>
        /// <param name="lineNumber">Строка кода в имени файла, из которого было записано это сообщение</param>
        /// <returns>A task that represents the work queued to execute in the ThreadPool.</returns>
        /// <exception cref="ArgumentNullException">The action parameter was null.</exception>
        Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        /// object that represents that work.
        /// </summary>
        /// <param name="action">Работа, выполняемая асинхронно</param>
        /// <param name="origin">Метод/функция, в которой было зарегистрировано это сообщение</param>
        /// <param name="filePath">Имя файла кода, из которого было записано это сообщение</param>
        /// <param name="lineNumber">Строка кода в имени файла, из которого было записано это сообщение</param>
        /// <remarks>
        ///     The passed in Task cannot be awaited as it is to be run and forgotten.
        ///     Any errors thrown will get logged to the ILogger in the DI provider
        ///     and then swallowed and not re-thrown to the caller thread
        /// </remarks>
        /// <returns>A task that represents the work queued to execute in the ThreadPool.</returns>
        /// <exception cref="ArgumentNullException">The action parameter was null.</exception>
        void RunAndForget(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
    }
}
