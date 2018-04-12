using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class Sx
    {
        public static DataSet GetMCPH()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct mcph from Wms_Bms_Inv_MC order by mcph ");
            
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetPH()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct ph from Wms_Bms_Inv_MC order by ph ");

            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet QueryInvMC(string strWhere, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = " WHERE 1=1 ";
            string oKey = "barcode";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pageSql = "WITH TempDB AS (select barcode,wlh,ph,gg,zl,weightrq,mcsx,sx,mcbarcode,mcwlh,mcph,mcgg,mczl,mczl-zl as zlxh, " +
                "row_number() OVER (ORDER BY {0}) AS RowNumber FROM Wms_Bms_Inv_MC {1}) SELECT * FROM TempDB WHERE RowNumber " +
                "BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sWhere += " AND " + strWhere;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            try
            {
                string sqlStr = string.Format(pageSql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
                AdoHelper dataHelp = new SqlHelp();
                DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds;
                return null;
            }
            catch (System.Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
            
        }
        public static int GetPageCount(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "WHERE 1=1 ";
            string strSql = "SELECT count(1) from Wms_Bms_Inv_MC {0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " AND " + strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
            {
                double temp = Convert.ToDouble(result);
                allCount = Convert.ToInt32(temp);
                double pageCount = Math.Ceiling(temp / pageSize);
                return Convert.ToInt32(pageCount);
            }
            allCount = 0;
            return 0;
        }
    }
}
