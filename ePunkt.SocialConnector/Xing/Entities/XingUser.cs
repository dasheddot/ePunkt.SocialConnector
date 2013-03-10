using Newtonsoft.Json;
using System;

namespace ePunkt.SocialConnector.Xing.Entities
{
    public class XingUser
    {
        public string Id { get; set; }
        public string Gender { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("active_email")]
        public string Email { get; set; }

        public Uri PermaLink { get; set; }

        [JsonProperty("private_address")]
        public XingAddress PrivateAddress { get; set; }

        [JsonProperty("business_address")]
        public XingAddress BusinessAddress { get; set; }

        [JsonProperty("professional_experience")]
        public XingExperience Experience { get; set; }

    }

}
