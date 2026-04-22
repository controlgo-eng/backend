using ControlGo.Domain.Models;

namespace ControlGo.Domain.Customers.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(int id);

        Task<Customer> Add(Customer customer);
    }
}
