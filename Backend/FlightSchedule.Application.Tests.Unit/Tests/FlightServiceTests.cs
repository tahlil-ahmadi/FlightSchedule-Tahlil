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
            flightServiceBuilder.GenerateAndKeepDesiredNumberOfFlightsInListFormat(2);

            //Act
            flightServiceBuilder.GenerateFlightsBasedOnReserveScheduleDtoInListMoq();
            var firstFlightGeneratedByApi = flightServiceBuilder.DesiredNumberOfFlightsInListFormatForReservedSchedule[0];
            var secondFlightGeneratedByApi = flightServiceBuilder.DesiredNumberOfFlightsInListFormatForReservedSchedule[1];

            //Assert
            flightServiceBuilder.FlightRepositoryMoq.Received(1).Save(firstFlightGeneratedByApi);
            flightServiceBuilder.FlightRepositoryMoq.Received(1).Save(secondFlightGeneratedByApi);
        }

    }
}