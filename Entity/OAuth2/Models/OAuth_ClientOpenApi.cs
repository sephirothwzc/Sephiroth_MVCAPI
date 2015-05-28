using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entity.OAuth2.Models
{
    [Table("OAuth_ClientOpenApi")]
    public class OAuth_ClientOpenApi
    {
        [Key, Column(Order = 0)]
        public int ClientId { get; set; }
        [Key, Column(Order = 1)]
        public string OpenApi { get; set; }
    }
}