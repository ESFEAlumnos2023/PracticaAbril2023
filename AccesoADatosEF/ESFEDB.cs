using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesNegocio;
namespace AccesoADatosEF
{
    public class ESFEDB : DbContext
    {
        public ESFEDB(DbContextOptions<ESFEDB> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(strConnection);
        }
    }
}
