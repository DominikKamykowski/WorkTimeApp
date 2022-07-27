using System;
using System.Collections.Generic;
using System.Text;

namespace CzasPracy
{
    class Day
    {
        public Day(DateTime date, 
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

        private DateTime Date { get; set; }
        
        private int ComeTimeHour { get; set; }
        private int ComeTimeMinute { get; set; }
        private int LeaveTimeHour { get; set; }
        private int LeaveTimeMinute { get; set; }

        public bool isSaturday { get; set; }

        public bool isSunday { get; set; }

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

        public string returnIsWeekend()
        {
            if (isSaturday) { return "Sobota"; }
            if (isSunday) { return "Niedziela"; }
            else
            {
                return "";
            }
        }

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
