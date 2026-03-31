using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlGo.Domain.Customers.Models;
using ControlGo.Domain.Customers.Services;

namespace ControlGo.Infrastructure.Features.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<Customer> Add(Customer customer)
        {
            //throw new NotImplementedException();
            return Task.FromResult(customer);
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return Task.FromResult(new Customer { Id = 10, Name = "Diego", Surname = "Maradona", DocumentNumber = 12125678 });
        }
    }
}
