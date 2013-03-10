using Newtonsoft.Json;

namespace ePunkt.SocialConnector.Xing.Entities
{
    public class XingCompany
    {
        [JsonProperty("end_date")]
        public string EndDate { get; set; }
        public string Description { get; set; }
        [JsonProperty("company_size")]
        public string CompanySize { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        [JsonProperty("begin_date")]
        public string BeginDate { get; set; }
        public string Industry { get; set; }
        public string Url { get; set; }
        [JsonProperty("career_level")]
        public string CareerLevel { get; set; }
        public string Name { get; set; }
    }
}
