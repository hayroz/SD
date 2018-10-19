using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using subDomain.Helpers;
//using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        [Authorize]
        [AuthorizeDomain]
        public ActionResult Index()
        {
            try {

                var systemContext = new SystemDAL.DataContext();
                return View(systemContext.Jobs);
                //}
            }
            catch
            {
              var result = new HttpUnauthorizedResult();
                return RedirectToAction("subDomainChangeAlert", "Account");
            }
            
            return View();
        }
    }
}