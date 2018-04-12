using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class KCQuery
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
        /// 获取PCH
        /// </summary>
        /// <returns></returns>
        public static DataSet GetKCPCH()
        {
            string strSql = "select distinct top 2000  PCH  from WMS_Bms_Inv_Info order by PCH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //属性
        public static DataSet GetKCSX()
        {
            string strSql = "select distinct SX  from WMS_Bms_Inv_Info  order by SX";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //物料
        public static DataSet GetKCWLH()
        {
            string strSql ="select distinct TOP 2000 WLH from WMS_Bms_Inv_Info order by WLH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //货位
        public static DataSet GetKCHW(string sqlwhere)
        {
            string strSql = "select distinct HW  from WMS_Bms_Inv_Info";
            AdoHelper dataHelp = new SqlHelp();
            if(!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where CK='" + sqlwhere + "'";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //特殊信息
        public static DataSet GetKCTSXX(string sqlwhere)
        {
            string strSql = "select distinct pcinfo from WMS_Bms_Inv_Info where 1=1";
            AdoHelper dataHelp = new SqlHelp();
            if(!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += sqlwhere;

            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //牌号
        public static DataSet GetKCPH()
        {
            string strSql = "select distinct top 2000 PH  from WMS_Bms_Inv_Info order by PH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //规格
        public static DataSet GetKCGG()
        {
            string strSql = "select distinct top 2000 GG  from WMS_Bms_Inv_Info order by GG";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //条码
        public static DataSet GetKCTM()
        {
            string strSql = "select distinct top 2000 barcode from WMS_Bms_Inv_Info order by barcode DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
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
        public static DataSet GetQueryKC_PCH(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "PCH,WLH,SX,VFREE1,VFREE2,VFREE3";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (SELECT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG, MAX(WLMC) AS WLMC, SX,VFREE1,VFREE2,VFREE3, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL,row_number() OVER (ORDER BY {0}) AS RowNumber FROM WMS_Bms_Inv_Info  WHERE (CK IS NOT NULL) {1} GROUP BY CK, HW, PCH, WLH,SX,VFREE1,VFREE2,VFREE3) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
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

        public static DataSet GetCountKC_PCH(string strWhere)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (SELECT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG, MAX(WLMC) AS WLMC, SX, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL){0} GROUP BY CK, HW, PCH, WLH, SX) select count(*) as HJCOUNT,sum(SL) as HJSL,sum(SUMZL) as HJZL from TempDB";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            return dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
        }
        /// <summary>
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount_PCH(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (SELECT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG, MAX(WLMC) AS WLMC, SX,VFREE1,VFREE2,VFREE3, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL){0} GROUP BY CK, HW, PCH, WLH, SX,VFREE1,VFREE2,VFREE3) select count(*) from TempDB";
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
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount_HW(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (SELECT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG,MAX(WLMC) AS WLMC, SX,VFREE1,VFREE2,VFREE3, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL){0} GROUP BY CK, HW, PCH, WLH, SX,VFREE1,VFREE2,VFREE3)select count(*) from TempDB";
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
        public static DataSet GetQueryKC_HW(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "PCH,WLH,SX,VFREE1,VFREE2,VFREE3";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (SELECT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG,MAX(WLMC) AS WLMC, SX,VFREE1,VFREE2,VFREE3, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL,row_number() OVER (ORDER BY {0}) AS RowNumber FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL){1} GROUP BY CK, HW, PCH, WLH,SX,VFREE1,VFREE2,VFREE3)SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
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

        public static DataSet GetCountKC_HW(string strWhere)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (SELECT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG,MAX(WLMC) AS WLMC, SX, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL){0} GROUP BY CK, HW, PCH, WLH, SX)select count(*) as HJCOUNT,sum(SL) as HJSL,sum(SUMZL) as HJZL from TempDB";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            return dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
        }

        /// <summary>
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount_TM(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (select * from WMS_Bms_Inv_Info{0})select count(*) from TempDB";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " where 1=1 " + strWhere;
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
        public static DataSet GetQueryKC_TM(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "barcode,PCH,WLH,SX";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (select * ,row_number() OVER (ORDER BY {0}) AS RowNumber FROM WMS_Bms_Inv_Info{1})SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere += " where 1=1 " + Sql_ZKD;
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

        public static DataSet GetCountKC_TM(string strWhere)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (select * from WMS_Bms_Inv_Info where 1=1 {0})select count(*) as HJCOUNT,sum(ZL) as HJZL from TempDB";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            return dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
        }


        public static DataSet GetCountKC_WLH(string strWhere)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (SELECT TOP 100 PERCENT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG,MAX(WLMC) AS WLMC, SX, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL) {0} GROUP BY CK, WLH, HW, PCH, SX)select count(*) as HJCOUNT,sum(SL) as HJSL,sum(SUMZL) as HJZL from TempDB";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            return dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
        }

        /// <summary>
        /// 得到总页数，和记录总条数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="allCount">记录总条数</param>
        /// <returns>总页数</returns>
        public static int GetPageCount_WLH(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "WITH TempDB AS (SELECT TOP 100 PERCENT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG,MAX(WLMC) AS WLMC, SX,VFREE1,VFREE2,VFREE3, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL) {0} GROUP BY CK, WLH, HW, PCH, SX,VFREE1,VFREE2,VFREE3)select count(*) from TempDB";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere +=strWhere;
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
        public static DataSet GetQueryKC_WLH(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "CK,WLH,PCH,HW,SX,VFREE1,VFREE2,VFREE3";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (SELECT TOP 100 PERCENT CK, HW, PCH, WLH, MAX(PH) AS PH, MAX(GG) AS GG,MAX(WLMC) AS WLMC, SX,VFREE1,VFREE2,VFREE3, MAX(RQ) AS RKRQ, SUM(ZL) AS SUMZL, COUNT(Barcode) AS SL,row_number() OVER (ORDER BY {0}) AS RowNumber FROM WMS_Bms_Inv_Info WHERE (CK IS NOT NULL) {1} GROUP BY CK, HW, PCH, WLH,SX,VFREE1,VFREE2,VFREE3)SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
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
    }
}
