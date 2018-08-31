using System;
using System.Collections.Generic;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using FlightSchedule.Application.Mappers;
using FlightSchedule.Application.Tests.Utils;
using FlightSchedule.Domain.Builders;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Shared;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Application.Tests.Unit.Tests
{
    public class MapperTests
    {
        [Fact]
        public void Mapper_schedule_dto_should_map_ReserveScheduleDto_to_ReserveSchedule()
        {
            var reserveScheduleDto = new ReserveScheduleDtoTestBuilder().Build();
            var expectedReserveSchedule = new ReserveScheduleBuilder()
                .WithEndReserveDate(reserveScheduleDto.EndReserveDate)
                .WithStartReserveDate(reserveScheduleDto.StartReserveDate)
                .WithAircraft(reserveScheduleDto.Aircraft)
                .WithFlightNumber(reserveScheduleDto.FlightNo)
                .WithRoute(new Route(reserveScheduleDto.Origin, reserveScheduleDto.Destination))
                .WithWeeklyTimetable(Mapper.MapWeeklyTimeTable(reserveScheduleDto.WeeklyTimetable))
                .Build();

            var reserveSchedule = Mapper.MapReserveScheduleDto(reserveScheduleDto);


            reserveSchedule.Should().BeEquivalentTo(expectedReserveSchedule);
        }

        [Fact]
        public void Mapper_weekly_time_table_should_map_WeeklyTimetableDto_to_WeeklyTimeTable()
        {
            var weeklyTimeTableDto = new List<WeeklyTimetableDto>()
            {
                new WeeklyTimetableDto(DayOfWeek.Monday,new TimeSpan(8, 0, 0)),
            };
            var expectedWeeklyTimeTable = new List<WeeklyTimetable>()
            {
                new WeeklyTimetable(DayOfWeek.Monday,new TimeSpan(8,0,0))
            };

            var weeklyTimeTable = Mapper.MapWeeklyTimeTable(weeklyTimeTableDto);

            weeklyTimeTable.Should().BeEquivalentTo(expectedWeeklyTimeTable);

        }
    }
}
