﻿using Microsoft.EntityFrameworkCore;

namespace PracticaESFE.AppMVC.Models
{
    public class UserEFDAL : IUser
    {    
        readonly ESFEDB _context;
        public UserEFDAL(ESFEDB context)
        {
            _context = context;
        }
        public async  Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }
        public  async Task<int> Create(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }
        public void xCosa()
        {
            UserDAL userDAL=new UserDAL();           
           // userDAL.
        }
    }
}
