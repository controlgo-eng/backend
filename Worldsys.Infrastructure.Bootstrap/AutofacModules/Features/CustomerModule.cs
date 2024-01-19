using Autofac;
using Worldsys.Domain.Customers.Repository;
using Worldsys.Domain.Customers.Services;
using Worldsys.Infrastructure.Features.Customers.Repository;
using Worldsys.Infrastructure.Features.Customers.Services;

namespace Worldsys.Infrastructure.Bootstrap.AutofacModules.Features
{
    public class CustomerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>()
             .As<ICustomerRepository>()
             .InstancePerLifetimeScope();

            builder.RegisterType<CustomerService>()
           .As<ICustomerService>()
           .InstancePerLifetimeScope();
        }
    }
}
