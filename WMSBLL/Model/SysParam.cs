using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class SysParam
    {
        public SysParam()
		{}
        public SysParam(string cs_name, string cs_value, string cs_explain)
        {
            this._cs_name = cs_name;
            this._cs_value = cs_value;
            this._cs_explain = cs_explain;
        }
		#region Model
		private string _cs_name;
		private string _cs_value;
		private string _cs_explain;
		/// <summary>
		/// 参数名
		/// </summary>
		public string CS_Name
		{
			set{ _cs_name=value;}
			get{return _cs_name;}
		}
		/// <summary>
		/// 参数值
		/// </summary>
		public string CS_Value
		{
			set{ _cs_value=value;}
			get{return _cs_value;}
		}
		/// <summary>
		/// 参数说明
		/// </summary>
		public string CS_Explain
		{
			set{ _cs_explain=value;}
			get{return _cs_explain;}
		}
		#endregion Model


        public static string getwzip(string userid)
        {
            string sqlstr="select isnull(serverip,' ') as sip,isnull(port,-1) as sport from WMS_Pub_Users a left join wms_pub_door b " +
                "on a.doorno=b.doorno where a.userid='" + userid + "'";
            AdoHelper helper = new SqlHelp();
            DataSet ds = null;
            try
            {
                ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string sip = ds.Tables[0].Rows[0]["sip"].ToString().Trim();
                    return sip;
                }
                else return "";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Pub_Param set ");
			strSql.Append("CS_Value=@CS_Value,");
			strSql.Append("CS_Explain=@CS_Explain");
			strSql.Append(" where CS_Name=@CS_Name");
			SqlParameter[] parameters = {
                    new SqlParameter("@CS_Name",SqlDbType.VarChar),
					new SqlParameter("@CS_Value", SqlDbType.VarChar),
					new SqlParameter("@CS_Explain", SqlDbType.VarChar)};
			parameters[0].Value = this.CS_Name;
            parameters[1].Value = this._cs_value;
            parameters[2].Value = this.CS_Explain;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_Param ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CS_Name ");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static string GetParamValue(string ParamName)
        {
            string sqlstr = "select * from WMS_Pub_Param where CS_Name='"+ParamName+"'";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["cs_value"].ToString();
            return "";
        }
    }
}
