using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIPContainer;

namespace VIPContainerConsoleDemo
{
    public class CustomerRepository : ICustomerRepository
    {
        public ILogger Logger { get; set; }

        [Inject]
        public CustomerRepository(ILogger logger)
        {
            Logger = logger;
        }

        public Customer Find(int id)
        {
            Logger.Log("Find called with param value " + id.ToString());
            return FindAll().Where(c => c.Id == id).FirstOrDefault();
        }

        public List<Customer> FindAll()
        {
            Logger.Log("FindAll called.");
            var data = new List<Customer>();
            data.Add(new Customer() { Id = 1, Name = "Joe" });
            data.Add(new Customer() { Id = 2, Name = "Steve" });
            data.Add(new Customer() { Id = 3, Name = "Karen" });
            return data;
        }

    }
}
