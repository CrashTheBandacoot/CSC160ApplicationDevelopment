using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockLibrary
{
    public class Clock
    {
        public void Start(ITickable handler)
        {
            for (int i = 0; i < 11; ++i)
            {
                handler.TimeChanged(i);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
