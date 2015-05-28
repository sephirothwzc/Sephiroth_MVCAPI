using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entity.OAuth2.Models
{
    [Table("SiteUser")]
    public class SiteUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}