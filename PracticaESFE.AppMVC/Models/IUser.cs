namespace PracticaESFE.AppMVC.Models
{
    public interface IUser
    {
        public Task<List<User>> GetAll();
        public Task<int> Create(User user);
    }
}
