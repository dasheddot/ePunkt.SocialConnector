using System.Collections.Generic;
using ePunkt.SocialConnector.Xing.Entities;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ePunkt.SocialConnector.Xing
{
    public class XingClientUsersPart
    {
        private readonly HttpClient _client;

        public XingClientUsersPart(HttpClient client)
        {
            _client = client;
        }

        public async Task<XingUser> ForMe()
        {
            var users = await Load("me");
            return users.FirstOrDefault();
        }

        public async Task<IEnumerable<XingUser>> ForIds(params string[] ids)
        {
            return await Load(ids.Aggregate("", (seed, current) => seed + "," + current).Trim(','));
        }

        private async Task<IEnumerable<XingUser>> Load(string param)
        {
            var response = await _client.GetAsync("https://api.xing.com/v1/users/" + param + ".json");
            var users = await response.Content.ReadAsAsync<XingUserResponse>();
            return users.Users;
        }
    }
}
