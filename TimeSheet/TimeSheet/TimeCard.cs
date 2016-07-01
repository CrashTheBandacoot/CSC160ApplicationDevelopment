using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public class TimeCard
    {
        public int HoursInWeek { get; set; }
        public float OverTime { get; set; }
        private const int numOfDaysInPayPeriod = 14;
        public Day[] PayPeriod = new Day[numOfDaysInPayPeriod];
        public float[] totalHoursWorked = new float[Day.numOfHourTypes];

        public TimeCard(DateTime payPeriodStart)
        {
            if (payPeriodStart.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                for (int i = 0; i < numOfDaysInPayPeriod; ++i)
                {
                    PayPeriod[i] = new Day(payPeriodStart.AddDays(i));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("payPeriodStart", "payPeriodStart must be a Sunday.");
            }
        }


        public void CalculateOverTime()
        {
            float regularHours = 0.0f;
            for (int i = 0; i < PayPeriod.Length / 2; ++i)
            {
                regularHours += PayPeriod[i].hoursArray[0];
            }
            if(regularHours > 40)
            {
                OverTime = regularHours - 40.0f;
            }
            regularHours = 0.0f;
            for (int i = PayPeriod.Length / 2; i < PayPeriod.Length; ++i)
            {
                regularHours += PayPeriod[i].hoursArray[0];
            }
            if (regularHours > 40)
            {
                OverTime += regularHours - 40.0f;
            }
        }

        public void CaluclateHoursWorked()
        {

            for(int i = 0; i < PayPeriod.Length; i++)
            {
                totalHoursWorked[0] += PayPeriod[i].hoursArray[0];
                totalHoursWorked[1] += PayPeriod[i].hoursArray[1];
                totalHoursWorked[2] += PayPeriod[i].hoursArray[2];
            }
        }
    }
}