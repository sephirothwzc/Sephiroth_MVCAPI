using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Dapper;
using Entity;


/*************************************************************************************
    * CLR 版本：       4.0.30319.33440
    * 类 名 称：       SYS_User_DAO
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       DAO
    * 文 件 名：       SYS_User_DAO
    * 创建时间：       15/5/17 09:17:16
    * 作    者：       吴占超
    * 说    明：       
    * 修改时间：
    * 修 改 人：
*************************************************************************************/

namespace DAO
{
    public class SYS_User_DAO
    {
        private Dapper_DAO<SYS_User> dao = new Dapper_DAO<SYS_User>(CreateSYSDAO.GetSephiroth_System());
        public IEnumerable<SYS_User> Get()
        {
            return dao.Query();
        }
        
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="usercode">用户编码</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public SYS_User Login(string usercode, string password)
        {
            return dao.Query(new SYS_User() { Usercode = usercode, Password = password }).FirstOrDefault();
        }

        /// <summary>
        /// 根据主键获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SYS_User GetForId(string id)
        {
            return dao.Query(new SYS_User() { Id = id }).FirstOrDefault();
        }

        public bool Save(SYS_User user)
        {
            if (user.Id == null)
            {
                user.Id = BaseEntity.NewComb().ToString();
                return dao.Insert(user) > 0;
            }
            else
                return dao.Update(user) > 0;
        }

        public bool Delete(string id)
        {
            return dao.Delete(new SYS_User() { Id = id }) > 0;
        }
    }
}
