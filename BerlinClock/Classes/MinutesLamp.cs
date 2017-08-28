using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class MinutesFirstRowLamp : Lamp
    {
        public const int MinsPerLamp = 5;
        public const int NumberOfLamps = 11;
        public MinutesFirstRowLamp(int position):
            base(position)
        {
            LightColour = position % 3 == 0 ? "R" : "Y";
        }
        public override void Process(TimeSpan aTime)
        {
            IsSwitchedOn = aTime.Minutes / MinsPerLamp >= Position;
        }
        protected override void Validate()
        {
            if (Position < 1 || Position > NumberOfLamps)
                throw new ArgumentOutOfRangeException("Invalid lamp position is specified: {Position}");
        }
    }
    
    public class MinutesSecondRowLamp : Lamp
    {
        public const int MinsPerLamp = 1;
        public const int NumberOfLamps = 4;
        public MinutesSecondRowLamp(int position) :
            base(position)
        {
            LightColour = "Y";
        }
        public override void Process(TimeSpan aTime)
        {
            IsSwitchedOn = aTime.Minutes % MinutesFirstRowLamp.MinsPerLamp / MinsPerLamp >= Position;
        }
        protected override void Validate()
        {
            if (Position < 1 || Position > NumberOfLamps)
                throw new ArgumentOutOfRangeException("Invalid lamp position is specified: {Position}");
        }
    }
}
