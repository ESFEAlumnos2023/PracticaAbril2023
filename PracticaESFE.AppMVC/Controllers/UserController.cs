using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models;

namespace PracticaESFE.AppMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        readonly UserEFDAL userDAL;
        public UserController(UserEFDAL userEFDAL)
        {
            userDAL = userEFDAL;
        }
        public ActionResult Index()
        {
            var list = userDAL.GetAll();       
            return View(list);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                int result = userDAL.Create(user);   
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    return View(user);
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
