using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIPContainer;

namespace VIPContainerConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
          
            // register types
            container.Register<ICustomerRepository, CustomerRepository>().;
            container.Register<ILogger, ConsoleLogger>();

            var repo = container.Resolve<ICustomerRepository>();
            var cust = repo.FindAll();

            Console.WriteLine("==============Customers========");
            foreach (var c in cust)
            {
                Console.WriteLine(c.Name);
            }

            Console.ReadKey();
        }
    }
}
