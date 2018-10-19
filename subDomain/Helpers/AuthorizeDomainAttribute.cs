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
 
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

    }
}