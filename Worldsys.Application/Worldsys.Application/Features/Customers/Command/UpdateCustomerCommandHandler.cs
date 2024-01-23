using AutoMapper;
using MediatR;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Customers.Repository;
using Worldsys.Domain.Exceptions;

namespace Worldsys.Application.Features.Customers.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository customerRepository;        

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;            
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = await this.customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                throw new CustomerDomainException($"Cannot update a customer with Id: {request.Id}");
            }

            await this.customerRepository.UpdateAsync(
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