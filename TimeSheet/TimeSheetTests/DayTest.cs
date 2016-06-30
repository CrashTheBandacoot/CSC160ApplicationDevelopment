using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;

namespace TimeSheetTests
{
    [TestClass]
    public class DayTest
    {
        [TestMethod]
        public void TestDayRegular()
        {
            //arrange
            TimeSheet.Day d = new Day(new DateTime(2016,6,28));

            //act
            try
            {
                d.Add(Day.TimeCodes.REGULAR, 8);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }

            //assert
            Assert.IsTrue(d.Validate());

        }

        [TestMethod]
        public void TestDayOve24()
        {
            //arrange
            TimeSheet.Day d = new Day(new DateTime(2016, 6, 28));

            //act
            d.Add(Day.TimeCodes.REGULAR, 21);
            d.Add(Day.TimeCodes.SICK, 5);

            //assert
            Assert.IsFalse(d.Validate());

        }
    }
}
