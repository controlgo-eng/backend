using Microsoft.AspNetCore.Builder;

namespace Worldsys.Infrastructure.Bootstrap.Extensions.ApplicationBuilder
{
    public static class HealthChecksApplicationBuilderExtensions
    {
        public static void UseMicroserviceExampleHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health");
        }
    }
}
