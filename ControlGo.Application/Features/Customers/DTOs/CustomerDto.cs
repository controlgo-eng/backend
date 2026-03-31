using ControlGo.Application.Mappers;
using ControlGo.Domain.Customers.Models;


namespace ControlGo.Application.Features.Customers.DTOs
{
    public class CustomerDto : ICreateMapper<Customer>
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
        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        public int DocumentNumber { get; set; }
    }
}
