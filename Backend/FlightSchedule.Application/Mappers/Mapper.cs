using System.Collections.Generic;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using FlightSchedule.Domain.Builders;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Shared;

namespace FlightSchedule.Application.Mappers
{
    public static class Mapper
    {
        public static ReserveSchedule MapReserveScheduleDto(ReserveScheduleDto reserveScheduleDto)
        {
            var route = new Route(reserveScheduleDto.Origin, reserveScheduleDto.Destination);

            var weeklyTimetables = MapWeeklyTimeTable(reserveScheduleDto.WeeklyTimetable);

            return new ReserveScheduleBuilder()
                .WithAircraft(reserveScheduleDto.Aircraft)
                .WithStartReserveDate(reserveScheduleDto.StartReserveDate)
                .WithEndReserveDate(reserveScheduleDto.EndReserveDate)
                .WithFlightNumber(reserveScheduleDto.FlightNo)
                .WithRoute(route)
                .WithWeeklyTimetable(weeklyTimetables)
                .Build();
        }

        public static List<WeeklyTimetable> MapWeeklyTimeTable(List<WeeklyTimetableDto> weeklyTimetable)
        {
            var result = new List<WeeklyTimetable>();
            weeklyTimetable.ForEach(item => { result.Add(new WeeklyTimetable(item.DayOfWeek, item.DepartTime)); });
            return result;
        }
    }
}