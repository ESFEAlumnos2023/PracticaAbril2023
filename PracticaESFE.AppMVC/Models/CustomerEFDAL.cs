namespace PracticaESFE.AppMVC.Models
{
    public class CustomerEFDAL
    {
        readonly ESFEDB _context;
        public CustomerEFDAL(ESFEDB context)
        {
            _context = context;
        }
        public  List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        public  int Create(Customer customer)
        {
            _context.Customers.Add(customer);
            return _context.SaveChanges();
        }
    }
}
