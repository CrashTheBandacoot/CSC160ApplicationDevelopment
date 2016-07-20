using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAboutEvents
{
    class Program : ExternalLibrary.IMyCustomEventHandler
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }
        private void Start()
        {
            Console.WriteLine("Console app starting...");
            ExternalLibrary.ExternalClass e = new ExternalLibrary.ExternalClass();
            e.SetEventHandler(this);
            e.DoSomething();
            Console.WriteLine("Console app ending...");
        }

        public void CustomEventHandler()
        {
            Console.WriteLine("My event handler.");
        }
    }
}
