using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalLibrary
{
    public class ExternalClass
    {
        private IMyCustomEventHandler handler;
        public void DoSomething()
        {
            Console.WriteLine("DoSomething() has started.");
            if (handler != null)
            {
                handler.CustomEventHandler();
            }
            Console.WriteLine("DoSomething() has finished");
        }

        public void SetEventHandler(IMyCustomEventHandler upstreamClass)
        {
            handler = upstreamClass;
        }
    }
}
