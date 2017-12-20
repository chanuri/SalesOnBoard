using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Model;

namespace SalesOnBoard.Controllers
{
    public class SalesController : Controller
    {
        BLL.Operations operations = new BLL.Operations();
        // GET: Sales
        public ActionResult Index()
        {
            var sales= operations.GetSalesData();
            return View(sales);
        }

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            var model = new SalesDTO { };
            model.CustomerList = operations.GetAllCustomers();
            model.StoreList = operations.GetAllStores();
            model.ProductList = operations.GetAllProducts();
            return View(model);
        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.SalesDTO  sales)
        {
            try
            {
                operations.AddSale(sales);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? Id)
        {
            var sales = operations.GetSalesByID(Id);
            sales.CustomerList = operations.GetAllCustomers();
            sales.StoreList = operations.GetAllStores();
            sales.ProductList = operations.GetAllProducts();
            return View(sales);
        }

        // POST: Sales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BLL.Model.SalesDTO Sales)
        {
            try
            {
                operations.UpdateSale(Sales);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
