using System.Collections.Generic;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Shared;

namespace FlightSchedule.Domain.Services
{
    public interface IFlightCalculationService
    {
        List<Flight> Calculate(ReserveSchedule schedule);
    }
}