using DAO;
using DotNetOpenAuth.Messaging.Bindings;
using Entity.OAuth2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Sephiroth_API.OAuth2
{
    /// <summary>
    /// OAuth 验证加密类
    /// </summary>
    public class DatabaseKeyNonceStore : INonceStore, ICryptoKeyStore
    {
        private Dictionary<string, string> _dicContext = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseKeyNonceStore"/> class.
        /// </summary>
        public DatabaseKeyNonceStore()
        {
        }

        #region INonceStore Members

        public bool StoreNonce(string context, string nonce, DateTime timestampUtc)
        {
            if (!_dicContext.ContainsKey(context))
                _dicContext.Add(context, this.ToMD5String(context));

            try
            {
                return new OAuth_Nonce_DAO().Insert(new OAuth_Nonce
                {
                    Context = _dicContext[context],
                    Code = nonce,
                    Timestamp = timestampUtc
                }) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
            #region 吴占超 旧版本注释
            //using (var db = new OAuthDbContext())
            //{
            //    db.Nonces.Add(new OAuth_Nonce { Context = _dicContext[context], Code = nonce, Timestamp = timestampUtc });
            //    try
            //    {
            //        db.SaveChanges();
            //        return true;
            //    }
            //    catch (SqlException)
            //    {
            //        return false;
            //    }
            //    catch (Exception e)
            //    {
            //        return false;
            //    }
            //}
            #endregion 
        }

        #endregion

        private string ToMD5String(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.Unicode.GetBytes(str);
            byte[] toData = md5.ComputeHash(fromData);
            string byteStr = null;
            for (int i = 0; i < toData.Length; i++)
            {
                byteStr += toData[i].ToString("x");
            }
            return byteStr;
        }

        #region ICryptoKeyStore Members

        public CryptoKey GetKey(string bucket, string handle)
        {
            OAuth_SymmetricCryptoKey matches = new OAuth_SymmetricCryptoKey_DAO().Get(new OAuth_SymmetricCryptoKey { Bucket = bucket, Handle = handle }).FirstOrDefault();
            return new CryptoKey(matches.Secret, this.AsUtc(Convert.ToDateTime(matches.ExpiresUtc)));
            #region 吴占超 旧版本注释
            //using (var db = new OAuthDbContext())
            //{
            //    // It is critical that this lookup be case-sensitive, which can only be configured at the database.
            //    var matches = from key in db.SymmetricCryptoKeys
            //                  where key.Bucket == bucket && key.Handle == handle
            //                  select key;

            //    var k = matches.FirstOrDefault();
            //    return new CryptoKey(k.Secret, this.AsUtc(k.ExpiresUtc));
            //}
            #endregion 
        }

        public IEnumerable<KeyValuePair<string, CryptoKey>> GetKeys(string bucket)
        {
            var query = new OAuth_SymmetricCryptoKey_DAO().Get(new OAuth_SymmetricCryptoKey { 
                Bucket = bucket
            }).OrderByDescending(key=>key.ExpiresUtc).ToList();
            return query.Select(k => new KeyValuePair<string, CryptoKey>(k.Handle,new CryptoKey(k.Secret,this.AsUtc(Convert.ToDateTime(k.ExpiresUtc)))));
            //using (var db = new OAuthDbContext())
            //{
            //    var query = from key in db.SymmetricCryptoKeys
            //                where key.Bucket == bucket
            //                orderby key.ExpiresUtc descending
            //                select key;
            //    var keys = query.ToList();
            //    return keys.Select(k => new KeyValuePair<string, CryptoKey>(k.Handle, new CryptoKey(k.Secret, this.AsUtc(k.ExpiresUtc))));
            //}
        }

        public void StoreKey(string bucket, string handle, CryptoKey key)
        {
            var keyRow = new OAuth_SymmetricCryptoKey()
            {
                Bucket = bucket,
                Handle = handle,
                Secret = key.Key,
                ExpiresUtc = key.ExpiresUtc,
            };
            new OAuth_SymmetricCryptoKey_DAO().Insert(keyRow);
            //using (var db = new OAuthDbContext())
            //{
            //    db.SymmetricCryptoKeys.Add(keyRow);
            //    db.SaveChanges();
            //}
        }

        public void RemoveKey(string bucket, string handle)
        {
            new OAuth_SymmetricCryptoKey_DAO().Delete(bucket, handle);
            //using (var db = new OAuthDbContext())
            //{
            //    var match = db.SymmetricCryptoKeys.FirstOrDefault(k => k.Bucket == bucket && k.Handle == handle);
            //    if (match != null)
            //    {
            //        db.SymmetricCryptoKeys.Remove(match);
            //        db.SaveChanges();
            //    }
            //}
        }

        #endregion

        /// <summary>
        /// Ensures that local times are converted to UTC times.  Unspecified kinds are recast to UTC with no conversion.
        /// </summary>
        /// <param name="value">The date-time to convert.</param>
        /// <returns>The date-time in UTC time.</returns>
        DateTime AsUtc(DateTime value)
        {
            if (value.Kind == DateTimeKind.Unspecified)
            {
                return new DateTime(value.Ticks, DateTimeKind.Utc);
            }

            return value.ToUniversalTime();
        }
    }
}