using Microsoft.EntityFrameworkCore;
using Worldsys.Domain.Customers.Models;


namespace Worldsys.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
