using System;
using System.Net.Http;

namespace ePunkt.SocialConnector.Xing
{
    public class XingClient : IDisposable
    {
        private readonly HttpClient _client;

        public XingClient(XingConsumer consumer, string accessToken)
        {
            _client = new HttpClient(consumer.CreateAuthorizingHandler(accessToken, new HttpClientHandler()));
            Users = new XingClientUsersPart(_client);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public XingClientUsersPart Users { get; private set; }
    }
}
