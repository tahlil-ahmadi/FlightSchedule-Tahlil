using System;
using System.Collections.Generic;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Services;
using FlightSchedule.Domain.Services.Exceptions;
using FlightSchedule.Domain.Shared;
using FlightSchedule.Domain.TestUtil;
using FluentAssertions;
using Framework.Core.Clock;
using Xunit;

namespace FlightSchedule.Domain.Tests.Unit.Services
{
    public class FlightCalculationServiceTests
    {
        [Fact]
        public void Calculate_Should_Throw_Exception_When_There_Are_No_Flights_In_The_Specified_Period_Of_Time()
        {
            //Arrange
            var reserveSchedule = new ReserveScheduleTestBuilder().WithStartReserveDate(TravelTo.SomeFutureTime())
                .WithEndReserveDate(TravelTo.SomeFutureTime()).Build();

            //Act
            Action action = () => new FlightCalculationService().Calculate(reserveSchedule);

            //Assert
            action.Should().Throw<ThereAreNoFlightsInTheSpecifiedPeriodException>();
        }

        [Fact]
        public void Calculate_should_calculate_flights_based_on_weekly_plan()
        {
            //Arrange
            var route = new Route("IKA", "SJC");
            var reserveSchedule = CreateReserveSchedule(route);
            var expectedFlights = CreateExpectedFlights(route);

            //Act
            var actualFlights = new FlightCalculationService().Calculate(reserveSchedule);

            //Assert
            actualFlights.Should().BeEquivalentTo(expectedFlights);
        }

        private static ReserveSchedule CreateReserveSchedule(Route route)
        {
            var startReserveDate = new DateTime(2018, 03, 17);
            var endReserveDate = new DateTime(2018, 04, 1);
            var weeklyTimetable = CreateWeeklyTimetable();

            return new ReserveScheduleTestBuilder().WithRoute(route).WithStartReserveDate(startReserveDate)
                .WithEndReserveDate(endReserveDate).WithWeeklyTimetable(weeklyTimetable).Build();
        }

        private static List<WeeklyTimetable> CreateWeeklyTimetable()
        {
            return new List<WeeklyTimetable>()
            {
                new WeeklyTimetable(DayOfWeek.Monday, new TimeSpan(8, 0, 0)),
                new WeeklyTimetable(DayOfWeek.Wednesday, new TimeSpan(15, 0, 0))
            };
        }

        private static IEnumerable<Flight> CreateExpectedFlights(Route route)
        {
            var flightBuilder = new FlightTestBuilder().WithRoute(route);
            return new List<Flight>()
            {
                flightBuilder.WithDepartDate(new DateTime(2018, 3, 19, 8, 0, 0)).Build(),
                flightBuilder.WithDepartDate(new DateTime(2018, 3, 21, 15, 0, 0)).Build(),
                flightBuilder.WithDepartDate(new DateTime(2018, 3, 26, 8, 0, 0)).Build(),
                flightBuilder.WithDepartDate(new DateTime(2018, 3, 28, 15, 0, 0)).Build()
            };
        }
    }
}