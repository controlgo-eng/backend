using Microsoft.Extensions.DependencyInjection;

namespace Worldsys.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class HealthChecksServiceCollectionExtensions
    {
        public static void AddMicroserviceExampleHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
    }
}
