using MediatR;
using ControlGo.Application.Features.Customers.DTOs;

namespace ControlGo.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int Id { get; private set; }

        public GetCustomerByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
