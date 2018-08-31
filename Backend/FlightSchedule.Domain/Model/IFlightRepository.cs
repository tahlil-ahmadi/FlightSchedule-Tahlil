using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Model
{
    public interface IFlightRepository
    {
        Flight GetById(long id);
        void Save(Flight flight);
        List<Flight> GetByFlightNumber(string flightNumber);
    }
}
