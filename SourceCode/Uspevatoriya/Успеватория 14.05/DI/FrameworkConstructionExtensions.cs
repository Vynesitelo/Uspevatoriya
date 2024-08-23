using Dna;
using Microsoft.Extensions.DependencyInjection;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Расширение для класса <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Внедряет представления моделей, необходимые для Успеватории
        /// </summary>
        /// <param name="construction">Конструкция фреймворка</param>
        /// <returns>Конструкция фреймворка для цепочки вызовов</returns>
        public static FrameworkConstruction AddUspViewModels(this FrameworkConstruction construction)
        {
            // Привязка к единственному экземпляру представления модели приложения
            construction.Services.AddSingleton<ApplicationViewModel>();

            // Привязка к единственному экземпляру представления модели настроек
            construction.Services.AddSingleton<SettingsViewModel>();

            // Возвращение конструкции фреймворка для цепочки вызовов
            return construction;
        }
        /// <summary>
        /// Внедряет необходимые службы клиентского приложения
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddUspClientServices(this FrameworkConstruction construction)
        {

            //// Добавляем наш диспетчер задач
            construction.Services.AddTransient<ITaskManager, BaseTaskManager>();

            // BiПривязать менеджер пользовательского интерфейса
            construction.Services.AddTransient<IUIManager, UIManager>();

            // Вернуть конструкцию для цепочки
            return construction;
        }
        /// <summary>
        /// Внедрение базы данных в di контейнер
        /// </summary>
        /// <param name="construction">Конструкция фреймворка</param>
        /// <returns>Конструкция фреймворка для цепочки вызовов</returns>
        public static FrameworkConstruction AddRepositories(this FrameworkConstruction construction)
        {
            construction.Services.AddScoped<IRepository<AcademicPerfomance>, Repository<AcademicPerfomance>>();
            construction.Services.AddScoped<IRepository<Cours>, Repository<Cours>>();
            construction.Services.AddScoped<IRepository<Role>, Repository<Role>>();
            construction.Services.AddScoped<IRepository<User>, Repository<User>>();
            construction.Services.AddScoped<IRepository<CourseStudent>, Repository<CourseStudent>>();
            construction.Services.AddScoped<IRepository<CourseName>, Repository<CourseName>>();
            construction.Services.AddScoped<IRepository<Lesson>, Repository<Lesson>>();
            construction.Services.AddScoped<IRepository<ParentsChild>, Repository<ParentsChild>>();
            return construction;
        }
    }
}
