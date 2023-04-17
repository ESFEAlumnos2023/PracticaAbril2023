using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models;

namespace PracticaESFE.AppMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            var list = new List<User>();
            string query = "SELECT Id,Name,Email,[Password] FROM [User]";
            Conexion.ExecuteReader(query, reader =>
            {
                list.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3),

                });
            });           
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
                int result = 0;
                string query = "INSERT INTO [User](Name,Email,[Password]) VALUES(@Name,@Email,@Password)";              
                result = Conexion.ExecuteCommand(query, command =>
                {
                    command.Parameters
                        .AddWithValue("Name", user.Name);
                    command.Parameters
                       .AddWithValue("Email", user.Email);
                    command.Parameters
                       .AddWithValue("Password", user.Password);
                });              
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
