using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers
{
    public class SubDomainRetrieverSection : ConfigurationSection
    {
        [ConfigurationProperty("SubDomainElements", IsRequired = true)]
        [ConfigurationCollection(typeof(SubDomainCollection), AddItemName = "add")]
        public SubDomainCollection SubDomainElements
        {
            get { return base["SubDomainElements"] as SubDomainCollection; }
        }
    }
}

