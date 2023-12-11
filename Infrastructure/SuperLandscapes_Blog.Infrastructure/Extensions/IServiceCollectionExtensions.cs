using BLL.Services.Author;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SuperLandscapes_Blog.Domain.Common;
using SuperLandscapes_Blog.Domain.Common.Interfaces;

namespace SuperLandscapes_Blog.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services) => services.AddServices();

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IAuthorService, AuthorService>();
        }
    }
}
