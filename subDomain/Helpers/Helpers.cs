using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using subDomain.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Web.Configuration;
using System.Web.Helpers;

namespace subDomain.Helpers
{
    [AuthorizeDomain]
    public static class Helpers
    {
        private static string _subDomain = string.Empty;
        public static string GetSubDomain(HttpRequestBase Request)
        {
            var url = Request.UrlReferrer != null ? Request.UrlReferrer : Request.Url;//Request.Url;//modied for testing

            string subDomain = string.Empty;            

            if (url.HostNameType == UriHostNameType.Dns)
            {
                //string host = "kmbl.localhost";//url.Host; //modied for testing
                string host = url.Host;
                if (host.Split('.').Length > 1)//> 2) //modied for testing kmbl.localhost.com >2
                {
                    int lastIndex = host.LastIndexOf(".");
                    int index = host.IndexOf(".");
                    //subdomain = index.Equals(lastIndex) ? string.Empty : host.Substring(0, index); //modied for testing
                    subDomain = index.Equals(lastIndex) ? host.Substring(0, index) : string.Empty;
                    //HttpContext.Current.Session["SubDomain"] =subdomain;
                    //_subDomain = subdomain;
                }
            }
            return subDomain;
        }

        public static string GetCompany(HttpRequestBase Request)
        {
            string subdomain = GetSubDomain(Request);
            _subDomain = subdomain;
            string company = string.Empty;

            List<SubDomainElement> SubDomainElementList = (List<SubDomainElement>)HttpContext.Current.Cache["SubDomainElementList"];
            HttpContext.Current.Cache["SubDomain"] = subdomain;

            var currentSetting = SubDomainElementList.FirstOrDefault(x => x.Code == subdomain);
            company = currentSetting.Account;

            if(subdomain =="") company = "";
            return company;
        }

        public static string GetLayout(HttpRequestBase Request)
        {
            string company = GetCompany(Request);
            string Layout = "~/Views/Shared/" + "_Layout" + company + ".cshtml";

            return Layout;
        }

        public static string GetIndex(HttpRequestBase Request)
        {
            string company = GetCompany(Request);
            company = company == "" ? "Default" : company;
            string view = "_" + company + "Index";

            return view;
        }

        public static string GetAbout(HttpRequestBase Request)
        {
            string company = GetCompany(Request);
            company = company == "" ? "Default" : company;
            string view = "_" + company + "About";

            return view;
        }

        public static string GetContact(HttpRequestBase Request)
        {
            string company = GetCompany(Request);
            company = company == "" ? "Default" : company;
            string view = "_" + company + "Contact";

            return view;
        }

        //public static string GetUserManagementDb(HttpRequestBase Request)
        //{
        //    List<SubDomainElement> SubDomainElementList = (List<SubDomainElement>)HttpContext.Current.Session["SubDomainElementList"];
        //    var currentSetting = SubDomainElementList.FirstOrDefault(x => x.Code == _subDomain);//GetSubDomain(Request));
        //    var adminDB = currentSetting.AdminDb;
        //    return adminDB;
        //}

        /// <summary>
        /// Gets Db for User Management for a Company
        /// </summary>
        /// <returns></returns>
        public static string GetUserManagementDb()
        {
            //string subDomain = string.Empty;
            string adminDB = string.Empty;

            //Fetch Allowed SubDomains from WebConfig
            SubDomainRetrieverSection settings = (SubDomainRetrieverSection)ConfigurationManager.GetSection("subDomainSection");
            var domainCollection = settings.SubDomainElements;
            List<SubDomainElement> SubDomainElementList = domainCollection.Cast<SubDomainElement>().ToList();
            //HttpContext.Current.Session["SubDomainElementList"] = SubDomainElementList;

            //if (HttpContext.Current.Session != null)
            //{
                //List<SubDomainElement> SubDomainElementList = (List<SubDomainElement>)HttpContext.Current.Session["SubDomainElementList"];
                var currentSetting = SubDomainElementList.FirstOrDefault(x => x.Code == _subDomain);
                adminDB = currentSetting.AdminDb;
            //}
            //else
            //{
            //    adminDB = "accountContext";
            //}

            return adminDB;
        }

        private static string GetCompanyDb()
        {
            string companyDBName = string.Empty;

            List<SubDomainElement> SubDomainElementList = (List<SubDomainElement>)HttpContext.Current.Cache["SubDomainElementList"];

            var currentSetting = SubDomainElementList.FirstOrDefault(x => x.Code == _subDomain);
            companyDBName = currentSetting.Database;

            return companyDBName;
        }
        /// <summary>
        /// Gets Connection String for Application Db for a Company
        /// </summary>
        /// <returns></returns>
        public static string GetCompanyDbConnectionString()
        {
            string companyDBName = string.Empty;

            List<SubDomainElement> SubDomainElementList = (List<SubDomainElement>)HttpContext.Current.Cache["SubDomainElementList"];
            
            var currentSetting = SubDomainElementList.FirstOrDefault(x => x.Code == (string)(HttpContext.Current.Cache["SubDomain"]));
            companyDBName = currentSetting.Database;

            var connectionSetting = WebConfigurationManager.ConnectionStrings[currentSetting.AdminDb];
            //var c = connectionSetting.CurrentConfiguration;  
            var s = connectionSetting.ToString().Substring(
                connectionSetting.ToString().ToLower().IndexOf("=") + 1,
                            connectionSetting.ToString().ToLower().IndexOf(";") - connectionSetting.ToString().ToLower().IndexOf("=") + 1
                );

            return "Data Source="+s+" Initial Catalog=" + companyDBName + ";Integrated Security=True";
        }
    }
}