using Dna;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Класс для работы с внедрением зависимостей (Depedency injection)
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// Получаем экземпляры классов
        /// </summary>
        #region ExampleClass

        public static ApplicationViewModel ViewModelApplication => Framework.Service<ApplicationViewModel>();

        public static SettingsViewModel ViewModelSettings => Framework.Service<SettingsViewModel>();
        #endregion

        /// <summary>
        /// Получаем экземпляры интерфейсов
        /// </summary>
        #region ExampleInterfaces

        public static IUIManager UI => Framework.Service<IUIManager>();
        public static IRepository<Role> RepositoryRole => Framework.Service<IRepository<Role>>();
        public static IRepository<AcademicPerfomance> RepositoryAcademicPerfomance => Framework.Service<IRepository<AcademicPerfomance>>();
        public static IRepository<Cours> RepositoryCourse => Framework.Service<IRepository<Cours>>();
        public static IRepository<User> RepositoryUser => Framework.Service<IRepository<User>>();
        public static IRepository<CourseStudent> RepositoryCourseStudent => Framework.Service<IRepository<CourseStudent>>();
        public static IRepository<CourseName> RepositoryCourseName => Framework.Service<IRepository<CourseName>>();
        public static IRepository<Lesson> RepositoryLesson => Framework.Service<IRepository<Lesson>>();
        public static IRepository<ParentsChild> RepositoryParentsChild => Framework.Service<IRepository<ParentsChild>>();
        #endregion

    }
}
