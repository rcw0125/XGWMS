using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using Acctrue.WM_WES.DataAccess;
using System.Web.SessionState;

namespace ACCTRUE.WMSBLL
{
    public class Common
    {
        //是否为历史库
        private static bool _isOldData = false;
        public static bool IsOldData
        {
            get { return _isOldData; }
            set { _isOldData = value; }
        }
        public static string GetConnectString()
        {
            if (IsOldData)
            {
                return ConfigurationManager.ConnectionStrings["OldData"].ConnectionString;
            }
            else
            {
                return ConfigurationManager.ConnectionStrings["CurrentData"].ConnectionString;
            }
        }
        public static string DeleLogServiceUrl
        {
            get {return ConfigurationManager.AppSettings["DeleteLogUrl"];}
        }
        public static string DeleLogServiceUser
        {
           get { return ConfigurationManager.AppSettings["DeleUserName"];}
        }
        public static string DeleLogServicePass
        {
            get { return ConfigurationManager.AppSettings["DelePassWord"]; }
        }

        public static string RFWEBSERVER
        {
            get { return GetServerAddr("RFWebServer");}
        }
        public static string NCWERBSERVER
        {
            get { return GetServerAddr("NcWebServer"); }
        }
        public static string INTERFACESERVER
        {
            get { return GetServerAddr("interfaceAddr"); }
        }

        /// <summary>
        /// 与NC数据库联接字符串
        /// </summary>
        public static string NCDATASTRING
        {
            get { return GetServerAddr("NCDATASTRING"); }
        }

        private static string GetServerAddr(string serverType)
        {
            string sqlPCH = "select CS_Value from WMS_Pub_Param where CS_Name='"+serverType+"'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["CS_Value"].ToString();
            return "";
        }

        /// <summary>
        /// 返回NC的物料查询字符串
        /// </summary>
        /// <returns></returns>
        public static string GetWLSql()
        {
            string sqlPCH = "select CS_Value from WMS_Pub_Param where CS_Name='NCWLKey'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["CS_Value"].ToString();
            return "";
        }
    }
}
