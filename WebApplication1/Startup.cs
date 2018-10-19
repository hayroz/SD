using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
//using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;
using WebApplication1.Helpers;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}


/*
 * ////////////////////////////////////////////////////ToDo List/////////////////////////////////////////////////
 * 1. Login Account id should not be passed. Host name should be translated to AccountId and validated using model
 * 2. Host name etc should be captured and passed for validation
 * 3. When host name is changed user should be warned and logged out
 * 4. Use HttpFilter or something to track host change in realtime.
 * 5. Fiddler used for host redirection
 * 6. https://stackoverflow.com/questions/27885975/encrypt-route-data-in-url  //url encoding
 */
