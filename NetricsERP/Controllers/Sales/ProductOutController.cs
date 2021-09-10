using NetricsERP.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetricsERP.Controllers.Sales
{
    public class ProductOutController : Controller
    {
        // GET: ProductOut
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult genChallan()
        {
            return View();
        }
        public ActionResult genChallan(Challan model)
        {

            return View();
        }
    }
}