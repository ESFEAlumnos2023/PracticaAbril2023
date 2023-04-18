namespace PracticaESFE.AppMVC.Models
{
    public class UserEFDAL
    {
        readonly ESFEDB _context;
        public UserEFDAL(ESFEDB context)
        {
            _context = context;
        }
        public  List<User> GetAll()
        {
            return _context.User.ToList();
        }
        public  int Create(User user)
        {
            _context.Add(user);
            return _context.SaveChanges();
        }
    }
}
