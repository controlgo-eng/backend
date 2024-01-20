using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worldsys.Domain.Customers.Models;

namespace Worldsys.Domain.Customers.Repository
{
    public interface ICustomerRepository
    {
        bool UpdateStatus(Customer customer);
    }
}
