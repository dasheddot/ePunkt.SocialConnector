using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace ePunkt.SocialConnector.Linkedin.Entities
{
    public class LinkedinPerson : IProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonProperty("DateOfBirth")]
        public Date BirthDate { get; set; }
        public string PublicProfileUrl { get; set; }
        public string PictureUrl { get; set; }
        public string Id { get; set; }
        public string EmailAddress { get; set; }
        public string MainAddress { get; set; }
        public string Summary { get; set; }
        public LinkedinPhoneNumbers PhoneNumbers { get; set; }
        public LinkedinPublications Publications { get; set; }
        public LinkedinLanguages Languages { get; set; }
        public LinkedinSkills Skills { get; set; }
        public LinkedinCertifications Certifications { get; set; }
        public LinkedinEducations Educations { get; set; }
        public LinkedinCourses Courses { get; set; }
        public LinkedinPositions Positions { get; set; }

        public Uri Url
        {
            get { return new Uri(PublicProfileUrl); }
        }

        public string Email
        {
            get { return EmailAddress; }
        }

        public Gender Gender
        {
            get { return Gender.NotSet; }
        }

        public string Address { get { return MainAddress; }}

        public string PhoneNubmer
        {
            get
            {
                if (PhoneNumbers.Values == null)
                    return "";

                var linkedinPhoneNumbers = PhoneNumbers.Values as LinkedinPhoneNumber[] ?? PhoneNumbers.Values.ToArray();

                if (linkedinPhoneNumbers.Any(x => x.PhoneType == "mobile"))
                {
                // ReSharper disable PossibleNullReferenceException
                    return linkedinPhoneNumbers.FirstOrDefault(x => x.PhoneType == "mobile").PhoneNumber;
                }
                if (linkedinPhoneNumbers.Any(x => x.PhoneType == "home"))
                {
                    return linkedinPhoneNumbers.FirstOrDefault(x => x.PhoneType == "home").PhoneNumber;
                }
                if (linkedinPhoneNumbers.Any(x => x.PhoneType == "work"))
                {
                    return linkedinPhoneNumbers.FirstOrDefault(x => x.PhoneType == "work").PhoneNumber;
                }
                // ReSharper restore PossibleNullReferenceException
                return "";
            }
        }

        
        string IProfile.PictureUrl { get { return PictureUrl;  } }

        public IEnumerable<IExperience> Experiences
        {
            get { return Positions.Values; }
        }

        public IEnumerable<IEducation> Education
        {
            get { return Educations.Values; }
        }

        public IEnumerable<string> AdditionalEducations
        {
            get { return Courses.Values.Select(x => x.Name).ToList(); }
        }

         IEnumerable<string> IProfile.Skills
        {
            get { return Skills.Values.Select(x => x.Skill.Name).ToList(); }
        }


        IEnumerable<ICertification> IProfile.Certifications
        {
            get { return Certifications.Values; }
        }

        IEnumerable<ILanguage> IProfile.Languages
        {
            get { return Languages.Values; }
        }

        IEnumerable<IPublication> IProfile.Publications
        {
            get { return Publications.Values; }
        }
    }
}
