using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlGo.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class PersistenceServiceCollectionExtensions
    {
        private const string CONNECTION_STRING = "DefaultConnection";

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING),
                                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                    .UseLazyLoadingProxies(), ServiceLifetime.Transient);
        }
    }
}
