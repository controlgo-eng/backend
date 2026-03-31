namespace ControlGo.Domain.Customers.Models
{

    public class Customer
    {


        public Customer() { }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int DocumentNumber { get; set; }

        public int Status { get; set; }


    }
}
