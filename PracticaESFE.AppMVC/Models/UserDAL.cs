namespace PracticaESFE.AppMVC.Models
{
    public class UserDAL
    {
        public static List<User> GetAll()
        {
            var list = new List<User>();
            string query = "SELECT Id,Name,Email,[Password] FROM [User]";
            Conexion.ExecuteReader(query, reader =>
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
        public static int Create(User user)
        {
            int result = 0;
            string query = "INSERT INTO [User](Name,Email,[Password]) VALUES(@Name,@Email,@Password)";
            result = Conexion.ExecuteCommand(query, command =>
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
