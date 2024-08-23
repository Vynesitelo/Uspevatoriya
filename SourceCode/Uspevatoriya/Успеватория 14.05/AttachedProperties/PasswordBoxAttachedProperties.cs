using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{
    /// <summary>
    /// Мониторинг пароля свойств <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Получение вызова
            var passwordBox = sender as PasswordBox;

            //Создание пасворд бокса
            if (passwordBox == null)
                return;

            //Удаление события
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            //если вызов монитора произошёл, начинается прослушка
            if ((bool)e.NewValue)
            {
                //Значение по умолчанию
                HasTextProperty.SetValue(passwordBox);

                //Начало просмотра списка изменения пароля
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Вызов когда пароль меняет значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Установка значения
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }
    /// <summary>
    /// HasText attched свойство для ввода пароля <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Установка HasText основанного на вызове <see cref="PasswordBox"/> каждого текста
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}