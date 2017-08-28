using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class HoursFirstRowLamp : Lamp
    {
        public const int HoursPerLamp = 5;
        public const int NumberOfLamps = 4;
        public HoursFirstRowLamp(int position):
            base(position)
        {
            LightColour = "R";
        }
        public override void Process(TimeSpan time)
        {
            var hours = (int) time.TotalHours;            
            IsSwitchedOn = hours / HoursPerLamp >= Position;       
        }
        protected override void Validate()
        {
            if (Position < 1 || Position > NumberOfLamps)
                throw new ArgumentOutOfRangeException("Invalid lamp position is specified: {Position}");
        }
    }

    public class HoursSecondRowLamp : Lamp
    {
        public const int HoursPerLamp = 1;
        public const int NumberOfLamps = 4;
        public HoursSecondRowLamp(int position):
            base(position)
        {
            LightColour = "R";
        }
        public override void Process(TimeSpan time)
        {
            var hours = (int)time.TotalHours;
            IsSwitchedOn = hours % HoursFirstRowLamp.HoursPerLamp / HoursPerLamp >= Position;
        }
        protected override void Validate()
        {
            if (Position < 1 || Position > NumberOfLamps)
                throw new ArgumentOutOfRangeException("Invalid lamp position is specified: {Position}");
        }
    }
}
