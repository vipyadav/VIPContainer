using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPContainerConsoleDemo
{
    public interface ICustomerRepository
    {
        Customer Find(int id);
        List<Customer> FindAll();
    }
}
