using ERPProject.Models;
using ERPProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(customerDetails cust)
        {
            int custId = 0;
            CustomerRepository repo = new CustomerRepository();
            if(ModelState.IsValid)
            {
                try
                {
                    custId = repo.AddCustomer(cust);
                    if(custId>0)
                    {
                        return View(new customerDetails());
                    }
                }
                catch(Exception ex)
                {

                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(customerDetails cust)
        {
            return View();
        }
    }
}