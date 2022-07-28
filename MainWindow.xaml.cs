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
using JsonInNET;

namespace CzasPracy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filePath = @"C:\Users\user\source\repos\CzasPracy\data.json";

        public MainWindow()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            ///// obsluga widoku 8h pracy
            cb8hours.IsChecked = true;
            txtLeaveTimeHour.IsEnabled = false;
            txtLeaveTimeMinute.IsEnabled = false;

            ///// Do implementacji
            ///
            btnDelegat.IsEnabled = false;
            


        }

        private void cb8hours_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cb8hours.IsChecked)
            {
                txtLeaveTimeHour.IsEnabled = false;
                txtLeaveTimeMinute.IsEnabled = false;
            }
            else
            {
                txtLeaveTimeHour.IsEnabled = true;
                txtLeaveTimeMinute.IsEnabled = true;
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cb8hours.IsChecked)
            {
                Day day = new Day(selectedDay(),
                    int.Parse(txtComeTimeHour.Text),
                    int.Parse(txtComeTimeMinute.Text),
                    int.Parse(txtComeTimeHour.Text)+8,
                    int.Parse(txtComeTimeMinute.Text),
                    (bool)cbSaturday.IsChecked,
                    (bool)cbSunday.IsChecked);

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

                List<Day> days = new List<Day>();
                days.Add(day);

                //lblDebug.Content = day.ToString();

                JsonFileUtils.PrettyWrite(days, filePath);
            }
            else
            {
                Day day = new Day(selectedDay(), 
                    int.Parse(txtComeTimeHour.Text),
                    int.Parse(txtComeTimeMinute.Text),
                    int.Parse(txtLeaveTimeHour.Text),
                    int.Parse(txtLeaveTimeMinute.Text),
                    (bool)cbSaturday.IsChecked,
                    (bool)cbSunday.IsChecked);
                
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

    }
}
