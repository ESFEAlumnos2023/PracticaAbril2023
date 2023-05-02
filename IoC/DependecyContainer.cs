using LogicaNegocio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatosADO;
using AccesoADatosEF;
namespace IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
           // services.AddDALADODependecies(configuration);
            services.AddDALEFDependecies(configuration);
            return services; 
        }
    }
}
