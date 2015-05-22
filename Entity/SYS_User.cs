using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interface_Dapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*************************************************************************************
    * CLR �汾��       4.0.30319.33440
    * �� �� �ƣ�       SYS_User
    * �������ƣ�       SEPHIROTHBF0C
    * �����ռ䣺       Entity
    * �� �� ����       SYS_User
    * ����ʱ�䣺       15/5/16 10:46:47
    * ��    �ߣ�       
    * ˵    ����       
    * �޸�ʱ�䣺
    * �� �� �ˣ�
*************************************************************************************/

namespace Entity
{
    /// <summary>
    /// ϵͳ�û�
    /// </summary>
    //[Serializable]
    [Table("SYS_User")]
    public class SYS_User: BaseEntity
    {
        
        /// <summary>
        /// ����Guid
        /// </summary>
        [Column("id")]
        [MaxLength(50)]
        [Key]
        [Required]
        [DisplayName("����Guid")]
        public string Id { get; set; }
        
        /// <summary>
        /// �û���
        /// </summary>
        [Column("UserName")]
        [MaxLength(50)]
        [Required]
        [DisplayName("�û���")]
        public string Username { get; set; }
        
        /// <summary>
        /// �û�����
        /// </summary>
        [Column("UserCode")]
        [MaxLength(50)]
        [Required]
        [DisplayName("�û�����")]
        public string Usercode { get; set; }
        
        /// <summary>
        /// ����
        /// </summary>
        [Column("PassWord")]
        [MaxLength(50)]
        [DisplayName("����")]
        public string Password { get; set; }
        
        /// <summary>
        /// �Ƿ�adminĬ��0
        /// </summary>
        [Column("iAdmin")]
        [MaxLength(1)]
        [DisplayName("�Ƿ�adminĬ��0")]
        public bool? Iadmin { get; set; }
        
        /// <summary>
        /// ״̬1����0ͣ��-1����
        /// </summary>
        [Column("nState")]
        [MaxLength(10)]
        [DisplayName("״̬1����0ͣ��-1����")]
        public int? Nstate { get; set; }
        
        /// <summary>
        /// ����޸�����ʱ��
        /// </summary>
        [Column("dPasswordDate")]
        [MaxLength(23)]
        [DisplayName("����޸�����ʱ��")]
        public DateTime? Dpassworddate { get; set; }
        
        /// <summary>
        /// ����
        /// </summary>
        [Column("UserEmail")]
        [MaxLength(50)]
        [DisplayName("����")]
        public string Useremail { get; set; }
        
        /// <summary>
        /// �绰
        /// </summary>
        [Column("UserTell")]
        [MaxLength(50)]
        [DisplayName("�绰")]
        public string Usertell { get; set; }
    }
}

