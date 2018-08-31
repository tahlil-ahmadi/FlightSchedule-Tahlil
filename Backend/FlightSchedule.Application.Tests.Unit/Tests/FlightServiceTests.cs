using System;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using FlightSchedule.Application.Tests.Utils;
using FlightSchedule.Domain.Shared;
using NSubstitute;
using Xunit;

namespace FlightSchedule.Application.Tests.Unit.Tests
{
    public class FlightServiceTests
    {
        [Fact]
        public void GenerateFlights_should_calculate_flights_and_save_them()
        {
            //Arrange
            var flightServiceBuilder = new FlightServiceBuilder();
            flightServiceBuilder.GetSomeFlight(2);

            //Act
            flightServiceBuilder.GenerateFlights();
            var firstFlight = flightServiceBuilder.SomeFlightsForReservedSchedule[0];
            var secondFlight = flightServiceBuilder.SomeFlightsForReservedSchedule[1];

            //Assert
            flightServiceBuilder.FlightRepositoryProp.Received(1).Save(firstFlight);
            flightServiceBuilder.FlightRepositoryProp.Received(1).Save(secondFlight);
        }

    }
}