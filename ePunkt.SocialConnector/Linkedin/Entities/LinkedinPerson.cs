using System;

namespace ePunkt.SocialConnector.Linkedin.Entities
{
    public class LinkedinPerson : IProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PublicProfileUrl { get; set; }
        public string Id { get; set; }
        public string EmailAddress { get; set; }

        public string Identifier
        {
            get { return Id; }
        }

        public Uri Url
        {
            get { return new Uri(PublicProfileUrl); }
        }

        public string Email
        {
            get { return EmailAddress; }
        }
    }
}
