using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class YWDQuery
    {
        /// <summary>
        /// 获取仓库ID
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCKID()
        {
            string strSql = "select CKID from WMS_Pub_Store order by CKID";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取货位
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public static DataSet GetHWID(string sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct top 1000 SHW  from View_ywd");
            if (sqlWhere.Trim() != "" && sqlWhere.Trim()!=null)
            {
                strSql.Append(" where CK=" + sqlWhere);
            }
            strSql.Append(" order by SHW");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        
        }
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetYWDDH()
        {
            string strSql = "select distinct top 1000 YWDH  from View_ywd  order by YWDH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
      /// <summary>
        /// 获取批次号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetYWDPCH()
        {
            string strSql = "select distinct top 1000 PCH  from View_ywd  order by PCH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
                  /// <summary>
        /// 获取移位人员
        /// </summary>
        /// <returns></returns>
        public static DataSet GetYWDYWRY()
        {
            string strSql = "select distinct top 1000 CZRY  from View_ywd  order by CZRY";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
        /// <summary>
        /// 属性
        /// </summary>
        /// <returns></returns>
        public static DataSet GetYWDSX()
        {
            string strSql = "select distinct top 1000 SX  from View_ywd  order by SX DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
         /// <summary>
        /// 牌号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetYWDPH()
        {
            string strSql = "select distinct PH  from View_ywd order by PH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
         /// <summary>
        /// 牌号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetYWDWLH()
        {
            string strSql = "select distinct top 1000 WLH  from View_ywd  order by WLH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        
                     /// <summary>
        ///规格
        /// </summary>
        /// <returns></returns>
        public static DataSet GetYWDGG()
        {
            string strSql = "select distinct GG  from View_ywd order by GG";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
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
            string strSql = "SELECT count(*) from View_YWD{0}";
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
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetQueryYWD(string Sql_YWD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "YWDH";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0}) AS RowNumber from View_YWD{1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                sWhere = " Where " + Sql_YWD;
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
        public static DataSet QueryYWDExcel(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select YWDH as 移位单号,THW AS 目标货位,Barcode AS 单卷号");
            sbSql.Append(",PCH AS 批次号,WLH AS 物料号,SX AS 属性,PH AS 牌号,GG AS 规格");
            sbSql.Append(",ZL AS 重量,CZRY AS 执行人员,CZRQ AS 操作时间 from View_YWD");

            //sbSql.Append(",RKOperator as 入库操作,RKTime as 转入时间,WLMC as 物料名称 from VIEW_ZKD_Total_CPH");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sbSql.Append(" WHERE ");
                sbSql.Append(strWhere);
            }
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sbSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }


        /// <summary>
        /// 得到重量
        /// </summary>
        /// <returns>总数</returns>
        public static double GetYWDZL(string col, string sqlwhere)
        {
            string strSql = "SELECT sum(" + col + ") from View_YWD";
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
