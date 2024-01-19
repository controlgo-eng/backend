using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Services;
using Worldsys.Domain.Exceptions;

namespace Worldsys.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerService customerService;
        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await this.customerService.GetCustomerByIdAsync(request.Id);            
            if (customer == null)
            {
                throw new CustomerDomainException($"Cliente con el id {request.Id} no encontrado");
            }

            return CustomerDto.FromDomain(customer);
        }
    }
   
}
