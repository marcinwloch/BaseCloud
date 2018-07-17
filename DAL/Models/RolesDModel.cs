using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class RolesDModel
    {
        public int Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
