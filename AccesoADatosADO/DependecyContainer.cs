using LogicaNegocio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatosADO
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALADODependecies(this IServiceCollection services, IConfiguration configuration)
        {
            //  const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True;Trust Server Certificate=true";          
            services.AddScoped<IUser, UserDAL>();
            services.AddScoped<ICustomer, CustomerDAL>();
            return services;
        }
    }
}
