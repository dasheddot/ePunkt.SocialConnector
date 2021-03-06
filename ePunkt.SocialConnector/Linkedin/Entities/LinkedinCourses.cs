﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace ePunkt.SocialConnector.Linkedin.Entities
{
    public class LinkedinCourses
    {
        [JsonProperty("_total")]
        public int Total { get; set; }
        public IEnumerable<LinkedinCourse> Values { get; set; }
    }
}
