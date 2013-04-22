using System.Collections.Generic;

namespace ePunkt.SocialConnector.Xing.Entities
{
    public class XingEducation
    {
        public IEnumerable<string> Qualifications { get; set; }

        public IEnumerable<XingSchool> Schools { get; set; }
    }
}
