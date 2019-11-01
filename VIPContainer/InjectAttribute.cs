using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPContainer
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor)]
    public class InjectAttribute : Attribute
    {

    }
}
