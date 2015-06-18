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
    * 类 名 称：       OAuth_Client
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_Client
    * 创建时间：       15/6/15 15:04:27
    * 作    者：       
    * 说    明：       
    * 修改时间：
    * 修 改 人：
*************************************************************************************/

namespace Entity.OAuth2.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("OAuth_Client")]
    public class OAuth_Client: BaseEntity
    {
        

        public const string CLIENTID = "ClientId"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("ClientId")]
        [MaxLength(50)]
        [Key]
        [Required]
        public string ClientId { get; set; }
        public const string CLIENTIDENTIFIER = "ClientIdentifier"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("ClientIdentifier")]
        [MaxLength(50)]
        public string ClientIdentifier { get; set; }
        public const string CLIENTSECRET = "ClientSecret"; 
        
        /// <summary>
        /// 密钥
        /// </summary>
        [Column("ClientSecret")]
        [MaxLength(50)]
        [DisplayName("密钥")]
        public string ClientSecret { get; set; }
        public const string CALLBACK = "Callback"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Callback")]
        [MaxLength(50)]
        public string Callback { get; set; }
        public const string NAME = "Name"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public const string CLIENTTYPE = "ClientType"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("ClientType")]
        [MaxLength(10)]
        public int? ClientType { get; set; }
        public const string SITEURL = "SiteUrl"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("SiteUrl")]
        [MaxLength(50)]
        public string SiteUrl { get; set; }
        public const string ACCOUNTNAME = "AccountName"; 
        
        /// <summary>
        /// 登陆名
        /// </summary>
        [Column("AccountName")]
        [MaxLength(50)]
        [DisplayName("登陆名")]
        public string AccountName { get; set; }
        public const string ACCOUNTPASSWORD = "AccountPassword"; 
        
        /// <summary>
        /// 登陆密码
        /// </summary>
        [Column("AccountPassword")]
        [MaxLength(50)]
        [DisplayName("登陆密码")]
        public string AccountPassword { get; set; }
        public const string ADDRESS = "Address"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Address")]
        [MaxLength(50)]
        public string Address { get; set; }
        public const string ISENABLED = "IsEnabled"; 
        
        /// <summary>
        /// 启用标识1正常0停用-1删除
        /// </summary>
        [Column("IsEnabled")]
        [MaxLength(10)]
        [DisplayName("启用标识1正常0停用-1删除")]
        public int? IsEnabled { get; set; }
    }
}

