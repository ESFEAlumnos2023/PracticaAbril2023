using Microsoft.EntityFrameworkCore;
using PracticaESFE.AppMVC.Models.Entity;
using PracticaESFE.AppMVC.Models.Logic.Intefaces;

namespace PracticaESFE.AppMVC.Models.DAL.EF
{
    public class CustomerEFDAL:ICustomer
    {
        readonly ESFEDB _context;
        public CustomerEFDAL(ESFEDB context)
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
