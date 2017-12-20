using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOnBoard.Controllers
{
    public class StoreController : Controller
    {
        BLL.Operations operations = new BLL.Operations();
        // GET: Store
        public ActionResult Index()
        {
            var stores = operations.GetAllStores();
            return View(stores);
        }

        // GET: Store/Details/5
        public ActionResult Details(int? id)
        {
            var store = operations.GetStore(id);
            return View(store);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.Store store)
        {
            try
            {
                operations.SaveStore(store);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int? id)
        {
            var store = operations.GetStore(id);
            return View(store);
            
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(BLL.Model.Store store)
        {
            try
            {
                // TODO: Add update logic here
                operations.UpdateStore(store);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int? id)
        {
            var store = operations.GetStore(id);
            return View(store);
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, BLL.Model.Store Store)
        {
            try
            {
                var store = operations.DeleteStore(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
