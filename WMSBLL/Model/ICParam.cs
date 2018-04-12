using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;
//��۽�
namespace ACCTRUE.WMSBLL.Model
{
    public class ICParam
    {
        public ICParam()
		{}
        public ICParam(string icid, string icnumber, string icpass, string khid, string khname, string Flag, string cph, string fk_user, DateTime fk_time, string zt_user, DateTime zt_time, string proposer)
        {
            this._icid = icid;
            this._icnumber = icnumber;
            this._icpass = icpass;
            this._khid = khid;
            this._khname = khname;
            this._flag = Flag;
            this._cph = cph;
            this._fk_user = fk_user;
            this._fk_time = fk_time;
            this._zt_user = zt_user;
            this._zt_time = zt_time;
            this._proposer = proposer;
        }
		#region Model
		private string _icid;
		private string _icnumber;
		private string _icpass;
		private string _khid;
		private string _khname;
		private string _flag;
		private string _cph;
		private string _fk_user;
		private DateTime _fk_time;
		private string _gs_user;
		private DateTime _gs_time;
		private string _zt_user;
		private DateTime _zt_time;
		private string _zx_user;
		private DateTime _zx_time;
		private string _proposer;
		/// <summary>
		/// 
		/// </summary>
		public string ICID
		{
			set{ _icid=value;}
			get{return _icid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICNumber
		{
			set{ _icnumber=value;}
			get{return _icnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICPass
		{
			set{ _icpass=value;}
			get{return _icpass;}
		}
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
		public string Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CPH
		{
			set{ _cph=value;}
			get{return _cph;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FK_User
		{
			set{ _fk_user=value;}
			get{return _fk_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime FK_Time
		{
			set{ _fk_time=value;}
			get{return _fk_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GS_User
		{
			set{ _gs_user=value;}
			get{return _gs_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime GS_Time
		{
			set{ _gs_time=value;}
			get{return _gs_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZT_User
		{
			set{ _zt_user=value;}
			get{return _zt_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ZT_Time
		{
			set{ _zt_time=value;}
			get{return _zt_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZX_User
		{
			set{ _zx_user=value;}
			get{return _zx_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ZX_Time
		{
			set{ _zx_time=value;}
			get{return _zx_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Proposer
		{
			set{ _proposer=value;}
			get{return _proposer;}
		}
		#endregion Model

        #region ��ȡIC��״̬
        /// <summary>
        /// ��ȡIC��״̬
        /// </summary>
        /// <param name="icid"></param>
        /// <returns></returns>
        public static string GetFlag(string icid)
        {
            string sql = "select flag from WMS_Pub_IC where ICID = '" + icid + "'";
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
        }
        #endregion

        #region �ж�ICID�Ƿ��Ѵ���
        /// <summary>
        /// �ж�ICID�Ƿ��Ѵ���
        /// </summary>
        /// <param name="icid"></param>
        /// <returns></returns>
        public static bool hasICID(string icid)
        {
            string sql = "select count(1) as hasicid from WMS_Pub_IC where ICID = '" + icid + "'";
            AdoHelper adohlp = new SqlHelp();
            string count = adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
            if (string.IsNullOrEmpty(count) || count == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  ����һ������
        /// <summary>
		/// ����һ������
		/// </summary>
		public void Update(string icid,string flag,string zt_user,DateTime zt_time)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Pub_IC set ");
			strSql.Append("Flag=@Flag,");
			strSql.Append("ZT_User=@ZT_User,");
			strSql.Append("ZT_Time=@ZT_Time");
			strSql.Append(" where ICID = @ICID");
			SqlParameter[] parameters = {
					new SqlParameter("@ICID", SqlDbType.VarChar),
					new SqlParameter("@Flag", SqlDbType.VarChar),
					new SqlParameter("@ZT_User", SqlDbType.VarChar),
					new SqlParameter("@ZT_Time", SqlDbType.VarChar)
            };
            parameters[0].Value = icid;
            parameters[1].Value = flag;
            parameters[2].Value = zt_user;
            if (flag == "ʹ��")
            {
                parameters[3].Value = DBNull.Value;
            }
            else
            {
                parameters[3].Value = zt_time;
            }

            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}

        public void UpdatePass(string icid, string pass, string zt_user, DateTime zt_time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Pub_IC set ");
            strSql.Append("icpass=@Pass,");
            strSql.Append("ZT_User=@ZT_User,");
            strSql.Append("ZT_Time=@ZT_Time");
            strSql.Append(" where ICID = @ICID");
            SqlParameter[] parameters = {
					new SqlParameter("@ICID", SqlDbType.VarChar),
					new SqlParameter("@Pass", SqlDbType.VarChar),
					new SqlParameter("@ZT_User", SqlDbType.VarChar),
					new SqlParameter("@ZT_Time", SqlDbType.DateTime)
            };
            parameters[0].Value = icid;
            parameters[1].Value = pass;
            parameters[2].Value = zt_user;
            parameters[3].Value = zt_time;

            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
        }

		#endregion 

        #region  ��������б�

        /// <summary>
        /// ��������б�
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ICID,KHID,KHName,CPH,ICNumber,Flag,FK_Time,(select UserName from WMS_Pub_Users where UserId=FK_User)FK_User,(select UserName from WMS_Pub_Users where UserId=Proposer)Proposer,(select UserName from WMS_Pub_Users where UserId=ZT_User)ZT_User,ZT_Time,Proposer+'|'+(select userName from WMS_Pub_Users where UserID = Proposer) as UserDesc,Proposer as ProposerID from WMS_Pub_IC  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by FK_Time desc");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion 

        #region ��ò�ѯ�����������б�
        /// <summary>
        /// ��ò�ѯ�����������б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetSearchProposer(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct Proposer,(Proposer+'|'+(select userName from WMS_Pub_Users where UserID = Proposer))UserDesc,(select UserName from WMS_Pub_Users where UserID = Proposer)UserName from WMS_Pub_IC");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
                strSql.Append(" order by UserName ");
                AdoHelper adohlp = new SqlHelp();
                DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds;
                return null;
            }
        #endregion

        #region ��÷��������������б�
            /// <summary>
            /// ��÷��������������б�
            /// </summary>
            /// <param name="strWhere"></param>
            /// <returns></returns>
            public static DataSet GetProposer(string strWhere)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select UserID,UserName from WMS_Pub_Users");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by UserID ");
                AdoHelper adohlp = new SqlHelp();
                DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds;
                return null;
            }
            #endregion

        #region  ɾ��һ������
            /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete WMS_Pub_IC ");
			strSql.Append(" where ICID=@ICID");
			SqlParameter[] parameters = {
					new SqlParameter("@ICID", SqlDbType.VarChar)
				};
			parameters[0].Value = this.ICID;
            AdoHelper adohlp=new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(),CommandType.Text,strSql.ToString(),parameters);
		}
        #endregion  ��Ա����

        #region  ����һ������

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add()
		{
            string sql = "select KHName from WMS_Pub_Customer where KHID = '" + this.KHID + "'";
            AdoHelper hlp = new SqlHelp();
            string khnameget = hlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
            if (khnameget != this.KHName)
            {
                return false;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into WMS_Pub_IC(");
                strSql.Append("ICID,ICNumber,ICPass,KHID,KHName,Flag,CPH,FK_User,FK_Time,ZT_User,ZT_Time,Proposer)");
                strSql.Append(" values (");
                strSql.Append("@ICID,@ICNumber,@ICPass,@KHID,@KHName,@Flag,@CPH,@FK_User,@FK_Time,@ZT_User,@ZT_Time,@Proposer)");
                SqlParameter[] parameters = {
					new SqlParameter("@ICID", SqlDbType.VarChar),
					new SqlParameter("@ICNumber", SqlDbType.VarChar),
					new SqlParameter("@ICPass", SqlDbType.VarChar),
					new SqlParameter("@KHID", SqlDbType.VarChar),
					new SqlParameter("@KHName", SqlDbType.VarChar),
					new SqlParameter("@Flag", SqlDbType.VarChar),
					new SqlParameter("@CPH", SqlDbType.VarChar),
					new SqlParameter("@FK_User", SqlDbType.VarChar),
					new SqlParameter("@FK_Time", SqlDbType.DateTime),
					new SqlParameter("@ZT_User", SqlDbType.VarChar),
					new SqlParameter("@ZT_Time", SqlDbType.DateTime),
					new SqlParameter("@Proposer", SqlDbType.VarChar)};
                parameters[0].Value = this.ICID;
                parameters[1].Value = this.ICNumber;
                parameters[2].Value = this.ICPass;
                parameters[3].Value = this.KHID;
                parameters[4].Value = this.KHName;
                parameters[5].Value = this.Flag;
                parameters[6].Value = this.CPH;
                parameters[7].Value = this.FK_User;
                parameters[8].Value = this.FK_Time;
                parameters[9].Value = this.ZT_User;
                parameters[10].Value = this.ZT_Time;
                parameters[11].Value = this.Proposer;
                SqlParameter[] parameter2 = {
					new SqlParameter("@ICID", SqlDbType.VarChar),
					new SqlParameter("@ICNumber", SqlDbType.VarChar),
					new SqlParameter("@ICPass", SqlDbType.VarChar),
					new SqlParameter("@KHID", SqlDbType.VarChar),
					new SqlParameter("@KHName", SqlDbType.VarChar),
					new SqlParameter("@Flag", SqlDbType.VarChar),
					new SqlParameter("@CPH", SqlDbType.VarChar),
					new SqlParameter("@FK_User", SqlDbType.VarChar),
					new SqlParameter("@FK_Time", SqlDbType.DateTime),
					new SqlParameter("@Proposer", SqlDbType.VarChar)};
                parameter2[0].Value = this.ICID;
                parameter2[1].Value = this.ICNumber;
                parameter2[2].Value = this.ICPass;
                parameter2[3].Value = this.KHID;
                parameter2[4].Value = this.KHName;
                parameter2[5].Value = this.Flag;
                parameter2[6].Value = this.CPH;
                parameter2[7].Value = this.FK_User;
                parameter2[8].Value = this.FK_Time;
                parameter2[9].Value = this.Proposer;
                if (ZT_Time == DateTime.MinValue)
                {
                    string sql2 = "insert into WMS_Pub_IC(ICID,ICNumber,ICPass,KHID,KHName,Flag,CPH,FK_User,FK_Time,Proposer) values (@ICID,@ICNumber,@ICPass,@KHID,@KHName,@Flag,@CPH,@FK_User,@FK_Time,@Proposer)";
                    AdoHelper ado = new SqlHelp();
                    ado.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql2, parameter2);
                }
                else
                {
                    AdoHelper adohlp = new SqlHelp();
                    adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
                }
                return true;
            }
		}
        #endregion  ��Ա����

        #region ��ò�ѯ���泵�ƺ��б�
        /// <summary>
        /// ��ò�ѯ���泵�ƺ��б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetSearchCPH(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct CPH from WMS_Pub_IC");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CPH ");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region  ����������ѯIC��
        /// <summary>
        /// ����������ѯIC��
        /// </summary>
        public DataSet GetICByEnter()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ICID,KHID,KHName,CPH,ICNumber,Flag,FK_Time,(select UserName from WMS_Pub_Users where UserId=FK_User)FK_User,(select UserName from WMS_Pub_Users where UserId=Proposer)Proposer,(select UserName from WMS_Pub_Users where UserId=ZT_User)ZT_User,ZT_Time,Proposer+'|'+(select userName from WMS_Pub_Users where UserID = Proposer) as UserDesc,Proposer as ProposerID from WMS_Pub_IC  ");
            strSql.Append(" where (ICID like '%'+@ICID+'%' OR @ICID IS NULL) AND ( KHName like '%'+@KHName+'%' OR @KHName IS NULL) AND ( CPH like '%'+@CPH+'%' OR @CPH IS NULL) AND (Proposer like '%'+@Proposer+'%' OR @Proposer IS NULL)");
            strSql.Append(" order by FK_Time desc ");
            if (string.IsNullOrEmpty(this.ICID))
            {
                this.ICID = null;
            }
            if (string.IsNullOrEmpty(this.KHName))
            {
                this.KHName = null;
            }
            if (string.IsNullOrEmpty(this.CPH)||this.CPH.Trim()=="��ѡ��")
            {
                this.CPH = null;
            }
            if (string.IsNullOrEmpty(this.Proposer)||this.Proposer.Trim()=="��ѡ��")
            {
                this.Proposer = null;
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@ICID", SqlDbType.VarChar),
                    new SqlParameter("@KHName", SqlDbType.VarChar),
                    new SqlParameter("@CPH",  SqlDbType.VarChar),
                    new SqlParameter("@Proposer",SqlDbType.VarChar)};
            parameters[0].Value = this.ICID;
            parameters[1].Value = this.KHName;
            parameters[2].Value = this.CPH;
            parameters[3].Value = this.Proposer;
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
            return ds;
        }


        public DataSet GetICInforbyID(string icNum)
        {
            string strSql = "select * from wms_PUB_IC where 1=1 ";
            if (!string.IsNullOrEmpty(icNum))
            {
                strSql += " and ICNumber='"+icNum+"'";
            }
            AdoHelper help = new SqlHelp();
            return help.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
        }

        public void ChangeICPass(string icNum,string newPass)
        {
            string strSql = "update wms_PUB_IC set icpass='"+newPass+"' where ICNumber='" + icNum + "'";
            AdoHelper help = new SqlHelp();
            help.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql);
        }


        #endregion 

        #region ��ȡ���˵���Ϣ�б�
        /// <summary>
        /// ��ȡ���˵���Ϣ�б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListFYD(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT FYDH,(select CKName from WMS_Pub_Store where CKID=CK)CK,(select KHName from WMS_Pub_Customer where KHID=KHBM)KHBM,");
            strSql.Append("case YSLB when '1' then '����' when '2' then '��' end as YSLB,CPH,JHSL,JHZL,SJSL,SJZL,");
            strSql.Append("case [Status] when 0 then '��δִ��' when 1 then '�ѽ���' when 2 then 'װ�����' when 3 then '�ѳ���' when 4 then '����' when 5 then '����װ��' end as Status,");
            strSql.Append("CZ_InTime,CZ_OtTime FROM WMS_Bms_Pic_FYD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by FYDH ");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion  

        #region ��ȡ����Excel�����DataSet
        /// <summary>
        /// ��ȡ����Excel�����DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet GetxlsDS()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select KHID as �ͻ�����,KHName as �ͻ�,CPH as ����,ICNumber as ����,Flag as ״̬,FK_Time as ����ʱ��,(select UserName from WMS_Pub_Users where UserId=FK_User)������,(select UserName from WMS_Pub_Users where UserId=Proposer)������,(select UserName from WMS_Pub_Users where UserId=ZT_User)��ʧ��,ZT_Time as ��ʧʱ�� from WMS_Pub_IC  ");
            strSql.Append(" where (ICID like '%'+@ICID+'%' OR @ICID IS NULL) AND ( KHName like '%'+@KHName+'%' OR @KHName IS NULL) AND ( CPH like '%'+@CPH+'%' OR @CPH IS NULL) AND (Proposer like '%'+@Proposer+'%' OR @Proposer IS NULL)");
            strSql.Append(" order by FK_Time desc ");
            if (string.IsNullOrEmpty(this.ICID))
            {
                this.ICID = null;
            }
            if (string.IsNullOrEmpty(this.KHName))
            {
                this.KHName = null;
            }
            if (string.IsNullOrEmpty(this.CPH)||this.CPH.Trim()=="��ѡ��")
            {
                this.CPH = null;
            }
            if (string.IsNullOrEmpty(this.Proposer)||this.Proposer.Trim()=="��ѡ��")
            {
                this.Proposer = null;
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@ICID", SqlDbType.VarChar),
                    new SqlParameter("@KHName", SqlDbType.VarChar),
                    new SqlParameter("@CPH",  SqlDbType.VarChar),
                    new SqlParameter("@Proposer",SqlDbType.VarChar)};
            parameters[0].Value = this.ICID;
            parameters[1].Value = this.KHName;
            parameters[2].Value = this.CPH;
            parameters[3].Value = this.Proposer;
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
            return ds;
        }
        #endregion

        /// <summary>
        /// ��ѯ�ͻ���Ϣ
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetKHInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_Customer ");
            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append(" where " + strWhere);
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            return ds;
        }

        public static DataSet GetPrintDS(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select KHID as �ͻ�����,KHName as �ͻ�,CPH as ����,ICNumber as ����,Flag as ״̬,FK_Time as ����ʱ��,(select UserName from WMS_Pub_Users where UserId=FK_User)������,(select UserName from WMS_Pub_Users where UserId=Proposer)������,(select UserName from WMS_Pub_Users where UserId=ZT_User)��ʧ��,ZT_Time as ��ʧʱ�� from WMS_Pub_IC  ");
            if(!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" WHERE ");
                strSql.Append(strWhere);
            }
            strSql.Append(" order by FK_Time desc ");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        public static DataSet GetDataSetsort(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ICID,KHID,KHName,CPH,ICNumber,Flag,FK_Time,(select UserName from WMS_Pub_Users where UserId=FK_User)FK_User,(select UserName from WMS_Pub_Users where UserId=Proposer)Proposer,(select UserName from WMS_Pub_Users where UserId=ZT_User)ZT_User,ZT_Time,Proposer+'|'+(select userName from WMS_Pub_Users where UserID = Proposer) as UserDesc,Proposer as ProposerID from WMS_Pub_IC  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            return ds;
        }
    }
}
