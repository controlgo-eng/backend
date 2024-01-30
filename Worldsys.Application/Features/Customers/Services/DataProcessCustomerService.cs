namespace Worldsys.Application.Features.Customers.Services
{
    public class DataProcessCustomerService
    {
        public Task ProcessData(dynamic data)
        {
            Console.WriteLine($"Procesando Customer: {Newtonsoft.Json.JsonConvert.SerializeObject(data)}");
            
            Thread.Sleep(9000);

            return Task.CompletedTask;
        }
    }
}
