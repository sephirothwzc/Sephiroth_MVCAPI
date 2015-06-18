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
    * 类 名 称：       OAuth_ClientOpenApi
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       OAuth_ClientOpenApi
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
    [Table("OAuth_ClientOpenApi")]
    public class OAuth_ClientOpenApi: BaseEntity
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
        public const string OPENAPI = "OpenApi"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("OpenApi")]
        [MaxLength(150)]
        [Key]
        [Required]
        public string OpenApi { get; set; }
    }
}

