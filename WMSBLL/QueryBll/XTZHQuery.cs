using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class XTZHQuery
    {
        /// <summary>
        /// 获取形态转换仓库号
        /// </summary>
        /// <returns></returns>
        public static DataSet GetXTZHCKID()
        {
            string strSql = "select CKID,CKName from WMS_Pub_Store order by ckid";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取形态转换
        /// </summary>
        /// <returns></returns>
        public static DataSet GetXTZH(string strWhere,string orderKey,int pageSize,int pageNum)
        {
            string sWhere = "";
            string oKey = "ZHDH";
            int pSize = 20;
            int pNum = 1;
            string pageSql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0}) AS RowNumber from wms_cha_xtzhd where 1=1{1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sWhere += strWhere;
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
        public static int GetPageCount(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(*) from wms_cha_xtzhd where 1=1{0}";
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
        /// 单据获取形态转换
        /// </summary>
        /// <returns></returns>
        public static DataSet GetDJXTZHYC(string sqlwhere)
        {
            string strSql = "select top 500 * from wms_cha_xtzhd where 1=1";
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
        /// 获取形态转换select * from wms_cha_xtzhd_item where zhdh=:zhdh
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 获取形态转换
        /// </summary>
        /// <returns></returns>
        public static DataSet GetXTZHYC()
        {
            string strSql = "select * from wms_cha_xtzhd where 1=2";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// 获取形态转换select * from wms_cha_xtzhd_item where zhdh=:zhdh
        /// </summary>
        /// <returns></returns>
        public static DataSet GetXTItem(string SqlWhere)
        {
            string strSql = "select * from wms_cha_xtzhd_item";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(SqlWhere))
            {
                strSql += " where ZHDH='" + SqlWhere+"'";
            }

                DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds;
                return null;
     
        }
        /// <summary>
        /// 获取形态转换select * from wms_cha_xtzhd_item where zhdh=:zhdh
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCopyXTItem(string sqlwhere)
        {
            string strSql = "select * from wms_cha_xtzhd_item";
            AdoHelper dataHelp = new SqlHelp();
            if(!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where zhdh='" + sqlwhere + "'";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetList(string SqlWhere)
        {
            string strSql = "select Status from wms_cha_xtzhd";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(SqlWhere))
            {
                strSql += " where ZHDH='" + SqlWhere+"'";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public void XTZHDDelete(string SqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            AdoHelper dataHelp = new SqlHelp();
            strSql.Append("delete WMS_Cha_XTZHD ");
            strSql.Append(" where ZHDH=" + SqlWhere);
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        public void ZHDitem(string SqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            AdoHelper dataHelp = new SqlHelp();
            strSql.Append("delete wms_cha_xtzhd_item ");
            strSql.Append(" where ZHDH=" + SqlWhere);
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }

        public void ZHDresult(string SqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            AdoHelper dataHelp = new SqlHelp();
            strSql.Append("delete wms_cha_xtzhd_result ");
            strSql.Append(" where ZHDH=" + SqlWhere);
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 单据编号是否存在
        /// </summary>
        public bool Exists(string SqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from wms_cha_xtzhd_item where ZHDH=" + SqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object obj = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 得到正在执行的形态转换单数目
        /// </summary>
        /// <returns>总数</returns>
        public static int GetExeXTZHCount()
        {
            string strSql = "SELECT count(*) FROM WMS_Cha_XTZHD where status<>2";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
                return Convert.ToInt32(result);
            return 0;
        }
        public static int Check_Zpzh(string zhdh)
        {
            int retvalue = 0;
            string sjhsl = "";
            string skcsl = "";
            string sqlstr = "select sum(jhsl)as sjhsl from WMS_Cha_XTZHD_Item where zhdh in (select zhdh from "+
                "WMS_Cha_XTZHD where  pch in(select pch from WMS_Cha_XTZHD where zhdh='"+zhdh+"')) ";        
            AdoHelper helper = new SqlHelp();
            DataSet ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            sjhsl = ds.Tables[0].Rows[0]["sjhsl"].ToString();
            sqlstr = "select count(1) as skcsl from WMS_Bms_Inv_Info where pch=(select pch from WMS_Cha_XTZHD "+
                     "where zhdh='"+zhdh+"')";
            ds = helper.ExecuteDataset(Common.GetConnectString(),CommandType.Text,sqlstr);
            skcsl = ds.Tables[0].Rows[0]["skcsl"].ToString();
            if (sjhsl != skcsl)
                retvalue = 1;
            return retvalue;
        }
        public static int Exec_Xtzk(string zhdh, string user,string flag)
        {
            string strSql = "wms_che_xtzh_zpgp";
            SqlParameter[] parameters = {
					new SqlParameter("@xtzhd", SqlDbType.VarChar),
					new SqlParameter("@Auser", SqlDbType.VarChar),
                    new SqlParameter("@operatFlag", SqlDbType.VarChar),
                    new SqlParameter("@result_i",SqlDbType.Int)};

            parameters[0].Value = zhdh;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = user;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = flag;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Direction = ParameterDirection.ReturnValue;
        
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, strSql, parameters);
            result = parameters[3].Value;
            return Convert.ToInt32(result);
        }
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="zkdh"></param>
        /// <param name="user"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public void Insert_Xtzk(string zkdh,string user,string ck)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WMS_Pub_HuiChuan(");
            strSql.Append("BillNum,Type,Operater,CK");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + zkdh + "',");
            strSql.Append("'4N',");
            strSql.Append("'" + user + "',");
            strSql.Append("" + ck + "");
            strSql.Append(")");
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
		}
        //删除形态转换的数据
        public static int DeleteXTZH(string zhdh)
        {
           string sqlxtzhd="delete from wms_cha_xtzhd where zhdh='"+zhdh+"'";
           string sqlitem = "delete from wms_cha_xtzhd_item where zhdh='" + zhdh + "'";
           string sqlresult = "delete from wms_cha_xtzhd_result where zhdh='" + zhdh + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlxtzhd);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlitem);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlresult);
                tra.Commit();
                con.Close();
                return 0;
            }
            catch
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return -1;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
