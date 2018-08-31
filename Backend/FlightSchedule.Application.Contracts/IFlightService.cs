using System.Collections.Generic;
using FlightSchedule.Application.Contracts.DataTransferObjects;

namespace FlightSchedule.Application.Contracts
{
    public interface IFlightService
    {
        void GenerateFlights(ReserveScheduleDto reserveScheduleDto);
        List<FlightDto> GetFlightsByNumber(string flightNumber);
    }
}