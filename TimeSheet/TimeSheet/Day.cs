using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    //TODO: Handle editing hours
    public class Day
    {
        public enum TimeCodes { REGULAR, SICK, VACATION}
        private const int numOfHourTypes = 3;
        public float[] hoursArray = new float[numOfHourTypes];
        public float totalHours = 0;
        public DateTime dateTime;

        public Day(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        public void SetHours(TimeCodes timeType, float hours)
        {
            if (hours > 0)
            {
                if(hours % .25f == 0)
                {
                    hoursArray[(int)timeType] = hours;
                    for (int i = 0; i < numOfHourTypes; ++i)
                    {
                        totalHours += hoursArray[i];
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("hours", "Hours must be in .25 increments");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("hours", "Hours must be > 0");
            }
        }
        public bool Validate()
        {
            if (totalHours <= 24 && totalHours > 0 && totalHours % .25f == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public float HoursWorked { get; set; }

    }
}