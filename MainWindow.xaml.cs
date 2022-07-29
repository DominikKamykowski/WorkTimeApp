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


        /// <summary>
        /// Metoda obsługująca inicjalizację elementów w GUI
        /// </summary>
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

        /// <summary>
        /// Metoda obsługująca naciśnięcie Checkbox'a, który odpowiada za opcję domyslnych 8 godzin pracy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Metoda obsługująca naciśnięcie przycisku "Zatwierdź".
        /// Sprawdza czy użytkownik zaznaczył opcję "8 godzin",
        /// tworzy obiekt klasy Day z atrybutami pobranymi z GUI,
        /// wysyła utworzony obiekt do klasy, która zapisuje obiekt do pliku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda, która zwraca zaznaczony na kalendarzu dzień.
        /// </summary>
        /// <returns>Aktualnie zaznaczony dzień na kalendarzu</returns>
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


        /// <summary>
        /// Metoda obsługująca dodanie obiektu klasy "Day" do pliku.
        /// 
        /// </summary>
        /// <param name="day">Obiekt klasy "Day"</param>
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


        /// <summary>
        /// Metoda obsługująca funkcję sprawdzenia tego, czy istnieje w liście konkretny obiekt klasy "Day".
        /// </summary>
        /// <param name="day">Poszukiwany obiekt klasy "Day"</param>
        /// <param name="list">Przeszukiwana lista obiektów klasy "Day"</param>
        /// <returns>True - obiekt istnieje w liście, False - obiekt nie znajduje się w liście.</returns>
        private bool CheckIfExist(Day day, List<Day> list)
        {
            var matches = list.Where(x => (x.Date.Month == day.Date.Month) && (x.Date.Day == day.Date.Day));
            if (matches.Count() == 0) return false;
            else return true;
        }
    }
}

