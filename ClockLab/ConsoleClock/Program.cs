using ClockWithEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClock
{
    class Program
    {
        Clock ticker;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            //This line no longer works because we changed the publicly exposed delegate to an event
            //c.secondsChanged = MyClockSecondsHaveChanged;

            //These lines are equivalent, they just point to different methods
            ticker.MillisecondsChanged += MillisecondsChangedHandler;
            ticker.SecondsChanged += new Clock.TimeChangedDelegate(SecondsChangedHandler);
            ticker.MinutesChanged += MinutesChangedHandler;
            ticker.HoursChanged += HoursChangedHandler;
            Console.Write("00:00:00:000");
            ticker.Start();
        }

        public Program()
        {
            ticker = new Clock();            
        }
        private void HoursChangedHandler(int hours)
        {
            if (hours >= 3)
            {
                hours %= 3;
            }
            Console.Write(hours.ToString(), Console.CursorLeft = 0);
        }
        private void MinutesChangedHandler(int minutes)
        {
            if (minutes >= 3)
            {
                minutes %= 3;
            }
            Console.Write(minutes.ToString(), Console.CursorLeft = 4);
        }
        void SecondsChangedHandler(int seconds)
        {
            if (seconds >= 10)
            {
                seconds %= 10;
            }
            Console.Write(seconds.ToString(), Console.CursorLeft = 7);
        }
        void MillisecondsChangedHandler(int milliseconds)
        {
            if(milliseconds >= 1000)
            {
                milliseconds %= 1000;
            }
            Console.Write(milliseconds.ToString(), Console.CursorLeft = 9);
        }
    }
}
