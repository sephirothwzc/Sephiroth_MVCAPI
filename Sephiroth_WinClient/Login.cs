using APIFacade;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*************************************************************************************
    * CLR 版本：       4.0.30319.33440
    * 类 名 称：       Login
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Sephiroth_WinClient
    * 文 件 名：       Login
    * 创建时间：       15/5/17 09:33:36
    * 作    者：       吴占超
    * 说    明：       
    * 修改时间：
    * 修 改 人：
*************************************************************************************/

namespace Sephiroth_WinClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登陆按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Interface_BusinessAPI.Interface_SYS_User iuser = new SYS_User_APIFacade();
            SYS_User user = iuser.Login(this.UserCode.Text, this.PassWord.Text);
            if (user != null)
                MessageBox.Show("登陆成功！" + user.Id);
            else
                MessageBox.Show("登陆失败！");
        }


    }
}
