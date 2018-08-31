using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Persistence.EF
{
    public class FlightScheduleContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public FlightScheduleContext() :base("DBConnection")
        {
            
        }

        
    }
}
