using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlGo.Domain.Models;
using ControlGo.Domain.Repository;

namespace ControlGo.Domain.Customers.Repository
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<IList<Customer>> GetCustomersByStatus(int status);
    }
}
