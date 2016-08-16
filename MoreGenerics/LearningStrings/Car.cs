using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreGenerics
{
    //public delegate void MachineSelfDelegate(Car c);
    //public delegate void MachineSelfIntDelegate(Car c, int i);
    //public delegate void MachineSelfDoubleDelegate(Car c, double d);
    //public delegate void MachineSelfIntDoubleJumpDownTurnAroundDelegate(Car c, int i, double d);

    public class Car
    {
        public event Action<Car> EngineStarted;
        public event Action<Car, int> EngineTempWarning;
        public event Action<Car, double> FuelWarning;
        public event Action<Car, int, double> EngineHealthTick;

        public Car()
        {

        }

        private void OnCarStarted()
        {
            EngineStarted?.Invoke(this);
        }

        private void OnEngineTempWarning()
        {
            EngineTempWarning?.Invoke(this, 5000);
        }
    }
}
