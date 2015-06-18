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
    * 类 名 称：       SiteUser
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       SiteUser
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
    public class SiteUser_DAO : BaseDAO<SiteUser>
    {
        private Interface_ORM<SiteUser> dao = new Dapper_DAO<SiteUser>(CreateSYSDAO.GetSephiroth_System());

        public override Interface_ORM<SiteUser> absORM
        {
            get { return dao; }
            set { dao = value; }
        }
    }
}

