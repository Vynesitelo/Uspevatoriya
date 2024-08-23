using Dna;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using static Dna.FrameworkDI;

namespace Успеватория.Ядро
{
    /// <summary>
    /// Handles anything to do with Tasks
    /// </summary>
    public class BaseTaskManager : ITaskManager
    {
        #region Task Methods

        public async Task Run(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                await Task.Run(function);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }

        public async void RunAndForget(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(function, origin, filePath, lineNumber);
            }
            catch { }
        }

        public async Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                return await Task.Run(function);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                return await Task.Run(function);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }

        public async Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }

        public async void RunAndForget(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(function, origin, filePath, lineNumber);
            }
            catch { }
        }

        public async Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                await Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }
        public async void RunAndForget(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(action, origin, filePath, lineNumber);
            }
            catch { }
        }

        public async Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                // Попытка запуска
                await Task.Run(action);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Logger.LogErrorSource(ex.ToString(), origin: origin, filePath: filePath, lineNumber: lineNumber);

                throw;
            }
        }

        public async void RunAndForget(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Run(action, origin, filePath, lineNumber);
            }
            catch { }
        }

        #endregion
    }
}
