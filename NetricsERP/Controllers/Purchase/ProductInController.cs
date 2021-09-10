using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetricsERP.Controllers.Purchase
{
    public class ProductInController : Controller
    {
        // GET: ProductIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RecvChallanEntry()
        {
            return View();
        }
    }
}