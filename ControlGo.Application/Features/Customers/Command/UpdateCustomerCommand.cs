using MediatR;
using ControlGo.Application.Features.Customers.DTOs;


namespace ControlGo.Application.Features.Customers.Command
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;  
        
        public int DocumentNumber { get; set; }
    }
}
 
