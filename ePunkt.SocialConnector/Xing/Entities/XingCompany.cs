using System;
using System.Globalization;
using Newtonsoft.Json;

namespace ePunkt.SocialConnector.Xing.Entities
{
    public class XingCompany : IExperience
    {
        [JsonProperty("end_date")]
        public string EndDateString { get; set; }
        public string Description { get; set; }
        [JsonProperty("company_size")]
        public string CompanySize { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        [JsonProperty("begin_date")]
        public string BeginDateString { get; set; }
        public string Industry { get; set; }
        public string Url { get; set; }
        [JsonProperty("career_level")]
        public string CareerLevel { get; set; }
        public string Name { get; set; }

        public Date EndDate { get { return ParseDateString(EndDateString); } }

        public Date StartDate { get { return ParseDateString(BeginDateString); } }

        public bool IsCurrent { get; set; }

        private Date ParseDateString(string dateString)
        {
            if (dateString == null)
            {
                return null;
            }

            try
            {
                var date = DateTime.ParseExact(dateString, new[] {"yyyy-MM", "yyyy-M", "yyyy", "yy"}, CultureInfo.InvariantCulture, DateTimeStyles.None);

                return new Date
                {
                    Month = dateString.Contains("-") ? (int?) date.Month : null,
                    Year = date.Year
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
