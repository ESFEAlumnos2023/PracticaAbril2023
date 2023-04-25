using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models.DAL.EF;
using PracticaESFE.AppMVC.Models.Logic.Intefaces;

namespace PracticaESFE.AppMVC.Controllers
{
    public class RPCustomerController : Controller
    {
        // GET: RPCustomerController
        readonly ICustomer customerDAL;
        public RPCustomerController(ICustomer Icustomer)
        {
            customerDAL = Icustomer;
        }
        public async Task<ActionResult> Index()
        {
            var list =await customerDAL.GetAll();           
            return View(list);
        }

       
    }
}
