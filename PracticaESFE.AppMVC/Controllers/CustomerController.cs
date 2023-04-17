using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaESFE.AppMVC.Models;
using System.Data.SqlClient;

namespace PracticaESFE.AppMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            var list = new List<Customer>();
            const string strConnectio = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True";
            using (var conn = new SqlConnection(strConnectio))
            {
                conn.Open();
                string query = "SELECT Id,Name,Addres FROM Customers";
                var sqlcommand = new SqlCommand(query, conn);
                var sqlReader = sqlcommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    list.Add(new Customer
                    {
                        
                        Id = sqlReader.GetInt32(0),
                        Name = sqlReader.GetString(1),
                        Addres = sqlReader.GetString(2),
                    });
                }
            }
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
        public ActionResult Create(Customer customer)
        {
            try
            {
                int result = 0;
                const string strConnectio = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True";
                using (var conn = new SqlConnection(strConnectio))
                {
                    conn.Open(); // conexion
                    string query = "INSERT INTO Customers(Name,Addres) VALUES(@Name,@Addres)";
                    var sqlcommand = new SqlCommand(query, conn);
                    sqlcommand.Parameters
                        .AddWithValue("Name", customer.Name);
                    sqlcommand.Parameters
                       .AddWithValue("Addres", customer.Addres);                   
                    result = sqlcommand.ExecuteNonQuery();

                }
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
