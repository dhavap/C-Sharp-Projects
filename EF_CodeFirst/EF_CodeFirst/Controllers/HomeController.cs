using EF_CodeFirst.DAL;
using EF_CodeFirst.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EF_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Users(string FName, string LName, int Age, string FavFruit)
        {
            using (UserContext db = new UserContext())
            {
                var userinput = new User();
                userinput.FName = FName;
                userinput.LName = LName;
                userinput.Age = Age;
                userinput.FavFruit = FavFruit;

                db.Users.Add(userinput);
                db.SaveChanges();
            }
            
            //making input data available to the view
            ViewBag.FName = FName;
            ViewBag.FavFruit = FavFruit;

            return View("Result");
        }

        
    }
}