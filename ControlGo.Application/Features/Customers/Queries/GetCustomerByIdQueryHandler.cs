using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ControlGo.Application.Features.Customers.DTOs;
using ControlGo.Domain.Models;
using ControlGo.Domain.Exceptions;
using ControlGo.Domain.Repository;

namespace ControlGo.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCustomerByIdQueryHandler> _logger;
        public GetCustomerByIdQueryHandler(IRepository<Customer> customerRepository, IMapper mapper, ILogger<GetCustomerByIdQueryHandler> logger)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await this._customerRepository.GetByIdAsync(request.Id);

            this._logger.LogInformation($"Consultando por el Cliente {request.Id}");
            
            if (customer == null)
            {
                this._logger.LogError($"No existe un cliente con el Id {request.Id}");
                throw new CustomerDomainException($"Cliente con el id {request.Id} no encontrado", System.Net.HttpStatusCode.NotFound, 601);
            }

            return  this._mapper.Map<CustomerDto>(customer);
        }
    }
   
}
