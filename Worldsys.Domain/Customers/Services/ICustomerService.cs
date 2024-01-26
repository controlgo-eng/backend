using Worldsys.Domain.Customers.Models;

namespace Worldsys.Domain.Customers.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(int id);

        Task<Customer> Add(Customer customer);
    }
}
