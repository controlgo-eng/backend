using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Repository;

namespace Worldsys.Domain.Customers.Repository
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<IList<Customer>> GetCustomersByStatus(int status);
    }
}
