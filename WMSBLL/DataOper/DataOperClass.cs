using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace ACCTRUE.WMSBLL.DataOper
{
    public class DataOperClass
    {
        public static int ResendData(string docID, string docType, string userID, string ck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WMS_Pub_HuiChuan(BillNum,Type,Operater,CK) values('");
            strSql.Append(docID);
            strSql.Append("','");
            strSql.Append(docType);
            strSql.Append("','");
            strSql.Append(userID);
            strSql.Append("','");
            strSql.Append(ck);
            strSql.Append("')");
            AdoHelper adoHelp = new SqlHelp();
            return adoHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 记录重发结果
        /// </summary>
        /// <param name="comResult"></param>
        /// <param name="comDes"></param>
        /// <returns></returns>
        public static int ReLoadLog(string comResult, string comDes,string comID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Com_Log set comtime=getdate(),comresult=");
            strSql.Append(comResult);
            strSql.Append(",ComDes=' 手动重发: ");
            strSql.Append(comDes);
            strSql.Append(" ' where Comid=");
            strSql.Append(comID);
            AdoHelper adoHelp = new SqlHelp();
            return adoHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除单据日志
        /// </summary>
        /// <param name="docID"></param>
        /// <returns></returns>
        public static void DeleteSingerDoc(string docID)
        {
            DataSet ds = GetDocLog(docID);
            if (ds != null)
            {
                int result = Convert.ToInt32(ds.Tables[0].Rows[0]["ComResult"]);
                if (result != 1)
                    return;
                DeleteDocLog(docID);
                string fileName = ds.Tables[0].Rows[0]["ComXML"].ToString().Trim();
                DeleteLogService.Service delService = new ACCTRUE.WMSBLL.DeleteLogService.Service();
                delService.Url = Common.DeleLogServiceUrl;
                ICredentials credentials = new NetworkCredential(Common.DeleLogServiceUser,Common.DeleLogServicePass);
                delService.Credentials = credentials;
                delService.DeleteTraFile(fileName,docID);
            }
        }

        /// <summary>
        /// 删除查询结果的日志信息
        /// </summary>
        /// <param name="sqlWhere"></param>
        public static void DeleteQueryDoc(string sqlWhere)
        {
            DataSet ds = QueryLOGInfos(sqlWhere);
            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DeleteSingerDoc(row["DOCID"].ToString().Trim());
                }
            }
        }

        private static DataSet GetDocLog(string docID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [WMS_Com_Log] where DOCID='");
            strSql.Append(docID);
            strSql.Append("' order by comTime desc");
            AdoHelper adoHelp = new SqlHelp();
            DataSet ds = adoHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        //删除日志信息
        private static void DeleteDocLog(string docID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [WMS_Com_Log] WHERE DOCID='");
            strSql.Append(docID);
            strSql.Append("'");
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("DELETE FROM [WMS_Pub_HuiChuan] WHERE BillNum='");
            strSql2.Append(docID);
            strSql2.Append("'");
            AdoHelper adoHelp = new SqlHelp();
            adoHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            adoHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql2.ToString());
        }
        //得到要删除的日志信息
        private static DataSet QueryLOGInfos(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT * FROM WMS_Com_Log");
            if (!string.IsNullOrEmpty(strWhere))
                sqlStr.Append(" WHERE 1=1 " + strWhere);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
    }
}
