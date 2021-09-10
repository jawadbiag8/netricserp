using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPProject.Models;
using NetricsERP.Repositories.Inventory;

namespace NetricsERP.Controllers.Inventory
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddVendor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVendor(vendorDetails model)
        {
            int newId = 0;
            InventoryRepository repo = new InventoryRepository();
            try
            {
                if(model!=null)
                {
                    newId = repo.Add_Vendor(model);
                }
            }
            catch(Exception ex)
            {
                RedirectToAction("AddVendor");
            }
            return View();
        }
        public ActionResult ChemRecvEntry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChemRecvEntry(purchaseProducts model)
        {
            int newId = 0;
            try
            {
                if (model!=null)
                {

                }
            }
            catch(Exception ex)
            {

            }
            return View();
        }
    }
}