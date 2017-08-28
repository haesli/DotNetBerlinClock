using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class SecondsLamp : Lamp
    {
        public const int NumberOfLamps = 1;

        public SecondsLamp(int position) :
            base(position)
        {
            LightColour = "Y";
        }
        public override void Process(TimeSpan aTime)
        {
            IsSwitchedOn = aTime.Seconds % 2 == 0;
        }
        protected override void Validate()
        {
            if (Position < 1 || Position > NumberOfLamps)
                throw new ArgumentOutOfRangeException("Invalid lamp position is specified: {Position}");
        }
    }    
}
