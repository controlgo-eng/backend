using MediatR;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Repository;

namespace Worldsys.Application.Features.Customers.Command
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {

        private readonly IRepository<Customer> _customerRepository;


        public DeleteCustomerCommandHandler(IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await this._customerRepository.DeleteAsync(request.Id);
        }
    }
}
