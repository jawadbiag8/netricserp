using ERPProject.Models;
using NetricsERP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    public class POController : Controller
    {
        // GET: PO
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPO()
        {
            return View(new PO());
        }
        [HttpPost]
        public ActionResult AddPO(PO model)
        {
            int newId = 0;
            PORepository repo = new PORepository();
            //if (ModelState.IsValid)
            //{
                try
                {
                    if(model!=null)
                    {
                        newId = repo.AddPO(model);
                    }
                }
                catch(Exception ex)
                {

                }
            //}
            return View();
        }
        
    }
}