using System;
using System.Collections.Generic;
using System.Text;

namespace CzasPracy
{
    class Day
    {
        /// <summary>
        /// Konstruktor klasy "Day"
        /// </summary>
        /// <param name="date">Data</param>
        /// <param name="comeTimeHour">Godzina wejścia do pracy</param>
        /// <param name="comeTimeMinute">Minuta wejścia do pracy</param>
        /// <param name="leaveTimeHour">Godzina wyjścia z pracy</param>
        /// <param name="leaveTimeMinute">Minuta wyjścia z pracy</param>
        /// <param name="isSaturday">Bool - czy jest to sobota?</param>
        /// <param name="isSunday">Bool - czy jest to niedziela?</param>
        public Day(
            DateTime date, 
            int comeTimeHour, 
            int comeTimeMinute, 
            int leaveTimeHour, 
            int leaveTimeMinute, 
            bool isSaturday, 
            bool isSunday)
        {
            Date = date;
            ComeTimeHour = comeTimeHour;
            ComeTimeMinute = comeTimeMinute;
            LeaveTimeHour = leaveTimeHour;
            LeaveTimeMinute = leaveTimeMinute;
            this.isSaturday = isSaturday;
            this.isSunday = isSunday;
        }

        public DateTime Date { get; set; }

        public int ComeTimeHour { get; set; }
        public int ComeTimeMinute { get; set; }
        public int LeaveTimeHour { get; set; }
        public int LeaveTimeMinute { get; set; }

        public bool isSaturday { get; set; }

        public bool isSunday { get; set; }


        /// <summary>
        /// Metoda obsługująca zwrócenie aktualnej daty.
        /// </summary>
        /// <returns>Aktualna data obiektu</returns>
        public DateTime returnDay()
        {
            DateTime dateTime = new DateTime(
                Date.Year,
                Date.Month,
                Date.Day,
                ComeTimeHour,
                ComeTimeMinute,
                0);

            return dateTime;
            }


        /// <summary>
        /// Metoda obsługująca zwrócenie właściwości klasy.
        /// Zwraca w formie string, czy obiekt posiada właściwość isSaturday lub isSunday.
        /// </summary>
        /// <returns>Informacja czy jest to dzień weekendu</returns>
            public string returnIsWeekend()
        {
            if (isSaturday) { return "Sobota"; }
            if (isSunday) { return "Niedziela"; }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// Metoda obsługująca funkcję zwrócenia obiektu w dormie string.
        /// </summary>
        /// <returns>Właściwości obiektu "Day" w formie jednego string</returns>
        public override string ToString()
        {
            string returnString = "Data: " + Date.Date;


            returnString += " Godzina wejścia: " + ComeTimeHour + ":" + ComeTimeMinute;
            returnString += " Godzina wyjścia: " + LeaveTimeHour + ":" + LeaveTimeMinute;
            returnString += " " + returnIsWeekend();


            return returnString;
        }
        
    }
}
