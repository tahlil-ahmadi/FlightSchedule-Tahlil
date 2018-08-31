using System.Collections.Generic;
using System.Web.Http;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Application.Contracts.DataTransferObjects;

namespace FlightSchedule.RestApi.Controllers
{
    public class FlightsController : ApiController
    {
        private readonly IFlightService _service;
        public FlightsController(IFlightService service)
        {
            _service = service;
        }
        public void Post(ReserveScheduleDto schedule)
        {
            _service.GenerateFlights(schedule);
        }

        public List<FlightDto> Get(string flightNumber)
        {
            return _service.GetFlightsByNumber(flightNumber);
        }
    }
}