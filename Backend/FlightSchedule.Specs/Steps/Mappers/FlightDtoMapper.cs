using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts.DataTransferObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FlightSchedule.Specs.Steps.Mappers
{
    public static class FlightDtoMapper
    {
        public static IEnumerable<FlightDto> FromTable(Table table)
        {
            //TODO: move to a [ValueRetrievers]
            foreach (var tableRow in table.Rows)
            {
                var flight = new FlightDto
                {
                    FlightNo = tableRow["FlightNo"],
                    Route = new RouteDto()
                    {
                        Destination = tableRow["Destination"],
                        Origin = tableRow["Origin"],
                    },
                    AirCraft = tableRow["Aircraft"],
                    DepartDate = DateTime.Parse(tableRow["DepartDate"])
                };
                yield return flight;
            }
        }
    }
}
