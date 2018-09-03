using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Services;
using FlightSchedule.Domain.Shared;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Application.Contracts.DataTransferObjects;

namespace FlightSchedule.Application.Tests.Utils
{
    public class FlightServiceBuilder
    {
        public ReserveScheduleDto ReserveScheduleDto { get; set; }
        public IFlightCalculationService FlightsOfReservedScheduleMoq { get; set; }
        public List<Flight> DesiredNumberOfFlightsInListFormatForReservedSchedule { get;private set; }
        public IFlightRepository FlightRepositoryMoq { get;private set; }
        public FlightService FlightService { get; set; }

        public FlightServiceBuilder()
        {
            FlightsOfReservedScheduleMoq = Substitute.For<IFlightCalculationService>();
            FlightRepositoryMoq = Substitute.For<IFlightRepository>();
            ReserveScheduleDto = new ReserveScheduleDtoTestBuilder().Build();
            DesiredNumberOfFlightsInListFormatForReservedSchedule = new FlightsTestListBuilder().GetSomeFlights(1).ToList();
            FlightService = new FlightService(FlightRepositoryMoq, FlightsOfReservedScheduleMoq);
        }

        public FlightServiceBuilder GenerateAndKeepDesiredNumberOfFlightsInListFormat(int numberOfFlights)
        {
            DesiredNumberOfFlightsInListFormatForReservedSchedule = new FlightsTestListBuilder().GetSomeFlights(numberOfFlights).ToList();
            return this;
        } 

        public void GenerateFlightsBasedOnReserveScheduleDtoInListMoq()
        {
            SetFlightsOfReservedScheduleMoq();

            FlightService.GenerateFlights(ReserveScheduleDto);
        }

        private void SetFlightsOfReservedScheduleMoq()
        {
            FlightsOfReservedScheduleMoq
                            .Calculate(Arg.Any<ReserveSchedule>())
                            .Returns(DesiredNumberOfFlightsInListFormatForReservedSchedule);
        }
    }
}
