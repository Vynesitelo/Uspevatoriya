using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Успеватория
{
    /// <summary>
    /// Логика взаимодействия для TextEntryControl.xaml
    /// </summary>
    public partial class TextEntryControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// label с контролом
        /// </summary>
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        // Использование свойств зависимости как резервное хранилище для LabelWidth
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public TextEntryControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Callbacks

        /// <summary>
        /// Вызывается, когда ширина лейбла изменилась
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                // Установите ширину определения столбца на новое значение

                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }

#pragma warning disable CS0168
            catch (Exception ex)
#pragma warning restore CS0168
            {
                // Сообщите разработчику о потенциальной проблеме
                Debugger.Break();

                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
    }
}
