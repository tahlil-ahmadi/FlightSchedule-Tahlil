using System;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using FlightSchedule.Specs.Constants;
using FlightSchedule.Specs.Endpoints;
using FlightSchedule.Specs.Steps.Mappers;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FlightSchedule.Specs.Steps
{
    [Binding]
    public class FlightGenerationSteps
    {
        private readonly ScenarioContext _context;
        public FlightGenerationSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"I have reserved a charter flight from airline with following information")]
        public void GivenIHaveReservedACharterFlightFromAirlineWithFollowingInformation(Table table)
        {
            var schedule = table.CreateInstance<ReserveScheduleDto>();
            schedule.FlightNo = Guid.NewGuid().ToString();
            _context.Add(FlightKeys.ReserveScheduleKey, schedule);
        }
        
        [Given(@"I have entered the following weekly flight schedule")]
        public void GivenIHaveEnteredTheFollowingWeeklyFlightSchedule(Table table)
        {
            var schedule = _context.Get<ReserveScheduleDto>(FlightKeys.ReserveScheduleKey);
            schedule.WeeklyTimetable = table.CreateSet<WeeklyTimetableDto>().ToList();
            //TODO: fix this O_o
            schedule.WeeklyTimetable[0].DayOfWeek =  DayOfWeek.Monday;
            schedule.WeeklyTimetable[1].DayOfWeek =  DayOfWeek.Wednesday;
        }
        
        [When(@"I press generate")]
        public void WhenIPressGenerate()
        {
            var schedule = _context.Get<ReserveScheduleDto>(FlightKeys.ReserveScheduleKey);
            FlightEndpoint.GenerateFlights(schedule);
        }
        
        [Then(@"The following flights should be generated")]
        public void ThenTheFollowingFlightsShouldBeGenerated(Table table)
        {
            var flightNumber = _context.Get<ReserveScheduleDto>(FlightKeys.ReserveScheduleKey).FlightNo;
            var expectedFlights = FlightDtoMapper.FromTable(table).ToList();
            var actualGeneratedFlights = FlightEndpoint.GetByFlightNumber(flightNumber);

            //TODO: include route :|
            actualGeneratedFlights.Should().BeEquivalentTo(expectedFlights,
                a=>a.Excluding(z=>z.Id));
        }
    }
}
