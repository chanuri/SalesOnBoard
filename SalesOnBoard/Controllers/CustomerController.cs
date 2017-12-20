using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOnBoard.Controllers
{
    public class CustomerController : Controller
    {
        BLL.Operations operations = new BLL.Operations();
        // GET: Customer
        public ActionResult Index()
        {
            var customerlist= operations.GetAllCustomers();
            return View(customerlist);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            var customer = operations.GetCustomer(id);
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.Customer customer)
        {
            try
            {
                operations.SaveCustomer(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            var customer = operations.GetCustomer(id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(BLL.Model.Customer customer)
        {
            try
            {
                operations.UpdateCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            var customer = operations.GetCustomer(id);
            return View(customer);
           
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, BLL.Model.Customer customer)
        {
            try
            {
                operations.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
