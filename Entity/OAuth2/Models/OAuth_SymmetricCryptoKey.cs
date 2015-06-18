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
    * 类 名 称：       OAuth_SymmetricCryptoKey
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_SymmetricCryptoKey
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
    [Table("OAuth_SymmetricCryptoKey")]
    public class OAuth_SymmetricCryptoKey: BaseEntity
    {
        

        public const string BUCKET = "Bucket"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Bucket")]
        [MaxLength(50)]
        [Key]
        [Required]
        public string Bucket { get; set; }
        public const string HANDLE = "Handle"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Handle")]
        [MaxLength(50)]
        [Key]
        [Required]
        public string Handle { get; set; }
        public const string EXPIRESUTC = "ExpiresUtc"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("ExpiresUtc")]
        [MaxLength(23)]
        public DateTime? ExpiresUtc { get; set; }
        public const string SECRET = "Secret"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Secret")]
        [MaxLength(2147483647)]
        public byte[] Secret { get; set; }
    }
}

