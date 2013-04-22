using System.Collections.Generic;
using Newtonsoft.Json;

namespace ePunkt.SocialConnector.Linkedin.Entities
{
    public class LinkedinLanguages
    {

        [JsonProperty("_total")]
        public int Total { get; set; }
        public IEnumerable<LinkedinLanguage> Values { get; set; }
    }
}
