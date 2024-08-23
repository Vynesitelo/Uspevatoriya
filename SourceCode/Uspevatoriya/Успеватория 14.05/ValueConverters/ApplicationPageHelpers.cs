using System.Diagnostics;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Преобразует <see cref="ApplicationPage"/> в фактическую страницу/представление
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Принимает <see cref="ApplicationPage"/> и, при необходимости, модель представления и создает желаемую страницу
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            // Найти соответствующую страницу
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Table:
                    return new GroupPage(viewModel as GroupPageViewModel);
                case ApplicationPage.User:
                    return new UserPage(viewModel as UserPageViewModel);
                case ApplicationPage.Schedule:
                    return new SchedulePage(viewModel as SchedulePageViewModel);
                case ApplicationPage.EditGroup:
                    return new GroupEditPage(viewModel as GroupEditPageViewModel);
                case ApplicationPage.StartPage:
                    return new StartPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Преобразует   a <see cref="BasePage"/> в конкретную <see cref="ApplicationPage"/> типа этой страницы
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            // Найти страницу приложения, соответствующую базовой странице
            if (page is GroupPage)
                return ApplicationPage.Table;

            if (page is LoginPage)
                return ApplicationPage.Login;
            if (page is UserPage)
                return ApplicationPage.User;
            if (page is SchedulePage)
                return ApplicationPage.Schedule;
            if (page is GroupEditPage)
                return ApplicationPage.EditGroup;
            if (page is StartPage)
                return ApplicationPage.StartPage;
            // Остановка отладчика, если страница не найдена
            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
