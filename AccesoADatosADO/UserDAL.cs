using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesNegocio;
using DTOs;

namespace AccesoADatosADO
{
    internal class UserDAL : IUser
    {
        public async Task<List<UserGetAllDTO>> GetAll()
        {
            var listData = new List<User>();
            string query = "SELECT Id,Name,Email,[Password] FROM [User]";
            await Conexion.ExecuteReaderAsync(query, reader =>
            {
                listData.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3),

                });
            });
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
            int result = 0;
            string query = "INSERT INTO [User](Name,Email,[Password]) VALUES(@Name,@Email,@Password)";
            result = await Conexion.ExecuteCommandASync(query, command =>
            {
                command.Parameters
                    .AddWithValue("Name", user.Name);
                command.Parameters
                   .AddWithValue("Email", user.Email);
                command.Parameters
                   .AddWithValue("Password", user.Password);
            });
            return result;
        }
    }
}
