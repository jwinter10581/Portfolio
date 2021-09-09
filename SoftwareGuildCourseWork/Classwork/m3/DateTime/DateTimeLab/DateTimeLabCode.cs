using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            DateTime dateToday = DateTime.Today;

            return dateToday;            
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            DateTime dateInput = new DateTime(year, month, day);
            string shortDate = "";

            if (month < 10)
            {
                if (day < 10)
                {
                    shortDate = dateInput.ToString("M/d/yy");
                }
                else
                {
                    shortDate = dateInput.ToString("M/dd/yy");
                }
            }
            else
            {
                shortDate = dateInput.ToString("MM/dd/yy");
            }

            return shortDate;
        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            DateTime dateString = DateTime.Parse(date);

            return dateString;
        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            DateTime dateInput = DateTime.Parse(date);

            string dateOutput = "";

            dateOutput = dateInput.ToString("MM.dd.yyyy hh:mm tt");

            return dateOutput;
        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            DateTime currentDate = DateTime.Parse(date);

            DateTime futureDate = currentDate.AddMonths(6);

            string sixMonthsLater = "";

            if (futureDate.Day < 10)
            {
                sixMonthsLater = futureDate.ToString("MMMM d, yyyy");
            }
            else
            {
                sixMonthsLater = futureDate.ToString("MMMM dd, yyyy");
            }

            return sixMonthsLater;
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            DateTime currentDate = DateTime.Parse(date);

            DateTime futureDate = currentDate.AddDays(-30);

            string thirtyDaysEarlier = "";

            if (futureDate.Day < 10)
            {
                thirtyDaysEarlier = futureDate.ToString("MMMM d, yyyy");
            }
            else
            {
                thirtyDaysEarlier = futureDate.ToString("MMMM dd, yyyy");
            }

            return thirtyDaysEarlier;
        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            DateTime[] nextWednesdays = new DateTime[count];
            DateTime currentDate = DateTime.Parse(startDate);
            DateTime tempDate = currentDate;

            int currentIndex = 0;

            do
            {
                if (tempDate.DayOfWeek == DayOfWeek.Wednesday)
                {
                    nextWednesdays[currentIndex] = tempDate;
                    currentIndex++;
                    tempDate = tempDate.AddDays(7);  // Skip a week at a time for speed
                }
                else
                {
                    tempDate = tempDate.AddDays(1);  // Add a day at a time until we get a Wednesday
                }
            } while (currentIndex < count);

            return nextWednesdays;
        }
    }
}
