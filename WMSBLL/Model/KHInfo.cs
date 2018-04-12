using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.Model
{
    public class KHInfo
    {
        public KHInfo()
		{}
		#region Model
		private string _khid;
		private string _khname;
		private string _khadress;
		private string _khlb;
		/// <summary>
		/// 
		/// </summary>
		public string KHID
		{
			set{ _khid=value;}
			get{return _khid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KHName
		{
			set{ _khname=value;}
			get{return _khname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KHAdress
		{
			set{ _khadress=value;}
			get{return _khadress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KHLB
		{
			set{ _khlb=value;}
			get{return _khlb;}
		}
		#endregion Model

        /// <summary>
        /// 导入客户数据
        /// </summary>
        /// <returns>-1：NC服务器连接错误 1：本地服务器错误 0:成功</returns>
        public static int InportKHFromNC()
        {
            string strSelectNC = "select pk_cubasdoc,custcode,custname, saleaddr from bd_cubasdoc";
            AdoHelper oracleHelp = new OracleHelp();
            DataSet ds = null;
            try
            {
                ds = oracleHelp.ExecuteDataset(Common.NCDATASTRING, CommandType.Text, strSelectNC);
            }
            catch
            {
                return -1;//NC数据库联接失败
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                AdoHelper sqlHelp = new SqlHelp();
                StringBuilder strDel = new StringBuilder();
                strDel.Append("DELETE FROM WMS_Pub_Customer");

                SqlConnection con = new SqlConnection(Common.GetConnectString());
                con.Open();
                SqlTransaction tra = con.BeginTransaction();
                try
                {
                    sqlHelp.ExecuteNonQuery(tra, CommandType.Text, strDel.ToString());
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        StringBuilder strSql=new StringBuilder();
			            strSql.Append("insert into WMS_Pub_Customer(");
			            strSql.Append("KHID,KHName,KHAdress,KHLB)");
			            strSql.Append(" values (");
			            strSql.Append("@KHID,@KHName,@KHAdress,@KHLB)");
			            SqlParameter[] parameters = {
					            new SqlParameter("@KHID", SqlDbType.VarChar),
					            new SqlParameter("@KHName", SqlDbType.VarChar),
					            new SqlParameter("@KHAdress", SqlDbType.VarChar),
					            new SqlParameter("@KHLB", SqlDbType.VarChar)};
                        parameters[0].Value = row["custcode"].ToString();
                        parameters[1].Value = row["custname"].ToString();
                        parameters[2].Value = row["saleaddr"].ToString();
                        parameters[3].Value = "1";
                        sqlHelp.ExecuteNonQuery(tra,CommandType.Text,strSql.ToString(),parameters);
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

        public static int GetKHCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from WMS_Pub_Customer");
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

        /// <summary>
        /// 是否存在该客户
        /// </summary>
        /// <returns></returns>
        public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WMS_Pub_Customer");
			strSql.Append(" where KHID= @KHID");
			SqlParameter[] parameters = {
					new SqlParameter("@KHID", SqlDbType.VarChar)
				};
            parameters[0].Value = this.KHID;
            AdoHelper adoHelp = new SqlHelp();
            object obj = adoHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString(),parameters);
			int cmdresult;
			if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
			{
				cmdresult=0;
			}
			else
			{
				cmdresult=int.Parse(obj.ToString());
			}
			if(cmdresult==0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


        /// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_Pub_Customer(");
			strSql.Append("KHID,KHName,KHAdress,KHLB)");
			strSql.Append(" values (");
			strSql.Append("@KHID,@KHName,@KHAdress,@KHLB)");
			SqlParameter[] parameters = {
					new SqlParameter("@KHID", SqlDbType.VarChar),
					new SqlParameter("@KHName", SqlDbType.VarChar),
					new SqlParameter("@KHAdress", SqlDbType.VarChar),
					new SqlParameter("@KHLB", SqlDbType.VarChar)};
			parameters[0].Value = this.KHID;
			parameters[1].Value = this.KHName;
			parameters[2].Value = this.KHAdress;
			parameters[3].Value = this.KHLB;
            AdoHelper adoHelp=new SqlHelp();
			adoHelp.ExecuteNonQuery(Common.GetConnectString(),CommandType.Text,strSql.ToString(),parameters);
		}
    }
}
