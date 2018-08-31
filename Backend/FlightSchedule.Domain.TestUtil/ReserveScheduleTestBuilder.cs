using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Shared;
using Framework.Core.Clock;

namespace FlightSchedule.Domain.TestUtil
{
    public class ReserveScheduleTestBuilder
    {
        private string _aircraft;
        private string _flightNo;
        private Route _route;
        private DateTime _startReserveDate;
        private DateTime _endReserveDate;
        private List<WeeklyTimetable> _weeklyTimetable;

        public ReserveScheduleTestBuilder()
        {
            var route = new Route("IKA", "SJC");
            _startReserveDate = TravelTo.SomeFutureTime();
            _endReserveDate = TravelTo.SomeFutureTime();
            _route = route;
            _weeklyTimetable = new List<WeeklyTimetable>();
            _aircraft = "AIRBUS";
            _flightNo = "2020";
        }

        public ReserveScheduleTestBuilder WithAircraft(string aircraft)
        {
            _aircraft = aircraft;
            return this;
        }

        public ReserveScheduleTestBuilder WithFlightNo(string flightNo)
        {
            _flightNo = flightNo;
            return this;
        }

        public ReserveScheduleTestBuilder WithRoute(Route route)
        {
            _route = route;
            return this;
        }

        public ReserveScheduleTestBuilder WithStartReserveDate(DateTime startReserveDate)
        {
            _startReserveDate = startReserveDate;
            return this;
        }

        public ReserveScheduleTestBuilder WithEndReserveDate(DateTime endReserveDate)
        {
            _endReserveDate = endReserveDate;
            return this;
        }

        public ReserveScheduleTestBuilder WithWeeklyTimetable(List<WeeklyTimetable> weeklyTimetable)
        {
            _weeklyTimetable = weeklyTimetable;
            return this;
        }

        public ReserveSchedule Build()
        {
            return new ReserveSchedule(_aircraft, _flightNo, _route, _startReserveDate, _endReserveDate, _weeklyTimetable);
        }
    }
}