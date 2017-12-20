using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOnBoardV2.Controllers
{
    public class StoreController : BaseController
    {
        BLL.Operations Operation = new BLL.Operations();
        // GET: Store
        public ActionResult Index()
        {
            var Stores = Operation.GetAllStores();
            return View(Stores);
        }
        // GET: Store JSON
        public JsonResult GetAllStore()
        {
            var Stores = Operation.GetAllStores();
            return Json(Stores, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStoreByID(int? id)
        {
            var Stores = Operation.GetStore(id);
            return Json(Stores, JsonRequestBehavior.AllowGet);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.Store Store)
        {
            try
            {
                // TODO: Add insert logic here
                var valid = TryUpdateModel(Store);
                if (valid)
                {
                    var Stores = Operation.SaveStore(Store);
                    //return RedirectToAction("Index");
                    //Index();
                    //return RedirectToAction("Index");
                }
                return Json(new
                {
                    Valid = valid,
                    Errors = GetErrorsFromModelState(),
                    //StudentsPartial = studentPartialViewHtml
                });
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
        [HttpPost]

        public JsonResult Edit(BLL.Model.Store Store)
        {
            try
            {
                var valid = TryUpdateModel(Store);
                if (valid)
                {
                    var Stores = Operation.UpdateStore(Store);
                }
                //return RedirectToAction("Index");
                return Json(new
                {
                    Valid = valid,
                    Errors = GetErrorsFromModelState(),
                    //StudentsPartial = studentPartialViewHtml
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = "Error occured"
                    //StudentsPartial = studentPartialViewHtml
                });
            }
        }


        //// GET: Store/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Store/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                // TODO: Add update logic here
                var Stores = Operation.DeleteStore(id);
                return Json(new
                {
                    result = "sucessfuly edited"

                    //StudentsPartial = studentPartialViewHtml
                });
            }
            catch
            {
                return Json(new
                {
                    result = "error occured"

                    //StudentsPartial = studentPartialViewHtml
                });
            }
        }
    }
}
