using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Worldsys.Infrastructure.Features.Posts.Services;

namespace Worldsys.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class HttpClientServiceCollectionExtensions
    {
        public static void AddHttpClientFactory(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<IExternalPostsService>()
               .ConfigureHttpClient((_, client) =>
               {
                   client.BaseAddress = new Uri(configuration.GetSection("AppSettings:urlPostsService").Value);
               });
        }
    }
}
