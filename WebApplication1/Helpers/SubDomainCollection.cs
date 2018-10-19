using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers
{

    [ConfigurationCollection(typeof(SubDomainElement))]
    public class SubDomainCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "SubDomainElement";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }


        public override bool IsReadOnly()
        {
            return false;
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new SubDomainElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SubDomainElement)(element)).Code;
        }

        public SubDomainElement this[int idx]
        {
            get
            {
                return (SubDomainElement)BaseGet(idx);
            }
        }

        #region Methods
        public void Add(SubDomainElement item)
        {
            base.BaseAdd(item);
        }

        public void Remove(SubDomainElement item)
        {
            base.BaseRemove(item);
        }

        public void RemoveAt(int index)
        {
            base.BaseRemoveAt(index);
        }
        #endregion
    }
}