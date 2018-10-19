using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;

namespace WebApplication1.Helpers
{
    public class SubDomainElement_orig : ConfigurationElement
    {
        //private static SubDomainSettings settings = ConfigurationManager.GetSection("SubDomainSettings") as SubDomainSettings;

        //public static SubDomainSettings Settings
        //{
        //    get
        //    {
        //        return settings;
        //    }
        //}

        [ConfigurationProperty("code", DefaultValue = "", IsRequired = false)]
        [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 12)]
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

        [ConfigurationProperty("account")]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 12)]
        public AccountElement Account
        {
            get
            {
                return (AccountElement)this["account"];
            }
            set
            { this["account"] = value; }
        }

        [ConfigurationProperty("database")]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 50)]
        public DatabaseElement Database
        {
            get
            {
                return (DatabaseElement)this["database"];
            }
            set
            { this["database"] = value; }
        }

        
        [ConfigurationProperty("layout")]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 256)]
        public LayoutElement Layout
        {
            get
            {
                return (LayoutElement)this["layout"];
            }
            set
            { this["layout"] = value; }
        }


        [ConfigurationProperty("login")]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\", MinLength = 1, MaxLength = 256)]
        public LoginElement Login
        {
            get
            {
                return (LoginElement)this["login"];
            }
            set
            { this["login"] = value; }
        }
    }

    public class DatabaseElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "Company1", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        //[ConfigurationProperty("size", DefaultValue = "12", IsRequired = false)]
        //[IntegerValidator(ExcludeRange = false, MaxValue = 24, MinValue = 6)]
        //public int Size
        //{
        //    get
        //    { return (int)this["size"]; }
        //    set
        //    { this["size"] = value; }
        //}
    }

    public class AccountElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "Company1", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\GHIJKLMNOPQRSTUVWXYZ", MinLength = 6, MaxLength = 6)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        //[ConfigurationProperty("foreground", DefaultValue = "000000", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\GHIJKLMNOPQRSTUVWXYZ", MinLength = 6, MaxLength = 6)]
        //public String Foreground
        //{
        //    get
        //    {
        //        return (String)this["foreground"];
        //    }
        //    set
        //    {
        //        this["foreground"] = value;
        //    }
        //}

    }

    public class LayoutElement : ConfigurationElement
    {
        [ConfigurationProperty("fileName", DefaultValue = "_Layout", IsRequired = true)]
        public String Name
        {
            get
            {
                return (String)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }
    }

    public class LoginElement : ConfigurationElement
    {
        [ConfigurationProperty("fileName", DefaultValue = "_LoginPartial", IsRequired = true)]
        public String Name
        {
            get
            {
                return (String)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }
    }
}