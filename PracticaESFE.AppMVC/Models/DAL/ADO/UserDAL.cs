using EntidadesNegocio;
using PracticaESFE.AppMVC.Models.Logic.Intefaces;

namespace PracticaESFE.AppMVC.Models.DAL.ADO
{
    public class UserDAL : IUser
    {
        public async Task<List<User>> GetAll()
        {
            var list = new List<User>();
            string query = "SELECT Id,Name,Email,[Password] FROM [User]";
            await Conexion.ExecuteReaderAsync(query, reader =>
              {
                  list.Add(new User
                  {
                      Id = reader.GetInt32(0),
                      Name = reader.GetString(1),
                      Email = reader.GetString(2),
                      Password = reader.GetString(3),

                  });
              });
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
