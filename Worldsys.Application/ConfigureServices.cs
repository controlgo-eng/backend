using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Worldsys.Application.Behaviors;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace Worldsys.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var enableCommandLogging = configuration.GetSection("AppSettings")["EnableCommandLogging"];            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //validation
                ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
                if (enableCommandLogging != null && enableCommandLogging.ToLower() == "true")
                {
                    ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
                }             
            });

            return services;
        }
    }
}
