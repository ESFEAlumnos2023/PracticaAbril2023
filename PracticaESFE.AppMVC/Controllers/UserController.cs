using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models;
using System.Data.SqlClient;

namespace PracticaESFE.AppMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            var list = new List<User>();
            const string strConnectio = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True";
            using (var conn= new SqlConnection(strConnectio))
            {
                conn.Open();
                string query = "SELECT Id,Name,Email,[Password] FROM [User]";
                var sqlcommand = new SqlCommand(query,conn);
                var sqlReader = sqlcommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    list.Add(new User {
                     Id = sqlReader.GetInt32(0),
                     Name = sqlReader.GetString(1),
                     Email = sqlReader.GetString(2),
                     Password = sqlReader.GetString(3),
                     
                    });
                }
            }
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
                const string strConnectio = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True";
                using (var conn = new SqlConnection(strConnectio))
                {
                    conn.Open();
                    string query = "INSERT INTO [User](Name,Email,[Password]) VALUES(@Name,@Email,@Password)";
                    var sqlcommand = new SqlCommand(query, conn);
                    sqlcommand.Parameters
                        .AddWithValue("Name", user.Name);
                    sqlcommand.Parameters
                       .AddWithValue("Email", user.Email);
                    sqlcommand.Parameters
                       .AddWithValue("Password", user.Password);
                     result = sqlcommand.ExecuteNonQuery();
                   
                }
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
