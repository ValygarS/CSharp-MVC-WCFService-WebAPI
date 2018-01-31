using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA2_Azure.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ASP.NET MVC4 Application for maintaining tea data of a teashop in the SQL Azure Database.";

            return View();
        }

        public ActionResult Teas()
        {
            return RedirectToAction("Index", "Teas");
        }

    }
}