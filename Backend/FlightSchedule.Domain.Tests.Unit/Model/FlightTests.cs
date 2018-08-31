using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.TestUtil;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Domain.Tests.Unit.Model
{
    public class FlightTests
    {
        [Fact]
        public void Constructor_should_construct_flight_properly()
        {
            var builder = new FlightTestBuilder();

            var flight = builder.Build();

            flight.DepartDate.Should().Be(builder.DepartDate);
            flight.AirCraft.Should().Be(builder.Aircraft);
            flight.FlightNo.Should().Be(builder.FlightNo);
            flight.Route.Should().Be(builder.Route);
        }
    }
}
