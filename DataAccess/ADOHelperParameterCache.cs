using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Acctrue.WM_WES.DataAccess
{
    public sealed class ADOHelperParameterCache
    {
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Deep copy of cached IDataParameter array
        /// </summary>
        /// <param name="originalParameters"></param>
        /// <returns></returns>
        internal static IDataParameter[] CloneParameters(IDataParameter[] originalParameters)
        {
            IDataParameter[] clonedParameters = new IDataParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (IDataParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for an IDbConnection</param>
        /// <param name="commandText">The stored procedure name or SQL command</param>
        /// <param name="commandParameters">An array of IDataParameters to be cached</param>
        /// <exception cref="System.ArgumentNullException">Thrown if commandText is null</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if connectionString is null</exception>
        internal static void CacheParameterSet(string connectionString, string commandText, params IDataParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + " :" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for an IDbConnection</param>
        /// <param name="commandText">The stored procedure name or SQL command</param>
        /// <returns>An array of IDataParameters</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if commandText is null</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if connectionString is null</exception>
        internal static IDataParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + " :" + commandText;

            IDataParameter[] cachedParameters = paramCache[hashKey] as IDataParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions
    }
}
