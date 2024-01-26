using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Worldsys.Application.Behaviors;

namespace Worldsys.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, bool enableCommandLogging = false)
        {            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());            
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //validation
                ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
                if (enableCommandLogging)
                {
                    ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
                }
            });
            

            return services;
        }
    }
}
