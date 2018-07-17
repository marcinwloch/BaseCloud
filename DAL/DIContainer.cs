using DAL.Models;
using DTO.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class DIContainer
    {

        public static void AddDALServices(this IServiceCollection service)
        {
            service.AddScoped<DbContext, AppDbContext>();
            service.AddTransient<IDAL<UserRolesDTO>, UserRolesDAL>();
        }
    }
}
