using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class MinutesFirstRowLampTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MinutesFirstRowLampConstructor_InvalidLowerPosition_ThrowsException()
        {
            new MinutesFirstRowLamp(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MinutesFirstRowLampConstructor_InvalidHigherPosition_ThrowsException()
        {
            new MinutesFirstRowLamp(12);
        }

        [TestMethod]
        public void Process_FirstLampZeroMins_IsSwitchedOffLightYellow()
        {
            var lamp = new MinutesFirstRowLamp(1);
            var time = new TimeSpan(12, 0, 59);
            lamp.Process(time);
            Assert.AreEqual(false, lamp.IsSwitchedOn);
            Assert.AreEqual("Y", lamp.LightColour);
        }

        [TestMethod]
        public void Process_ThirdOrSixthOrNinthLampZeroMins_IsSwitchedOffLightRed()
        {
            var thirdLamp = new MinutesFirstRowLamp(3);
            var time = new TimeSpan(12, 0, 30);
            thirdLamp.Process(time);
            Assert.AreEqual(false, thirdLamp.IsSwitchedOn);
            Assert.AreEqual("R", thirdLamp.LightColour);

            var sixthLamp = new MinutesFirstRowLamp(6);
            sixthLamp.Process(time);
            Assert.AreEqual(false, sixthLamp.IsSwitchedOn);
            Assert.AreEqual("R", sixthLamp.LightColour);

            var ninthLamp = new MinutesFirstRowLamp(9);
            ninthLamp.Process(time);
            Assert.AreEqual(false, ninthLamp.IsSwitchedOn);
            Assert.AreEqual("R", ninthLamp.LightColour);
        }

        [TestMethod]
        public void Process_FirstLampFiveMins_IsSwitchedOnLightYellow()
        {
            var lamp = new MinutesFirstRowLamp(1);
            var time = new TimeSpan(0, 5, 30);
            lamp.Process(time);
            Assert.AreEqual(true, lamp.IsSwitchedOn);
            Assert.AreEqual("Y", lamp.LightColour);
        }

        [TestMethod]
        public void Process_ThirdLampFifteenMins_IsSwitchedOnLightRed()
        {
            var thirdLamp = new MinutesFirstRowLamp(3);
            var time = new TimeSpan(0, 15, 0);
            thirdLamp.Process(time);
            Assert.AreEqual(true, thirdLamp.IsSwitchedOn);
            Assert.AreEqual("R", thirdLamp.LightColour);            
        }

        [TestMethod]
        public void ToString_SwitchedOn()
        {
            var lamp = new MinutesFirstRowLamp(6);
            var time = new TimeSpan(0, 30, 0);
            lamp.Process(time);
            Assert.AreEqual("R", lamp.ToString());
        }

        [TestMethod]
        public void ToString_SwitchedOff()
        {
            var lamp = new MinutesFirstRowLamp(1);
            var time = new TimeSpan(0, 0, 0);
            lamp.Process(time);
            Assert.AreEqual("O", lamp.ToString());
        }
    }
}

