using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnBoardV3.Controllers
{
    public class CustomerController : Controller
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

        

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(BLL.Model.Customer Customer)
        {
            try
            {
                var valid = Operation.SaveCustomer(Customer);
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
        public JsonResult Edit(BLL.Model.Customer Customer)
        {
            try
            {
                    var valid = Operation.UpdateCustomer(Customer);
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