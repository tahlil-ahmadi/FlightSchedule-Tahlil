using System;
using System.Collections.Generic;

namespace FlightSchedule.Application.Contracts.DataTransferObjects
{
    public class ReserveScheduleDto
    {
        public string Aircraft { get; set; }
        public string FlightNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime StartReserveDate { get; set; }
        public DateTime EndReserveDate { get; set; }
        public List<WeeklyTimetableDto> WeeklyTimetable { get; set; }
    }
}