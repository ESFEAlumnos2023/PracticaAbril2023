namespace PracticaESFE.AppMVC.Models
{
    public class UserEFDAL
    {
        public static List<User> GetAll()
        {
            using (var context = new ESFEDB())
            {
                return context.User.ToList();
            }
        }
        public static int Create(User user)
        {
            using (var context = new ESFEDB())
            {
                context.Add(user);
                return context.SaveChanges();
            }
        }
    }
}
