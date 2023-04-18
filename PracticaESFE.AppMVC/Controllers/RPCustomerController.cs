using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models;

namespace PracticaESFE.AppMVC.Controllers
{
    public class RPCustomerController : Controller
    {
        // GET: RPCustomerController
        public ActionResult Index()
        {
            var list = CustomerDAL.GetAll();           
            return View(list);
        }

       
    }
}
