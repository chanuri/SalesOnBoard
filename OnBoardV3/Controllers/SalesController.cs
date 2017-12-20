using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnBoardV3.Controllers
{
    public class SalesController : Controller
    {
        BLL.Operations Operation = new BLL.Operations();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        // GET: Customers JSON
        public JsonResult GetAllCustomers()
        {
            var data = Operation.GetAllCustomers();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // GET: Store JSON
        public JsonResult GetAllStores()
        {
            var data = Operation.GetAllStores();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // GET: Product JSON
        public JsonResult GetAllProducts()
        {
            var data = Operation.GetAllProducts();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSalesData()
        {
            var data = Operation.GetSalesData();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSalesByID(int? ID)
        {
            var data = Operation.GetSalesByID(ID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Create(BLL.Model.SalesDTO sales)
        {
            try
            {                
                var valid = Operation.AddSale(sales);
                return Json(new
                {
                    Valid = valid,
                    
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Valid = false,
                    
                });
            }
        }
        [HttpPost]
        public JsonResult Edit(BLL.Model.SalesDTO sales)
        {
            try
            {
                 var valid = Operation.UpdateSale(sales);
                 
                return Json(new
                {
                    Valid = valid,
                   
                });
            }
            catch
            {
                return Json(new
                {
                    Valid = false,
                  
                });
            }
        }

    }

}