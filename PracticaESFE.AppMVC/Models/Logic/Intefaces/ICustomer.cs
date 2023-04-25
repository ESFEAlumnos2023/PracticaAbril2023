using PracticaESFE.AppMVC.Models.Entity;

namespace PracticaESFE.AppMVC.Models.Logic.Intefaces
{
    public interface ICustomer
    {
        public Task<List<Customer>> GetAll();
        public Task<int> Create(Customer customer);
    }
}
