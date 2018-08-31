using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Model
{
    public class Flight
    {
        public long Id { get; set; }
        public DateTime DepartDate { get; set; }
        public string AirCraft { get; set; }
        public string FlightNo { get; set; }
        public Route Route { get; set; }

        protected Flight() { }
        public Flight(DateTime departDate, string aircraft, string flightNo, Route route)
        {
            this.DepartDate = departDate;
            this.AirCraft = aircraft;
            this.FlightNo = flightNo;
            this.Route = route;
        }

    }
}
