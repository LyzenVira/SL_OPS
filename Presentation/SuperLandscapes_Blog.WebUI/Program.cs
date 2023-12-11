
using SuperLandscapes_Blog.WebUI.Extensions;
using SuperLandscapes_Blog.Application.Exstensions;
using SuperLandscapes_Blog.Infrastructure.Extensions;
using SuperLandscapes_Blog.Persistence.Extensions;
using MassTransit;

namespace SuperLandscapes_Blog.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationLayer();
            builder.Services.AddInfrastructureLayer();
            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddPresentationLayer();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.AddWebApplicationLayer();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.MapControllers();

            app.Run();
        }
    }
}