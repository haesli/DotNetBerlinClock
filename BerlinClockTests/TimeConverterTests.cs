using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class TimeConverterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertTime_InvalidTimeFormat_ThrowsException()
        {
            var clock = new Clock();
            clock.ConvertTime("Aug 10, 2017");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertTime_InvalidHours_ThrowsException()
        {
            var clock = new Clock();
            clock.ConvertTime("24:00:01");
        }

        [TestMethod]
        public void ConvertTime_Midnight()
        {
            var clock = new Clock();
            var result = clock.ConvertTime("24:00:00");
            Assert.AreEqual(result,"Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO");
        }
        [TestMethod]
        public void ConvertTime_TwentyOneHoursFortyFiveMinutes()
        {
            var clock = new Clock();
            var result = clock.ConvertTime("21:45:00");
            Assert.AreEqual(result, "Y\r\nRRRR\r\nROOO\r\nYYRYYRYYROO\r\nOOOO");
        }
    }
}
