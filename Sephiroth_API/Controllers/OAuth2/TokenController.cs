using DotNetOpenAuth.OAuth2;
using Sephiroth_API.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Entity.Controllers.SystemAPI
{
    public class TokenController : ApiController
    {
        // POST /token
        public HttpResponseMessage AccessToken(HttpRequestMessage request)
        {
            var authServer = new AuthorizationServer(new OAuth2AuthorizationServer());
            var message = authServer.HandleTokenRequestAsync(request);
            return message.Result;
        }
    }
}
