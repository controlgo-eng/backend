using MediatR;

namespace ControlGo.Application.Features.Customers.Command
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
