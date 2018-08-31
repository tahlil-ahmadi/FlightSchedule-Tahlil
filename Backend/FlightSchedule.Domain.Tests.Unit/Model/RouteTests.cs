using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.TestUtil;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Domain.Tests.Unit.Model
{
    public class RouteTests
    {
        [Fact]
        public void Constructor_should_construct_route_properly()
        {
            const string origin = "ika";
            const string destination = "dxb";
            const string expectedOrigin = "IKA";
            const string expectedDestination = "DXB";

            var route = new RouteTestBuilder()
                            .WithOrigin(origin)
                            .WithDestination(destination)
                            .Build();

            route.Origin.Should().Be(expectedOrigin);
            route.Destination.Should().Be(expectedDestination);
        }

        [Theory]
        [InlineData("IKA","IKA")]
        [InlineData("ika", "IKA")]
        [InlineData("IKA", "ika")]
        public void Constructor_should_throw_when_origin_is_same_as_destination(string origin, string destination)
        {
            var routeBuilder = new RouteTestBuilder()
                                        .WithOrigin(origin)
                                        .WithDestination(destination);

            Action constructor = () => routeBuilder.Build();

            constructor.Should().Throw<Exception>();
        }
    }
}
