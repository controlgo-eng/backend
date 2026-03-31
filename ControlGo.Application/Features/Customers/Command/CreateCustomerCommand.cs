using MediatR;
using ControlGo.Application.Features.Customers.DTOs;

namespace ControlGo.Application.Features.Customers.Command
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int DocumentNumber { get; set; }
    }
}
