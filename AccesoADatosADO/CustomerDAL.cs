using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio;
using EntidadesNegocio;
namespace AccesoADatosADO
{
    internal class CustomerDAL : ICustomer
    {
        public async Task<List<Customer>> GetAll()
        {
            var list = new List<Customer>();
            string query = "SELECT Id,Name,Addres FROM Customers";
            await Conexion.ExecuteReaderAsync(query, reader =>
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
        public async Task<int> Create(Customer customer)
        {
            int result = 0;
            string query = "INSERT INTO Customers(Name,Addres) VALUES(@Name,@Addres)";
            result = await Conexion.ExecuteCommandASync(query, command =>
            {
                command.Parameters
                    .AddWithValue("Name", customer.Name);
                command.Parameters
                   .AddWithValue("Addres", customer.Addres);
            });
            return result;
        }
    }
}
