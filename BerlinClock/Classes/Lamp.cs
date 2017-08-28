using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public abstract class Lamp
    {
        public bool IsSwitchedOn { get; set; }
        public string LightColour { get; set; }
        protected string SwitchedOff { get; set; } = "O";        
        protected int Position { get; set; }
        protected Lamp(int position)
        {
            Position = position;
            Validate();
        }
        public abstract void Process(TimeSpan time);
        protected virtual void Validate()
        {

        }
        public override string ToString()
        {
            return IsSwitchedOn ? LightColour : SwitchedOff;
        }
    }    
}
