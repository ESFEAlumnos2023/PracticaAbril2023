namespace PracticaESFE.AppMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Ok(string str) {
            return "";
        }
        public string Ok(int str)
        {
            return "";
        }
        public string Ok(string str,int num) {
            return "";
        }
        public string Ok(string str, int num,decimal num2)
        {
            return "";
        }
    }
}
