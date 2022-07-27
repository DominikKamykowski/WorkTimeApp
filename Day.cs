using System;
using System.Collections.Generic;
using System.Text;

namespace CzasPracy
{
    class Day
    {
        public Day(DateTime date, DateTime comeTime, DateTime leaveTime)
        {
            Date = date;
            ComeTime = comeTime;
            LeaveTime = leaveTime;
        }

        private DateTime Date { get; set; }
        
        private DateTime ComeTime { get; set; }
        private DateTime LeaveTime { get; set; }

        public bool isSaturday { get; set; }

        public bool isSunday { get; set; }

        public DateTime returnDay()
        {
            DateTime dateTime = new DateTime(
                Date.Year, 
                Date.Month, 
                Date.Day, 
                ComeTime.Hour, 
                ComeTime.Minute, 
                ComeTime.Second);

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

            

            returnString += " Godzina wejścia: " + ComeTime.ToString();
            returnString += " Godzina wyjścia: " + LeaveTime.ToString();
            returnString += " " + returnIsWeekend();


            return returnString;
        }
        
    }
}
