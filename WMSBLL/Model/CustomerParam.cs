using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;
namespace ACCTRUE.WMSBLL.Model
{
    public class CustomerParam
    {
        public CustomerParam()
		{}
        public CustomerParam(string KHID, string KHName, string KHAdress, string KHLB)
        {
            this._khid = KHID;
            this._khname = KHName;
            this._khadress = KHAdress;
            this._khlb = KHLB;
        }
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

        #region  成员方法

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by KHID ");

            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion  成员方法

        #region  成员方法
        /// <summary>
        /// 根据条件查询客户
        /// </summary>
        public DataSet GetListByEnter()
		{
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select * from WMS_Pub_Customer ");
            strSql.Append(" where (KHID like '%'+@KHID+'%' OR @KHID IS NULL) AND ( KHName like '%'+@KHName+'%' OR @KHName IS NULL)");
            SqlParameter[] parameters = {
                    new SqlParameter("@KHID", SqlDbType.VarChar),
                    new SqlParameter("@KHName", SqlDbType.VarChar),};
            parameters[0].Value = this.KHID;
            parameters[1].Value = this.KHName;

            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
            return ds;
		}

        #endregion  成员方法
        #region  成员方法
        /// <summary>
		/// 得到客户的总个数
		/// </summary>
		public int GetSumId()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(khid) as countkhid from WMS_Pub_Customer");
            AdoHelper DbhelperSQL = new SqlHelp();
            object obj = DbhelperSQL.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        #endregion  成员方法
        #region  成员方法

        /// <summary>
        /// 导入客户数据
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
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
		}
        #endregion  成员方法
    }
    	
}
