using Castle.LoggingFacility.MsLogging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Libs.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseLibs(this IApplicationBuilder app)
        {
            app.UseLibs(null);
        }

        public static void UseLibs(this IApplicationBuilder app, Action<ApplicationBuilderOptions> optionsAction)
        {
            var options = new ApplicationBuilderOptions();
            optionsAction?.Invoke(options);

            if (options.UseCastleLoggerFactory)
            {
                app.UseCastleLoggerFactory();
            }

            if (options.UseSecurityHeaders)
            {
                app.UseMiddleware<SecurityHeadersMiddleware>();
            }
        }

        public static void UseCastleLoggerFactory(this IApplicationBuilder app)
        {
            var castleLoggerFactory = app.ApplicationServices.GetService<Castle.Core.Logging.ILoggerFactory>();
            if (castleLoggerFactory == null)
            {
                return;
            }

            app.ApplicationServices
                .GetRequiredService<ILoggerFactory>()
                .AddCastleLogger(castleLoggerFactory);
        }
    }
}
