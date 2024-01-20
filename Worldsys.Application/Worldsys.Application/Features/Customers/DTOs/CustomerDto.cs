using Worldsys.Domain.Customers.Models;

namespace Worldsys.Application.Features.Customers.DTOs
{
    public class CustomerDto
    {
        public CustomerDto(int id, string name, string surname, int documentNumber)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.DocumentNumber = documentNumber;
        }

        public CustomerDto()
        {
                
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public int DocumentNumber { get; set; }

        public static CustomerDto FromDomain(Customer customer)
        {
            return new CustomerDto(customer.Id, customer.Name, customer.Surname, customer.DocumentNumber);
        }
    }
}
