using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class MinutesSecondRowLampTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MinutesSecondRowLampConstructor_InvalidLowerPosition_ThrowsException()
        {
            new MinutesSecondRowLamp(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MinutesSecondRowLampConstructor_InvalidHigherPosition_ThrowsException()
        {
            new MinutesSecondRowLamp(5);
        }

        [TestMethod]
        public void Process_FourthLampFiftyFiveMins_IsSwitchedOffLightYellow()
        {
            var lamp = new MinutesSecondRowLamp(4);
            var time = new TimeSpan(0, 55, 0);
            lamp.Process(time);
            Assert.AreEqual(false, lamp.IsSwitchedOn);
            Assert.AreEqual("Y", lamp.LightColour);
        }

        [TestMethod]
        public void Process_FourthLampFiftyNineMins_IsSwitchedOnLightYellow()
        {
            var lamp = new MinutesSecondRowLamp(4);
            var time = new TimeSpan(0, 59, 0);
            lamp.Process(time);
            Assert.AreEqual(true, lamp.IsSwitchedOn);
            Assert.AreEqual("Y", lamp.LightColour);
        }

        [TestMethod]
        public void ToString_SwitchedOn()
        {
            var lamp = new MinutesSecondRowLamp(4);
            var time = new TimeSpan(0, 59, 0);
            lamp.Process(time);
            Assert.AreEqual("Y", lamp.ToString());
        }

        [TestMethod]
        public void ToString_SwitchedOff()
        {
            var secondsLamp = new MinutesSecondRowLamp(1);
            var time = new TimeSpan(0, 55, 0);
            secondsLamp.Process(time);
            Assert.AreEqual("O", secondsLamp.ToString());
        }
    }
}

