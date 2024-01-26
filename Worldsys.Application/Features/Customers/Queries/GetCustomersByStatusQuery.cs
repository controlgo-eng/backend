using MediatR;
using Worldsys.Application.Features.Customers.DTOs;

namespace Worldsys.Application.Features.Customers.Queries
{
    public class GetCustomersByStatusQuery : IRequest<List<CustomerDto>>
    {
        public int Status { get; private set; }

        public GetCustomersByStatusQuery(int status)
        {
            this.Status = status;
        }
    }
}
