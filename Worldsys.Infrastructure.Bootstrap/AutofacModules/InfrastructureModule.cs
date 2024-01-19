using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Worldsys.Infrastructure.Bootstrap.AutofacModules
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration configuration;

        public InfrastructureModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            const string defaultDatabaseIdentifier = "Default";

            //builder.RegisterType<LdapDataSourceProvider>()
            //    .WithParameter("ldapDataSources", this.configuration.GetSection("Database:LdapDataSources").Get<IEnumerable<string>>())
            //    .As<IDataSourceProvider>()
            //    .SingleInstance();

            //this.RegisterAppConfigurationCredentialsProvider(builder, defaultDatabaseIdentifier);

            //builder.RegisterType<ConnectionStringProvider>()
            //    .As<IConnectionStringProvider>()
            //    .WithParameter("connectionString", this.configuration.GetConnectionString(defaultDatabaseIdentifier))
            //    .SingleInstance();

            //builder.RegisterType<SqlProviderSettings>()
            //        .As<ISqlProviderSettings>()
            //        .WithParameter("schema", this.configuration.GetSection($"Database:{defaultDatabaseIdentifier}:Schema")?.Value)
            //        .WithParameter("sqlTimeout", Convert.ToInt32(this.configuration.GetSection($"Database:{defaultDatabaseIdentifier}:SqlTimeout")?.Value))
            //        .SingleInstance();

            //builder.RegisterType<SqlProvider>()
            //        .As<ISqlProvider>()
            //        .SingleInstance();
        }

    }
}
