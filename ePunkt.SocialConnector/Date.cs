using System;

namespace ePunkt.SocialConnector
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public DateTime? GetDateIfPossible()
        {
            if (Day != 0 && Month != 0 & Year != 0)
            {
                return new DateTime(Year, Month, Day);
            }
            return null;
        }

        public string GetMonthYearIfPossible()
        {
            if (Month != 0 & Year != 0)
            {
                return Month + "-" + Year;
            }
            return null;
        }
    }
}
