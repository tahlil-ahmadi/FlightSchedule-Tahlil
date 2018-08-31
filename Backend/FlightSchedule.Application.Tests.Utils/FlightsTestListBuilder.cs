using System.Collections.Generic;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.TestUtil;

namespace FlightSchedule.Application.Tests.Utils
{
    public class FlightsTestListBuilder
    {
        public IEnumerable<Flight> GetSomeFlights(long numberOfFlights)
        {
            var builder = new FlightTestBuilder();
            for (var i = 0; i < numberOfFlights; i++)
            {
                yield return builder.Build();
            }
        }
    }
}