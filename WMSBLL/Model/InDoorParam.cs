using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;
//��۽�
namespace ACCTRUE.WMSBLL.Model
{
    public class InDoorParam
    {
        public InDoorParam()
		{}
		#region Model
		private int _ckdh;
		private string _fydh;
		private string _ck;
		private string _khbm;
		private string _yslb;
		private string _cph;
		private string _wlh;
		private string _wlmc;
		private string _ph;
		private string _gg;
		private string _sx;
		private string _zldj;
		private string _zjldw;
		private string _fjldw;
		private int _jhsl;
		private decimal _jhzl;
		private int _sjsl;
		private decimal _sjzl;
		private int _status;
		private string _cz_inuser;
		private DateTime _cz_intime;
		private string _cz_otuser;
		private DateTime _cz_ottime;
		private string _zfr;
		private DateTime _zftime;
		private int _mulnum;
		private string _aimadress;
		private string _nczdry;
		private DateTime _nczdrq;
		private string _ncbm;
		private DateTime _revdatetime;
		private string _flag;
		private DateTime _ckrq;
		private string _filed1;
		private string _pcinfo;
		private string _filed2;
		private string _indoorid;
		private string _outdoorid;
		/// <summary>
		/// 
		/// </summary>
		public int CKDH
		{
			set{ _ckdh=value;}
			get{return _ckdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FYDH
		{
			set{ _fydh=value;}
			get{return _fydh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK
		{
			set{ _ck=value;}
			get{return _ck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KHBM
		{
			set{ _khbm=value;}
			get{return _khbm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YSLB
		{
			set{ _yslb=value;}
			get{return _yslb;}
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
		public string WLH
		{
			set{ _wlh=value;}
			get{return _wlh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WLMC
		{
			set{ _wlmc=value;}
			get{return _wlmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PH
		{
			set{ _ph=value;}
			get{return _ph;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GG
		{
			set{ _gg=value;}
			get{return _gg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SX
		{
			set{ _sx=value;}
			get{return _sx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZLDJ
		{
			set{ _zldj=value;}
			get{return _zldj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZJLDW
		{
			set{ _zjldw=value;}
			get{return _zjldw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FJLDW
		{
			set{ _fjldw=value;}
			get{return _fjldw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int JHSL
		{
			set{ _jhsl=value;}
			get{return _jhsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal JHZL
		{
			set{ _jhzl=value;}
			get{return _jhzl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SJSL
		{
			set{ _sjsl=value;}
			get{return _sjsl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SJZL
		{
			set{ _sjzl=value;}
			get{return _sjzl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CZ_InUser
		{
			set{ _cz_inuser=value;}
			get{return _cz_inuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CZ_InTime
		{
			set{ _cz_intime=value;}
			get{return _cz_intime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CZ_OtUser
		{
			set{ _cz_otuser=value;}
			get{return _cz_otuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CZ_OtTime
		{
			set{ _cz_ottime=value;}
			get{return _cz_ottime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZFR
		{
			set{ _zfr=value;}
			get{return _zfr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ZFTime
		{
			set{ _zftime=value;}
			get{return _zftime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MulNum
		{
			set{ _mulnum=value;}
			get{return _mulnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AimAdress
		{
			set{ _aimadress=value;}
			get{return _aimadress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NCZDRY
		{
			set{ _nczdry=value;}
			get{return _nczdry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime NCZDRQ
		{
			set{ _nczdrq=value;}
			get{return _nczdrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NCBM
		{
			set{ _ncbm=value;}
			get{return _ncbm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime REVDATETIME
		{
			set{ _revdatetime=value;}
			get{return _revdatetime;}
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
		public DateTime CKRQ
		{
			set{ _ckrq=value;}
			get{return _ckrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Filed1
		{
			set{ _filed1=value;}
			get{return _filed1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PCInfo
		{
			set{ _pcinfo=value;}
			get{return _pcinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Filed2
		{
			set{ _filed2=value;}
			get{return _filed2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string indoorid
		{
			set{ _indoorid=value;}
			get{return _indoorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string outdoorid
		{
			set{ _outdoorid=value;}
			get{return _outdoorid;}
		}
		#endregion Model

        #region ����ICID��ѯIC����
        /// <summary>
        /// ����ICID��ѯIC����
        /// </summary>
        /// <param name="icid"></param>
        /// <returns></returns>
        public DataSet GetICNumber(string icid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WMS_Pub_IC.ICID,WMS_Pub_IC.ICNumber,WMS_Pub_IC.KHID,WMS_Pub_IC.CPH,WMS_Pub_IC.Flag,WMS_Pub_Customer.KHLB from WMS_Pub_IC,WMS_Pub_Customer where WMS_Pub_IC.KHID=WMS_Pub_Customer.KHID and ICID = '" + icid + "'");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            return ds;
        }
        #endregion

        #region �жϳ��ƺ��Ƿ��ѽ���
        /// <summary>
        /// �жϳ��ƺ��Ƿ��ѽ���
        /// </summary>
        /// <param name="CPH"></param>
        /// <returns></returns>
        public bool IsInDoor(string CPH)
        {
            string sql = "select count(1) as fydcount from WMS_Bms_Pic_FYD where cph='" + CPH + " ' and (status in (1,2,5))";
            AdoHelper adohlp = new SqlHelp();
            int result = Int32.Parse(adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString());
            if (result >= 1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        #endregion

        #region �ж��Ƿ�����������֤ʱ�����ĳ���
        /// <summary>
        /// �ж��Ƿ�����������֤ʱ�����ĳ���
        /// </summary>
        /// <param name="CPH"></param>
        /// <returns></returns>
        public bool isAllowCPH(string CPH)
        {
            string sql = "select count(1) as allowCPH from WMS_pub_AllowCPH where CPH = '" + CPH + "'";
            AdoHelper adohlp = new SqlHelp();
            int result = Int32.Parse(adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString());
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region �ж��Ƿ��ڽ���ʱ��������Χ��
        /// <summary>
        /// �ж��Ƿ��ڽ���ʱ��������Χ��
        /// </summary>
        /// <param name="CPH"></param>
        /// <returns></returns>
        public bool isTimeAllow(string CPH)
        {
            bool a = isAllowCPH(CPH);
            if (a == true)
            {
                return true;
            }
            else
            {
                string sqlPara = "select CS_Value from WMS_Pub_Param where CS_Name = 'ICIninterval'";
                AdoHelper adopara = new SqlHelp();
                string timeInterval = adopara.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sqlPara).ToString();
                if (string.IsNullOrEmpty(timeInterval))
                {
                    return true;
                }
                else
                {
                    string[] time = timeInterval.Split(':');
                    int hour = Int32.Parse(time[0]);
                    int minute = Int32.Parse(time[1]);
                    int second = Int32.Parse(time[2]);
                    DateTime now = DateTime.Now;
                    now = now.AddHours(hour * (-1));
                    now = now.AddMinutes(minute * (-1));
                    now = now.AddSeconds(second * (-1));

                    string sqltime = "select CZ_ottime from WMS_Bms_Pic_FYD where cph='" + CPH + "' and (status in (1,2,3,4,5))  and cz_ottime is not null  order by cz_ottime desc";
                    DataSet ds = adopara.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqltime);
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        return true;
                    }
                    else
                    {
                        DateTime oldtime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CZ_ottime"].ToString());
                        if (oldtime <= now)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        #endregion

        #region ���ݷ��˵��š��ֿ�š����Ϻš����Ի�ȡ���˵�״̬
        /// <summary>
        /// ���ݷ��˵��š��ֿ�š����Ϻš����Ի�ȡ���˵�״̬
        /// </summary>
        /// <param name="FYDH"></param>
        /// <param name="CK"></param>
        /// <param name="WLH"></param>
        /// <param name="SX"></param>
        /// <returns></returns>
        public string getStatus(string FYDH, string CK, string WLH, string SX)
        {
            string sql = "";
            if(string.IsNullOrEmpty(CK.Trim()))
                sql = "select Status from WMS_Bms_Pic_FYD where FYDH='"+FYDH+"' and WLH='"+WLH+"' and sx='"+SX+"'";
            else
                sql = "select Status from WMS_Bms_Pic_FYD where FYDH='" + FYDH + "' and CK='" + CK + "' and WLH='" + WLH + "' and sx='" + SX + "'";
            AdoHelper adohlp = new SqlHelp();
            string status = adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
            return status;
        }
        #endregion

        #region ���ݷ��˵��Ż�ȡ���˵����ݼ�
        /// <summary>
        /// ���ݷ��˵��Ż�ȡ���˵����ݼ�
        /// </summary>
        /// <param name="FYDH"></param>
        /// <returns></returns>
        public static DataSet getDSByFYDH(string FYDH)
        {
            string sql = "select * from WMS_Bms_Pic_FYD where FYDH='" + FYDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ���ݷ��˵��Ż�ȡ���˵�״̬���ݼ�
        /// <summary>
        /// ���ݷ��˵��Ż�ȡ���˵�״̬���ݼ�
        /// </summary>
        /// <param name="FYDH"></param>
        /// <returns></returns>
        public static DataSet StatusDS(string FYDH)
        {
            string fydhlist = FYDH.Replace(",", "','");
            fydhlist = "'"+fydhlist+"'";
            string sql = "select Status from WMS_Bms_Pic_FYD where FYDH in(" + fydhlist + ")";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �������ŷ��˵�״̬
        /// <summary>
        /// �������ŷ��˵�״̬
        /// </summary>
        /// <param name="FYDH"></param>
        /// <param name="CK"></param>
        /// <param name="WLH"></param>
        /// <param name="SX"></param>
        /// <returns></returns>
        public void cancelInDoor(string FYDH)
        {
            string sql = "update WMS_Bms_Pic_FYD set Status = 0 where FYDH='" + FYDH + "'";
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql);
        }
        #endregion

        #region  ���Ÿ��·��˵�״̬
        /// <summary>
        /// ���Ÿ��·��˵�״̬
        /// </summary>
        public bool Update(string FYDH,int StatusSet,string CZ_User,DateTime CZ_Time)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Bms_Pic_FYD set ");
			strSql.Append("Status=@Status,");
			strSql.Append("CZ_InUser=@CZ_InUser,");
			strSql.Append("CZ_InTime=@CZ_InTime");
			strSql.Append(" where FYDH=@FYDH");
			SqlParameter[] parameters = {
					new SqlParameter("@FYDH", SqlDbType.VarChar),
					new SqlParameter("@Status", SqlDbType.Int),
					new SqlParameter("@CZ_InUser", SqlDbType.VarChar),
					new SqlParameter("@CZ_InTime", SqlDbType.DateTime)};
			parameters[0].Value = FYDH;
			parameters[1].Value = StatusSet;
			parameters[2].Value = CZ_User;
			parameters[3].Value = CZ_Time;

            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
            return true;
        }
        #endregion  ��Ա����

        #region  ���Ÿ��·��˵�״̬
        /// <summary>
        /// ���Ÿ��·��˵�״̬
        /// </summary>
        public bool Update2(string FYDH, int StatusSet, string CZ_User, DateTime CZ_Time)
        {
            string fydhlist = FYDH.Replace(",", "','");
            fydhlist = "'" + fydhlist + "'";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Bms_Pic_FYD set ");
            strSql.Append("Status=@Status,");
            strSql.Append("CZ_OtUser=@CZ_InUser,");
            strSql.Append("CZ_OtTime=@CZ_InTime");
            strSql.Append(" where FYDH in(@FYDH)");
            SqlParameter[] parameters = {
					new SqlParameter("@FYDH", SqlDbType.VarChar),
					new SqlParameter("@Status", SqlDbType.Int),
					new SqlParameter("@CZ_InUser", SqlDbType.VarChar),
					new SqlParameter("@CZ_InTime", SqlDbType.DateTime)};
            parameters[0].Value = fydhlist;
            parameters[1].Value = StatusSet;
            parameters[2].Value = CZ_User;
            parameters[3].Value = CZ_Time;
            string sqlstr = "update WMS_Bms_Pic_FYD set Status=" + StatusSet.ToString() + ",CZ_OtUser='" + CZ_User +
                "',CZ_OtTime='" + CZ_Time + "' where FYDH in("+fydhlist+")";
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr.ToString());
            return true;
        }
        #endregion  ��Ա����

        #region ��¼������ʹ�õ�IC��ID
        /// <summary>
        /// ��¼������ʹ�õ�IC��ID
        /// </summary>
        /// <param name="ICID"></param>
        /// <param name="FYDH"></param>
        public void setICIDindoor(string ICID, string FYDH)
        {
            string sql = "update WMS_Bms_Pic_FYD set indoorid='" + ICID + "' where FYDH='" + FYDH + "'";
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql);
        }
        #endregion

        #region ��¼������ʹ�õ�IC��ID
        /// <summary>
        /// ��¼������ʹ�õ�IC��ID
        /// </summary>
        /// <param name="ICID"></param>
        /// <param name="FYDH"></param>
        public void setICIDoutdoor(string ICID, string FYDH)
        {
            string fydhlist = FYDH.Replace(",", "','");
            fydhlist = "'" +fydhlist + "'";
            string sql = "update WMS_Bms_Pic_FYD set outdoorid='" + ICID + "' where FYDH in(" + fydhlist + ")";
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql);
        }
        #endregion        

        #region �ж��Ƿ��д�IC��
        /// <summary>
        /// �ж��Ƿ��д�IC��
        /// </summary>
        /// <param name="icid"></param>
        /// <param name="icnumber"></param>
        /// <returns></returns>
        public bool hasIC(string icid, string icnumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) as hasic from WMS_Pub_IC where (icid = @icid or @icid is null) and (icnumber = @icnumber or @icnumber is null)");
            if (string.IsNullOrEmpty(icid))
            {
                icid = null;
            }
            if (string.IsNullOrEmpty(icnumber))
            {
                icnumber = null;
            }
            SqlParameter[] parameters = {
					new SqlParameter("@icid", SqlDbType.VarChar),
					new SqlParameter("@icnumber", SqlDbType.VarChar)};
            parameters[0].Value = icid;
            parameters[1].Value = icnumber;
            AdoHelper adohlp = new SqlHelp();
            string count = adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters).ToString();
            if (string.IsNullOrEmpty(count)||count=="0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region ��֤ԭ�����Ƿ���ȷ
        /// <summary>
        /// ��֤ԭ�����Ƿ���ȷ
        /// </summary>
        /// <param name="icid"></param>
        /// <param name="icnumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool PasswordValidate(string icid, string icnumber, string password)
        { 
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) as passwordValidate from WMS_Pub_IC where ICPass = '" + password + "' ");
            if (!string.IsNullOrEmpty(icid))
            {
                sql.Append(" and icid = '" + icid + "'");
            }
            if (!string.IsNullOrEmpty(icnumber))
            {
                sql.Append(" and icnumber = '" + icnumber + "'");
            }
            AdoHelper adohlp = new SqlHelp();
            string count = adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql.ToString()).ToString();
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

        #region �޸�IC������
        /// <summary>
        /// �޸�IC������
        /// </summary>
        /// <param name="icid"></param>
        /// <param name="icnumber"></param>
        /// <param name="passnew"></param>
        public void ModifyPassword(string icid, string icnumber, string passnew)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Pub_IC set ICPass = '" + passnew + "' where ");
            if ((!string.IsNullOrEmpty(icid)) && (!string.IsNullOrEmpty(icnumber)))
            {
                strSql.Append(" ICID = '" + icid + "' and ICNumber = '" + icnumber + "'");
            }
            else
            {
                if (!string.IsNullOrEmpty(icid))
                {
                    strSql.Append(" icid = '" + icid + "'");
                }
                if (!string.IsNullOrEmpty(icnumber))
                {
                    strSql.Append(" icnumber = '" + icnumber + "'");
                }
            }
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        #endregion

        #region ���ǰ1000�����˵��б�
        /// <summary>
        /// ���ǰ1000�����˵��б�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetFYDH()
        {
            string sql = "select  distinct top 1000 fydh from WMS_Bms_Pic_FYD order by fydh desc ";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ��ò������б�
        /// <summary>
        /// ��ò������б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetUser(string strWhere)
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

        #region ��ô�ӡСƱ�������ݼ�
        /// <summary>
        /// ��ô�ӡСƱ�������ݼ�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet getDS(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CKDH,FYDH,(select CKName from WMS_Pub_Store where CKID=CK)CKName,(select KHName from WMS_Pub_Customer where KHID=KHBM)KHName,YSLB,CPH,WLH,(WLMC+PH+GG) AS WLMC,PH,GG,SX,ZLDJ,ZJLDW,FJLDW,JHSL,JHZL,SJSL,SJZL,Status,CZ_InUser,CZ_InTime,CZ_OtUser,CZ_OtTime,ZFR,ZFTime,MulNum,AimAdress,NCZDRY,NCZDRQ,NCBM,REVDATETIME,Flag,CKRQ,Filed1,PCInfo,Filed2,indoorid,outdoorid,vfree1,vfree2,vfree3 FROM WMS_Bms_Pic_FYD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CKDH ");
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        #endregion

        #region ���IC����Ϣ���ݼ�
        /// <summary>
        /// ���IC����Ϣ���ݼ�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetICDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select wms_pub_ic.ICID,wms_pub_ic.ICnumber,wms_pub_ic.ICPass,wms_pub_ic.khid,wms_pub_ic.flag,WMS_Pub_Customer.KHLB from  wms_pub_ic,WMS_Pub_Customer where wms_pub_ic.khid=WMS_Pub_Customer.khid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by ICID ");
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        #endregion

        #region ��÷��˵���Ϣ���ݼ�
        /// <summary>
        /// ��÷��˵���Ϣ���ݼ�
        /// </summary>
        /// <param name="strWhere">ɸѡ����</param>
        /// <returns></returns>
        public static DataSet GetFYDDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CKDH,FYDH,case status when 0 then 'δִ��' when 1 then '�ѽ���' when 2 then 'װ�����' when 5 then '����װ��' end as status,CPH,(select KHName from WMS_Pub_Customer where khid = KHBM)KHBM,khbm as khbmh,CK,WLH,(WLMC+PH+GG) AS WLMC,SX,JHSL,CAST(JHZL as numeric(20,3)) as JHZL,SJSL,CAST(SJZL as numeric(20,3)) as SJZL,CZ_InTime,NCZDRY from WMS_Bms_Pic_FYD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by cph,FYDH ");
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        #endregion

        #region ��ò�ѯ���˵�����ķ��˵���Ϣ���ݼ�
        /// <summary>
        /// ��ò�ѯ���˵�����ķ��˵���Ϣ���ݼ�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetFYDInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            strSql.Append("select FYDH,case status when 0 then 'δִ��' when 1 then '�ѽ���' when 2 then 'װ�����' when 3 then '�ѳ���' when 4 then '����' when 5 then '����װ��' end as status,(select KHName from WMS_Pub_Customer where KHID = KHBM)KHName,(WLMC+PH+GG) AS WLMC,SX,CPH,CK,JHSL,SJSL,CAST(JHZL as numeric(20,3)) as JHZL,CAST(SJZL as numeric(20,3)) as SJZL,CZ_InTime,CZ_OtTime,(select UserName from WMS_Pub_Users where UserID=CZ_InUser)CZ_InUser,(select UserName from WMS_Pub_Users where UserID=CZ_OtUser)CZ_OtUser,NCZDRY from WMS_Bms_Pic_FYD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by FYDH ");
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        #endregion

        #region ��ò�ѯ���˵�����ķ��˵���Ϣ�ϼ����ݼ�
        /// <summary>
        /// ��ò�ѯ���˵�����ķ��˵���Ϣ�ϼ����ݼ�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetFYDInfoCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(distinct FYDH) as HS,sum(JHSL) as HJJHSL,sum(SJSL) as HJSJSL,CAST(sum(JHZL) as numeric(20,3)) as HJJHZL,CAST(sum(SJZL) as numeric(20,3)) as HJSJZL from WMS_Bms_Pic_FYD ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        #endregion

        #region ��ò�ѯ���˵�����ķ��˵���Ϣ���ݼ�������
        /// <summary>
        /// ��ò�ѯ���˵�����ķ��˵���Ϣ���ݼ�������
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetFYDInfoSort(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FYDH,case status when 0 then 'δִ��' when 1 then '�ѽ���' when 2 then 'װ�����' when 3 then '�ѳ���' when 4 then '����' when 5 then '����װ��' end as status,(select KHName from WMS_Pub_Customer where KHID = KHBM)KHName,WLMC,SX,CPH,CK,JHSL,SJSL,CAST(JHZL as numeric(20,3)) as JHZL,CAST(SJZL as numeric(20,3)) as SJZL,CZ_InTime,CZ_OtTime,(select UserName from WMS_Pub_Users where UserID=CZ_InUser)CZ_InUser,(select UserName from WMS_Pub_Users where UserID=CZ_OtUser)CZ_OtUser,NCZDRY from WMS_Bms_Pic_FYD ");//,sum(JHSL) as HJJHSL,sum(SJSL) as HJSLSL,sum(JHZL) as HJJHZL,sum(SJZL) as HJSJZL
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        #endregion

        #region ��ô�ӡ���˵��б���������ݼ�
        /// <summary>
        /// ��ô�ӡ���˵��б���������ݼ�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetPrintDS(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT FYDH as ���˵���,case status when 0 then 'δִ��' when 1 then '�ѽ���' when 2 then 'װ�����' when 3 then '�ѳ���' when 4 then '������' else '����װ��' end as ״̬,(select KHName from WMS_Pub_Customer where KHID=KHBM)�ͻ�����,WLMC as ��������,SX as ����,CPH as ���ƺ�,CK as �ֿ�,JHSL as Ӧ����,SJSL as ʵ����,CAST(JHZL as numeric(20,3)) as Ӧ����,CAST(SJZL as numeric(20,3)) as ʵ����,CZ_InTime as ����ʱ��,CZ_OtTime as ����ʱ��,(select UserName from WMS_Pub_Users where UserID=CZ_InUser)������Ա,(select UserName from WMS_Pub_Users where UserID=CZ_OtUser)������Ա,NCZDRY as �Ƶ��� from WMS_Bms_Pic_FYD ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" WHERE ");
                strSql.Append(strWhere);
            }
            strSql.Append(" order by FYDH desc ");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region ���״̬������1�����ݼ�
        public static DataSet StatusNo1DS(string FYDH)
        {
            string sql = " select Status from WMS_Bms_Pic_FYD where FYDH = '" + FYDH + "' and status <> 1";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion
    }
}
