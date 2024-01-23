using MediatR;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Repository;

namespace Worldsys.Application.Features.Customers.Command
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {

        private readonly IRepository<Customer> customerRepository;


        public DeleteCustomerCommandHandler(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await this.customerRepository.DeleteAsync(request.Id);
        }
    }
}
