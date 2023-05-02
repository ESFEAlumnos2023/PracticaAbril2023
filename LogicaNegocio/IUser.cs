using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesNegocio;
using DTOs;
namespace LogicaNegocio
{
    public interface IUser
    {
        public Task<List<UserGetAllDTO>> GetAll();
        public Task<int> Create(User user);
    }
}
