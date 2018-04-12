using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Xml;

namespace Acctrue.WM_WES.DataAccess
{
    public class DAABSectionHandler :
         IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        /// <summary>
        /// Evaluates the given XML section and returns a Hashtable that contains the results of the evaluation.
        /// </summary>
        /// <param name="parent">The configuration settings in a corresponding parent configuration section. </param>
        /// <param name="configContext">An HttpConfigurationContext when Create is called from the ASP.NET configuration system. Otherwise, this parameter is reserved and is a null reference (Nothing in Visual Basic). </param>
        /// <param name="section">The XmlNode that contains the configuration information to be handled. Provides direct access to the XML contents of the configuration section. </param>
        /// <returns>A Hashtable that contains the section's configuration settings.</returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            Hashtable ht = new Hashtable();
            XmlNodeList list = section.SelectNodes("daabProvider");
            foreach (XmlNode prov in list)
            {
                if (prov.Attributes["alias"] == null)
                    throw new InvalidOperationException("The 'daabProvider' node must contain an attribute named 'alias' with the alias name for the provider.");
                if (prov.Attributes["assembly"] == null)
                    throw new InvalidOperationException("The 'daabProvider' node must contain an attribute named 'assembly' with the name of the assembly containing the provider.");
                if (prov.Attributes["type"] == null)
                    throw new InvalidOperationException("The 'daabProvider' node must contain an attribute named 'type' with the full name of the type for the provider.");

                ht[prov.Attributes["alias"].Value] = new ProviderAlias(prov.Attributes["assembly"].Value, prov.Attributes["type"].Value);
            }
            return ht;
        }

        #endregion
    }

}
