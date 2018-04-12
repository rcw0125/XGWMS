using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.Model
{
    public class WlbaseInfo
    {
        public WlbaseInfo()
        { }
        #region Model
        private string _wlh;
        private string _ph;
        private string _gg;
        private string _sx;
        private string _sxcode;
        /// <summary>
        /// 
        /// </summary>
        public string wlh
        {
            set { _wlh = value; }
            get { return _wlh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ph
        {
            set { _ph = value; }
            get { return _ph; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gg
        {
            set { _gg = value; }
            get { return _gg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sx
        {
            set { _sx = value; }
            get { return _sx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sxcode
        {
            set { _sxcode = value; }
            get { return _sxcode; }
        }
        #endregion Model
        /// <summary>
        /// 获得物料基础信息
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_BMS_WL_SX ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            AdoHelper adoHelp = new SqlHelp();
            DataSet ds = adoHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 导入物料基础数据
        /// </summary>
        /// <returns>-1：NC服务器连接错误 1：本地服务器错误 0:成功</returns>
        public static int InportWLFromNC()
        {
            string strSele = Common.GetWLSql();
            if (string.IsNullOrEmpty(strSele))
                return -1;//无配置信息
            AdoHelper oracleHelp = new OracleHelp();
            DataSet ds = null;
            try
            {
                ds = oracleHelp.ExecuteDataset(Common.NCDATASTRING, CommandType.Text, strSele);
            }
            catch
            {
                return -1;//NC数据库联接失败
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                AdoHelper sqlHelp = new SqlHelp();
                StringBuilder strDel = new StringBuilder();
                strDel.Append("delete from wms_bms_wl_sx");

                SqlConnection con = new SqlConnection(Common.GetConnectString());
                con.Open();
                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    sqlHelp.ExecuteNonQuery(tra, CommandType.Text, strDel.ToString());
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("INSERT INTO WMS_BMS_WL_SX (wlh,sx) VALUES (@WLH,@SX)");
                        SqlParameter[] parameters = {
					            new SqlParameter("@WLH", SqlDbType.VarChar),
					            new SqlParameter("@SX", SqlDbType.VarChar)};
                        parameters[0].Value = row["invcode"].ToString();
                        parameters[1].Value = row["docname"].ToString();
                        sqlHelp.ExecuteNonQuery(tra, CommandType.Text, strSql.ToString(), parameters);
                    }
                    tra.Commit();
                    con.Close();
                }
                catch
                {
                    tra.Rollback();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    return 1;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return 0;
        }

        public static string GetPHGG(string wlh)
        {
            AdoHelper oracleHelp = new OracleHelp();
            DataSet ds = null;
            try
            {
                ds = oracleHelp.ExecuteDataset(Common.NCDATASTRING, CommandType.Text, "select invtype,invspec from bd_invbasdoc where invcode='" + wlh + "'");
            }
            catch
            {
                return "";//NC数据库联接失败
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString() +","+ ds.Tables[0].Rows[0][1].ToString();
            }
            return "";
        }

        public static int GetWLCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from WMS_BMS_WL_SX");
            AdoHelper adoHelp = new SqlHelp();
            object obj = adoHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            return cmdresult;
        }
    }
}
