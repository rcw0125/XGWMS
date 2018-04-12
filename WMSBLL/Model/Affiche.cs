using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Acctrue.WM_WES.DataAccess;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.Model
{
    public class Affiche
    {
        public Affiche()
		{}
		private string _guid;
		private string _userid;
		private string _username;
		private DateTime _ptime;
		private string _title;
		private string _filename;
		private string _filecontent;
        private int _typenbr;
		/// <summary>
		/// 
		/// </summary>
		public string GUID
		{
			set{ _guid=value;}
            get { return _guid; }
		}
		/// <summary>
		/// 发布人ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 发布人名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime PTime
		{
			set{ _ptime=value;}
			get{return _ptime;}
		}
		/// <summary>
		/// 发布标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 文件名
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 文件内容
		/// </summary>
		public string FileContent
		{
			set{ _filecontent=value;}
			get{return _filecontent;}
		}
        /// <summary>
        /// 类型
        /// </summary>
        public int TypeNbr
        {
            set { _typenbr = value; }
            get { return this._typenbr; }
        }
        /// <summary>
        /// 获得所有公告信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllAffiches()
        {
            string strSql = "SELECT * FROM WMS_Pub_Affiche";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Pub_Affiche set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("PTime=@PTime,");
			strSql.Append("Title=@Title,");
			strSql.Append("FileName=@FileName,");
			strSql.Append("FileContent=@FileContent,");
			strSql.Append("TypeNbr=@TypeNbr");
			strSql.Append(" where Guid=@Guid");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.VarChar),
					new SqlParameter("@UserID", SqlDbType.VarChar),
					new SqlParameter("@UserName", SqlDbType.VarChar),
					new SqlParameter("@PTime", SqlDbType.VarChar),
					new SqlParameter("@Title", SqlDbType.VarChar),
					new SqlParameter("@FileName", SqlDbType.VarChar),
					new SqlParameter("@FileContent", SqlDbType.VarChar),
					new SqlParameter("@TypeNbr", SqlDbType.Int)};
            parameters[0].Value = this.GUID;
            parameters[1].Value = this.UserID;
            parameters[2].Value = this.UserName;
            parameters[3].Value = this.PTime;
            parameters[4].Value = this.Title;
            parameters[5].Value = this.FileName;
            parameters[6].Value = this.FileContent;
            parameters[7].Value = this.TypeNbr;
            AdoHelper ado = new SqlHelp();
            ado.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_Pub_Affiche(");
			strSql.Append("Guid,UserID,UserName,PTime,Title,FileName,FileContent,TypeNbr)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@UserID,@UserName,@PTime,@Title,@FileName,@FileContent,@TypeNbr)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.VarChar),
					new SqlParameter("@UserID", SqlDbType.VarChar),
					new SqlParameter("@UserName", SqlDbType.VarChar),
					new SqlParameter("@PTime", SqlDbType.DateTime),
					new SqlParameter("@Title", SqlDbType.VarChar),
					new SqlParameter("@FileName", SqlDbType.VarChar),
					new SqlParameter("@FileContent", SqlDbType.VarChar),
					new SqlParameter("@TypeNbr", SqlDbType.Int)};
            parameters[0].Value = this.GUID;
            parameters[1].Value = this.UserID;
            parameters[2].Value = this.UserName;
            parameters[3].Value = this.PTime;
            parameters[4].Value = this.Title;
            parameters[5].Value = this.FileName;
            parameters[6].Value = this.FileContent;
            parameters[7].Value = this.TypeNbr;

            AdoHelper ado = new SqlHelp();
            ado.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Delete()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM WMS_Pub_Affiche where Guid='");
            strSql.Append(this.GUID);
            strSql.Append("'");
            AdoHelper ado = new SqlHelp();
            ado.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到公告
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static Affiche GetAffiche(string guid)
        {
            string slq = "SELECT * FROM WMS_Pub_Affiche WHERE Guid='" + guid + "'";
            AdoHelper adoHelp = new SqlHelp();
            DataSet ds = adoHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, slq);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Affiche aff = new Affiche();
                aff.GUID = guid;
                aff.FileContent=ds.Tables[0].Rows[0]["FileContent"].ToString();
                aff.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                aff.PTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PTime"]);
                aff.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                aff.TypeNbr = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeNbr"]);
                aff.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                aff.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                return aff;
            }
            return null;
        }
    }
}
