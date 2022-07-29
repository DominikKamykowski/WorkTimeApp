using System;
using System.Collections.Generic;
using System.Windows;
using JsonInNET;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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
            txtLeaveTimeHour.IsEnabled = false;
            txtLeaveTimeMinute.IsEnabled = false;

            ///// Wiązanie DataGrid do listy dni

            dgDays.ItemsSource = JsonFileUtils.GetSortedList();

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
                Day day = new Day(
                    selectedDay(),
                    int.Parse(txtComeTimeHour.Text),
                    int.Parse(txtComeTimeMinute.Text),
                    int.Parse(txtComeTimeHour.Text) + 8,
                    int.Parse(txtComeTimeMinute.Text),
                    (bool)cbSaturday.IsChecked,
                    (bool)cbSunday.IsChecked);

                if ((bool)cbSaturday.IsChecked || (bool)cbSunday.IsChecked)
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

                AddToRegister(day);

            }
            else
            {
                Day day = new Day(
                    selectedDay(),
                    int.Parse(txtComeTimeHour.Text),
                    int.Parse(txtComeTimeMinute.Text),
                    int.Parse(txtLeaveTimeHour.Text),
                    int.Parse(txtLeaveTimeMinute.Text),
                    (bool)cbSaturday.IsChecked,
                    (bool)cbSunday.IsChecked);

                AddToRegister(day);
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

        private void AddToRegister(Day day)
        {
            var daysList = JsonFileUtils.Deserialize();

            if (daysList == null)
            {
                List<Day> list = new List<Day>();
                list.Add(day);
                JsonFileUtils.Serialize(list);
                
            }
            else
            {
                if (!CheckIfExist(day, daysList))
                {
                    daysList.Add(day);

                    JsonFileUtils.Serialize(daysList);
                }
                else
                {
                    MyMessageBox.ShowWarningMessageBox("Dzień jest już uzupełniony!");
                }

            }
        }

        private bool CheckIfExist(Day day, List<Day> list)
        {
            var matches = list.Where(x => (x.Date.Month == day.Date.Month) && (x.Date.Day == day.Date.Day));
            if (matches.Count() == 0) return false;
            else return true;
        }
    }
}

