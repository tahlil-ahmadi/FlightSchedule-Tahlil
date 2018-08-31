using System;
using System.Collections.Generic;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Domain.Shared
{
    public class ReserveSchedule
    {
        public string Aircraft { get;private set; }
        public string FlightNo { get; private set; }
        public Route Route { get; private set; }
        public DateTime StartReserveDate { get; private set; }
        public DateTime EndReserveDate { get; private set; }
        public List<WeeklyTimetable> WeeklyTimetable { get; private set; }

        public ReserveSchedule()
        {
            
        }

        public ReserveSchedule(string aircraft, string flightNo, Route route, DateTime startReserveDate, DateTime endReserveDate, List<WeeklyTimetable> weeklyTimetable)
        {
            Aircraft = aircraft;
            FlightNo = flightNo;
            Route = route;
            StartReserveDate = startReserveDate;
            EndReserveDate = endReserveDate;
            WeeklyTimetable = weeklyTimetable;
        }
    }
}
