using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOnBoard.Controllers
{
    public class ProductController : Controller
    {
        BLL.Operations operations = new BLL.Operations();
        // GET: Product
        public ActionResult Index()
        {
            var products = operations.GetAllProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            var products = operations.GetProduct(id);
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.Product product)
        {
            try
            {
                // TODO: Add insert logic here
                var products = operations.SaveProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product= operations.GetProduct(id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(BLL.Model.Product product)
        {
            try
            {
                // TODO: Add update logic here
                var products = operations.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
