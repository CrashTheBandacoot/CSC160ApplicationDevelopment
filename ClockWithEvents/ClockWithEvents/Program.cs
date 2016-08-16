using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockWithEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock c = new Clock();
            c.SecondsChanged += MyClockSecondsHaveChanged;
            c.MinutesChanged += MinutesChangedHandler;
            c.Start();
        }

        private static void MinutesChangedHandler(int minutes)
        {
            Console.WriteLine($"Minutes changed!!!!!!!!!!!!!! It's now {minutes}");
        }

        static void MyClockSecondsHaveChanged(int seconds)
        {
            Console.WriteLine(seconds);
        }
    }
}