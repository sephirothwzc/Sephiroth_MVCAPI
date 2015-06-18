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
    * 类 名 称：       OAuth_ClientAuthorization
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_ClientAuthorization
    * 创建时间：       15/5/29 14:31:53
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
    public class OAuth_ClientAuthorization_DAO : BaseDAO<OAuth_ClientAuthorization>
    {
        private Interface_ORM<OAuth_ClientAuthorization> dao = new Dapper_DAO<OAuth_ClientAuthorization>(CreateSYSDAO.GetSephiroth_System());

        public override Interface_ORM<OAuth_ClientAuthorization> absORM
        {
            get { return dao; }
            set { dao = value; }
        }

        /// <summary>
        /// 查询当前clientAuth 是否存在
        /// </summary>
        /// <param name="clientIdentifier"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public OAuth_ClientAuthorization Get_SaveClientAuthorization(string clientIdentifier, string userid)
        {
            string sql = string.Format(@"select a.* from {0} A INNER join
OAuth_Client B ON A.{1} = B.{2}
where  B.{3} = @ClientIdentifier and A.{4} = @UserId ", 
                                                      new OAuth_ClientAuthorization().TableName(), 
                                                      OAuth_ClientAuthorization.CLIENTID, 
                                                      OAuth_Client.CLIENTID, 
                                                      OAuth_Client.CLIENTIDENTIFIER, 
                                                      OAuth_ClientAuthorization.USERID);
            return dao.Query(sql, new { ClientIdentifier = clientIdentifier, UserId = userid }).FirstOrDefault();
        }
    }
}

