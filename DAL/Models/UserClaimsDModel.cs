using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UserClaimsDModel
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string UserId { get; set; }
    }
}
