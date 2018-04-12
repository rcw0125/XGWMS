using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ACCTRUE.WMSBLL.QueryBll;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class QTCKQuery
    {
        //生成新出库单号
        public static DataSet execQCDH()
        {
            string strSql = "XB_GetQTCKID";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds= dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.StoredProcedure, strSql.ToString());
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
        /// 绑定控件
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCHE_QTCK(string col, string sqlwhere)
        {
            string strSql = "select distinct "+col+" from WMS_CHE_QTCK";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where not (" + sqlwhere + " is null) and (" + sqlwhere + "<>'')";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 其它出库单批次号
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public static DataSet GetCHE_QTCKPCH(string col,string querycol,string sqlwhere)
        {
            string strSql = "select distinct " + col + " from WMS_CHE_QTCK_Item";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where " + querycol + "=" + "'"+sqlwhere+"'";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //select CKDH,CK,CPH,AimAdress,ZDR,ZDRQ,case STATUS when 0 then ''新建'' when 1 then ''正在执行'' when 2 then ''完成'' end as status from WMS_CHE_QTCK where 1=1 
        //查询条件
        public static DataSet QTCK_Query(string sqlwhere)
        {
            string strSql = "select *,case STATUS when 0 then '新建' when 1 then '正在执行' when 2 then '完成' end as status from WMS_CHE_QTCK where 1=1";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += sqlwhere;
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 其它出库明细单
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public static DataSet GetQTCKitem(string querycol, string sqlwhere)
        {
            string strSql = "select * from WMS_CHE_QTCK_Item";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where " + querycol + "='" + sqlwhere + "'";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 得到状态
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public static DataSet GetQTCKstatus(string querycol, string sqlwhere)
        {
            string strSql = "select STATUS from WMS_CHE_QTCK";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where " + querycol + "='" + sqlwhere + "'";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 得到记录个数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="allCount">数</param>
        /// <returns>得到记录个数</returns>
        public static int GetRecordCount(string strWhere)
        {
            string sqlWhere = "";
            string strSql = "select STATUS from WMS_CHE_QTCK";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " where ckdh='" + strWhere + "'";
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
        /// 取消完成
        /// </summary>
        public static int Exec_cancelqtck(string ckdh, string ick, string ioper)
        {
            string strSql = "L_OtherSell_CancelComplate";
            SqlParameter[] parameters = {
					new SqlParameter("@ickdh", SqlDbType.VarChar),
					new SqlParameter("@ick", SqlDbType.VarChar),
                    new SqlParameter("@ioper", SqlDbType.VarChar)};

            parameters[0].Value = ckdh;
            parameters[1].Value = ick;
            parameters[2].Value=ioper;
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.StoredProcedure, strSql.ToString(), parameters);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }
        /// <summary>
        /// 增加一个出库明细单
        /// </summary>
        public void Add(string ckdh, string pch, string sx, string wlh, string wlmc, string ph, string gg, string jhsl, string jhzl, int sjsl, double sjzl, string sldw, string zldw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WMS_CHE_QTCK_Item(");
            strSql.Append("CKDH,PCH,SX,WLH,WLMC,PH,GG,JHSL,JHZL,SJSL,SJZL,SLDW,ZLDW");
            strSql.Append(") values (");
            strSql.Append("'" + ckdh + "',");
            strSql.Append("'" + pch+ "',");
            strSql.Append("'" +sx + "',");
            strSql.Append("'" + wlh+ "',");
            strSql.Append("'" + wlmc + "',");
            strSql.Append("'" + ph + "',");
            strSql.Append("'" + gg + "',");
            strSql.Append("" + jhsl + ",");
            strSql.Append("" + jhzl + ",");
            strSql.Append("" + sjsl + ",");
            strSql.Append("" + sjzl + ",");
            strSql.Append("'" + sldw+ "',");
            strSql.Append("'" + zldw + "'");
            strSql.Append(")");
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除一个出库明细单
        /// </summary>
        public void CKDHDel(string sqlwhere)
        {
            string sqlDeleteDetail = "delete from WMS_Che_qtck_Item where ckdh = '" + sqlwhere + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteDetail);
                tra.Commit();
                con.Close();
            }
            catch
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        /// <summary>
        /// 重置一个出库明细单
        /// </summary>
        public void CKDHChongZhi(string sqlwhere)
        {
            string sqlDeleteDetail = "delete from wms_che_qtck_detail where ckdh='" + sqlwhere + "'";
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlDeleteDetail.ToString());
        }
        /// <summary>
        /// 修改一个出库明细单状态
        /// </summary>
        public void ChongZhiStatus(string sqlwhere)
        {
            string sqlDeleteDetail = "update WMS_CHE_QTCK set STATUS=0 where ckdh='" + sqlwhere + "'";
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlDeleteDetail.ToString());
        }
        /// <summary>
        /// 得到出库单打印明细
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public static DataSet GetQTCKprint(string sqlwhere)
        {
            string strSql = "select * from WMS_CHE_QTCK";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where ckdh='" + sqlwhere + "'";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        //select * from WMS_CHE_QTCK  where (1=1)and (ZDRQ  between datetimetostr(dtpstar.Date-1) and '+#39+datetimetostr(dtpend.Date)+#39+')'+sqlstr
        public static DataSet GetQTCKpt_Query1(string ckrq1,string ckrq2,string sqlwhere)
        {
            string strSql = "select * from WMS_CHE_QTCK";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where (1=1) and (ZDRQ  between '" +ckrq1 + "' and '" + ckrq2 + "') "+ sqlwhere;
            }
           
            
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        public static DataSet GetQTCKDJMX(string sqlwhere)
        {
            string strSql = "select * from WMS_Bms_Inv_OutInfo";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where FYDH='" + sqlwhere + "'";
            }


            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }


        public static DataSet GetPCHbyCK(string CK)
        {
            string sql = "select distinct pch from wms_bms_inv_info where ck= '" + CK + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetSXbyPCH(string PCH,string CK)
        {
            string sql = "select distinct sx,vfree1,vfree2,vfree3,wlh,WLMC,PH,GG from wms_bms_inv_info where ck='" + CK + "' and pch='" + PCH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetSXbyPCHNEW(string PCH, string CK)
        {
            string sql = "select distinct sx from wms_bms_inv_info where ck='" + CK + "' and pch='" + PCH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetFree1BySX(string SX, string PCH, string CK)
        {
            string sql = "select distinct VFREE1 from wms_bms_inv_info where CK = '" + CK + "' and PCH = '" + PCH + "' and SX = '" + SX + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetFree2BySX(string SX, string PCH, string CK)
        {
            string sql = "select distinct VFREE2 from wms_bms_inv_info where CK = '" + CK + "' and PCH = '" + PCH + "' and SX = '" + SX + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetFree3BySX(string SX, string PCH, string CK)
        {
            string sql = "select distinct VFREE3 from wms_bms_inv_info where CK = '" + CK + "' and PCH = '" + PCH + "' and SX = '" + SX + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetWLHbySX(string SX, string PCH, string CK)
        {
            string sql = "select distinct wlh,WLMC,PH,GG,VFREE1,VFREE2,VFREE3 from wms_bms_inv_info where CK = '" + CK + "' and PCH = '" + PCH + "' and SX = '" + SX + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetItemJieGou()
        {
            string sql1 = "select * from wms_che_qtck_item where 1=2";
            string sql2 = "select * from WMS_CHE_QTCK where 1=2";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds1 = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql1);
            ds1.Tables[0].TableName = "wms_che_qtck_item";
            DataSet ds2 = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql2);
            ds1.Tables.Add(ds2.Tables[0].Copy());
            ds1.Tables[1].TableName = "WMS_CHE_QTCK";
            return ds1;
        }

        public static void AddQTCKD(DataSet ds)
        {
            SqlHelp sqlhlp = new SqlHelp();
            sqlhlp.DataSetUpdate(Common.GetConnectString(), ds);
        }

        public static DataSet GetItem(string CKDH)
        {
            string sqlItem = "select * from wms_che_qtck_item where CKDH = '" + CKDH + "'";
            string sql = "select *,case STATUS when 0 then '新建' when 1 then '正在执行' when 2 then '完成' end as statusName from WMS_CHE_QTCK where CKDH = '" + CKDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet dsItem = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlItem);
            dsItem.Tables[0].TableName = "wms_che_qtck_item";
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            dsItem.Tables.Add(ds.Tables[0].Copy());
            dsItem.Tables[1].TableName = "WMS_CHE_QTCK";
            return dsItem;
        }

        public static string DeleteCKD(string CKDH)
        {
            string sqlDeleteItem = "delete from WMS_Che_qtck_Item where ckdh= '" + CKDH + "'";
            string sqlDeleteCKD = "delete from  WMS_CHE_QTCK where CKDH = '" + CKDH + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteItem);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteCKD);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch (Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public static int GetStatus(string CKDH)
        {
            string strSql = "select STATUS from WMS_CHE_QTCK where CKDH = '"+CKDH+"'";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        public static string CZDJ(string CKDH)
        {
            string sql1 = "delete from wms_che_qtck_detail where ckdh='" + CKDH + "'";
            string sql2 = "update WMS_CHE_QTCK set Status = 0 where CKDH = '" + CKDH + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql1);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql2);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch (Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public static int QXWC(string CKDH, string CK, string User)
        {
            string strSql = "L_OtherSell_CancelComplate";
            SqlParameter[] parameters = {
                    new SqlParameter("@ickdh", SqlDbType.VarChar),
                    new SqlParameter("@ick", SqlDbType.VarChar),
                    new SqlParameter("@ioper", SqlDbType.VarChar),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};

            parameters[0].Value = CKDH;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = CK;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = User;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Direction = ParameterDirection.ReturnValue;

            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteNonQuery(Common.GetConnectString(),CommandType.StoredProcedure, strSql, parameters);
            result = parameters[3].Value;
            return Convert.ToInt32(result);
        }

        public static DataSet GetDJDS(string CKDH)
        {
            string sql = "select * from WMS_Bms_Inv_OutInfo where FYDH= '" + CKDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetPrintDS(string strWhere)
        {
            string sql = "select * from WMS_CHE_QTCK where 1=1 " + strWhere;
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetPrintItem(string CKDH)
        {
            string sql = "select * from WMS_CHE_QTCK_ITEM where CKDH= '" + CKDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetPrintDJMX(string CKDH)
        {
            string sql = "select * from WMS_Bms_Inv_OutInfo where FYDH= '" + CKDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
    }
}
