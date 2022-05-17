using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TimePickerControlApp.CustomControl
{
    /// <summary>
    /// Interaction logic for TimeControl.xaml
    /// </summary>
    public partial class TimeControl : UserControl
    {
        #region Constructor 
        public TimeControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Accessor 

        public static readonly DependencyProperty DateProperty =
        DependencyProperty.Register("MyTime", typeof(DateTime), typeof(TimeControl));

        public DateTime MyTime
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        #endregion

        #region Private Methods
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MyTime = DateTime.Parse(this.txtDatePicker.Text);
            }
            catch (FormatException)
            {
                MyTime = DateTime.MinValue;
            }
        }
        private void ListView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ListView lstView = sender as ListView;
            int index = 0;
            switch (e.Key)
            {
                case Key.Down:
                    {
                        ChangeSelection(3);
                        break;
                    }
                case Key.Up:
                    {
                        ChangeSelection(1);
                        break;
                    }
            }

            void ChangeSelection(int selectedIndex)
            {
                lstView.Focus();
                foreach (var a in lstView.ItemsSource)
                {
                    if (index == selectedIndex)
                    {
                        lstView.SelectedValue = a;
                        break;
                    }
                    index++;
                }
                e.Handled = true;
            }
        }
        #endregion
    }
}