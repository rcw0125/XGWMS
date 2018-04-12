using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class Store
    {
        public Store()
		{}
        public Store(string ckncid, string ckid, string ckname)
        {
            this._ckid = ckid;
            this._ckname = ckname;
            this._ckncid = ckncid;
        }
		private string _ckncid;
		private string _ckid;
		private string _ckname;
		/// <summary>
		/// 仓库NC编码
		/// </summary>
		public string CKNCID
		{
			set{ _ckncid=value;}
			get{return _ckncid;}
		}
		/// <summary>
		/// 仓库ID
		/// </summary>
		public string CKID
		{
			set{ _ckid=value;}
			get{return _ckid;}
		}
		/// <summary>
		/// 仓库名称
		/// </summary>
		public string CKName
		{
			set{ _ckname=value;}
			get{return _ckname;}
		}

        /// <summary>
        /// 增加一个仓库
        /// </summary>
        /// <param name="model"></param>
        public void Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_Pub_Store(");
			strSql.Append("CKNCID,CKID,CKName)");
			strSql.Append(" values (");
			strSql.Append("@CKNCID,@CKID,@CKName)");
			SqlParameter[] parameters = {
					new SqlParameter("@CKNCID", SqlDbType.VarChar),
					new SqlParameter("@CKID", SqlDbType.VarChar),
					new SqlParameter("@CKName", SqlDbType.VarChar)};
            parameters[0].Value = this._ckncid;
            parameters[1].Value = this._ckid;
            parameters[2].Value = this._ckname;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}

        /// <summary>
        /// 是否已经存在该仓库
        /// </summary>
        public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WMS_Pub_Store");
            strSql.Append(" where CKNCID= @CKNCID and CKID=@CKID");
			SqlParameter[] parameters = {
					new SqlParameter("@CKNCID", SqlDbType.VarChar),
                    new SqlParameter("@CKID",SqlDbType.VarChar)};
			parameters[0].Value =this._ckncid;
            parameters[1].Value = this._ckid;
            AdoHelper dataHelp = new SqlHelp();
            Object obj = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Pub_Store set ");
			strSql.Append("CKNCID=@CKNCID,");
			strSql.Append("CKID=@CKID,");
			strSql.Append("CKName=@CKName");
			strSql.Append(" where CKNCID=@CKNCID AND CKID=@CKID");
			SqlParameter[] parameters = {
					new SqlParameter("@CKNCID", SqlDbType.VarChar),
					new SqlParameter("@CKID", SqlDbType.VarChar),
					new SqlParameter("@CKName", SqlDbType.VarChar)};
            parameters[0].Value = this._ckncid;
            parameters[1].Value = this._ckid;
            parameters[2].Value = this._ckname;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [WMS_Pub_Store] ");
            strSql.Append(" where CKNCID=@CKNCID AND CKID=@CKID");
            SqlParameter[] parameters = {
					new SqlParameter("@CKNCID", SqlDbType.VarChar),
					new SqlParameter("@CKID", SqlDbType.VarChar)};
            parameters[0].Value = this._ckncid;
            parameters[1].Value = this._ckid;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_Store ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CKID ");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds= dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        public static DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CKID,CKNCID,CKID+'|'+CKName AS CKCKName from WMS_Pub_Store ");
            strSql.Append(" order by CKID ");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
    }
}
