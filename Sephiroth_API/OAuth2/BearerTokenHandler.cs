using DotNetOpenAuth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Sephiroth_API.OAuth2
{
    /// <summary>
    /// 拦截信息
    /// </summary>
    public class BearerTokenHandler : DelegatingHandler
    {
        /// <summary>
        /// 验证访问令牌合法性，由授权服务器私钥签名，资源服务器通过对应的公钥验证
        /// </summary>
        private static readonly RSAParameters AuthorizationServerSigningPublicKey = new RSAParameters();//just a 例子

        private RSACryptoServiceProvider CreateAuthorizationServerSigningServiceProvider()
        {
            var authorizationServerSigningServiceProvider = new RSACryptoServiceProvider();
            authorizationServerSigningServiceProvider.ImportParameters(AuthorizationServerSigningPublicKey);
            return authorizationServerSigningServiceProvider;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization != null)
            {
                if (request.Headers.Authorization.Scheme == "Bearer")
                {
                    var resourceServer = new ResourceServer(new StandardAccessTokenAnalyzer(this.CreateAuthorizationServerSigningServiceProvider(), null));
                    var principal = resourceServer.GetPrincipalAsync(request);//可以在此传入待访问资源标识参与验证
                    HttpContext.Current.User = principal.Result;
                    Thread.CurrentPrincipal = principal.Result;
                }
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}