using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;
using System.Data.OleDb;

namespace Acctrue.WM_WES.DataAccess
{
    internal class SqlDeriveParameters
    {
        internal static void DeriveParameters(SqlCommand cmd)
        {
            string cmdText;
            SqlCommand newCommand;
            SqlDataReader reader;
            ArrayList parameterList;
            SqlParameter sqlParam;
            CommandType cmdType;
            string procedureSchema;
            string procedureName;
            int groupNumber;
            SqlTransaction trnSql = cmd.Transaction;

            cmdType = cmd.CommandType;

            if ((cmdType == CommandType.Text))
            {
                throw new InvalidOperationException();
            }
            else if ((cmdType == CommandType.TableDirect))
            {
                throw new InvalidOperationException();
            }
            else if ((cmdType != CommandType.StoredProcedure))
            {
                throw new InvalidOperationException();
            }

            procedureName = cmd.CommandText;
            string server = null;
            string database = null;
            procedureSchema = null;

            // split out the procedure name to get the server, database, etc.
            GetProcedureTokens(ref procedureName, ref server, ref database, ref procedureSchema);

            // look for group numbers
            groupNumber = ParseGroupNumber(ref procedureName);

            newCommand = null;

            // set up the command string.  We use sp_procuedure_params_rowset to get the parameters
            if (database != null)
            {
                cmdText = string.Concat("[", database, "]..sp_procedure_params_rowset");
                if (server != null)
                {
                    cmdText = string.Concat(server, ".", cmdText);
                }

                // be careful of transactions
                if (trnSql != null)
                {
                    newCommand = new SqlCommand(cmdText, cmd.Connection, trnSql);
                }
                else
                {
                    newCommand = new SqlCommand(cmdText, cmd.Connection);
                }
            }
            else
            {
                // be careful of transactions
                if (trnSql != null)
                {
                    newCommand = new SqlCommand("sp_procedure_params_rowset", cmd.Connection, trnSql);
                }
                else
                {
                    newCommand = new SqlCommand("sp_procedure_params_rowset", cmd.Connection);
                }
            }

            newCommand.CommandType = CommandType.StoredProcedure;
            newCommand.Parameters.Add(new SqlParameter("@procedure_name", SqlDbType.NVarChar, 255));
            newCommand.Parameters[0].Value = procedureName;

            // make sure we specify 
            if (!IsEmptyString(procedureSchema))
            {
                newCommand.Parameters.Add(new SqlParameter("@procedure_schema", SqlDbType.NVarChar, 255));
                newCommand.Parameters[1].Value = procedureSchema;
            }

            // make sure we specify the groupNumber if we were given one
            if (groupNumber != 0)
            {
                newCommand.Parameters.Add(new SqlParameter("@group_number", groupNumber));
            }

            reader = null;
            parameterList = new ArrayList();

            try
            {
                // get a reader full of our params
                reader = newCommand.ExecuteReader();
                sqlParam = null;

                while (reader.Read())
                {
                    // get all the parameter properties that we can get, Name, type, length, direction, precision
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = (string)(reader["PARAMETER_NAME"]);
                    sqlParam.SqlDbType = GetSqlDbType((short)(reader["DATA_TYPE"]), (string)(reader["TYPE_NAME"]));

                    if (reader["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                    {
                        sqlParam.Size = (int)(reader["CHARACTER_MAXIMUM_LENGTH"]);
                    }

                    sqlParam.Direction = GetParameterDirection((short)(reader["PARAMETER_TYPE"]));

                    if ((sqlParam.SqlDbType == SqlDbType.Decimal))
                    {
                        sqlParam.Scale = (byte)(((short)(reader["NUMERIC_SCALE"]) & 255));
                        sqlParam.Precision = (byte)(((short)(reader["NUMERIC_PRECISION"]) & 255));
                    }
                    parameterList.Add(sqlParam);
                }
            }
            finally
            {
                // close our reader and connection when we're done
                if (reader != null)
                {
                    reader.Close();
                }
                newCommand.Connection = null;
            }

            // we didn't get any parameters
            if ((parameterList.Count == 0))
            {
                throw new InvalidOperationException();
            }

            cmd.Parameters.Clear();

            // add the parameters to the command object

            foreach (object parameter in parameterList)
            {
                cmd.Parameters.Add(parameter);
            }
        }

        /// <summary>
        /// Checks to see if the stored procedure being called is part of a group, then gets the group number if necessary
        /// </summary>
        /// <param name="procedure">Stored procedure being called.  This method may change this parameter by removing the group number if it exists.</param>
        /// <returns>the group number</returns>
        private static int ParseGroupNumber(ref string procedure)
        {
            string newProcName;
            int groupPos = procedure.IndexOf(';');
            int groupIndex = 0;

            if (groupPos > 0)
            {
                newProcName = procedure.Substring(0, groupPos);
                try
                {
                    groupIndex = int.Parse(procedure.Substring(groupPos + 1));
                }
                catch
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                newProcName = procedure;
                groupIndex = 0;
            }

            procedure = newProcName;
            return groupIndex;
        }

        /// <summary>
        /// Tokenize the procedure string
        /// </summary>
        /// <param name="procedure">The procedure name</param>
        /// <param name="server">The server name</param>
        /// <param name="database">The database name</param>
        /// <param name="owner">The owner name</param>
        private static void GetProcedureTokens(ref string procedure, ref string server, ref string database, ref string owner)
        {
            string[] spNameTokens;
            int arrIndex;
            int nextPos;
            int currPos;
            int tokenCount;

            server = null;
            database = null;
            owner = null;

            spNameTokens = new string[4];

            if (!IsEmptyString(procedure))
            {
                arrIndex = 0;
                nextPos = 0;
                currPos = 0;

                while ((arrIndex < 4))
                {
                    currPos = procedure.IndexOf('.', nextPos);
                    if ((-1 == currPos))
                    {
                        spNameTokens[arrIndex] = procedure.Substring(nextPos);
                        break;
                    }
                    spNameTokens[arrIndex] = procedure.Substring(nextPos, (currPos - nextPos));
                    nextPos = (currPos + 1);
                    if ((procedure.Length <= nextPos))
                    {
                        break;
                    }
                    arrIndex = (arrIndex + 1);
                }

                tokenCount = arrIndex + 1;

                // based on how many '.' we found, we know what tokens we found
                switch (tokenCount)
                {
                    case 1:
                        procedure = spNameTokens[0];
                        break;
                    case 2:
                        procedure = spNameTokens[1];
                        owner = spNameTokens[0];
                        break;
                    case 3:
                        procedure = spNameTokens[2];
                        owner = spNameTokens[1];
                        database = spNameTokens[0];
                        break;
                    case 4:
                        procedure = spNameTokens[3];
                        owner = spNameTokens[2];
                        database = spNameTokens[1];
                        server = spNameTokens[0];
                        break;
                }
            }
        }

        /// <summary>
        /// Checks for an empty string
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>boolean value indicating whether string is empty</returns>
        private static bool IsEmptyString(string str)
        {
            if (str != null)
            {
                return (0 == str.Length);
            }
            return true;
        }

        /// <summary>
        /// Convert OleDbType to SQlDbType
        /// </summary>
        /// <param name="paramType">The OleDbType to convert</param>
        /// <param name="typeName">The typeName to convert for items such as Money and SmallMoney which both map to OleDbType.Currency</param>
        /// <returns>The converted SqlDbType</returns>
        private static SqlDbType GetSqlDbType(short paramType, string typeName)
        {
            SqlDbType cmdType;
            OleDbType oleDbType;
            cmdType = SqlDbType.Variant;
            oleDbType = (OleDbType)(paramType);

            switch (oleDbType)
            {
                case OleDbType.SmallInt:
                    cmdType = SqlDbType.SmallInt;
                    break;
                case OleDbType.Integer:
                    cmdType = SqlDbType.Int;
                    break;
                case OleDbType.Single:
                    cmdType = SqlDbType.Real;
                    break;
                case OleDbType.Double:
                    cmdType = SqlDbType.Float;
                    break;
                case OleDbType.Currency:
                    cmdType = (typeName == "money") ? SqlDbType.Money : SqlDbType.SmallMoney;
                    break;
                case OleDbType.Date:
                    cmdType = (typeName == "datetime") ? SqlDbType.DateTime : SqlDbType.SmallDateTime;
                    break;
                case OleDbType.BSTR:
                    cmdType = (typeName == "nchar") ? SqlDbType.NChar : SqlDbType.NVarChar;
                    break;
                case OleDbType.Boolean:
                    cmdType = SqlDbType.Bit;
                    break;
                case OleDbType.Variant:
                    cmdType = SqlDbType.Variant;
                    break;
                case OleDbType.Decimal:
                    cmdType = SqlDbType.Decimal;
                    break;
                case OleDbType.TinyInt:
                    cmdType = SqlDbType.TinyInt;
                    break;
                case OleDbType.UnsignedTinyInt:
                    cmdType = SqlDbType.TinyInt;
                    break;
                case OleDbType.UnsignedSmallInt:
                    cmdType = SqlDbType.SmallInt;
                    break;
                case OleDbType.BigInt:
                    cmdType = SqlDbType.BigInt;
                    break;
                case OleDbType.Filetime:
                    cmdType = (typeName == "datetime") ? SqlDbType.DateTime : SqlDbType.SmallDateTime;
                    break;
                case OleDbType.Guid:
                    cmdType = SqlDbType.UniqueIdentifier;
                    break;
                case OleDbType.Binary:
                    cmdType = (typeName == "binary") ? SqlDbType.Binary : SqlDbType.VarBinary;
                    break;
                case OleDbType.Char:
                    cmdType = (typeName == "char") ? SqlDbType.Char : SqlDbType.VarChar;
                    break;
                case OleDbType.WChar:
                    cmdType = (typeName == "nchar") ? SqlDbType.NChar : SqlDbType.NVarChar;
                    break;
                case OleDbType.Numeric:
                    cmdType = SqlDbType.Decimal;
                    break;
                case OleDbType.DBDate:
                    cmdType = (typeName == "datetime") ? SqlDbType.DateTime : SqlDbType.SmallDateTime;
                    break;
                case OleDbType.DBTime:
                    cmdType = (typeName == "datetime") ? SqlDbType.DateTime : SqlDbType.SmallDateTime;
                    break;
                case OleDbType.DBTimeStamp:
                    cmdType = (typeName == "datetime") ? SqlDbType.DateTime : SqlDbType.SmallDateTime;
                    break;
                case OleDbType.VarChar:
                    cmdType = (typeName == "char") ? SqlDbType.Char : SqlDbType.VarChar;
                    break;
                case OleDbType.LongVarChar:
                    cmdType = SqlDbType.Text;
                    break;
                case OleDbType.VarWChar:
                    cmdType = (typeName == "nchar") ? SqlDbType.NChar : SqlDbType.NVarChar;
                    break;
                case OleDbType.LongVarWChar:
                    cmdType = SqlDbType.NText;
                    break;
                case OleDbType.VarBinary:
                    cmdType = (typeName == "binary") ? SqlDbType.Binary : SqlDbType.VarBinary;
                    break;
                case OleDbType.LongVarBinary:
                    cmdType = SqlDbType.Image;
                    break;
            }
            return cmdType;
        }

        /// <summary>
        /// Converts the OleDb parameter direction
        /// </summary>
        /// <param name="oledbDirection">The integer parameter direction</param>
        /// <returns>A ParameterDirection</returns>
        private static ParameterDirection GetParameterDirection(short oledbDirection)
        {
            ParameterDirection pd;
            switch (oledbDirection)
            {
                case 1:
                    pd = ParameterDirection.Input;
                    break;
                case 2: //或者干脆注释掉 case 2 的全部
                    pd = ParameterDirection.Output; //是这里的问题
                    goto default; //我加的这句话
                //break; //我注释掉的这句话
                case 4:
                    pd = ParameterDirection.ReturnValue;
                    break;
                default:
                    pd = ParameterDirection.InputOutput;
                    break;
            }
            return pd;
        }
    }
}
