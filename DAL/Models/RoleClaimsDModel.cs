using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class RoleClaimsDModel
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string RoleId { get; set; }
    }
}
