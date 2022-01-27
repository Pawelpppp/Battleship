using Battleship.Application.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Battleship.Application
{
    public static class AppBuilderExtension
    {
        public static IApplicationBuilder AddAplicationMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<CommandValidationErrorsMiddleware>();

            return app;
        }
    }
}
