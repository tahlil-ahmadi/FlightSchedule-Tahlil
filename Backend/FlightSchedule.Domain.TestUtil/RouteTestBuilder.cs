using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Domain.TestUtil
{
    public class RouteTestBuilder
    {
        public string Origin { get; private set; }
        public string Destination { get; private set; }

        public RouteTestBuilder()
        {
            Origin = "IKA";
            Destination = "DXB";
        }
        public RouteTestBuilder WithOrigin(string origin)
        {
            Origin = origin;
            return this;
        }

        public RouteTestBuilder WithDestination(string destination)
        {
            Destination = destination;
            return this;
        }

        public Route Build()
        {
            return new Route(Origin, Destination);
        } 
    }
}
