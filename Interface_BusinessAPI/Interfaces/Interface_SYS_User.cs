using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_BusinessAPI
{
    /// <summary>
    /// 用户_接口
    /// </summary>
    public interface Interface_SYS_User
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="UserCode">用户编码</param>
        /// <param name="PassWord">密码</param>
        /// <returns>登陆用户 null代表登陆失败</returns>
        SYS_User Login(string UserCode,string PassWord);
    }
}
