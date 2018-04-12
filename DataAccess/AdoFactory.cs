using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Configuration;

namespace Acctrue.WM_WES.DataAccess
{
    public enum DataBaseType
    {
        SqlServer,
        OleDbType,
        Oracle
    }
    public class AdoFactory
    {
        #region Factory
        /// <summary>
        /// Create an AdoHelper for working with a specific provider (i.e. Sql, Odbc, OleDb, Oracle)
        /// </summary>
        /// <param name="providerAssembly">Assembly containing the specified helper subclass</param>
        /// <param name="providerType">Specific type of the provider</param>
        /// <returns>An AdoHelper instance of the specified type</returns>
        /// <example><code>
        /// AdoHelper helper = AdoHelper.CreateHelper("GotDotNet.ApplicationBlocks.Data", "GotDotNet.ApplicationBlocks.Data.OleDb");
        /// </code></example>
        public static AdoHelper CreateHelper(string providerAssembly, string providerType)
        {
            Assembly assembly = Assembly.Load(providerAssembly);
            object provider = assembly.CreateInstance(providerType);
            if (provider is AdoHelper)
            {
                return provider as AdoHelper;
            }
            else
            {
                throw new InvalidOperationException("The provider specified does not extend the AdoHelper abstract class.");
            }
        }


        /// <summary>
        /// Create an AdoHelper instance for working with a specific provider by using a providerAlias specified in the App.Config file.
        /// </summary>
        /// <param name="providerAlias">The alias to look up</param>
        /// <returns>An AdoHelper instance of the specified type</returns>
        /// <example><code>
        /// AdoHelper helper = AdoHelper.CreateHelper("OracleHelper");
        /// </code></example>
        public static AdoHelper CreateHelper(string providerAlias)
        {
            IDictionary dict;
            try
            {
                dict = ConfigurationManager.GetSection("daabProviders") as IDictionary;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("If the section is not defined on the configuration file this method can't be used to create an AdoHelper instance.", e);
            }

            ProviderAlias providerConfig = dict[providerAlias] as ProviderAlias;
            string providerAssembly = providerConfig.AssemblyName;
            string providerType = providerConfig.TypeName;

            Assembly assembly = Assembly.Load(providerAssembly);
            object provider = assembly.CreateInstance(providerType);
            if (provider is AdoHelper)
            {
                return provider as AdoHelper;
            }
            else
            {
                throw new InvalidOperationException("The provider specified does not extends the AdoHelper abstract class.");
            }
        }

        public static AdoHelper CreateHelper(DataBaseType dataType)
        {
            switch (dataType)
            {
                case DataBaseType.SqlServer:
                    {
                        return new SqlHelp();
                    }
                case DataBaseType.Oracle:
                    {
                        return new OracleHelp();
                    }
                case DataBaseType.OleDbType:
                    {
                        return new OleDbHelp();
                    }
                default:
                    {
                        return new SqlHelp();
                    }
            }
        }

        #endregion
    }
}
