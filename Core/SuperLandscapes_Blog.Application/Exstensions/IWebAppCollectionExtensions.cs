

using SuperLandscapes_Blog.Application.Exceptions.Handling;
using Microsoft.AspNetCore.Builder;

namespace SuperLandscapes_Blog.Application.Exstensions
{
    public static class IWebAppCollectionExtensions
    {
        public static void AddWebApplicationLayer(this IApplicationBuilder app)
        {
            app.AddExceptionHandling();
        }

        private static void AddExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
