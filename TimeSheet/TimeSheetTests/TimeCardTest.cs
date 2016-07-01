using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;

namespace TimeSheetTests
{
    [TestClass]
    public class TimeCardTest
    {
        [TestMethod]
        public void Test2WeekPayPeriod()
        {
            DateTime startingDay = new DateTime(2016, 7, 3);
            TimeCard t = new TimeCard(startingDay);
            int arraySize = 0;
            for(int i = 0; i < t.PayPeriod.Length; i++)
            {
                Assert.AreEqual(t.PayPeriod[i].dateTime, startingDay.AddDays(i));
                ++arraySize;
            }
        }

        [TestMethod]
        public void TestStartsOnSunday()
        {
            try {
                DateTime startingDay = new DateTime(2016, 6, 30);
                TimeCard t = new TimeCard(startingDay);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void TestOverTime()
        {    
            DateTime startingDay = new DateTime(2016, 7, 3);
            TimeCard t = new TimeCard(startingDay);
            t.PayPeriod[4].SetHours(Day.TimeCodes.REGULAR, 15.0f);
            t.PayPeriod[6].SetHours(Day.TimeCodes.REGULAR, 8.0f);
            t.PayPeriod[2].SetHours(Day.TimeCodes.REGULAR, 20.0f);
            t.PayPeriod[3].SetHours(Day.TimeCodes.REGULAR, 5.0f);
            t.PayPeriod[10].SetHours(Day.TimeCodes.REGULAR, 12.0f);
            t.CalculateOverTime();
            float expected = 8.0f;
            Assert.AreEqual(expected, t.OverTime);
        }
    }
}