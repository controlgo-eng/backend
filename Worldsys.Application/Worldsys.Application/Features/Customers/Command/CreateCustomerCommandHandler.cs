using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Customers.Services;
using Worldsys.Domain.Repository;

namespace Worldsys.Application.Features.Customers.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IRepository<Customer> customerRepository;

        public CreateCustomerCommandHandler(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return CustomerDto.FromDomain(await this.customerRepository.AddAsync(
                 new Customer
                 {
                     Name = request.Name,
                     Surname = request.Surname,
                     DocumentNumber = request.DocumentNumber
                 }));
        }
    }
}
