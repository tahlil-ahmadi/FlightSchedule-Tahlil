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
        public IFlightCalculationService FlightsOfReservedSchedule { get; set; }
        public List<Flight> SomeFlightsForReservedSchedule { get;private set; }
        public IFlightRepository FlightRepositoryProp { get;private set; }
        public FlightService FlightService { get; set; }

        public FlightServiceBuilder()
        {
            FlightsOfReservedSchedule = Substitute.For<IFlightCalculationService>();
            FlightRepositoryProp = Substitute.For<IFlightRepository>();
            ReserveScheduleDto = new ReserveScheduleDtoTestBuilder().Build();
            SomeFlightsForReservedSchedule = new FlightsTestListBuilder().GetSomeFlights(1).ToList();
            FlightService = new FlightService(FlightRepositoryProp, FlightsOfReservedSchedule);
        }

        public FlightServiceBuilder GetSomeFlight(int numberOfFlights)
        {
            SomeFlightsForReservedSchedule = new FlightsTestListBuilder().GetSomeFlights(numberOfFlights).ToList();
            return this;
        } 

        public void GenerateFlights()
        {
            SetFlightsOfReservedSchedule();

            FlightService.GenerateFlights(ReserveScheduleDto);
        }

        private void SetFlightsOfReservedSchedule()
        {
            FlightsOfReservedSchedule
                            .Calculate(Arg.Any<ReserveSchedule>())
                            .Returns(SomeFlightsForReservedSchedule);
        }
    }
}
