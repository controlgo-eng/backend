using MediatR;
using ControlGo.Domain.Models;
using ControlGo.Domain.Repository;

namespace ControlGo.Application.Features.Customers.Command
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
