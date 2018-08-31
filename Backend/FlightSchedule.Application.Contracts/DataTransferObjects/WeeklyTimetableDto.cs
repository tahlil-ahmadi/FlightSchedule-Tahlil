using System;

namespace FlightSchedule.Application.Contracts.DataTransferObjects
{
    public class WeeklyTimetableDto
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan DepartTime { get; set; }

        public WeeklyTimetableDto()
        {
        }
        public WeeklyTimetableDto(DayOfWeek dayOfWeek, TimeSpan departTime)
        {
            DayOfWeek = dayOfWeek;
            DepartTime = departTime;
        }

      
    }
}
