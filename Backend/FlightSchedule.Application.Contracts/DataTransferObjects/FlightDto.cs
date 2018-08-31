using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.Application.Contracts.DataTransferObjects
{
    public class FlightDto
    {
        public long Id { get; set; }
        public DateTime DepartDate { get; set; }
        public string AirCraft { get; set; }
        public string FlightNo { get; set; }
        public RouteDto Route { get; set; }
    }
}
