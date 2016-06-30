﻿using System;
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
        public float regularHours;
        public float sickHours;
        public float vacationHours;
        private DateTime dateTime;

        public Day(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public DateTime Date { get; set; }

        public void Add(TimeCodes timeType, float hours)
        {
            if (hours > 0)
            {
                if (timeType == TimeCodes.REGULAR)
                {
                    regularHours += hours;
                }
                else if (timeType == TimeCodes.SICK)
                {
                    sickHours += hours;
                }
                else
                {
                    vacationHours += hours;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("hours", "Hours must be > 0");
            }
        }
        public float totalHours = 0;
        public bool Validate()
        {
            if (totalHours <= 24 && totalHours > 0)
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