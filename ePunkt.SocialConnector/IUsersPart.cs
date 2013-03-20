using System.Threading.Tasks;

namespace ePunkt.SocialConnector
{
    public interface IUsersPart
    {
        Task<IProfile> ForMe();
    }
}
