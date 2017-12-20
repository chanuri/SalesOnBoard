using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOnBoardV2.Controllers
{
    public class SalesSummaryController : Controller
    {
        // GET: SalesSummary
        BLL.Operations operations = new BLL.Operations();
        // GET: SalesSummary
        public ActionResult Index()
        {
            var sales = operations.GetSalesSummary();
            return View(sales);
        }
    }
}