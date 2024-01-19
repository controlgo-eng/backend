using Autofac;
using Microsoft.Extensions.Configuration;
using Worldsys.Infrastructure.Bootstrap.AutofacModules;
using Worldsys.Infrastructure.Bootstrap.AutofacModules.Features;


namespace Worldsys.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class AutofacConfigurationServiceCollectionExtensions
    {
        public static void AddConfigurationAutofac(this ContainerBuilder builder, IConfiguration configuration)
        {                   
            builder.RegisterModule<CustomerModule>();
            builder.RegisterModule(new InfrastructureModule(configuration));
            builder.RegisterModule(new MediatorModule(configuration.GetValue("CommandLoggingEnabled", false)));                        
        }
    }
}
