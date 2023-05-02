using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesNegocio;
namespace LogicaNegocio
{
    public interface ICustomer
    {

        public Task<List<Customer>> GetAll();
        public Task<int> Create(Customer customer);
    }
}
