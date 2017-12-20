using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Model;

namespace SalesOnBoardV2.Controllers
{
    public class ProductController : BaseController
    {
        BLL.Operations Operation = new BLL.Operations();
        // GET: Product
        public ActionResult Index()
        {
            var products=Operation.GetAllProducts();
            return View(products);
        }
        // GET: Product JSON
        public JsonResult GetAllProduct()
        {
            var products = Operation.GetAllProducts();
            return Json(products,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductByID(int? id)
        {
            var products = Operation.GetProduct(id);
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var valid = TryUpdateModel(product);
                if (valid)
                {
                    var products = Operation.SaveProduct(product);
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]        
        public JsonResult Edit(BLL.Model.Product product)
        {
            try
            {
                var valid = TryUpdateModel(product);
                if (valid)
                {
                    var products = Operation.UpdateProduct(product);
                }
                //return RedirectToAction("Index");
                return Json(new
                {
                    Valid = valid,
                    Errors = GetErrorsFromModelState(),
                    //StudentsPartial = studentPartialViewHtml
                });
            }
            catch( Exception ex)
            {
                return Json(new
                {
                    result = "Error occured"
                    //StudentsPartial = studentPartialViewHtml
                });
            }
        }

        
        // POST: Product/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                // TODO: Add update logic here
                var products = Operation.DeleteProduct(id);
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
