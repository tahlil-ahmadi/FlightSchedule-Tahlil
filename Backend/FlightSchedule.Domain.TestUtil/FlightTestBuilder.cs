using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model;
using Framework.Core.Clock;

namespace FlightSchedule.Domain.TestUtil
{
    public class FlightTestBuilder
    {
        public DateTime DepartDate { get; private set; }
        public string Aircraft { get; private set; }
        public string FlightNo { get; private set; }
        public Route Route { get; private set; }

        public FlightTestBuilder()
        {
            DepartDate = TravelTo.SomeFutureTime();
            Aircraft = "AIRBUS";
            FlightNo = "2020";
            Route = new RouteTestBuilder().Build();
        }

        public FlightTestBuilder WithDepartDate(DateTime departDate)
        {
            DepartDate = departDate;
            return this;
        }

        public FlightTestBuilder WithAircraft(string aircraft)
        {
            Aircraft = aircraft;
            return this;
        }

        public FlightTestBuilder WithFlightNo(string flightNo)
        {
            FlightNo = flightNo;
            return this;
        }

        public FlightTestBuilder WithRoute(Route route)
        {
            Route = route;
            return this;
        }

        public Flight Build()
        {
            return new Flight(DepartDate, Aircraft, FlightNo, Route);
        }
    }
}
