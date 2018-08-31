using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FlightSchedule.Domain.TestUtil;
using FlightSchedule.Persistence.EF.Repositories;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Persistence.EF.Tests.Integration
{
    public class FlightPersistenceTests : PersistTest
    {
        [Fact]
        public void SaveChanges_should_save_flight_with_route_to_database()
        {
            var repository = new FlightRepository(DbContext);
            var flight = new FlightTestBuilder().Build();

            repository.Save(flight);

            DetachAllEntities();
            var savedFlight = repository.GetById(flight.Id);
            flight.Should().BeEquivalentTo(savedFlight);
        }

       
    }
}
