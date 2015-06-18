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
    * 类 名 称：       OAuth_Nonce
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_Nonce
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
    public class OAuth_Nonce_DAO : BaseDAO<OAuth_Nonce>
    {
        private Interface_ORM<OAuth_Nonce> dao = new Dapper_DAO<OAuth_Nonce>(CreateSYSDAO.GetSephiroth_System());


        public override Interface_ORM<OAuth_Nonce> absORM
        {
            get { return dao; }
            set { dao = value; }
        }

        //public int Insert(OAuth_Nonce oAuth_Nonce)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

