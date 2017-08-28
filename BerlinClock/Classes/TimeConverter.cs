using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private Lamp[][] Rows { get; set; }

        public TimeConverter()
        {
            CreateLampRows();
        }

        public string ConvertTime(string aTime)
        {
            var time = ParseTime(aTime);
            var result = string.Empty;

            foreach (var row in Rows)
            {
                var rowStr = string.Empty;
                foreach (var lamp in row)
                {
                    lamp.Process(time);
                    rowStr += lamp.ToString();
                }
                result += rowStr + "\r\n";
            }
            return result.TrimEnd();
        }

        private void CreateLampRows()
        {
            Rows = new Lamp[5][];
            Rows[0] = new SecondsLamp[SecondsLamp.NumberOfLamps];
            Rows[0][0] = new SecondsLamp(1);

            Rows[1] = new HoursFirstRowLamp[HoursFirstRowLamp.NumberOfLamps];
            Rows[2] = new HoursSecondRowLamp[HoursSecondRowLamp.NumberOfLamps];

            for (var inx = 0; inx < HoursFirstRowLamp.NumberOfLamps; ++inx)
            {
                var position = inx + 1;
                Rows[1][inx] = new HoursFirstRowLamp(position);
                Rows[2][inx] = new HoursSecondRowLamp(position);
            }
            Rows[3] = new MinutesFirstRowLamp[MinutesFirstRowLamp.NumberOfLamps];
            for (var inx = 0; inx < MinutesFirstRowLamp.NumberOfLamps; ++inx)
            {
                Rows[3][inx] = new MinutesFirstRowLamp(inx + 1);
            }
            Rows[4] = new MinutesSecondRowLamp[MinutesSecondRowLamp.NumberOfLamps];
            for (var inx = 0; inx < MinutesSecondRowLamp.NumberOfLamps; ++inx)
            {
                Rows[4][inx] = new MinutesSecondRowLamp(inx + 1);
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
