using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models;

namespace PracticaESFE.AppMVC.Controllers
{
    public class RPCustomerController : Controller
    {
        // GET: RPCustomerController
        readonly CustomerEFDAL customerDAL;
        public RPCustomerController(CustomerEFDAL customerEFDAL)
        {
            customerDAL = customerEFDAL;
        }
        public ActionResult Index()
        {
            var list = customerDAL.GetAll();           
            return View(list);
        }

       
    }
}
