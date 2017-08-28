using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class HoursFirstRowLampTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HoursFirstRowLampConstructor_InvalidLowerPosition_ThrowsException()
        {
            new HoursFirstRowLamp(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HoursFirstRowLampConstructor_InvalidHigherPosition_ThrowsException()
        {
            new HoursFirstRowLamp(5);
        }

        [TestMethod]
        public void Process_FourthLampNineteenHours_IsSwitchedOffLightRed()
        {
            var lamp = new HoursFirstRowLamp(4);
            var time = new TimeSpan(19, 0, 0);
            lamp.Process(time);
            Assert.AreEqual(false, lamp.IsSwitchedOn);
            Assert.AreEqual("R", lamp.LightColour);
        }

        [TestMethod]
        public void Process_FourthLampTwentyHours_IsSwitchedOnLightYellow()
        {
            var lamp = new HoursFirstRowLamp(4);
            var time = new TimeSpan(20, 0, 0);
            lamp.Process(time);
            Assert.AreEqual(true, lamp.IsSwitchedOn);
            Assert.AreEqual("R", lamp.LightColour);
        }

        [TestMethod]
        public void ToString_SwitchedOn()
        {
            var lamp = new HoursFirstRowLamp(1);
            var time = new TimeSpan(5, 0, 0);
            lamp.Process(time);
            Assert.AreEqual("R", lamp.ToString());
        }

        [TestMethod]
        public void ToString_SwitchedOff()
        {
            var lamp = new MinutesFirstRowLamp(1);
            var time = new TimeSpan(4, 0, 0);
            lamp.Process(time);
            Assert.AreEqual("O", lamp.ToString());
        }
    }
}

