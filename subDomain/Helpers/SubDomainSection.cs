using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers
{

    public class SubDomainSection : ConfigurationSection
    {
        [ConfigurationProperty("SubDomains")]
        public SubDomainCollection SubDomainElements
        {
            get { return ((SubDomainCollection)(base["SubDomains"])); }
            set { base["SubDomains"] = value; }
        }
    }
}