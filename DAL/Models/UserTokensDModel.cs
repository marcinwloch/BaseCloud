using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UserTokensDModel
    {
        public string Userid { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
