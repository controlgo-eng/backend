using AutoMapper;
using MediatR;
using ControlGo.Application.Features.Customers.DTOs;
using ControlGo.Domain.Models;
using ControlGo.Domain.Repository;

namespace ControlGo.Application.Features.Customers.Command
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
            var customer = new Customer
            {
                Name = request.Name,
                Surname = request.Surname,
                DocumentNumber = request.DocumentNumber
            };
            var newUser = await this._customerRepository.AddAsync(customer);
            
            return this._mapper.Map<CustomerDto>(newUser);
            
        }
    }
}
