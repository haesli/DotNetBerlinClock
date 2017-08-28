using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class Clock : ITimeConverter
    {
        private Lamp[][] LampRows { get; set; }

        public Clock()
        {
            CreateLamps();
        }

        public string ConvertTime(string aTime)
        {
            var time = ParseTime(aTime);
            var result = string.Empty;

            foreach (var lampRow in LampRows)
            {
                var rowStr = string.Empty;
                foreach (var lamp in lampRow)
                {
                    lamp.Process(time);
                    rowStr += lamp.ToString();
                }
                result += rowStr + "\r\n";
            }
            return result.TrimEnd();
        }

        private void CreateLamps()
        {
            LampRows = new Lamp[5][];
            LampRows[0] = new SecondsLamp[SecondsLamp.NumberOfLamps];
            LampRows[0][0] = new SecondsLamp(1);

            LampRows[1] = new HoursFirstRowLamp[HoursFirstRowLamp.NumberOfLamps];
            LampRows[2] = new HoursSecondRowLamp[HoursSecondRowLamp.NumberOfLamps];

            for (var inx = 0; inx < HoursFirstRowLamp.NumberOfLamps; ++inx)
            {
                var position = inx + 1;
                LampRows[1][inx] = new HoursFirstRowLamp(position);
                LampRows[2][inx] = new HoursSecondRowLamp(position);
            }
            LampRows[3] = new MinutesFirstRowLamp[MinutesFirstRowLamp.NumberOfLamps];
            for (var inx = 0; inx < MinutesFirstRowLamp.NumberOfLamps; ++inx)
            {
                LampRows[3][inx] = new MinutesFirstRowLamp(inx + 1);
            }
            LampRows[4] = new MinutesSecondRowLamp[MinutesSecondRowLamp.NumberOfLamps];
            for (var inx = 0; inx < MinutesSecondRowLamp.NumberOfLamps; ++inx)
            {
                LampRows[4][inx] = new MinutesSecondRowLamp(inx + 1);
            }
        }
        private TimeSpan ParseTime(string timeStr)
        {
            TimeSpan time;
            bool result = true;

            if (timeStr == "24:00:00" || timeStr == "24:00")
                time = new TimeSpan(1, 0, 0, 0);
            else
                result = TimeSpan.TryParseExact(timeStr, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out time);

            if (!result)
                throw new ArgumentException("Invalid time specified");

            if (time.TotalHours > 24)
                throw new ArgumentException("Invalid hours specified");

            return time;
        }        
    }
}
