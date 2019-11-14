using CarInsuranceMvc.Models;
using CarInsuranceMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsurance_CustomersEntities db = new CarInsurance_CustomersEntities()) //to get access to the database using the db object
            {
                var customers = db.CarInsurance_Customers; //represents all the records in the db
                var customersVm = new List<CustomersVm>(); //create a list of ViewModels
                foreach (var customer in customers) //for each customer in the db
                {
                    var customerVm = new CustomersVm(); //instantiating the object customer
                    customerVm.FirstName = customer.FirstName; //map the FirstName from the database to the customer object created
                    customerVm.LastName = customer.LastName;
                    customerVm.EmailAdd = customer.EmailAdd;
                    customerVm.InsuranceQuote = customer.InsuranceQuote;
                    customersVm.Add(customerVm); //add the customer object to the list of customers for display
                }
                return View(customersVm);
            }
        }
    }
}


