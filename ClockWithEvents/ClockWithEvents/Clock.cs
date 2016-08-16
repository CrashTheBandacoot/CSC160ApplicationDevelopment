using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockWithEvents
{
    class Clock
    {
        public delegate void TimeChangedDelegate(int seconds);
        public event TimeChangedDelegate SecondsChanged;
        public event TimeChangedDelegate MinutesChanged;
        int thousanths;
        internal void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1);
                thousanths++;
                if(thousanths % 1000 == 0)
                {
                    OnSecondsChanged();
                }
                if (thousanths % 5000 == 0)
                {
                    OnMinuteChanged();
                }
                //Console.WriteLine(seconds);
            }
        }

        private void OnMinuteChanged()
        {
            if (MinutesChanged != null)
            {
                MinutesChanged.Invoke(thousanths / 10);
            }
        }

        private void OnSecondsChanged()
        {
            if (SecondsChanged != null)
            {
                SecondsChanged.Invoke(thousanths / 10);
            }
        }
    }
}