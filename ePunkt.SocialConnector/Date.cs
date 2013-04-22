using System;

namespace ePunkt.SocialConnector
{
    public class Date
    {
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }

        public DateTime? GetDateIfPossible()
        {
            if (Day.HasValue && Month.HasValue & Year.HasValue)
                return new DateTime(Year.Value, Month.Value, Day.Value);
            return null;
        }

        public string GetMonthYearIfPossible()
        {
            if (Month.HasValue & Year.HasValue)
                return Month.Value + "-" + Year.Value;
            return null;
        }
    }
}
