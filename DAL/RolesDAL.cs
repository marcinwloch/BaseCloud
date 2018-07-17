using DAL.Models;
using DTO.User;
using Mapster;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RolesDAL : IDAL<RolesDTO>
    {
        private IConfiguration _config;

        public RolesDAL(IConfiguration config)
        {
            _config = config;
        }

        public RolesDTO Add(RolesDTO model)
        {
            throw new NotImplementedException();
        }

        public RolesDTO AddOrUpdate(RolesDTO model)
        {
            throw new NotImplementedException();
        }

        public RolesDTO Find(Func<RolesDTO, bool> p)
        { 
            using(var ctx = new AppDbContext())
            {
                return ctx.Roles.Find(p).Adapt<RolesDTO>();
            }

            return null;
        }

        public RolesDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public RolesDTO Remove(RolesDTO model)
        {
            throw new NotImplementedException();
        }

        public RolesDTO Update(RolesDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
