namespace PracticaESFE.AppMVC.Models
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.EntityFrameworkCore;
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True;Trust Server Certificate=true";
            services.AddDbContext<ESFEDB>(options =>
                        options.UseSqlServer(strConnection));
            services.AddScoped<IUser, UserDAL>();
            services.AddScoped<CustomerEFDAL>();
            return services;
        }
    }
}
