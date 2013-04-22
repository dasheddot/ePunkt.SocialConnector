﻿using Newtonsoft.Json;

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
                return null;

            var date = dateString.Trim().Split('-');
            var newDate = new Date();
            foreach (var elem in date)
            {
                if (elem.Length == 4)
                {
                    int year = int.TryParse(elem, out year) ? year : 0;
                    newDate.Year = year;
                }
                if (elem.Length <= 2)
                {
                    int day = int.TryParse(elem, out day) ? day : 0;
                    newDate.Day = day;
                }
            }
            return newDate;
        }
    }
}
