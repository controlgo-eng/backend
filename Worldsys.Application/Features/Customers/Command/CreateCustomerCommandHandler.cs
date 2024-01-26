using AutoMapper;
using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Application.Mappers;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Customers.Services;
using Worldsys.Domain.Repository;

namespace Worldsys.Application.Features.Customers.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(IRepository<Customer> customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return this._mapper.Map<CustomerDto>(await this._customerRepository.AddAsync(
                 new Customer
                 {
                     Name = request.Name,
                     Surname = request.Surname,
                     DocumentNumber = request.DocumentNumber
                 }));
        }
    }
}
