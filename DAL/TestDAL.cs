using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class TestDAL : IDAL<TestDTO>
    {
        private IConfiguration _config;

        public TestDAL(IConfiguration config)
        {
            _config = config;
        }

        public TestDTO Add(TestDTO model)
        {
             throw new NotImplementedException();
            using (var ctx = new AppDbContext())
            {
                //ctx.Add(model)
            }
        }

        public TestDTO AddOrUpdate(TestDTO model)
        {
            throw new NotImplementedException();
        }

        public TestDTO Find(Func<TestDTO, bool> p)
        {
            throw new NotImplementedException();
        }

        public TestDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public TestDTO Remove(TestDTO model)
        {
            throw new NotImplementedException();
        }

        public TestDTO Update(TestDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
