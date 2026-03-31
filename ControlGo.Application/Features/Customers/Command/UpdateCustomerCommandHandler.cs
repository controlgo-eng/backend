using AutoMapper;
using MediatR;
using ControlGo.Domain.Customers.Models;
using ControlGo.Domain.Customers.Repository;
using ControlGo.Domain.Exceptions;

namespace ControlGo.Application.Features.Customers.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;        

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;            
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = await this._customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                throw new CustomerDomainException($"Cannot update a customer with Id: {request.Id}");
            }

            await this._customerRepository.UpdateAsync(
               new Customer
               {
                   Id = request.Id,
                   Name = request.Name,
                   Surname = request.Surname,
                   DocumentNumber = request.DocumentNumber
               });
            return true;
        }    
    }
}
