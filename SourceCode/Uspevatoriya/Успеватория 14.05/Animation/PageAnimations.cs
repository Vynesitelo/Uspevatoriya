using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Успеватория
{
    /// <summary>
    /// Помощник анимирования страницы специфичным методом
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Слайд страницы вправо 
        /// </summary>
        /// <param name="page">Страницы</param>
        /// <param name="seconds">Время анимации</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            //создание новой раскадровки
            var sb = new Storyboard();

            //Добавление слайда из нужной анимации
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //Добавление градиента в анимации
            sb.AddFadeIn(seconds);

            //Запуск анимации
            sb.Begin(page);

            //Делаем страницу видимой
            page.Visibility = Visibility.Visible;

            //Ждём конца
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Слайд страницы влево 
        /// </summary>
        /// <param name="page">Страницы</param>
        /// <param name="seconds">Время анимации</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float seconds)
        {
            //создание новой раскадровки
            var sb = new Storyboard();

            //Добавление слайда из нужной анимации
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Добавление градиента в анимации
            sb.AddFadeOut(seconds);

            //Запуск анимации
            sb.Begin(page);

            //Делаем страницу видимой
            page.Visibility = Visibility.Visible;

            //Ждём конца
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
