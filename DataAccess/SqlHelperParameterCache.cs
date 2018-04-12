using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Acctrue.WM_WES.DataAccess
{
    public sealed class SqlHelperParameterCache
    {
        #region private constructor

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new SqlHelperParameterCache()"
        private SqlHelperParameterCache()
        {
        }

        #endregion constructor

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters to be cached</param>
        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            new SqlHelp().CacheParameterSet(connectionString, commandText, commandParameters);
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An array of SqlParamters</returns>
        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            ArrayList tempValue = new ArrayList();
            IDataParameter[] sqlP = new SqlHelp().GetCachedParameterSet(connectionString, commandText);
            foreach (IDataParameter parameter in sqlP)
            {
                tempValue.Add(parameter);
            }
            return (SqlParameter[])tempValue.ToArray(typeof(SqlParameter));
        }

        #endregion caching functions

        #region Parameter Discovery Functions

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of SqlParameters</returns>
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            ArrayList tempValue = new ArrayList();
            foreach (IDataParameter parameter in new SqlHelp().GetSpParameterSet(connectionString, spName))
            {
                tempValue.Add(parameter);
            }
            return (SqlParameter[])tempValue.ToArray(typeof(SqlParameter));
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            ArrayList tempValue = new ArrayList();
            foreach (IDataParameter parameter in new SqlHelp().GetSpParameterSet(connectionString, spName, includeReturnValueParameter))
            {
                tempValue.Add(parameter);
            }
            return (SqlParameter[])tempValue.ToArray(typeof(SqlParameter));
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of SqlParameters</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if spName is null</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if connection is null</exception>
        public static SqlParameter[] GetSpParameterSet(IDbConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if spName is null</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if connection is null</exception>
        public static SqlParameter[] GetSpParameterSet(IDbConnection connection, string spName, bool includeReturnValueParameter)
        {
            ArrayList tempValue = new ArrayList();
            foreach (IDataParameter parameter in new SqlHelp().GetSpParameterSet(connection, spName, includeReturnValueParameter))
            {
                tempValue.Add(parameter);
            }
            return (SqlParameter[])tempValue.ToArray(typeof(SqlParameter));
        }

        #endregion Parameter Discovery Functions
    }
}
