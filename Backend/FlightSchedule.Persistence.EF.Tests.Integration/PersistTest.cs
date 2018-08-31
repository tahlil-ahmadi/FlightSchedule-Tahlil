using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace FlightSchedule.Persistence.EF.Tests.Integration
{
    public abstract class PersistTest : IDisposable
    {
        private readonly TransactionScope _scope;
        protected FlightScheduleContext DbContext;
        protected PersistTest()
        {
            _scope = new TransactionScope();
            DbContext = new FlightScheduleContext();
        }

        protected void DetachAllEntities()
        {
            var changedEntriesCopy = this.DbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();
            foreach (var entity in changedEntriesCopy)
            {
                this.DbContext.Entry(entity.Entity).State = EntityState.Detached;
            }
        }
        public void Dispose()
        {
            DbContext.Dispose();
            _scope?.Dispose();
        }
    }
}
