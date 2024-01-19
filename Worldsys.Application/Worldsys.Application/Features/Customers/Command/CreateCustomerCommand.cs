using MediatR;
using Worldsys.Application.Features.Customers.DTOs;

namespace Worldsys.Application.Features.Customers.Command
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int DocumentNumber { get; set; }
    }
}
