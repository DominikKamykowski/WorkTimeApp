using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CzasPracy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            ///// obsluga widoku 8h pracy
            cb8hours.IsChecked = true;
            txtLeaveTime.IsEnabled = false;

            ///// Do implementacji
            ///
            btnDelegat.IsEnabled = false;
            


        }

        private void cb8hours_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cb8hours.IsChecked)
            {
                txtLeaveTime.IsEnabled = false;
            }
            else
            {
                txtLeaveTime.IsEnabled = true;
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cb8hours.IsChecked)
            {
                var timeLeave = convertToTime(txtComeTime.Text).AddHours(8);
                Day day = new Day(selectedDay(), convertToTime(txtComeTime.Text), timeLeave);
                List<Day> days = new List<Day>();
                days.Add(day);

                if((bool)cbSaturday.IsChecked || (bool)cbSunday.IsChecked)
                {
                    if ((bool)cbSaturday.IsChecked)
                    {
                        day.isSaturday = true;
                    }
                    else
                    {
                        day.isSunday = true;
                    }
                }

                lblDebug.Content = day.ToString();
            }
            else
            {
                Day day = new Day(selectedDay(), convertToTime(txtComeTime.Text), convertToTime(txtLeaveTime.Text));
                
                lblDebug.Content = day.ToString();
            }
        }

        private DateTime selectedDay()
        {
            if (calData.SelectedDate.HasValue)
            {
                DateTime date = (DateTime)calData.SelectedDate;
                return date;
            }
            else
            {
                return DateTime.Now;
            }
        }

        private DateTime convertToTime(string text)
        {
            DateTime dt = DateTime.Parse(text);
            
            return dt;
        }
    }
}
