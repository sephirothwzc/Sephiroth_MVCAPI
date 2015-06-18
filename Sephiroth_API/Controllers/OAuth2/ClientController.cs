using DAO;
using Entity.OAuth2;
using Entity.OAuth2.Models;
using Interface_Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Entity.Controllers.OAuth2
{
    public class ClientController : ApiController
    {
        public IEnumerable<OAuth_Client> GetClients()
        {
            return new OAuth_Client_DAO().Query();

            //using (var db = new OAuthDbContext())
            //{
            //    var clients = db.Clients.ToArray();
            //    return clients;
            //}
        }

        public OAuth_Client GetAccountClient(string accountName)
        {
            return new OAuth_Client_DAO().Query(new OAuth_Client { AccountName = accountName }).FirstOrDefault();
            //using (var db = new OAuthDbContext())
            //{
            //    var client = db.Clients.FirstOrDefault(o => o.AccountName == accountName);
            //    return client;
            //}
        }

        //change information
        [AcceptVerbs("POST")]
        public OPResult Update(OAuth_Client client)
        {
            OAuth_Client_DAO dao = new OAuth_Client_DAO();
            bool exists = dao.Exists(client);
            if (exists)
                return new OPResult { IsSucceed = false, Message = "已存在相同名称或相同标识的其它商户" };
            try
            {
                dao.Save(client);
            }
            catch (Exception e)
            {
                return new OPResult { IsSucceed = false, Message = e.Message };
            }
            return new OPResult { IsSucceed = true };

            #region 旧版本注释
            //using (var db = new OAuthDbContext())
            //{
            //    var exists = db.Clients.Any(o => o.ClientId != client.ClientId && (o.ClientIdentifier == client.ClientIdentifier || client.Name == o.Name));
            //    if (exists)
            //    {
            //        return new OPResult { IsSucceed = false, Message = "已存在相同名称或相同标识的其它商户" };
            //    }
            //    db.Entry(client).State = EntityState.Modified;
            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        return new OPResult { IsSucceed = false, Message = e.Message };
            //    }
            //}
            //return new OPResult { IsSucceed = true };
            #endregion 
        }

        [AcceptVerbs("DELETE")]
        public OPResult Delete(string clientId)
        {

            try
            {
                new OAuth_ClientAuthorization_DAO().Delete(new OAuth_ClientAuthorization { ClientId = clientId });
                new OAuth_Client_DAO().Delete(new OAuth_Client { ClientId = clientId });
            }
            catch (Exception e)
            {
                return new OPResult { IsSucceed = false, Message = e.Message };
            }
            return new OPResult { IsSucceed = true };

            #region 
            //using (var db = new OAuthDbContext())
            //{
            //    using (TransactionScope scope = new TransactionScope())
            //    {
            //        var auths = db.ClientAuthorizations.Where(o => o.ClientId == clientId).ToArray();
            //        var client = db.Clients.Find(clientId);
            //        db.ClientAuthorizations.RemoveRange(auths);
            //        db.Clients.Remove(client);
            //        try
            //        {
            //            db.SaveChanges();
            //            scope.Complete();
            //        }
            //        catch (Exception e)
            //        {
            //            return new OPResult { IsSucceed = false, Message = e.Message };
            //        }
            //    }
            //}
            //return new OPResult { IsSucceed = true };
            #endregion
        }

        [AcceptVerbs("POST")]
        public OPResult Create(OAuth_Client client)
        {
            OAuth_Client_DAO dao = new OAuth_Client_DAO();
            try
            {
                var tempclient = dao.Query(client, paramwhere: string.Format("{0} = @{0} or {1} = @{1}", OAuth_Client.CLIENTIDENTIFIER, OAuth_Client.NAME)).FirstOrDefault();

                if (tempclient != null)
                {
                    if (tempclient.ClientIdentifier == client.ClientIdentifier)
                        return new OPResult { IsSucceed = false, Message = "已存在相同标识的商户" };
                    else
                        return new OPResult { IsSucceed = false, Message = "已存在相同名称的商户" };
                }
                dao.Insert(client);
            }
            catch (Exception e)
            {
                return new OPResult { IsSucceed = false, Message = e.Message };
            }

            return new OPResult<string> { IsSucceed = true, Result = client.ClientId };
            //using (var db = new OAuthDbContext())
            //{
            //    var c = db.Clients.FirstOrDefault(o => o.ClientIdentifier == client.ClientIdentifier || client.Name == o.Name);
            //    if (c != null)
            //    {
            //        if (c.ClientIdentifier == client.ClientIdentifier)
            //            return new OPResult { IsSucceed = false, Message = "已存在相同标识的商户" };
            //        else
            //            return new OPResult { IsSucceed = false, Message = "已存在相同名称的商户" };
            //    }
            //    client = db.Clients.Add(client);
            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        return new OPResult { IsSucceed = false, Message = e.Message };
            //    }
            //}
            //return new OPResult<int> { IsSucceed = true, Result = client.ClientId };
        }

        public IEnumerable<OAuth_ClientOpenApi> GetClientApis(string clientId)
        {
            OAuth_ClientOpenApi_DAO oco = new OAuth_ClientOpenApi_DAO();
            return oco.Query(new OAuth_ClientOpenApi { ClientId = clientId }).ToArray();

            //using (var db = new OAuthDbContext())
            //{
            //    var apis = db.ClientOpenApis.Where(o => o.ClientId == clientId).ToArray();
            //    return apis;
            //}
        }

        //get api authority
        public HttpResponseMessage GetApis()
        {
            var httpClient = new HttpClient();
            using (var resourceResponse = httpClient.GetAsync(MvcApplication.OpenApiAddress))
            {
                return resourceResponse.Result;
            }
        }

        [AcceptVerbs("POST")]
        public OPResult SaveClientAPIs(int clientId, IEnumerable<string> apis)
        {
            using (var db = new OAuthDbContext())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var capis = db.ClientOpenApis.Where(o => o.ClientId == clientId).ToArray();
                    db.ClientOpenApis.RemoveRange(capis);
                    foreach (var api in apis)
                    {
                        db.ClientOpenApis.Add(new OAuth_ClientOpenApi { ClientId = clientId, OpenApi = api });
                    }
                    try
                    {
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new OPResult { IsSucceed = false, Message = e.Message };
                    }
                }
            }
            return new OPResult { IsSucceed = true };
        }
    }
}
