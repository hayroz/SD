using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.Areas.Campaign.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Campaign/Dashboard
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        // GET: Campaign/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Campaign/Dashboard
        public ActionResult Dashboard1()
        {
            return View();
        }

        // GET: Campaign/Dashboard
        public ActionResult Dashboard2()
        {
            return View();
        }
    }
}