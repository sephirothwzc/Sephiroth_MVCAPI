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
    * 类 名 称：       OAuth_ClientOpenApi
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_ClientOpenApi
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
    public class OAuth_ClientOpenApi_DAO : BaseDAO<OAuth_ClientOpenApi>
    {
        private Interface_ORM<OAuth_ClientOpenApi> dao = new Dapper_DAO<OAuth_ClientOpenApi>(CreateSYSDAO.GetSephiroth_System());


        public override Interface_ORM<OAuth_ClientOpenApi> absORM
        {
            get { return dao; }
            set { dao = value; }
        }
    }
}

