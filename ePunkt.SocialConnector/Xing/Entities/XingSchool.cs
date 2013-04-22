using Newtonsoft.Json;

namespace ePunkt.SocialConnector.Xing.Entities
{
    public class XingSchool : IEducation
    {
        public string Name { get; set; }
        [JsonProperty("subject")]
        public string FieldOfStudy { get; set; }
        public string Degree { get; set; }
        [JsonProperty("end_date")]
        public string EndDateString { get; set; }
        [JsonProperty("begin_date")]
        public string BeginDateString { get; set; }
        public string Notes { get; set; }


        public Date EndDate { get { return ParseDateString(EndDateString); } }
        public Date StartDate { get { return ParseDateString(BeginDateString); } }

        private Date ParseDateString(string dateString)
        {
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
