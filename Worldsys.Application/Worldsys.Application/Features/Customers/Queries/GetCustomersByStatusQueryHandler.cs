using MediatR;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Repository;

namespace Worldsys.Application.Features.Customers.Queries
{
    public class GetCustomersByStatusQueryHandler : IRequestHandler<GetCustomersByStatusQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository customerRepository;
        public GetCustomersByStatusQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersByStatusQuery request, CancellationToken cancellationToken)
        {
            var customers = await this.customerRepository.GetCustomersByStatus(request.Status);
            //var customers = await this.customerRepository.ExecuteFromStoredProcedure($"GetCustomersByStatus {request.Status}");

            return  customers.Select(x=> new CustomerDto { Id = x.Id, Name= x.Name, Surname = x.Surname, DocumentNumber = x.DocumentNumber }).ToList();
        }
    }
   
}
