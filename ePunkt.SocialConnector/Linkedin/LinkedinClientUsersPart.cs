using ePunkt.SocialConnector.Linkedin.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace ePunkt.SocialConnector.Linkedin
{
    public class LinkedinClientUsersPart : IUsersPart
    {
        private readonly HttpClient _client;

        public LinkedinClientUsersPart(HttpClient client)
        {
            _client = client;
        }

        public async Task<LinkedinPerson> ForMe()
        {
            var response = await _client.GetAsync("http://api.linkedin.com/v1/people/~:(id,first-name,last-name,email-address,public-profile-url)?format=json");
            //var content = await response.Content.ReadAsStringAsync();
            var person = await response.Content.ReadAsAsync<LinkedinPerson>();
            return person;
        }

        #region IUsersPart interface
        async Task<IProfile> IUsersPart.ForMe()
        {
            return await ForMe();
        }
        #endregion
    }
}
