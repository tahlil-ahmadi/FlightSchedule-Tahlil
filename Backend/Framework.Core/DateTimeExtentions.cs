using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core
{
    public static class DateTimeExtentions
    {
        /// <summary>
        /// EachDay will retuen a list of dates that are between fromDate and toDate
        /// </summary>
        /// <param name="fromDate">Start Date to itterate through dates</param>
        /// <param name="toDate">End Date to itterate through dates</param>
        /// <returns>List of Dates between fromDate and toDate</returns>
        public static IEnumerable<DateTime> EachDay(this DateTime fromDate, DateTime toDate)
        {
            return ItterrateThroughDateRange(fromDate, toDate);
        }

        /// <summary>
        /// SpecificDay will retuen a list of dates that are between fromDate and toDate and are in the days list
        /// </summary>
        /// <param name="fromDate">Start Date to itterate through dates</param>
        /// <param name="toDate">End Date to itterate through dates</param>
        /// <param name="days">List of days to return corresponding date</param>
        /// <returns>List of Dates between fromDate and toDate and are in days list</returns>
        public static IEnumerable<DateTime> SpecificDays(this DateTime fromDate, DateTime toDate, DayOfWeek[] days)
        {
            if (days != null)
            {
                for (var day = fromDate.Date; day.Date <= toDate.Date; day = day.AddDays(1))
                    if (days.Any(dayOfWeek => dayOfWeek.ToString() == day.DayOfWeek.ToString()))
                    {
                        yield return day;
                    }
            }
            else
            {
                foreach (var dateTime in ItterrateThroughDateRange(fromDate, toDate))
                    yield return dateTime;
            }
        }

        private static IEnumerable<DateTime> ItterrateThroughDateRange(DateTime fromDate, DateTime toDate)
        {
            for (var day = fromDate.Date; day.Date <= toDate.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
