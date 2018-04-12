using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class WGDQuery
    {
        /// <summary>
        /// 获取批次号的查询条件
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPCHTerm()
        {
            string sqlPCH = "select distinct TOP 1000 PCH  from WMS_Bms_Rec_WGD order by PCH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取特殊信息查询条件
        /// </summary>
        /// <param name="pch"></param>
        /// <returns></returns>
        public static DataSet GetPCInfo(string pch)
        {
            string sqlPCInfo = "select distinct pcinfo from WMS_Bms_Rec_WGD";
            if (!string.IsNullOrEmpty(pch))
            {
                sqlPCInfo += " WHERE pch='" + pch + "'";
            }
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCInfo);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取批次属性的查询条件
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPCSX()
        {
            string sqlPCH = "select Distinct PCSX  from WMS_Bms_Rec_WGD order by PCSX";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取物料号的查询条件
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWLH()
        {
            string sqlPCH = "select distinct TOP 1000 WLH  from WMS_Bms_Rec_WGD order by WLH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取生产线条件
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSCX()
        {
            string sqlPCH = "select Distinct SCXBM,SCXName  from WMS_Pub_SCX order by SCXBM";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取牌号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPH()
        {
            string sqlPCH = "select distinct TOP 1000 PH  from WMS_Bms_Rec_WGD order by PH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取规格
        /// </summary>
        /// <returns></returns>
        public static DataSet GetGG()
        {
            string sqlPCH = "select distinct TOP 1000 GG  from WMS_Bms_Rec_WGD order by GG DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取完工单号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWGDH()
        {
            string sqlPCH = "select distinct top 1000 WGDH  from WMS_Bms_Rec_WGD order by WGDH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取质检人
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZJR()
        {
            string sqlPCH = "SELECT distinct a.NCWLBMID,B.USERNAME,a.NCWLBMID+'|'+B.USERNAME AS ZJR FROM WMS_Bms_Rec_WGD a , WMS_PUB_USERS B where ncwlbmid  is not NULL AND A.NCWLBMID =B.USERid ORDER BY B.USERnAME";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 通过生产线编码获取生产线ID
        /// </summary>
        /// <param name="scxbm">生产线编码</param>
        /// <returns></returns>
        public static string GetSCXID(string scxbm)
        {
            string sql = "select * from WMS_Pub_scx where scxbm='" + scxbm + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["SCXNCID"].ToString();
            return "";
        }
        /// <summary>
        /// 分页查询完工单信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">每页多少条</param>
        /// <param name="pageNum">当前显示的为第几页</param>
        /// <returns></returns>
        public static DataSet QueryWGD(string strWhere,string orderKey,int pageSize,int pageNum)
        {
            string sWhere = "";
            string oKey = "WGDH";
            int pSize = 20;
            int pNum = 1;
            //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pageSql = "WITH TempDB AS (SELECT a.*,case a.pclx when 0 then '普通线材' else '出口线材' end as Desc_pclx,case a.wcbz when 0 then '未执行' when 1 then '正在打牌' when 2 then '打牌完毕'else '入库完毕'end as Desc_wcbz,b.scxbm as Scxbm,row_number() OVER (ORDER BY {0}) AS RowNumber FROM wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sWhere = " Where " + strWhere;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pageSql, oKey,sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text,sqlStr.ToString());
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
        public static int GetPageCount(string strWhere,int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(*) from wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid {0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE " + strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text,strSql);
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
        /// 得到跑钩数
        /// </summary>
        /// <param name="strWhere">查询条件，不带WHERE</param>
        /// <returns>跑钩数</returns>
        public static int GetPaoGouCount(string strWhere)
        {
            string sqlWhere = "";
            string strSql = "SELECT sum(a.PGBZ) from wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid {0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE " + strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        /// <summary>
        /// 根据完工单号获取完工单明细
        /// </summary>
        /// <param name="strWGDH"></param>
        /// <returns></returns>
        public static DataSet GetWGDItems(string strWGDH)
        {
            string sqlPCH = "SELECT * FROM WMS_Bms_Rec_WGD_Item WHERE WGDH='"+strWGDH+"'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 根据完工单号获取完工单信息
        /// </summary>
        /// <param name="strWGDH"></param>
        /// <returns></returns>
        public static DataSet GetWGDInfo(string strWGDH)
        {
            string sqlPCH = "select * from WMS_Bms_Rec_WGD where wgdh='" + strWGDH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 到处EXCEL时的查询语句
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet QueryWGDExcel(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select a.WGDH AS 完工单号,b.scxbm AS 生产线,a.PCH AS 批次,a.PCSX AS 批次属性");
            sbSql.Append(",a.pcinfo AS 特殊信息,case a.pclx when 0 then '普通线材' else '出口线材' end as 批次类型 ");
            sbSql.Append(",a.PH AS 牌号,a.GG AS 规格,a.WLH AS 物料号,a.WLMC AS 物料名称 ");
            sbSql.Append(",a.ZXBZ AS 执行标准,a.FZDW AS 辅助单位");
            sbSql.Append(",a.PCXH AS 序号,a.ZJBZ AS 质检标志");
            sbSql.Append(",a.PGBZ as 跑钩数目,a.Rev_Time AS 接收时间,a.PEnd_Time AS 生产完成时间");
            sbSql.Append(",a.End_Time as 入库完成时间,case a.wcbz when 0 then '未执行' when 1 then '正在打牌' when 2 then '打牌完毕'else '入库完毕'end as 单据状态");
            sbSql.Append(",a.BB AS 班别 from wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid");
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
        /// 得到正在执行的所有完工单数目
        /// </summary>
        /// <returns>总数</returns>
        public static int GetExeWGDCount()
        {
            string strSql = "SELECT count(*) FROM WMS_Bms_Rec_WGD where wcbz<3";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
                return Convert.ToInt32(result);
            return 0;
        }
    }
}
