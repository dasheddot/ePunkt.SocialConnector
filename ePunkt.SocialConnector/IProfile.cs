using System;

namespace ePunkt.SocialConnector
{
    public interface IProfile
    {
        string Identifier { get; }
        Uri Url { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        Gender Gender { get; }
    }
}
