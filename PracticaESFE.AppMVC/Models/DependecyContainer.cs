namespace PracticaESFE.AppMVC.Models
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.EntityFrameworkCore;
    using PracticaESFE.AppMVC.Models.DAL.EF;
    using PracticaESFE.AppMVC.Models.DAL.ADO;
    using PracticaESFE.AppMVC.Models.Logic.Intefaces;

    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
          //  const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True;Trust Server Certificate=true";
            services.AddDbContext<ESFEDB>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            services.AddScoped<IUser, UserEFDAL>();
            services.AddScoped<ICustomer,CustomerEFDAL>();
            return services;
        }
    }
}
