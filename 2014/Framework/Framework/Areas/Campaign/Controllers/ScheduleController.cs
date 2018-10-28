using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.Areas.Campaign.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Campaign/Schedule
        public ActionResult Index()
        {
            return RedirectToAction("Calendar");
        }

        public ActionResult Calendar()
        {
            return View();
        }
    }
}