
using Microsoft.EntityFrameworkCore;
using SuperLandscapes_Blog.Domain.Common;
using SuperLandscapes_Blog.Domain.Common.Interfaces;
using System.Reflection;

namespace SuperLandscapes_Blog.Persistence.Context
{
    public class DataContext  : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public DataContext(DbContextOptions<DataContext> options,
            IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_dispatcher is null) { return result; }

            var entitiesWithEvent = ChangeTracker.Entries<BaseEntity>()
                .Select(ent => ent.Entity)
                .Where(ent => ent.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEventsAsync(entitiesWithEvent);

            return result;
        }
    }
}
