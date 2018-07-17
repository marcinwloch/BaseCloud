using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.User
{
    public class LoginExtendedDTO : LoginDTO
    {
        public string Role;
        public bool isEmailConfirmed;
    }
}
