using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Customers.Services;

namespace Worldsys.Application.Features.Customers.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = await this.customerService.Add(
                new Customer
                {
                    Id = request.Id,
                    Name = request.Name,
                    Surname = request.Surname,
                    DocumentNumber = request.DocumentNumber
                });

            return CustomerDto.FromDomain(newCustomer);
        }

    }
}