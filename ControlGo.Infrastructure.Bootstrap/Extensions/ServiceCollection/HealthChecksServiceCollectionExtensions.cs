using Microsoft.Extensions.DependencyInjection;

namespace ControlGo.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class HealthChecksServiceCollectionExtensions
    {
        public static void AddMicroserviceExampleHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
    }
}
