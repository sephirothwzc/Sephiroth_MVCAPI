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
    * 类 名 称：       OAuth_ClientAuthorization
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_ClientAuthorization
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
    [Table("OAuth_ClientAuthorization")]
    public class OAuth_ClientAuthorization: BaseEntity
    {
        

        public const string AUTHORIZATIONID = "AuthorizationId"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("AuthorizationId")]
        [MaxLength(50)]
        [Key]
        [Required]
        public string AuthorizationId { get; set; }
        public const string TOKEN = "Token"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Token")]
        [MaxLength(50)]
        public string Token { get; set; }
        public const string CREATEDONUTC = "CreatedOnUtc"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("CreatedOnUtc")]
        [MaxLength(23)]
        public DateTime? CreatedOnUtc { get; set; }
        public const string CLIENTID = "ClientId"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("ClientId")]
        [MaxLength(50)]
        public string ClientId { get; set; }
        public const string USERID = "UserId"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("UserId")]
        [MaxLength(50)]
        public string UserId { get; set; }
        public const string SCOPE = "Scope"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Scope")]
        [MaxLength(50)]
        public string Scope { get; set; }
        public const string EXPIRATIONDATEUTC = "ExpirationDateUtc"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("ExpirationDateUtc")]
        [MaxLength(23)]
        public DateTime? ExpirationDateUtc { get; set; }
    }
}

