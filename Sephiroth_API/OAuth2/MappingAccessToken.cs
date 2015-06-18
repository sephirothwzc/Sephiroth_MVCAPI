using DAO;
using DotNetOpenAuth.OAuth2;
using Entity.OAuth2.Models;
using Interface_Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sephiroth_API.OAuth2
{
    /// <summary>
    /// 验证token
    /// </summary>
    public class MappingAccessToken : AuthorizationServerAccessToken
    {
        /// <summary>
        /// token 序列化
        /// </summary>
        /// <returns></returns>
        protected override string Serialize()
        {
            DateTime? expirationDateUtc = null;
            if (this.Lifetime.HasValue)
            {
                DateTime expirationDate = this.UtcIssued + this.Lifetime.Value;
                expirationDateUtc = expirationDate.ToLocalTime();
            }
            var token = this.SaveClientAuthorization(this.ClientIdentifier, this.User, OAuthUtilities.JoinScopes(this.Scope), expirationDateUtc);
            return token;
        }

        /// <summary>
        /// 保存客户端auth 不存在则新增 存在则更新
        /// </summary>
        /// <param name="clientIdentifier">客户端主键</param>
        /// <param name="userid">用户主键</param>
        /// <param name="scope"></param>
        /// <param name="expirationDateUtc"></param>
        /// <returns></returns>
        private string SaveClientAuthorization(string clientIdentifier, string userid, string scope, DateTime? expirationDateUtc)
        {
            string token = Guid.NewGuid().ToString().ToUpper();
            OAuth_ClientAuthorization_DAO ca_DAO = new OAuth_ClientAuthorization_DAO();
            OAuth_ClientAuthorization clientAuth = ca_DAO.Get_SaveClientAuthorization(clientIdentifier, userid);
            if (clientAuth == null)
            {
                OAuth_Client client = new OAuth_Client_DAO().Get(new OAuth_Client { ClientIdentifier = clientIdentifier }).FirstOrDefault();
                if (client == null)
                    throw new Exception("不受信任的用户！");
                clientAuth = new OAuth_ClientAuthorization
                {
                    ClientId = client.ClientId,
                    CreatedOnUtc = DateTime.Now,
                    Scope = scope,
                    UserId = userid,
                    Token = token,
                    ExpirationDateUtc = expirationDateUtc
                };
                ca_DAO.Insert(clientAuth);
            }
            else
            {
                clientAuth.AuthorizationId = BaseEntity.NewComb().ToString();
                clientAuth.CreatedOnUtc = DateTime.Now;
                clientAuth.Scope = scope;
                clientAuth.Token = token;
                clientAuth.ExpirationDateUtc = expirationDateUtc;
                ca_DAO.Update(clientAuth);
            }
            return token;
            #region 旧版本注释
            //using (var db = new OAuthDbContext())
            //{
            //    var query = from auth in db.ClientAuthorizations
            //                from client in db.Clients
            //                where
            //                    auth.ClientId == client.ClientId && client.ClientIdentifier == clientIdentifier
            //                    && auth.UserId == userid
            //                select auth;
            //    var clientAuth = query.FirstOrDefault();
            //    if (clientAuth == null)
            //    {
            //        var client = db.Clients.FirstOrDefault(o => o.ClientIdentifier == clientIdentifier);
            //        if (client == null)
            //            throw new Exception("不受信任的商户！");

            //        clientAuth = new OAuth_ClientAuthorization
            //        {
            //            ClientId = client.ClientId,
            //            CreatedOnUtc = DateTime.Now,
            //            Scope = scope,
            //            UserId = userid,
            //            Token = token,
            //            ExpirationDateUtc = expirationDateUtc
            //        };
            //        db.ClientAuthorizations.Add(clientAuth);
            //    }
            //    else
            //    {
            //        clientAuth.CreatedOnUtc = DateTime.Now;
            //        clientAuth.Scope = scope;
            //        clientAuth.Token = token;
            //        clientAuth.ExpirationDateUtc = expirationDateUtc;
            //    }
            //    db.SaveChanges();
            //}

            //return token;
            #endregion 
        }
    }
}
