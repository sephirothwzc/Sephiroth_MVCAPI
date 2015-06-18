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
    * 类 名 称：       OAuth_Client
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_Client
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
    public class OAuth_Client_DAO : BaseDAO<OAuth_Client>
    {
        private Interface_ORM<OAuth_Client> dao = new Dapper_DAO<OAuth_Client>(CreateSYSDAO.GetSephiroth_System());

        public override Interface_ORM<OAuth_Client> absORM
        {
            get { return dao; }
            set { dao = value; }
        }


        //public IEnumerable<OAuth_Client> Get(OAuth_Client oc)
        //{
        //    return dao.Query(oc);
        //}

        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool Exists(OAuth_Client client)
        {
            string sql = string.Format("select count(*) from {3} where {0} <> @{0} and ({1} = @{1} or {2}=@{2})",
                OAuth_Client.CLIENTID, OAuth_Client.CLIENTIDENTIFIER,
                OAuth_Client.NAME,client.TableName());
            return dao.QueryDynamic(sql, client).FirstOrDefault() != null;

        }

        /// <summary>
        /// 保存client clientid存在更新不存在 修改
        /// </summary>
        /// <param name="client"></param>
        public void Save(OAuth_Client client)
        {
            if (client.ClientId == string.Empty)
                this.Insert(client);
            else
                this.Update(client);
        }

        public bool Create(OAuth_Client client)
        {
            var tempclient = this.Query(client, paramwhere: string.Format("{0} = @{0} or {1} = @{1}", OAuth_Client.CLIENTIDENTIFIER,OAuth_Client.NAME)).FirstOrDefault();
            if (tempclient != null)
            { 
                return 
            }
        }
    }
}

