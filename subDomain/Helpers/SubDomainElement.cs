using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;

namespace subDomain.Helpers
{
    public class SubDomainElement : ConfigurationElement
    {
        [ConfigurationProperty("account", IsKey = true, IsRequired = true)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 12)]
        public string Account
        {
            get
            {
                return (string)this["account"];
            }
            set
            { this["account"] = value; }
        }

        [ConfigurationProperty("code", DefaultValue = "", IsRequired = false)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 12)]
        public string Code
        {
            get
            {
                return (string)this["code"];
            }
            set
            {
                this["code"] = value;
            }
        }        

        [ConfigurationProperty("database")]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 50)]
        public string Database
        {
            get
            {
                return (string)this["database"];
            }
            set
            { this["database"] = value; }
        }

        [ConfigurationProperty("adminDb")]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 50)]
        public string AdminDb
        {
            get
            {
                return (string)this["adminDb"];
            }
            set
            { this["adminDb"] = value; }
        }


        [ConfigurationProperty("layout", DefaultValue = "_Layout", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 256)]
        public string Layout
        {
            get
            {
                return (string)this["layout"];
            }
            set
            { this["layout"] = value; }
        }


        [ConfigurationProperty("login", DefaultValue = "_LoginPartial", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 256)]
        public string Login
        {
            get
            {
                return (string)this["login"];
            }
            set
            { this["login"] = value; }
        }
    }   
}