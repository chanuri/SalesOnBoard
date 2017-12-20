using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOnBoard.Controllers
{
    public class SalesSummaryController : Controller
    {
        BLL.Operations operations = new BLL.Operations();
        // GET: SalesSummary
        public ActionResult Index()
        {
            var sales = operations.GetSalesSummary();
            return View(sales);
        }
    }
}