using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Успеватория
{
    /// <summary>
    /// Помощник для раскадровки <see cref="StoryBoard"/>
    /// </summary>
    public static class StoryboardHelpers
    {
        #region Sliding To/From Left

        /// <summary>
        /// Добавляет слайд из левой анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние слева от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Добавляет слайд в левую анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние слева от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        #endregion

        #region Sliding To/From Right

        /// <summary>
        /// Добавляет слайд справа анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние справа от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Добавляет слайд вправ анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние справа от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        #endregion

        #region Sliding To/From Top

        /// <summary>
        /// Добавляет слайд из верхней анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние справа от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideFromTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Добавляет слайд вверх анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние сверху от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideToTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        #endregion

        #region Sliding To/From Bottom

        /// <summary>
        /// Добавляет слайд снизу анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние снизу от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideFromBottom(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Добавляет слайд вниз анимации в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию.</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="offset">Расстояние снизу от начала</param>
        /// <param name="decelerationRatio">Скорость замедления</param>
        /// <param name="keepMargin">Сохранять ли элемент одинаковой ширины во время анимации</param>
        public static void AddSlideToBottom(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Создайте анимацию поля справа 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                DecelerationRatio = decelerationRatio
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        #endregion

        #region Fade In/Out

        /// <summary>
        /// Добавляет плавную анимацию в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds, bool from = false)
        {
            // Создайте анимацию поля справа
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 1,
            };

            // Анимировать по запросу
            if (from)
                animation.From = 0;

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Добавляет анимацию затухания в раскадровку
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // Создайте анимацию поля справа
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 0,
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }

        #endregion


        /// <summary>
        /// Добавляет в раскадровку анимацию прокрутки справа налево
        /// </summary>
        /// <param name="storyboard">Раскадровка, к которой нужно добавить анимацию</param>
        /// <param name="seconds">Время, которое займет анимация</param>
        /// <param name="contentOffset">Размер внутреннего содержимого, чтобы начать выделение, как только это содержимое прокрутится вне поля зрения</param>
        /// <param name="offset">Смещение родительского элемента для прокрутки внутри</param>
        public static void AddMarquee(this Storyboard storyboard, float seconds, double offset = 0, double contentOffset = 0)
        {
            // Создайте анимацию поля справа налево
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(-contentOffset, 0, contentOffset, 0),
                RepeatBehavior = RepeatBehavior.Forever
            };

            // Задайте имя целевого свойства
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Добавьте это в раскадровку
            storyboard.Children.Add(animation);
        }
    }
}
