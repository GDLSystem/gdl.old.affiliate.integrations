using System;
using System.Globalization;
using FluentDate;
using FluentDateTime;

namespace Gdl.Affiliate.Integrations.Core.Helpers
{
    public static class DateTimeHelper
    {
        // This presumes that weeks start with Monday.
        public static int GetWeekOfYear(DateTime time)
        {
            // Return the week of our adjusted day
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        }

        public static DateTime GetFirstDateOfWeek(this DateTime dateTime)
        {
            // First Date of week is Monday
            if (dateTime.DayOfWeek == DayOfWeek.Monday)
            {
                return dateTime;
            }
            return dateTime.Previous(DayOfWeek.Monday);
        }

        public static DateTime GetPreviousMonth(this DateTime dateTime)
        {
            return dateTime.PreviousMonth();
        }

        public static DateTime GetLastDateOfWeek(this DateTime dateTime)
        {
            // Last Date of week is Sunday
            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return dateTime;
            }
            return dateTime.Next(DayOfWeek.Sunday);
        }
        
        public static DateTime RandomDay(DateTime start, DateTime end)
        {
            Random gen = new Random();
            int range = (end - start).Days;           
            return start.AddDays(gen.Next(range));
        }
    }
}