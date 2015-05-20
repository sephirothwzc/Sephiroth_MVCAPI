using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
   * CLR 版本：       4.0.30319.33440
   * 类 名 称：       SYS_User_APIFacade
   * 机器名称：       SEPHIROTHBF0C
   * 命名空间：       Interface_BusinessAPI
   * 文 件 名：       SYS_User_APIFacade
   * 创建时间：       15/5/20 20:34:52
   * 作    者：       吴占超
   * 说    明：        
   * 修改时间：
   * 修 改 人：
  *************************************************************************************/

namespace APIFacade
{
    public class SYS_User_APIFacade:Interface_BusinessAPI.Interface_SYS_User
    {
        #region Interface_SYS_User 成员

        public Entity.SYS_User Login(string UserCode, string PassWord)
        {
            return HttpClient_Helper.DoPost<Entity.SYS_User>("Login", new Dictionary<string, string> { 
                {"Usercode",UserCode},
                {"Password",PassWord}
            });
        }

        #endregion
    }
}
