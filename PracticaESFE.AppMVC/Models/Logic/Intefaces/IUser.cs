using EntidadesNegocio;
namespace PracticaESFE.AppMVC.Models.Logic.Intefaces
{
    public interface IUser
    {
        public Task<List<User>> GetAll();
        public Task<int> Create(User user);
    }
}
