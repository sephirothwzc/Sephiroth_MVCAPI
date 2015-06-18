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
    * 类 名 称：       SiteUser
    * 机器名称：       SEPHIROTHBF0C
    * 命名空间：       Entity
    * 文 件 名：       SiteUser
    * 创建时间：       15/6/15 15:04:28
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
    [Table("SiteUser")]
    public class SiteUser: BaseEntity
    {
        

        public const string ID_ = "ID"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("ID")]
        [MaxLength(50)]
        public string ID { get; set; }
        public const string NAME = "Name"; 
        
        /// <summary>
        /// 
        /// </summary>
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

