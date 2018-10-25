using subDomain.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace subDomain.Helpers
{

    public class AuthorizeDomainAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpContext.Current.Cache["SubDomain"] = Helpers.GetSubDomain(filterContext.HttpContext.Request);
            // Check for DomainAuthorization
            if (HttpContext.Current.Cache["SubDomainElementList"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();                
            }

            if (HttpContext.Current.Cache["year"] != null)
            {
                int year = DateTime.Now.Year;
                if (year > Convert.ToInt64(HttpContext.Current.Cache["year"]))
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
            else
            {
                Crypto objCrypt = new Crypto();
                string Decryptkey = ConfigurationManager.AppSettings["QRSD"];
                Decryptkey = objCrypt.Decrypt(Decryptkey, true);

                int year = DateTime.Now.Year;
                //string Decryptkey = objCrypt.Encrypt("QRSD-01Dec2020", true);
                HttpContext.Current.Cache["year"] = Convert.ToInt64(Decryptkey.Substring(10, 4));
                if (year > Convert.ToInt64(Decryptkey.Substring(10, 4)))
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }                
            }            

            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

    }
}