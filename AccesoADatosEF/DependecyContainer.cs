using LogicaNegocio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatosEF
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALEFDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            //  const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True;Trust Server Certificate=true";
            services.AddDbContext<ESFEDB>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            services.AddScoped<IUser, UserDAL>();
            services.AddScoped<ICustomer, CustomerDAL>();
            return services;
        }
    }
}
