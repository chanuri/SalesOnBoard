using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOnBoardV2.Controllers
{
    public class CustomerController : BaseController
    {
        BLL.Operations Operation = new BLL.Operations();
        // GET: Customer
        public ActionResult Index()
        {
            var Customers = Operation.GetAllCustomers();
            return View(Customers);
        }
        // GET: Customer JSON
        public JsonResult GetAllCustomer()
        {
            var Customers = Operation.GetAllCustomers();
            return Json(Customers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCustomerByID(int? id)
        {
            var Customers = Operation.GetCustomer(id);
            return Json(Customers, JsonRequestBehavior.AllowGet);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.Customer Customer)
        {
            try
            {
                // TODO: Add insert logic here
                var valid = TryUpdateModel(Customer);
                if (valid)
                {
                    var Customers = Operation.SaveCustomer(Customer);
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]

        public JsonResult Edit(BLL.Model.Customer Customer)
        {
            try
            {
                var valid = TryUpdateModel(Customer);
                if (valid)
                {
                    var Customers = Operation.UpdateCustomer(Customer);
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


        //// GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Customer/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                // TODO: Add update logic here
                var Customers = Operation.DeleteCustomer(id);
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