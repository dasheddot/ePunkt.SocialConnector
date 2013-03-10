using System.Net.Http;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.ChannelElements;
using ePunkt.Utilities;
using System.Web;
using System.Web.Mvc;

namespace ePunkt.SocialConnector.Xing
{
    public class XingConsumer
    {
        private readonly WebConsumer _consumer;

        public XingConsumer(ITokenManager tokenManager)
        {
            _consumer = new WebConsumer(GetServiceProviderDescription(), new TokenManager(tokenManager));
        }

        private ServiceProviderDescription GetServiceProviderDescription()
        {
            return new ServiceProviderDescription
                {
                    RequestTokenEndpoint = new MessageReceivingEndpoint("https://api.xing.com/v1/request_token", HttpDeliveryMethods.PostRequest),
                    UserAuthorizationEndpoint = new MessageReceivingEndpoint("https://api.xing.com/v1/authorize", HttpDeliveryMethods.GetRequest),
                    AccessTokenEndpoint = new MessageReceivingEndpoint("https://api.xing.com/v1/access_token", HttpDeliveryMethods.GetRequest),
                    TamperProtectionElements = new ITamperProtectionChannelBindingElement[] {new HmacSha1SigningBindingElement()}
                };
        }

        public ActionResult ProcessAuthorization(HttpRequestBase httpRequest, string redirectOnSuccess, out string accessToken)
        {
            accessToken = null;

            if (httpRequest["oauth_token"].HasValue())
            {
                accessToken = _consumer.ProcessUserAuthorization().AccessToken;
                return new RedirectResult(redirectOnSuccess);
            }

            var request = _consumer.PrepareRequestUserAuthorization();
            return _consumer.Channel.PrepareResponse(request).AsActionResult();
        }

        public XingClient GetClient(string accessToken)
        {
            return new XingClient(this, accessToken);
        }

        internal DelegatingHandler CreateAuthorizingHandler(string accessToken, HttpMessageHandler innerHandler)
        {
            return _consumer.CreateAuthorizingHandler(accessToken, innerHandler);
        }
    }
}