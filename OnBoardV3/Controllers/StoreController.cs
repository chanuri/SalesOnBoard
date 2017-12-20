using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnBoardV3.Controllers
{
    public class StoreController : Controller
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
        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.Store Store)
        {
            try
            {
                var valid = Operation.SaveStore(Store);
                return Json(new
                {
                    Valid = valid,

                });
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Edit(BLL.Model.Store Store)
        {
            try
            {
                var valid = Operation.UpdateStore(Store);
                return Json(new
                {
                    Valid = valid,
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