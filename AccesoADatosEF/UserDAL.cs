using LogicaNegocio;
using EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace AccesoADatosEF
{
    internal class UserDAL : IUser
    {
        readonly ESFEDB _context;
        public UserDAL(ESFEDB context)
        {
            _context = context;
        }
        public async Task<List<UserGetAllDTO>> GetAll()
        {
            var listData= await _context.User.ToListAsync();
            var list = new List<UserGetAllDTO>();
            listData.ForEach(s => list.Add(new UserGetAllDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            }));
            return list;
        }
        public async Task<int> Create(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }
    }
}
