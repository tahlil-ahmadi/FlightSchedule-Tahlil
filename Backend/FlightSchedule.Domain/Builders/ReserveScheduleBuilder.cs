using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Shared;

namespace FlightSchedule.Domain.Builders
{
    public class ReserveScheduleBuilder
    {
        private string _aircraft;
        private string _flightNumber;
        private Route _route;
        private DateTime _startReserveDate;
        private DateTime _endReserveDate;
        private List<WeeklyTimetable> _weeklyTimetable;

        public ReserveScheduleBuilder WithAircraft(string aircraft)
        {
            this._aircraft = aircraft;
            return this;
        }
        public ReserveScheduleBuilder WithFlightNumber(string flightNumber)
        {
            this._flightNumber = flightNumber;
            return this;
        }
        public ReserveScheduleBuilder WithRoute(Route route)
        {
            this._route = route;
            return this;
        }
        public ReserveScheduleBuilder WithStartReserveDate(DateTime startReserveDate)
        {
            this._startReserveDate = startReserveDate;
            return this;
        }
        public ReserveScheduleBuilder WithEndReserveDate(DateTime endReserveDate)
        {
            this._endReserveDate = endReserveDate;
            return this;
        }
        public ReserveScheduleBuilder WithWeeklyTimetable(List<WeeklyTimetable> weeklyTimetable)
        {
            this._weeklyTimetable = weeklyTimetable;
            return this;
        }

        public ReserveSchedule Build()
        {
            return new ReserveSchedule(_aircraft,_flightNumber,_route,_startReserveDate,_endReserveDate,_weeklyTimetable);
        }
    }
}
