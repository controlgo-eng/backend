using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Worldsys.Infrastructure.Bootstrap.Extensions.ApplicationBuilder;
using Worldsys.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Worldsys.Domain.Customers.Services;
using Worldsys.Infrastructure.Features.Customers.Services;
using Worldsys.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Worldsys.Infrastructure.Bootstrap
{
    public static class ApplicationStartup
    {
        private static IConfiguration configuration;
        private const string JwtPolicy = "JwtPolicy";

        public static void Startup(IConfiguration config)
        {
            configuration = config;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMicroserviceExampleHealthChecks();
            services.ConfigureResponseCompression();

            services.AddHttpContextAccessor();
            services.AddCorsConfiguration();


            #region Implementations
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion Implementations

            #region DataBase
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("connection string 'ApplicationDbContext not found '")));

            #endregion

            services.AddControllers(o =>
                {
                    o.Filters.Add(new ProducesResponseTypeAttribute(400));
                    o.Filters.Add(new ProducesResponseTypeAttribute(500));
                });
            return services;
        }

        public static void ConfigureApp(WebApplication app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseMicroserviceExampleHealthChecks();
            app.UseResponseCompression();
            app.UseCorsConfiguration();
            app.UseExceptionHandler(errorPipeline =>
            {
                errorPipeline.UseExceptionHandlerMiddleware(configuration.GetValue("AppSettings:IncludeErrorDetailInResponse", false));
            });


            app.UseHttpsRedirection();
            app.UseAuthorization();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllers();

        }

        public static void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtPolicy, policy =>
                {
                    policy.RequireAuthenticatedUser()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                });
            });
            services.AddAuthenticationConfiguration(configuration);
        }
    }
}
