using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Customers.Services;

namespace Worldsys.Application.Features.Customers.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return CustomerDto.FromDomain(await this.customerService.Add(
               new Customer(
                   request.Id,
                   request.Name,
                   request.Surname,
                   request.DocumentNumber)
               ));
        }
    }
}
