using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnBoardV3.Controllers
{
    public class ProductController : Controller
    {
        BLL.Operations Operation = new BLL.Operations();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        // GET: Product JSON
        public JsonResult GetAllProduct()
        {
            var products = Operation.GetAllProducts();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
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
                    //Errors = GetErrorsFromModelState(),
                    //StudentsPartial = studentPartialViewHtml
                });
            }
            catch
            {
                return View();
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public JsonResult Edit(BLL.Model.Product product)
        {
            try
            {
                //var valid = TryUpdateModel(product);
                //if (valid)
                //{
                    var products = Operation.UpdateProduct(product);
                //}
                //return RedirectToAction("Index");
                return Json(new
                {
                    Valid = products,
                    //Errors = GetErrorsFromModelState(),
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


        //// GET: Product/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

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
                    result = "sucessfuly deleted"

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