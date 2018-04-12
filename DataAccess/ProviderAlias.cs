using System;
using System.Collections.Generic;
using System.Text;

namespace Acctrue.WM_WES.DataAccess
{
    public class ProviderAlias
    {
        #region Member variables

        private string _assemblyName;
        private string _typeName;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor required by IConfigurationSectionHandler
        /// </summary>
        /// <param name="assemblyName">The Assembly where this provider can be found</param>
        /// <param name="typeName">The type of the provider</param>
        public ProviderAlias(string assemblyName, string typeName)
        {
            _assemblyName = assemblyName;
            _typeName = typeName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the Assembly name for this provider
        /// </summary>
        /// <value>The Assembly name for the specified provider</value>
        public string AssemblyName
        {
            get { return _assemblyName; }
        }

        /// <summary>
        /// Returns the type name of this provider
        /// </summary>
        /// <value>The type name of the specified provider</value>
        public string TypeName
        {
            get { return _typeName; }
        }

        #endregion
    }
}
