using MediatR;
using Worldsys.Domain.Customers.Services;
using Worldsys.Domain.Exceptions;

namespace Worldsys.Application.Features.Customers.Command
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {

        public DeleteCustomerCommandHandler()
        {
        }

        public Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new CustomerDomainException($"Cannot delete a customer with Id: {request.Id}");
        }
    }
}
