﻿using Interface_BusinessAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
   * CLR 版本：       4.0.30319.33440
   * 类 名 称：       SYS_User_Facade
   * 机器名称：       SEPHIROTHBF0C
   * 命名空间：       Interface_BusinessAPI.Facade
   * 文 件 名：       SYS_User_Facade
   * 创建时间：       15/5/20 20:32:28
   * 作    者：       吴占超
   * 说    明：        
   * 修改时间：
   * 修 改 人：
  *************************************************************************************/

namespace APIFacade
{
    public class SYS_User_Facade:Interface_SYS_User
    {
        #region Interface_SYS_User 成员

        public Entity.SYS_User Login(string UserCode, string PassWord)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
