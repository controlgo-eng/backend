using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Customers.Repository;
using Worldsys.Domain.Repository;

namespace Worldsys.Infrastructure.Features.Customers.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>, ICustomerRepository
    {


        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        //Se podria realizar un override al metodo en caso de querer implementarlgo de alguna otra forma
        public override Task<Customer> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);

        }

        //Este metodo fue implementado de la interfaz ICustomerRepository, ya que además de contar con los métodos bases se podria aplicar lógica adicional
        public async Task<IList<Customer>> GetCustomersByStatus(int status)
        {
            //return await base.ExecuteFromStoredProcedure($"GetCustomersByStatus @Status={status}");
            return await _context.Customers.FromSql($"EXEC GetCustomersByStatus {status}").ToListAsync();
        }
    }

}
