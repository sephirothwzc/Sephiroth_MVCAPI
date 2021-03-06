﻿using DAO;
using DotNetOpenAuth.OAuth2;
using Entity.OAuth2.Models;
using Sephiroth_API.OAuth2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sephiroth_API.Controllers
{
    public class OAuthController : Controller
    {
        private static string _authorizeUrl = ConfigurationManager.AppSettings["AuthorizeUrl"];
        private static string[] _queryParameters = new string[] { "client_id", "redirect_uri", "state", "response_type", "scope" };
        private readonly AuthorizationServer _authorizationServer = new AuthorizationServer(new OAuth2AuthorizationServer());

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Authorize(string userkey)
        {
            //var pendingRequest = this._authorizationServer.ReadAuthorizationRequest(Request);
            //吴占超 采用5.0异步
            var pendingRequest = this._authorizationServer.ReadAuthorizationRequestAsync(Request).Result;

            if (pendingRequest == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Missing authorization request.");
            }

            if (string.IsNullOrEmpty(userkey))
            {
                string url = _authorizeUrl, callback = Request.Url.GetLeftPart(UriPartial.Path);
                StringBuilder querystring = new StringBuilder(string.Format("client_id={0}&", HttpUtility.UrlEncode(this.Request.QueryString["client_id"]))), callbackQuery = new StringBuilder();
                foreach (string key in this.Request.QueryString.Keys)
                {
                    if (!_queryParameters.Contains(key))
                        querystring.Append(string.Format("{0}={1}&", key, HttpUtility.UrlEncode(this.Request.QueryString[key])));
                    else
                        callbackQuery.Append(string.Format("{0}={1}&", key, HttpUtility.UrlEncode(this.Request.QueryString[key])));
                }
                if (callbackQuery.Length > 0)
                {
                    callback += ("?" + callbackQuery.ToString().TrimEnd('&'));
                    querystring.Append(string.Format("callback={0}&", HttpUtility.UrlEncode(callback)));
                }
                if (querystring.Length > 0)
                {
                    url += ("?" + querystring.ToString().TrimEnd('&'));
                }
                return Redirect(url);
            }
            else
            {
                OAuth_Client client = new OAuth_Client_DAO().Get(new OAuth_Client { ClientIdentifier = pendingRequest.ClientIdentifier }).FirstOrDefault();
                if (client == null)
                    throw new Exception("不受信任的用户！");
                else
                {
                    var user = DESCrypt.Decrypt(userkey, client.ClientSecret);
                    var approval = this._authorizationServer.PrepareApproveAuthorizationRequest(pendingRequest, user);
                    var response = this._authorizationServer.Channel.PrepareResponseAsync(approval).Result;
                    //*特别注意断点测试
                    return Content(response.Content.ToString());
                }
                #region 吴占超 旧版本注释
                //using (var db = new OAuthDbContext())
                //{
                //    var client = db.Clients.FirstOrDefault(o => o.ClientIdentifier == pendingRequest.ClientIdentifier);
                //    if (client == null)
                //        throw new Exception("不受信任的商户");
                //    else
                //    {
                //        var user = DESCrypt.Decrypt(userkey, client.ClientSecret);
                //        var approval = this._authorizationServer.PrepareApproveAuthorizationRequest(pendingRequest, user);
                //        var response = this._authorizationServer.Channel.PrepareResponse(approval);
                //        return response.AsActionResult();
                //    }
                //}
                #endregion
            }
        }

        public ActionResult Index()
        {
            ViewBag.Body = "Welcome To OAuth2.0";
            return View();
        }
    }
}