using AutoMapper;
using MediatR;
using ControlGo.Application.Features.Customers.DTOs;
using ControlGo.Domain.Customers.Repository;

namespace ControlGo.Application.Features.Customers.Queries
{
    public class GetCustomersByStatusQueryHandler : IRequestHandler<GetCustomersByStatusQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomersByStatusQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersByStatusQuery request, CancellationToken cancellationToken)
        {
            var customers = await this._customerRepository.GetCustomersByStatus(request.Status);
            //var customers = await this.customerRepository.ExecuteFromStoredProcedure($"GetCustomersByStatus {request.Status}");
            return this._mapper.Map<List<CustomerDto>>(customers);
            //return  customers.Select(x=> new CustomerDto { Id = x.Id, Name= x.Name, Surname = x.Surname, DocumentNumber = x.DocumentNumber }).ToList();
        }
    }
   
}
