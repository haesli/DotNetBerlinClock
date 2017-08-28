using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class HoursSecondRowLampTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HoursSecondRowLampConstructor_InvalidLowerPosition_ThrowsException()
        {
            new HoursSecondRowLamp(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HoursSecondRowLampConstructor_InvalidHigherPosition_ThrowsException()
        {
            new HoursSecondRowLamp(5);
        }

        [TestMethod]
        public void Process_FourthLampTwentyThreeHours_IsSwitchedOffLightRed()
        {
            var lamp = new HoursSecondRowLamp(4);
            var time = new TimeSpan(23, 59, 59);
            lamp.Process(time);
            Assert.AreEqual(false, lamp.IsSwitchedOn);
            Assert.AreEqual("R", lamp.LightColour);
        }

        [TestMethod]
        public void Process_FourthLampTwentyFourHours_IsSwitchedOnLightYellow()
        {
            var lamp = new HoursSecondRowLamp(4);
            var time = new TimeSpan(24, 0, 0);
            lamp.Process(time);
            Assert.AreEqual(true, lamp.IsSwitchedOn);
            Assert.AreEqual("R", lamp.LightColour);
        }

        [TestMethod]
        public void ToString_SwitchedOn()
        {
            var lamp = new HoursSecondRowLamp(1);
            var time = new TimeSpan(1, 0, 0);
            lamp.Process(time);
            Assert.AreEqual("R", lamp.ToString());
        }

        [TestMethod]
        public void ToString_SwitchedOff()
        {
            var lamp = new HoursSecondRowLamp(1);
            var time = new TimeSpan(5, 0, 0);
            lamp.Process(time);
            Assert.AreEqual("O", lamp.ToString());
        }
    }
}

