namespace PracticaESFE.AppMVC.Models
{
    public class CustomerEFDAL
    {
        public static List<Customer> GetAll()
        {           
           using(var context=new ESFEDB())
            {
                return context.Customers.ToList();
            }
        }
        public static int Create(Customer customer)
        {
            using (var context = new ESFEDB())
            {
                context.Customers.Add(customer);
                return context.SaveChanges();
            }
        }
    }
}
