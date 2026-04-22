using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ControlGo.Infrastructure.Repositories.EntityFramework;
using ControlGo.Domain.Models;

namespace ControlGo.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<TenantSetting> TenantSetting { get; set; }
        public DbSet<TenantUser> TenantUser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserPermission> UserPermission { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Obtengo los ensamblados correspondientes que implementen la interfaz IEntityTypeConfiguration..
            IEnumerable<Type> typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(t => !string.IsNullOrEmpty(t.Namespace)).Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            foreach (Type type in typesToRegister)
            {
                // Obtengo la instancia del modelo/entidad..
                dynamic configurationInstance = Activator.CreateInstance(type);

                // Agrego la configuración del modelo.
                modelBuilder.ApplyConfiguration(configurationInstance);
            }


            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
