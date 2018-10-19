using subDomain.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //original
            //SubDomainRetrieverSection settings = (SubDomainRetrieverSection)ConfigurationManager.GetSection("subDomainSection");
            //var domainCollection = settings.SubDomainElements;
            //List<SubDomainElement> SubDomainElementList = domainCollection.Cast<SubDomainElement>().ToList();
            //HttpContext.Current.Cache["SubDomainElementList"] = SubDomainElementList;

            SubDomainRetrieverSection settings = (SubDomainRetrieverSection)ConfigurationManager.GetSection("subDomainSection");
            var domainCollection = settings.SubDomainElements;
            List<SubDomainElement> SubDomainElementList = domainCollection.Cast<SubDomainElement>().ToList();
            HttpContext.Current.Cache["SubDomainElementList"] = SubDomainElementList;
        }
    }
}
