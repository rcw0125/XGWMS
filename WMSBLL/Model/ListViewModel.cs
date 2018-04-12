using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class ListViewModel
    {
        public ListViewModel()
		{}
		private int _id;
		private int _pagenbr;
		private string _pagedes;
		private string _showlist;
		private string _userid;
		private int _type;
		private string _typedes;
        private int _headfont=9;
        private int _listfont=9;
		/// <summary>
		/// 模板ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 所属页面
		/// </summary>
		public int PageNbr
		{
			set{ _pagenbr=value;}
			get{return _pagenbr;}
		}
		/// <summary>
		/// 页面描述
		/// </summary>
		public string PageDes
		{
			set{ _pagedes=value;}
			get{return _pagedes;}
		}
		/// <summary>
		/// 要显示的列表
		/// </summary>
		public string ShowList
		{
			set{ _showlist=value;}
			get{return _showlist;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 模板类型0：自定义模板 1：系统模板，本系统只支持自定义模板
		/// </summary>
		public int Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 模板类型描述
		/// </summary>
		public string TypeDes
		{
			set{ _typedes=value;}
			get{return _typedes;}
		}

        /// <summary>
        /// 列表头字体
        /// </summary>
        public int HeadFont
        {
            set { _headfont = value; }
            get { return _headfont; }
        }
        /// <summary>
        /// 列表字体
        /// </summary>
        public int ListFont
        {
            set { _listfont = value; }
            get { return _listfont; }
        }

        /// <summary>
        /// 得到一模板
        /// </summary>
        public static ListViewModel GetListViewModelModel(string userID,int pageNbr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from WMS_PUB_LISTCONFIG ");
			strSql.Append(" where UserID=@UserID AND PageNbr=@PageNbr");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar),
                    new SqlParameter("@PageNbr",SqlDbType.Int)};
            parameters[0].Value = userID;
            parameters[1].Value = pageNbr;
            ListViewModel listMode = null;
            AdoHelper dataHelp = new SqlHelp();
            using (SqlDataReader sdr = (SqlDataReader)dataHelp.ExecuteReader(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters))
            {
                if (sdr.Read())
                {

                    listMode = new ListViewModel();
                    listMode.ID = Convert.ToInt32(sdr["ID"]);
                    listMode.PageDes = Convert.ToString(sdr["PageDes"]);
                    listMode.PageNbr = Convert.ToInt32(sdr["PageNbr"]);
                    listMode.ShowList = Convert.ToString(sdr["ShowList"]);
                    listMode.Type = Convert.ToInt32(sdr["Type"]);
                    listMode.TypeDes = Convert.ToString(sdr["TypeDes"]);
                    listMode.UserID = Convert.ToString(sdr["UserID"]);
                    listMode.HeadFont = Convert.ToInt32(sdr["HeadFont"]);
                    listMode.ListFont = Convert.ToInt32(sdr["ListFont"]);
                }
                sdr.Dispose();
            }
            return listMode;
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_PUB_LISTCONFIG set ");
            strSql.Append("ShowList=@ShowList,HeadFont=@HeadFont,ListFont=@ListFont");
			strSql.Append(" where UserID=@UserID AND PageNbr=@PageNbr");
            SqlParameter[] parameters = {
					new SqlParameter("@PageNbr", SqlDbType.Int),
					new SqlParameter("@ShowList", SqlDbType.VarChar),
                    new SqlParameter("@HeadFont",SqlDbType.Int),
                    new SqlParameter("@ListFont",SqlDbType.Int),
					new SqlParameter("@UserID", SqlDbType.VarChar)};
			parameters[0].Value = this.PageNbr;
			parameters[1].Value = this.ShowList;
            parameters[2].Value = this.HeadFont;
            parameters[3].Value = this.ListFont;
			parameters[4].Value = this.UserID;
            AdoHelper dataHelp=new SqlHelp();
			dataHelp.ExecuteNonQuery(Common.GetConnectString(),CommandType.Text,strSql.ToString(),parameters);
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_PUB_LISTCONFIG(");
            strSql.Append("PageNbr,PageDes,ShowList,UserID,HeadFont,ListFont)");
			strSql.Append(" values (");
            strSql.Append("@PageNbr,@PageDes,@ShowList,@UserID,@HeadFont,@ListFont)");
			SqlParameter[] parameters = {
					new SqlParameter("@PageNbr", SqlDbType.Int),
					new SqlParameter("@PageDes", SqlDbType.VarChar),
					new SqlParameter("@ShowList", SqlDbType.VarChar),
					new SqlParameter("@UserID", SqlDbType.VarChar),
                    new SqlParameter("@HeadFont", SqlDbType.Int),
                    new SqlParameter("@ListFont", SqlDbType.Int)};
			parameters[0].Value = this.PageNbr;
			parameters[1].Value = this.PageDes;
			parameters[2].Value = this.ShowList;
			parameters[3].Value = this.UserID;
            parameters[4].Value = this.HeadFont;
            parameters[5].Value = this.ListFont;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}
    }
}
