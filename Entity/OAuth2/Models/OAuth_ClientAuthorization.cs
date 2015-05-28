﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entity.OAuth2.Models
{
    [Table("OAuth_ClientAuthorization")]
    public class OAuth_ClientAuthorization
    {
        [Key]
        public int AuthorizationId { get; set; }

        public string Token { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public int ClientId { get; set; }

        public string UserId { get; set; }

        public string Scope { get; set; }

        public DateTime? ExpirationDateUtc { get; set; }
    }
}