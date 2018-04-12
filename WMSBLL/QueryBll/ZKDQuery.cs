using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class ZKDQuery
    {
         public ZKDQuery()
		{}
        public ZKDQuery(string ZKDH, string PCH, string SX)
        {
         
         this._ZKDH = ZKDH;
         this._PCH = PCH;
         this._SX = SX;
        }

        private string _ZKDH;
        private string _PCH;
        private string _SX;
        /// <summary>
        /// 
        /// </summary>
        public string ZKDH
        {
            set { _ZKDH = value; }
            get { return _ZKDH; }
        }
            public string PCH
            {
                set{_PCH=value;}
                get{return _PCH;}
            }
            public string SX
            {
                set{_SX=value;}
                get{return _SX;}
            }
       
        	
        /// <summary>
        /// 获取转库单号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDID()
        {
            string strSql = "select distinct TOP 1000 ZKDH  from WMS_Bms_Tra_ZKD  order by ZKDH DESC";
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
        public static DataSet GetPCHID()
        {
            string strSql = "select distinct TOP 1000 pch  from WMS_Bms_Tra_ZKD_Detail  order by pch";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
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
        /// 获取物料号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWLHID()
        {
            string strSql = "select distinct TOP 1000 wlh  from WMS_Bms_Tra_ZKD  order by wlh";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取属性
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDSX()
        {
            string strSql = "select distinct TOP 1000 sx  from WMS_Bms_Tra_ZKD  order by sx";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取牌号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDPH()
        {
            string strSql = "select distinct TOP 1000 ph  from WMS_Bms_Tra_ZKD  order by ph";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取规格
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDGG()
        {
            string strSql = "select distinct TOP 1000 gg  from WMS_Bms_Tra_ZKD  order by gg";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取车牌号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDCPH()
        {
            string strSql = "select distinct TOP 1000 CPH  from WMS_Bms_Tra_ZKD_Detail  order by CPH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取转库单明细
        /// </summary>
        /// <param name="strWGDH"></param>
        /// <returns></returns>
        public static DataSet GetZKDItems(string strZKDH)
        {
            string sqlPCH = "SELECT * FROM WMS_Bms_Tra_ZKD_Detail WHERE ZKDH='" + strZKDH + "' order by zkdh";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
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
            string strSql = "SELECT count(*) from VIEW_ZKD_Total_CPH{0}";
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
        public static DataSet GetQueryZKD(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "ZKDH";
            int pSize = 20;
            int pNum = 1;
              //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
            string pagesql = "WITH TempDB AS (select *,case status when 0 then '未转入' else '转入完毕' end as desc_status,case outstatus when 0 then '未转出' else '转出完毕' end as desc_outstatus,case zhxlb when 0 then '单卷转出' when 1 then '整批转出' else '未转出' end as desc_zhxlb,row_number() OVER (ORDER BY {0}) AS RowNumber from VIEW_ZKD_Total_CPH{1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
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
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text,sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        
        }

        /// <summary>
        /// 到处EXCEL时的查询语句
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet QueryZKDExcel(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select ZKDH AS 转库单号,cph AS 车牌号,pch as 批次,wlh as 物料号");
            sbSql.Append(",SX as 属性,substring(YHW,1,3) as 原仓库,YHW as 原货位,substring(MBHW,1,3) as 目的仓库");
            sbSql.Append(",MBHW AS 目标货位, FJLDW AS 辅计量单位");
            sbSql.Append(",ZJLDW AS 主计量单位,JHSL AS 计划数量");
            sbSql.Append(",OutNum as 卷数转出总计,OutZL as 重量转出总计,InNum as 转入卷数总计,SL as 单车卷数,ZL as 单车重量");
            //sbSql.Append(",OutNum as 卷数(转出总计));
            sbSql.Append(",case zhxlb when 0 then '单卷转出' when 1 then '整批转出' else '未转出' end as 转出类别");
            sbSql.Append(",case outstatus when 0 then '未转出' else '转出完毕' end as 转出状态");
            sbSql.Append(",CKOperator as 出库操作,CKTime as 转出时间");
            sbSql.Append(",case status when 0 then '未转入' else '转入完毕'end as 转入状态");
            sbSql.Append(",RKOperator as 入库操作,RKTime as 转入时间,WLMC as 物料名称 from VIEW_ZKD_Total_CPH");
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
        /// 更新一条单据信息
        /// </summary>
        public void UpdteZKD(string zhdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Bms_Tra_ZKD set status=1,outstatus=1");
            strSql.Append(" where zkdh='" + zhdh + "'");
            AdoHelper DbHelperSQL = new SqlHelp();
            DbHelperSQL.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        public int execZKD()
        {
            string strSql = "ZKD_Reset";
            SqlParameter[] parameters = {
					new SqlParameter("@ZKDH", SqlDbType.VarChar),
					new SqlParameter("@PCH", SqlDbType.VarChar),
					new SqlParameter("@SX", SqlDbType.VarChar),
                    new SqlParameter("@return_value",SqlDbType.Int)};
            parameters[0].Value = this.ZKDH; ;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = this.PCH;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = this.SX;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Direction = ParameterDirection.ReturnValue;
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, strSql, parameters);
            result = parameters[3].Value;
            return Convert.ToInt32(result);
        
        }
        public static int chongzhiZKD(string zkdh, string pch, string sx)
        {
            string strSql = "ZKD_Reset";
            SqlParameter[] parameters = {
              		new SqlParameter("@ZKDH", SqlDbType.VarChar),
					new SqlParameter("@PCH", SqlDbType.VarChar),
					new SqlParameter("@SX", SqlDbType.VarChar),
                    new SqlParameter("@return_value",SqlDbType.Int)};

            parameters[0].Value = zkdh;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = pch;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = sx;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Direction = ParameterDirection.ReturnValue;

            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, strSql, parameters);
            result = parameters[3].Value;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 得到正在执行的转库单数目
        /// </summary>
        /// <returns>总数</returns>
        public static int GetExeZKDCount()
        {
            string strSql = "SELECT count(*) FROM WMS_Bms_Tra_ZKD where status<>1 or outstatus<>1";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
                return Convert.ToInt32(result);
            return 0;
        }
        /// <summary>
        /// 得到数量
        /// </summary>
        /// <returns>总数</returns>
        public static int GetCKDSL(string col, string sqlwhere)
        {
            AdoHelper dataHelp = new SqlHelp();
            string strSql = "SELECT sum(" + col + ") from VIEW_ZKD_Total_CPH";
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where " + sqlwhere;
            }
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
        public static double GetCKDZL(string col, string sqlwhere)
        {
            string strSql = "SELECT sum(" + col + ") from VIEW_ZKD_Total_CPH";
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
