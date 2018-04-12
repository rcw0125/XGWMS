using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ACCTRUE.WMSBLL.QueryBll;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class RKZBQuery
    {
        //仓库
        public static DataSet GetRKCKHID()
        {
            string strSql = "select CKID from WMS_Pub_Store order by CKID";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //属性
        public static DataSet GetRKSX()
        {
            string strSql = "select distinct SX  from WMS_Rev_Doc order by SX";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //单号
        public static DataSet GetRKDH()
        {
            string strSql = "select distinct top 2000 RKDH  from WMS_Rev_Doc order by RKDH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //牌号
        public static DataSet GetRKPH()
        {
            string strSql = "select distinct PH  from WMS_Rev_Doc order by PH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //批次号
        public static DataSet GetRKPCH()
        {
            string strSql = "select distinct top 1000 PCH  from WMS_Rev_Doc order by PCH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        //规格
        public static DataSet GetRKGG()
        {
            string strSql = "select distinct GG  from WMS_Rev_Doc order by GG";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //物料号
        public static DataSet GetRKWLH()
        {
            string strSql = "select distinct WLH from WMS_Rev_Doc order by WLH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //车号
        public static DataSet GetRKCPH()
        {
            string strSql = "select distinct top 1000 CPH  from WMS_Rev_Doc order by CPH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //入库类型
        public static DataSet GetRKType()
        {
            string strSql = "select distinct RKType  from WMS_Rev_Doc order by RKType";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //生产线
        public static DataSet GetRKSCX()
        {
            string strSql = "select  scxbm  from WMS_Pub_SCX order by scxbm";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //班别
        public static DataSet GetRKBB()
        {
            string strSql = "select distinct bb from wms_bms_rec_wgd";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //特殊信息
        public static DataSet GetRKTSXX()
        {
            string strSql = "select distinct pcinfo from wms_bms_rec_wgd";
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
            string strSql = "select count(*) from WMS_Rev_Doc where 1=1{0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += strWhere;
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
        /// 得到合计信息，包括合计条数、合计件数、合计重量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetCount(string strWhere)
        {
            string sql = "select count(*) as countAll,sum(SL) as HJSL,sum(ZL) as HJZL from WMS_Rev_Doc where 1=1 "+strWhere;
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 分页查询发运单信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">每页多少条</param>
        /// <param name="pageNum">当前显示的为第几页</param>
        /// <returns></returns>
        /// 
        public static DataSet GetQueryRKZB(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "CK ASC,RKDH";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (SELECT *,row_number() OVER (ORDER BY {0}) AS RowNumber from WMS_Rev_Doc where 1=1{1})SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere += Sql_ZKD;
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
        public static DataSet QueryRKZBExcel(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select RKDH AS 入库单号,CK AS 仓库,PCH AS 批次号,SX AS 属性,PH AS 牌号");
            sbSql.Append(",GG AS 规格,SL AS 卷数,ZL AS 重量,CPH AS 车牌号,RKTime AS 入库日期");
            sbSql.Append(",RKType AS 入库类型,WLMC AS 物料名称 from WMS_Rev_Doc");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sbSql.Append(" WHERE 1=1");
                sbSql.Append(strWhere);
            }
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sbSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }


        /// <summary>
        ///  得到数量
        /// </summary>
        /// <returns>总数</returns>
        public static int GetRKDSL(string col, string sqlwhere)
        {
            AdoHelper dataHelp = new SqlHelp();
            string strSql = "SELECT sum(" + col + ") from WMS_Rev_Doc where 1=1";
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += sqlwhere;
            }
            strSql = string.Format(strSql, sqlwhere);
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (!string.IsNullOrEmpty(result.ToString()))
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }
        /// <summary>
        /// 得到重量
        /// </summary>
        /// <returns>总数</returns>
        public static double GetRKDZL(string col, string sqlwhere)
        {
            string strSql = "SELECT sum(" + col + ") from WMS_Rev_Doc where 1=1";
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += sqlwhere;
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
