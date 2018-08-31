using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Builders;
using FlightSchedule.Domain.TestUtil;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Domain.Tests.Unit.Builders
{
    public class ReserveScheduleBuilderTests
    {
        [Fact]
        public void reserveSchedule_builder_should_build_reserveSchedule()
        {
            var reserveSchedule = new ReserveScheduleTestBuilder().Build();

            var expectedReserveSchedule = new ReserveScheduleBuilder()
                .WithAircraft(reserveSchedule.Aircraft)
                .WithEndReserveDate(reserveSchedule.EndReserveDate)
                .WithStartReserveDate(reserveSchedule.StartReserveDate)
                .WithFlightNumber(reserveSchedule.FlightNo)
                .WithRoute(reserveSchedule.Route)
                .WithWeeklyTimetable(reserveSchedule.WeeklyTimetable)
                .Build();

            expectedReserveSchedule.Should().BeEquivalentTo(reserveSchedule);
        }
    }
}
