using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntidadesNegocio;
using LogicaNegocio;
namespace AccesoADatosEF
{
    internal class CustomerDAL : ICustomer
    {
        readonly ESFEDB _context;
        public CustomerDAL(ESFEDB context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<int> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            return await _context.SaveChangesAsync();
        }
    }
}
