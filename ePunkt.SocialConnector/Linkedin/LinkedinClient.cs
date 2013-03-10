using System;
using System.Net.Http;

namespace ePunkt.SocialConnector.Linkedin
{
    public class LinkedinClient : IDisposable
    {
        public readonly HttpClient _client;

        public LinkedinClient(LinkedinConsumer consumer, string accessToken)
        {
            _client = new HttpClient(consumer.CreateAuthorizingHandler(accessToken, new HttpClientHandler()));

            People = new LinkedinClientPeoplePart(_client);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public LinkedinClientPeoplePart People { get; private set; }

    }
}
