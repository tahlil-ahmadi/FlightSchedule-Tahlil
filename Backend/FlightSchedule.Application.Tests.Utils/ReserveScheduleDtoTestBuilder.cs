using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using FlightSchedule.Domain.Shared;

namespace FlightSchedule.Application.Tests.Utils
{
    public class ReserveScheduleDtoTestBuilder
    {
        public ReserveScheduleDto Build()
        {
            return new ReserveScheduleDto()
            {
                Aircraft = "Airbus-W350",
                WeeklyTimetable = new List<WeeklyTimetableDto>()
                {
                    new WeeklyTimetableDto(DayOfWeek.Friday,TimeSpan.MaxValue)
                },
                FlightNo = "WS-2040",
                Destination = "FRA",
                Origin = "IKA",
                StartReserveDate = DateTime.Now,
                EndReserveDate = DateTime.Now
            };
        }
    }
}
