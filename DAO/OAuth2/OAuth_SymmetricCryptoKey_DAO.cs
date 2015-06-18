using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Dapper;
using Entity;
using Entity.OAuth2.Models;
using Interface_ORM;

/*************************************************************************************
    * CLR 版本：       4.0.30319.33440
    * 类 名 称：       OAuth_SymmetricCryptoKey
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_SymmetricCryptoKey
    * 创建时间：       15/5/29 14:31:54
    * 作    者：       
    * 说    明：       
    * 修改时间：
    * 修 改 人：
*************************************************************************************/

namespace DAO
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuth_SymmetricCryptoKey_DAO : BaseDAO<OAuth_SymmetricCryptoKey>
    {
        private Interface_ORM<OAuth_SymmetricCryptoKey> dao = new Dapper_DAO<OAuth_SymmetricCryptoKey>(CreateSYSDAO.GetSephiroth_System());


        public override Interface_ORM<OAuth_SymmetricCryptoKey> absORM
        {
            get { return dao; }
            set { dao = value; }
        }

        //public IEnumerable<OAuth_SymmetricCryptoKey> Get(OAuth_SymmetricCryptoKey oAuth_SymmetricCryptoKey)
        //{
        //    return dao.Query(oAuth_SymmetricCryptoKey);
        //}

        ///// <summary>
        ///// Insert
        ///// </summary>
        ///// <param name="keyRow"></param>
        ///// <returns></returns>
        //public int Insert(OAuth_SymmetricCryptoKey keyRow)
        //{
        //    return dao.Insert(keyRow);
        //}

        public int Delete(string bucket, string handle)
        {
            return dao.Delete(new OAuth_SymmetricCryptoKey
            {
                Bucket = bucket,
                Handle = handle
            });
        }
    }
}

