using MediatR;
using ControlGo.Application.Features.Customers.DTOs;

namespace ControlGo.Application.Features.Customers.Queries
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
