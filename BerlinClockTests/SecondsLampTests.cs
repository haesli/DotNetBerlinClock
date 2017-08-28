using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockTests
{
    [TestClass]
    public class SecondsLampTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SecondsLampConstructor_InvalidLowerPosition_ThrowsException()
        {
            new SecondsLamp(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SecondsLampConstructor_InvalidHigherPosition_ThrowsException()
        {
            new SecondsLamp(2);
        }

        [TestMethod]
        public void Process_EvenSeconds_IsSwitchedOnLightYellow()
        {
            var secondsLamp = new SecondsLamp(1);
            var time = new TimeSpan(12, 25, 0);
            secondsLamp.Process(time);
            Assert.AreEqual(true, secondsLamp.IsSwitchedOn);
            Assert.AreEqual("Y", secondsLamp.LightColour);
        }
        
        [TestMethod]
        public void Process_OddSeconds_IsSwitchedOffLightYellow()
        {
            var secondsLamp = new SecondsLamp(1);
            var time = new TimeSpan(12, 25, 7);
            secondsLamp.Process(time);
            Assert.AreEqual(false, secondsLamp.IsSwitchedOn);
            Assert.AreEqual("Y", secondsLamp.LightColour);
        }


        [TestMethod]
        public void ToString_SwitchedOn()
        {
            var secondsLamp = new SecondsLamp(1);
            var time = new TimeSpan(0, 0, 2);
            secondsLamp.Process(time);
            Assert.AreEqual("Y", secondsLamp.ToString());
        }

        [TestMethod]
        public void ToString_SwitchedOff()
        {
            var secondsLamp = new SecondsLamp(1);
            var time = new TimeSpan(0, 0, 1);
            secondsLamp.Process(time);
            Assert.AreEqual("O", secondsLamp.ToString());
        }
    }
}
