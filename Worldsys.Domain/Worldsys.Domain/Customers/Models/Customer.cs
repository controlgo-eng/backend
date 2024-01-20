namespace Worldsys.Domain.Customers.Models
{

    public class Customer
    {


        public Customer() { }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public int DocumentNumber { get; set; }

        private const string ARGUMENT_EXCEPTION = "Missing argument";

        //public Customer(int id, string name, string surname, int documentNumber)
        //{
        //    this.Id = (id != 0) ? documentNumber : throw new ArgumentException(ARGUMENT_EXCEPTION, nameof(id));
        //    this.Name = (!string.IsNullOrEmpty(name)) ? name : throw new ArgumentException(ARGUMENT_EXCEPTION, nameof(name));
        //    this.Surname = (!string.IsNullOrEmpty(surname)) ? surname: throw new ArgumentException(ARGUMENT_EXCEPTION, nameof(surname));
        //    //this.DocumentNumber = (documentNumber != 0) ? documentNumber : throw new ArgumentException(ARGUMENT_EXCEPTION, nameof(documentNumber));
        //}
    }
}
