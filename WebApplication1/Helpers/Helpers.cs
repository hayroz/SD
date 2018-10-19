
using System.Web.Helpers;
using subDomain.Helpers;

namespace WebApplication1.Helpers
{
    [AuthorizeDomain]
    public static class Helpers
    {
        public static string GetAntiForgeryToken()
        {
            string cookieToken, formToken;
            AntiForgery.GetTokens(null, out cookieToken, out formToken);
            return cookieToken + "," + formToken;
        }
    }
}