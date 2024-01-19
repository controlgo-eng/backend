using MediatR;

namespace Worldsys.Application.Features.Customers.Command
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
