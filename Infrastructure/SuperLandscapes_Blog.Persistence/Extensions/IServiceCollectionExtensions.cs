

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperLandscapes_Blog.Application.Interfaces;
using SuperLandscapes_Blog.Persistence.Context;
using SuperLandscapes_Blog.Persistence.Repositories;

namespace SuperLandscapes_Blog.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextConfiguration(configuration);
            services.AddRepositoriesConfiguration();
        }

        private static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
        });
        }

        private static void AddRepositoriesConfiguration(this IServiceCollection services)
        {
            services
               .AddTransient(typeof(IWrapperRepository), typeof(WrapperRepository))
               .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
               .AddTransient<IAuthorRepository, AuthorRepository>();
        }
    }
}
