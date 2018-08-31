using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Persistence.EF.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightScheduleContext _context;
        public FlightRepository(FlightScheduleContext context)
        {
            this._context = context;
        }

        public Flight GetById(long id)
        {
            return _context.Flights.First(a => a.Id == id);
        }

        public void Save(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges(); //TODO:remove this & move to UOW
        }

        public List<Flight> GetByFlightNumber(string flightNumber)
        {
            return _context.Flights.Where(a => a.FlightNo == flightNumber).ToList();
        }
    }
}
