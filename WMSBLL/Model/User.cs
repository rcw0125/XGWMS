using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.Model
{
    public class User
    {
        public User()
		{}
        public User(string userid, string ck, string username,string userdept,string userduty,string userrole,string userpass,string rfscx,string doorno,string qzs_no)
        {
            this._userid = userid;
            this._ck = ck;
            this._username = username;
            this._userduty = userduty;
            this._userdept = userdept;
            this._userrole = userrole;
            this._userpass = userpass;
            this._rfscx = rfscx;
            this._doorno = doorno;
            this._qzs_no = qzs_no;
        }
		#region Model
		private string _userid;
		private string _ck;
		private string _cknc;
		private string _username;
		private string _userdept;
		private string _userduty;
		private string _userpass;
		private string _userrole;
		private string _rfscx;
        private string _doorno;
        private string _qzs_no;
        private Function _userFunction;
        private WeightQCFunction _weightFunction;
        /// <summary>
        /// 门岗
        /// </summary>
        public string DoorNo
        {
            set { _doorno = value; }
            get { return _doorno; }
        }
        /// <summary>
        /// 签证室
        /// </summary>
        public string QZS_no
        {
            set { _qzs_no = value; }
            get { return _qzs_no; }
        }
		/// <summary>
		/// 用户编码
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户所属仓库
		/// </summary>
		public string CK
		{
			set{ _ck=value;}
			get{return _ck;}
		}
		/// <summary>
		/// 用户所属仓库
		/// </summary>
		public string CKNC
		{
			set{ _cknc=value;}
			get{return _cknc;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户所属部门
		/// </summary>
		public string UserDept
		{
			set{ _userdept=value;}
			get{return _userdept;}
		}
		/// <summary>
		/// 用户职务
		/// </summary>
		public string UserDuty
		{
			set{ _userduty=value;}
			get{return _userduty;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string UserPass
		{
			set{ _userpass=value;}
			get{return _userpass;}
		}
		/// <summary>
		/// 用户角色
		/// </summary>
		public string UserRole
		{
			set{ _userrole=value;}
			get{return _userrole;}
		}
		/// <summary>
		/// RF生产线
		/// </summary>
		public string RFSCX
		{
			set{ _rfscx=value;}
			get{return _rfscx;}
		}
        /// <summary>
        /// 用户权限
        /// </summary>
        public Function USERFUNCTION
        {
            set { _userFunction = value; }
            get { return _userFunction; }
        }
        /// <summary>
        /// 称重质检权限
        /// </summary>
        public WeightQCFunction WEIGTHQCFUNCTION
        {
            set { _weightFunction = value; }
            get { return _weightFunction; }
        }
		#endregion Model
        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static User GetUser(string userID)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from WMS_Pub_Users ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar)};
            parameters[0].Value = userID;
			User model=new User();
            AdoHelper adoHelp=new SqlHelp();
			DataSet ds=adoHelp.ExecuteDataset(Common.GetConnectString(),CommandType.Text,strSql.ToString(),parameters);
            model.UserID = userID;
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{
				model.CK=ds.Tables[0].Rows[0]["CK"].ToString();
				model.CKNC=ds.Tables[0].Rows[0]["CKNC"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserDept=ds.Tables[0].Rows[0]["UserDept"].ToString();
				model.UserDuty=ds.Tables[0].Rows[0]["UserDuty"].ToString();
				model.UserPass=ds.Tables[0].Rows[0]["UserPass"].ToString();
				model.UserRole=ds.Tables[0].Rows[0]["UserRole"].ToString();
				model.RFSCX=ds.Tables[0].Rows[0]["RFSCX"].ToString();
                model.DoorNo = ds.Tables[0].Rows[0]["DoorNo"].ToString();
                model.QZS_no = ds.Tables[0].Rows[0]["qzs_no"].ToString();
				return model;
			}
			return null;
        }

        /// <summary>
        /// 设置用户为登录状态
        /// </summary>
        public void SetUserLogin()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Pub_Users set IsLogin=1");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar)};
            parameters[0].Value = this.UserID;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 设置用户退出系统
        /// </summary>
        public void SetUserLoginOut()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Pub_Users set IsLogin=0");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar)};
            parameters[0].Value = this.UserID;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="newPass"></param>
        public void ChangePass(string newPass)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Pub_Users set UserPass=@UserPass");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar),
                    new SqlParameter("@UserPass",SqlDbType.VarChar)};
            parameters[0].Value = this.UserID;
            parameters[1].Value = newPass;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
        }
       /// <summary>
        /// 获得仓库ID获得用户列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_Users a left join wms_pub_door b on a.doorno=b.doorno left join wms_pub_qzs c on a.qzs_no=c.qzs_no ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where CK =" + strWhere);
            }
            strSql.Append(" order by UserID ");

            AdoHelper adoHelp = new SqlHelp();
            DataSet ds = adoHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="strWhere">查询条件，不需要加where</param>
        public static DataSet GetListByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,UserID+'|'+UserName as UserDesc from WMS_Pub_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE "+strWhere);
            }
            strSql.Append(" order by UserName ");

            AdoHelper adoHelp = new SqlHelp();
            DataSet ds = adoHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            return ds;
        }
        /// <summary>
        /// 删除用户数据
        /// </summary>
        public void Delete(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete WMS_Pub_Users ");
            strSql.Append(" where UserID='" + UserID + "'");
            AdoHelper DbHelperSQL = new SqlHelp();
            DbHelperSQL.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
       
        /// <summary>
        /// 是否存在该用户信息
        /// </summary>
        public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WMS_Pub_Users");
			strSql.Append(" where UserID= @UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar)
				};
			parameters[0].Value = UserID;
            AdoHelper dataHelp = new SqlHelp();
            Object obj = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
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
		/// 增加一个用户
		/// </summary>
		public void Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_Pub_Users(");
			strSql.Append("UserID,CK,CKNC,UserName,UserDept,UserDuty,UserPass,UserRole,RFSCX,doorno,qzs_no)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@CK,@CKNC,@UserName,@UserDept,@UserDuty,@UserPass,@UserRole,@RFSCX,@doorno,@qzs_no)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar),
					new SqlParameter("@CK", SqlDbType.VarChar),
					new SqlParameter("@CKNC", SqlDbType.VarChar),
					new SqlParameter("@UserName", SqlDbType.VarChar),
					new SqlParameter("@UserDept", SqlDbType.VarChar),
					new SqlParameter("@UserDuty", SqlDbType.VarChar),
					new SqlParameter("@UserPass", SqlDbType.VarChar),
					new SqlParameter("@UserRole", SqlDbType.VarChar),
					new SqlParameter("@RFSCX", SqlDbType.VarChar),
                    new SqlParameter("@doorno", SqlDbType.VarChar),
                    new SqlParameter("@qzs_no", SqlDbType.VarChar)};
			parameters[0].Value = this.UserID;
			parameters[1].Value = this.CK;
            parameters[2].Value = this.CKNC;
            parameters[3].Value = this.UserName;
            parameters[4].Value = this.UserDept;
            parameters[5].Value = this.UserDuty;
            parameters[6].Value = this.UserPass;
            parameters[7].Value = this.UserRole;
            parameters[8].Value = this.RFSCX;
            parameters[9].Value = this.DoorNo;
            parameters[10].Value = this.QZS_no;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);

		}
        /// <summary>
        /// 更新一个用户权限
        /// </summary>
        public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Pub_Users set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("CK=@CK,");
			strSql.Append("CKNC=@CKNC,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserDept=@UserDept,");
			strSql.Append("UserDuty=@UserDuty,");
			strSql.Append("UserPass=@UserPass,");
			strSql.Append("UserRole=@UserRole,");
			strSql.Append("RFSCX=@RFSCX,");
            strSql.Append("DoorNo=@doorno,");
            strSql.Append("Qzs_no=@qzs_no");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar),
					new SqlParameter("@CK", SqlDbType.VarChar),
					new SqlParameter("@CKNC", SqlDbType.VarChar),
					new SqlParameter("@UserName", SqlDbType.VarChar),
					new SqlParameter("@UserDept", SqlDbType.VarChar),
					new SqlParameter("@UserDuty", SqlDbType.VarChar),
					new SqlParameter("@UserPass", SqlDbType.VarChar),
					new SqlParameter("@UserRole", SqlDbType.VarChar),
					new SqlParameter("@RFSCX", SqlDbType.VarChar),
                    new SqlParameter("@doorno", SqlDbType.VarChar),
                    new SqlParameter("@qzs_no", SqlDbType.VarChar)};
			parameters[0].Value = this.UserID;
            parameters[1].Value = this.CK;
            parameters[2].Value = this.CKNC;
            parameters[3].Value = this.UserName;
            parameters[4].Value = this.UserDept;
            parameters[5].Value = this.UserDuty;
            parameters[6].Value = this.UserPass;
            parameters[7].Value = this.UserRole;
            parameters[8].Value = this.RFSCX;
            parameters[9].Value = this.DoorNo;
            parameters[10].Value = this.QZS_no;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);

		}
	
    }
}
