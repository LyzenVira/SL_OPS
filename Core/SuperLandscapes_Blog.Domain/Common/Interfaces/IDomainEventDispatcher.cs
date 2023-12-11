
namespace SuperLandscapes_Blog.Domain.Common.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEventsAsync(IEnumerable<BaseEntity> entitiesWithEvents);
    }
}
