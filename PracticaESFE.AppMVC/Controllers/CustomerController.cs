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
            string query = "SELECT Id,Name,Addres FROM Customers";
            Conexion.ExecuteReader(query, reader =>
            {
                list.Add(new Customer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Addres = reader.GetString(2),

                });
            });           
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
                string query = "INSERT INTO Customers(Name,Addres) VALUES(@Name,@Addres)";
                result = Conexion.ExecuteCommand(query, command => {
                    command.Parameters
                        .AddWithValue("Name", customer.Name);
                    command.Parameters
                       .AddWithValue("Addres", customer.Addres);
                });               
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
