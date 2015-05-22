using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interface_Dapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*************************************************************************************
    * CLR 版本：       4.0.30319.33440
    * 类 名 称：       SYS_User
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       SYS_User
    * 创建时间：       15/5/16 10:46:47
    * 作    者：       
    * 说    明：       
    * 修改时间：
    * 修 改 人：
*************************************************************************************/

namespace Entity
{
    /// <summary>
    /// 系统用户
    /// </summary>
    //[Serializable]
    [Table("SYS_User")]
    public class SYS_User: BaseEntity
    {
        
        /// <summary>
        /// 主键Guid
        /// </summary>
        [Column("id")]
        [MaxLength(50)]
        [Key]
        [Required]
        [DisplayName("主键Guid")]
        public string Id { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("UserName")]
        [MaxLength(50)]
        [Required]
        [DisplayName("用户名")]
        public string Username { get; set; }
        
        /// <summary>
        /// 用户编码
        /// </summary>
        [Column("UserCode")]
        [MaxLength(50)]
        [Required]
        [DisplayName("用户编码")]
        public string Usercode { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        [Column("PassWord")]
        [MaxLength(50)]
        [DisplayName("密码")]
        public string Password { get; set; }
        
        /// <summary>
        /// 是否admin默认0
        /// </summary>
        [Column("iAdmin")]
        [MaxLength(1)]
        [DisplayName("是否admin默认0")]
        public bool? Iadmin { get; set; }
        
        /// <summary>
        /// 状态1正常0停用-1禁用
        /// </summary>
        [Column("nState")]
        [MaxLength(10)]
        [DisplayName("状态1正常0停用-1禁用")]
        public int? Nstate { get; set; }
        
        /// <summary>
        /// 最后修改密码时间
        /// </summary>
        [Column("dPasswordDate")]
        [MaxLength(23)]
        [DisplayName("最后修改密码时间")]
        public DateTime? Dpassworddate { get; set; }
        
        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("UserEmail")]
        [MaxLength(50)]
        [DisplayName("邮箱")]
        public string Useremail { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        [Column("UserTell")]
        [MaxLength(50)]
        [DisplayName("电话")]
        public string Usertell { get; set; }
    }
}

