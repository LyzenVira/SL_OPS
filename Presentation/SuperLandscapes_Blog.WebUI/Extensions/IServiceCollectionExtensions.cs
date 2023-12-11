using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.OpenApi.Models;
using SuperLandscapes_Blog.WebUI.Consumers;
using System.Reflection;

namespace SuperLandscapes_Blog.WebUI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPresentationLayer(this IServiceCollection services)
        {
            services.AddSwaggerConfiguration();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://rabbitmq-server");
                    cfg.ReceiveEndpoint("blog-service-queue", e =>
                    {
                        e.Consumer<BlogConsumer>();
                    });
                });
            });

        }
        private static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = " API",
                    Description = "...",
                    Version = "v1"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
