namespace PracticaESFE.AppMVC.Models
{
    public class CustomerDAL
    {
        public static List<Customer> GetAll()
        {
            var list = new List<Customer>();
            string query = "SELECT Id,Name,Addres FROM Customers";
            Conexion.ExecuteReader(query, reader =>
            {
                list.Add(new Customer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Addres = reader.GetString(2),

                });
            });
            return list;
        }
        public static int Create(Customer customer)
        {
            int result = 0;
            string query = "INSERT INTO Customers(Name,Addres) VALUES(@Name,@Addres)";
            result = Conexion.ExecuteCommand(query, command => {
                command.Parameters
                    .AddWithValue("Name", customer.Name);
                command.Parameters
                   .AddWithValue("Addres", customer.Addres);
            });
            return result;
        }
    }
}
