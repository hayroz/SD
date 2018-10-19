using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //return this.Json("Post Passed Validation -" + name);
            return View();
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult TestToken(string name)
        {
            return this.Json("Post Passed Validation -" + name);
            //return View();
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public string GetSecuredData(string userName, string password)
        {
            string securedInfo = "";
            if ((userName == "admin") && (password == "admin"))
                securedInfo = "Hello admin, your secured information is .......";
            else
                securedInfo = "Wrong username or password, please retry.";
            return securedInfo;
        }
    }
}