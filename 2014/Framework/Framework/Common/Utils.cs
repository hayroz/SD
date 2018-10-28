using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Framework.Common
{
    public static class HtmlHelperExtensions

    {
        public static string ResolveUrl(this HtmlHelper helper, string relativeUrl)
        {
            if (VirtualPathUtility.IsAppRelative(relativeUrl))
            {
                return VirtualPathUtility.ToAbsolute(relativeUrl);
            }
            else
            {
                var curPath = WebPageContext.Current.Page.TemplateInfo.VirtualPath;
                var curDir = VirtualPathUtility.GetDirectory(curPath);
                return VirtualPathUtility.ToAbsolute(VirtualPathUtility.Combine(curDir, relativeUrl));

            }


        }
    }
}