using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockLibrary;

namespace ClockUI
{
    class Program : ClockLibrary.ITickable
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            ClockLibrary.Clock clock = new Clock();
            clock.Start(this);
        }

        void ITickable.TimeChanged(int elasedSeconds)
        {
            Console.WriteLine(elasedSeconds);
        }
    }
}
