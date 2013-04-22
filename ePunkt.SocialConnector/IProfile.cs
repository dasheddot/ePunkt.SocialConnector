﻿using System;
using System.Collections.Generic;

namespace ePunkt.SocialConnector
{
    public interface IProfile
    {
        string Id { get; }
        Uri Url { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        Gender Gender { get; }
        Date BirthDate { get; }
        string Address { get; }
        string PhoneNubmer { get; }
        string PictureUrl { get; }
        IEnumerable<IExperience> Experiences { get; }
        IEnumerable<IEducation> Education { get; }
        IEnumerable<string> AdditionalEducations { get; }
        IEnumerable<ICertification> Certifications { get; }
        IEnumerable<string> Skills { get; }
        IEnumerable<ILanguage> Languages { get; }
        IEnumerable<IPublication> Publications { get; }
        string Summary { get; }
    }
}
