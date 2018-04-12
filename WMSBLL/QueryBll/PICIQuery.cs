using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class PICIQuery
    {

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetRKJL(string sqlwhere)
        //{
        //    string strSql = "select * from wms_rev_doc";
        //    AdoHelper dataHelp = new SqlHelp();
        //    if (!string.IsNullOrEmpty(sqlwhere))
        //    {
        //        strSql += " where PCH like '%" + sqlwhere + "%' order by PCH DESC";
        //    }
        //    DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        return ds;
        //    return null;
        //}
        /// <summary>
        /// 入库记录
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRKJL(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "PCH";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0}) AS RowNumber  from wms_rev_doc{1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere = " Where " + Sql_ZKD;
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
        /// 出库记录
        /// </summary>
        /// <returns></returns>
        //public static DataSet GetCKJL(string sqlwhere)
        //{
        //    string strSql = "select * from wms_pic_doc";
        //    AdoHelper dataHelp = new SqlHelp();
        //    if (!string.IsNullOrEmpty(sqlwhere))
        //    {
        //        strSql += " where PCH like '%" + sqlwhere + "%' order by PCH DESC";
        //    }
        //    DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        return ds;
        //    return null;
        //}
        public static DataSet GetCKJL(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "PCH";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0}) AS RowNumber  from wms_pic_doc{1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere = " Where " + Sql_ZKD;
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
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount1(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(*) from wms_rev_doc{0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE " + strWhere;
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
        /// <summary>
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount2(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(*) from wms_pic_doc{0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE " + strWhere;
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
