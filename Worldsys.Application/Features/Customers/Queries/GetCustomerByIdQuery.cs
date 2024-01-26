using MediatR;
using Worldsys.Application.Features.Customers.DTOs;

namespace Worldsys.Application.Features.Customers.Queries
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
