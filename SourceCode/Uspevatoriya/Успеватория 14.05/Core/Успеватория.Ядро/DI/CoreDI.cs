using Dna;

namespace Успеватория.Ядро
{
    /// <summary>
    /// Яддро DI
    /// </summary>
    public static class CoreDI
    {
        public static ITaskManager TaskManager => Framework.Service<ITaskManager>();
    }
}
