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
    * 类 名 称：       OAuth_Nonce
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_Nonce
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
    [Table("OAuth_Nonce")]
    public class OAuth_Nonce: BaseEntity
    {
        

        public const string CONTEXT = "Context"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Context")]
        [MaxLength(50)]
        [Key]
        [Required]
        public string Context { get; set; }
        public const string CODE = "Code"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Code")]
        [MaxLength(50)]
        [Key]
        [Required]
        public string Code { get; set; }
        public const string TIMESTAMP = "Timestamp"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Timestamp")]
        [MaxLength(23)]
        [Key]
        [Required]
        public DateTime Timestamp { get; set; }
    }
}

