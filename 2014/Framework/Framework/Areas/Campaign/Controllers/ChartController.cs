using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.Areas.Campaign.Controllers
{
    public class ChartController : Controller
    {
        // GET: Campaign/Chart
        public ActionResult Index()
        {
            return RedirectToAction("chartjs");
        }

        // GET: Campaign/Chart
        public ActionResult Chartjs()
        {
            return View();
        }

        // GET: Campaign/Chart
        public ActionResult chartjs2()
        {
            return View();
        }

        // GET: Campaign/Chart
        public ActionResult echarts()
        {
            return View();
        }

        // GET: Campaign/Chart
        public ActionResult morisjs()
        {
            return View();
        }

        // GET: Campaign/Chart
        public ActionResult other_charts()
        {
            return View();
        }
    }
}