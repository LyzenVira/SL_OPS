
using Domain.Common;
using Domain.Entities;

namespace Application.Features.BlogFeature.Commands.Create
{
    public class BlogCreatedEvent : BaseEvent
    {
        public Blog Blog { get; set; }
        public BlogCreatedEvent(Blog blog)
        {
            Blog = blog;
        }
    }
}
