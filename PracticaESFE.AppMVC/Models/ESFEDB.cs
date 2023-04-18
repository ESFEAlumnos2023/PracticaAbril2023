using Microsoft.EntityFrameworkCore;

namespace PracticaESFE.AppMVC.Models
{
    public class ESFEDB:DbContext
    {
        //const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True;Trust Server Certificate=true";
        public ESFEDB(DbContextOptions<ESFEDB> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(strConnection);
        }
    }
}
