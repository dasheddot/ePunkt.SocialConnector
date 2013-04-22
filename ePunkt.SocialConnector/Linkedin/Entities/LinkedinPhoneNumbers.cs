using Newtonsoft.Json;
using System.Collections.Generic;

namespace ePunkt.SocialConnector.Linkedin.Entities
{
    public class LinkedinPhoneNumbers
    {
        [JsonProperty("_total")]
        public int Total { get; set; }

        public IEnumerable<LinkedinPhoneNumber> Values { get; set; }
    }
}