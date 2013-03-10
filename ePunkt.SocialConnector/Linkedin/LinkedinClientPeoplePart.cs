using ePunkt.SocialConnector.Linkedin.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace ePunkt.SocialConnector.Linkedin
{
    public class LinkedinClientPeoplePart
    {
        private readonly HttpClient _client;

        public LinkedinClientPeoplePart(HttpClient client)
        {
            _client = client;
        }

        public async Task<LinkedinPerson> ForMe()
        {
            var response = await _client.GetAsync("http://api.linkedin.com/v1/people/~:(first-name,last-name,positions,email-address)?format=json");
            var person = await response.Content.ReadAsAsync<LinkedinPerson>();
            return person;
        }
    }
}
