using AutoMapper;
using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.QuequeMessage.Services;
using Worldsys.Domain.Repository;

namespace Worldsys.Application.Features.Customers.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMessageQueueService _messageQueueService;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(IRepository<Customer> customerRepository, IMapper mapper, IMessageQueueService messageQueueService)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
            this._messageQueueService = messageQueueService;
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
