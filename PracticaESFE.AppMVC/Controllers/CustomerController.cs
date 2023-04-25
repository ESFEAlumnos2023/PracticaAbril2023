using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models.Entity;
using PracticaESFE.AppMVC.Models.Logic.Intefaces;

namespace PracticaESFE.AppMVC.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomer customerDAL;
        public CustomerController(ICustomer iCustomer)
        {
            customerDAL = iCustomer;
        }
        // GET: CustomerController
        public async  Task<ActionResult> Index()
        {
            var list = await customerDAL.GetAll();  
            return View(list);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                int result =await customerDAL.Create(customer);                            
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View(customer);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
