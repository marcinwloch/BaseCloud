using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UsersLoginsDModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }
    }
}
