using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnBoardV3.Controllers
{
    public class SalesSummaryController : Controller
    {
        BLL.Operations Operation = new BLL.Operations();
        // GET: SalesSummary
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetSalesSummaryData()
        {
            var data= Operation.GetSalesSummary();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}