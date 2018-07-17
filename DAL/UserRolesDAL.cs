using DAL.Models;
using DTO.User;
using Mapster;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserRolesDAL : IDAL<UserRolesDTO>
    {


        public UserRolesDAL()
        {
           
        }

        public UserRolesDTO Add(UserRolesDTO model)
        {
            throw new NotImplementedException();
        }

        public UserRolesDTO AddOrUpdate(UserRolesDTO model)
        {
            throw new NotImplementedException();
        }

        public UserRolesDTO Find(Func<UserRolesDTO, bool> p)
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.UserRoles.Find(p).Adapt<UserRolesDTO>();
            }
        }

        public UserRolesDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public UserRolesDTO Remove(UserRolesDTO model)
        {
            throw new NotImplementedException();
        }

        public UserRolesDTO Update(UserRolesDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
