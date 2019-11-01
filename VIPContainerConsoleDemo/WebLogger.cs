using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIPContainerConsoleDemo
{
    public class WebLogger : ILogger
    {
        public void Log(string message)
        {
            //HttpContext.Current.Response.Write(message);
        }
    }
}
