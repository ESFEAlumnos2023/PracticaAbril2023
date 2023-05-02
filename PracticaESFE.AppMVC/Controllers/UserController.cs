using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntidadesNegocio;
using LogicaNegocio;

namespace PracticaESFE.AppMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        readonly IUser userDAL;
        public UserController(IUser pUserDAL)
        {
            userDAL = pUserDAL;
        }
        public async Task<ActionResult> Index()
        {
            var list =await userDAL.GetAll();       
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
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                int result =await userDAL.Create(user);   
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
