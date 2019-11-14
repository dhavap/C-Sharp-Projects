using CarInsuranceMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Customers(string FirstName, string LastName, string EmailAdd, string BirthDate, string CarYear, string CarMake, string CarModel, string Dui, string SpeedTix, string Coverage)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(EmailAdd) || 
                string.IsNullOrEmpty(BirthDate) || string.IsNullOrEmpty(CarYear) || string.IsNullOrEmpty(CarMake) || 
                string.IsNullOrEmpty(CarModel) || string.IsNullOrEmpty(Dui) || string.IsNullOrEmpty(SpeedTix) || 
                string.IsNullOrEmpty(Coverage))
            {
                return View("~/Views/Shared/Error.cshtml"); //error page
            }
            else
            {
                DateTime Dob = Convert.ToDateTime(BirthDate);
                int carYear = Convert.ToInt32(CarYear);
                int speedTickets = Convert.ToInt32(SpeedTix);
                
                //============== CALCULATE INSURANCE QUOTE BASED ON USER INPUT===================
                int insurQuote = 50;
                DateTime timeNow = DateTime.Now;
                int age = timeNow.Year - Dob.Year;

                if ( age < 18) { insurQuote += 100; }
                else if ( age < 25 || age > 100) { insurQuote += 25; }

                if (carYear < 2000 || carYear > 2015) { insurQuote += 25; }

                if (CarMake.ToLower() == "porsche")
                {
                    insurQuote += 25;
                    if (CarModel.ToLower() == "911 carrera" || CarModel.ToLower() == "911carrera") { insurQuote += 25; }
                }

                if (speedTickets > 0){ insurQuote += speedTickets*10; }

                if (Dui == "true") { insurQuote += insurQuote / 4; }

                if (Coverage == "full coverage") { insurQuote += insurQuote/2; }


                //===================== SAVE USER INPUT TO DATABASE =====================
                using (CarInsurance_CustomersEntities db = new CarInsurance_CustomersEntities())
                {
                    var userinput = new CarInsurance_Customers();
                    userinput.FirstName = FirstName;
                    userinput.LastName = LastName;
                    userinput.EmailAdd = EmailAdd;
                    userinput.DateOfBirth = Dob;
                    userinput.CarYear = carYear;
                    userinput.CarMake = CarMake;
                    userinput.CarModel = CarModel;
                    userinput.DUI = Dui;
                    userinput.SpeedingTickets = speedTickets;
                    userinput.CoverageType = Coverage;
                    userinput.InsuranceQuote = insurQuote;

                    db.CarInsurance_Customers.Add(userinput);
                    db.SaveChanges();
                }
                ViewBag.FirstName = FirstName;
                ViewBag.LastName = LastName;
                ViewBag.InsuranceQuote = insurQuote.ToString();
            }
            return View("Result");
        }
    }
}