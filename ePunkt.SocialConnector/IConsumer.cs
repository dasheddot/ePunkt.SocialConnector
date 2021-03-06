﻿using System.Web;
using System.Web.Mvc;

namespace ePunkt.SocialConnector
{
    public interface IConsumer
    {
        ActionResult ProcessAuthorization(HttpRequestBase httpRequest, string redirectOnSuccess, out string accessToken);
        IClient GetClient(string accessToken);
    }
}
