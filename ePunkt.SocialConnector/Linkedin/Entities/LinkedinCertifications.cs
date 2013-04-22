using System.Collections.Generic;
using Newtonsoft.Json;

namespace ePunkt.SocialConnector.Linkedin.Entities
{
    public class LinkedinCertifications
    {

        [JsonProperty("_total")]
        public int Total { get; set; }
        public IEnumerable<LinkedinCertification> Values { get; set; }
    }
}
