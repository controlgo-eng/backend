using AutoMapper;
using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Customers.Services;
using Worldsys.Domain.Exceptions;
using Worldsys.Domain.Repository;

namespace Worldsys.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(IRepository<Customer> customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await this.customerRepository.GetByIdAsync(request.Id);            
            if (customer == null)
            {
                throw new CustomerDomainException($"Cliente con el id {request.Id} no encontrado");
            }

            return  this._mapper.Map<CustomerDto>(customer);
        }
    }
   
}
