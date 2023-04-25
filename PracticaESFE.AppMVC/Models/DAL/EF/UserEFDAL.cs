using Microsoft.EntityFrameworkCore;
using EntidadesNegocio;
using PracticaESFE.AppMVC.Models.Logic.Intefaces;

namespace PracticaESFE.AppMVC.Models.DAL.EF
{
    public class UserEFDAL : IUser
    {
        readonly ESFEDB _context;
        public UserEFDAL(ESFEDB context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<int> Create(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }       
    }
}
