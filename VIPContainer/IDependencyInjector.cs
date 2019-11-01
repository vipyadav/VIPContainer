using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPContainer
{
    public interface IDependencyInjector
    {
        T GetInjectedInstance<T>() where T : class;
        object GetInjectedInstance(Type fromType);
        IContainer ServiceResolver { get; set; }
    }
}
