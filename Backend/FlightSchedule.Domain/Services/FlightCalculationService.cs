using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Shared;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Domain.Services.Exceptions;

namespace FlightSchedule.Domain.Services
{
    public class FlightCalculationService : IFlightCalculationService
    {
        public List<Flight> Calculate(ReserveSchedule schedule)
        {
            var specificDays = GetSpecificDaysInSchedule(schedule);

            var flights = GetFlightsInTheSpecificPeriod(schedule, specificDays);

            GuardAgianstNoFlightInSpecificPeriod(flights);

            return flights;
        }
        private static IEnumerable<DateTime> GetSpecificDaysInSchedule(ReserveSchedule schedule)
        {
            return schedule.StartReserveDate
                .SpecificDays(schedule.EndReserveDate,
                    schedule.WeeklyTimetable
                        .Select(a => a.DayOfWeek).ToArray());
        }
        private static List<Flight> GetFlightsInTheSpecificPeriod(ReserveSchedule schedule, IEnumerable<DateTime> specificDays)
        {
            //TODO : is LINQ better? -sohrab

            List<Flight> flightsInTheSpecificPeriod = new List<Flight>();
            foreach (var specificDay in specificDays)
            {
                WeeklyTimetable dayOfWeekInReserves = FindDayInWeek(schedule, specificDay);

                if (HasFlightInDay(dayOfWeekInReserves))
                {
                    var departDate = CalculateDepartDate(specificDay, dayOfWeekInReserves);
                    flightsInTheSpecificPeriod.Add(new Flight(departDate, schedule.Aircraft, schedule.FlightNo, schedule.Route));
                }
            }

            return flightsInTheSpecificPeriod;
        }

        private static WeeklyTimetable FindDayInWeek(ReserveSchedule schedule, DateTime dateTime)
        {
            return schedule.WeeklyTimetable.FirstOrDefault(a => a.DayOfWeek == dateTime.DayOfWeek);
        }

        private static bool HasFlightInDay(WeeklyTimetable dayOfWeekInReserves)
        {
            return dayOfWeekInReserves != null;
        }
        private static DateTime CalculateDepartDate(DateTime dateTime, WeeklyTimetable dayOfWeekInReserves)
        {
            var departDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            departDate = departDate.Add(dayOfWeekInReserves.DepartTime);
            return departDate;
        }

        private static void GuardAgianstNoFlightInSpecificPeriod(List<Flight> flights)
        {
            if (!flights.Any())
                throw new ThereAreNoFlightsInTheSpecifiedPeriodException();
        }
    }
}