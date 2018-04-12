using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class DPPQuery
    {
        //仓库
        public static DataSet GetCKHID()
        {
            string strSql = "select * from WMS_Pub_Store order by CKID";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //物料号
        
        public static DataSet GetWLHID()
        {
            string strSql = "select distinct TOP 2000 WLH  from View_KC_WL  order by WLH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //货位
        public static DataSet GetHWID(string sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct HW  from View_KC_WL");
            if (sqlWhere.Trim() != "" && sqlWhere.Trim() != null)
            {
                strSql.Append(" where CK=" + sqlWhere);
            }
            strSql.Append(" order by HW");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }
        //批次
        public static DataSet GetPCHID()
        {
            string strSql = "select distinct top 2000 PCH  from View_KC_WL order by PCH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //属性
        public static DataSet GetSX()
        {
            string strSql = "select distinct SX  from View_KC_WL  order by SX";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //牌号
        public static DataSet GetPH()
        {
            string strSql = "select distinct TOP 2000 PH  from View_KC_WL  order by PH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
      //规格
        public static DataSet GetGG()
        {
            string strSql = "select distinct TOP 2000 GG  from View_KC_WL  order by GG";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //特殊信息

         public static DataSet GetTSXX(string sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct pcinfo from WMS_Bms_Inv_Info where 1=1");
            if (sqlWhere.Trim() != "" && sqlWhere.Trim() != null)
            {
                strSql.Append(sqlWhere);
            }
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }
        //绑定bindgrv

        public static DataSet GetGrvDPP(string sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ck,hw,pch,wlh,wlmc,sx,ph,gg,sum(zl) zl,count(1) sl from view_dp_qry where");
            if (sqlWhere.Trim() != "" && sqlWhere.Trim() != null)
            {
                strSql.Append(sqlWhere);
            }
            strSql.Append("group by ck,hw,pch,wlh,wlmc,sx,ph,gg");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }
        /// <summary>
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (select ck,hw,pch,wlh,wlmc,sx,ph,gg,sum(zl) zl,count(1) sl from view_dp_qry{0} group by ck,hw,pch,wlh,wlmc,sx,ph,gg) select count(*) from TempDB";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE 1=1 " + strWhere;
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

        public static DataSet GetCount(string strWhere)
        {
            string sql = "select count(*) as countAll,sum(zl) as HJZL from (select sum(zl) as zl from view_dp_qry ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += " WHERE 1=1 " + strWhere;
            }
            sql += " Group by ck,hw,pch,wlh,wlmc,sx,ph,gg) a";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }


        /// <summary>
        ///记录个数
        /// </summary>
        /// <returns></returns>
        public static DataSet GetQueryDPP(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "wlh";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (select ck,hw,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,ph,gg,sum(zl) zl,count(1) sl,MAX(WeightRQ) AS WeightRQ, row_number() OVER (ORDER BY {0}) AS RowNumber from view_dp_qry {1} group by ck,hw,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,ph,gg) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere = " Where 1=1 " + Sql_ZKD;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pagesql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }

        /// <summary>
        /// 到处EXCEL时的查询语句
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet QueryPDDExcel(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select ck,hw,pch,wlh,wlmc,sx,ph,gg,sum(zl) zl,count(1) sl from view_dp_qry");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sbSql.Append(" WHERE ");
                sbSql.Append(strWhere);
            }
            sbSql.Append("group by ck,hw,pch,wlh,wlmc,sx,ph,gg");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sbSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 得到数量
        /// </summary>
        /// <returns>总数</returns>
        public static int GetzongSL(string col,string database,string sqlwhere)
        {
            AdoHelper dataHelp = new SqlHelp();
            string strSql = "WITH TempDB AS (select ck,hw,pch,wlh,wlmc,sx,ph,gg,sum(zl) zl,count(1) sl from " + database;
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where 1=1 " + sqlwhere+"group by ck,hw,pch,wlh,wlmc,sx,ph,gg) SELECT sum(" + col + ") from TempDB";
            }
            else
               strSql += " where 1=1 group by ck,hw,pch,wlh,wlmc,sx,ph,gg) SELECT sum(" + col + ") from TempDB";

            strSql = string.Format(strSql, sqlwhere);
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (!string.IsNullOrEmpty(result.ToString()))
                return Convert.ToInt32(result);
            return 0;
        }
        /// <summary>
        /// 得到重量
        /// </summary>
        /// <returns>总数</returns>
        public static double GetzongZL(string col,string database,string sqlwhere)
        {
            string strSql = "SELECT sum(" + col + ") from " + database;
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where " + sqlwhere;
            }
            strSql = string.Format(strSql, sqlwhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (!string.IsNullOrEmpty(result.ToString()))
                return Convert.ToDouble(result);
            return 0;
        }
        
    }
}
