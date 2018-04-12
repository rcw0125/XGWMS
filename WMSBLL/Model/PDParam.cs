using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class PDParam
    {
        #region ����̵㵥�����б�
        /// <summary>
        /// ����̵㵥�����б�
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PDDH,YSDH,CK,(select CKName from WMS_Pub_Store where CKID=CK)CKName,PDRQ,ZDRQ,ZDUser,SHUser,SHRQ,DJZT,DJLX FROM WMS_Che_PDD ");
            strSql.Append("where " + strWhere);
            strSql.Append(" order by YSDH ");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region ���NCԭʼ�̵㵥�����б�
        /// <summary>
        /// ���NCԭʼ�̵㵥�����б�
        /// </summary>
        public static DataSet GetPDDNC(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT YSDH,CK,(select CKName from WMS_Pub_Store where CKID=CK)CKName,PDRQ,DJZT,SHUser,SHDATE,pkckbz,pyrkbz FROM WMS_CHE_PDDNC ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by YSDH ");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region ����̵㵥�嵥
        /// <summary>
        /// ����̵㵥�嵥
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet getPddDetailDS(string PDDH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PDDH,HW,WLH,WLMC,PCH,GG,PH,SX,vfree1,vfree2,vfree3,ZCSL,SPSL,JLDW,PDCY,SHBZ,CAST(ZCZL as numeric(20,3)) as ZCZL,CAST(SPZL as numeric(20,3)) as SPZL,ZLDW,OperUser,Operdate from wms_che_pdd_detail where PDDH = '" + PDDH + "'");
            strSql.Append(" order by PDDH ");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region ��ó����̵㵥�嵥
        /// <summary>
        /// ��ó����̵㵥�嵥
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet getXPDDetailDS(string PDDH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PDDH,HW,WLH,WLMC,BARCODE,PCH,GG,PH,SX,ZCSL,SPSL,JLDW,PDCY,shbz,CAST(ZL as numeric(20,3)) as ZL,ZLDW,OperUser,OperDate,vfree1,vfree2,vfree3 from WMS_CHE_PDD_DJDETAIL where PDDH = '" + PDDH + "'");
            strSql.Append(" order by PDDH ");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region ��û�λ1�б�
        /// <summary>
        /// ��û�λ1�б�
        /// </summary>
        /// <param name="YSDH">ԭʼ����</param>
        /// <param name="CK">�ֿ��</param>
        /// <returns></returns>
        public static DataSet getHW1DS(string YSDH,string CK)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT DISTINCT HW FROM WMS_Bms_Inv_Info WHERE (CK ='"+CK+"')");
            strSql.Append(" AND (RKType is not null) and EXISTS (SELECT DISTINCT barcode FROM wms_che_pddnc_detail");
            strSql.Append(" WHERE ysdh = '"+YSDH+"' AND wms_che_pddnc_detail.barcode = wms_bms_inv_info.wlh");
            strSql.Append(" AND wms_che_pddnc_detail.pch = wms_bms_inv_info.pch");
            strSql.Append(" AND wms_che_pddnc_detail.vfree1=wms_bms_inv_info.vfree1 and wms_che_pddnc_detail.vfree2=wms_bms_inv_info.vfree2 "+
                         "and wms_che_pddnc_detail.vfree3=wms_bms_inv_info.vfree3");//�����������ж�
            strSql.Append(" AND ((wms_che_pddnc_detail.sx = wms_bms_inv_info.sx)or(wms_che_pddnc_detail.sx='DP'))) and HW not in ");
            strSql.Append(" ((select distinct HW from WMS_Che_PDD_DETAIL where PDDH in (select PDDH from WMS_Che_PDD where YSDH = '"+YSDH+"'))");   //�����ڴ��̵���ϸ�еĻ�λ
            strSql.Append(" union (select distinct HW from WMS_CHE_PDD_DJDETAIL where pddh in (select PDDH from WMS_Che_PDD where YSDH = '" + YSDH + "')))");   //�����ڳ��̵���ϸ�еĻ�λ
            strSql.Append(" order by HW");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region ��û�λ2�б�
        /// <summary>
        /// ��û�λ2�б�
        /// </summary>
        /// <param name="PDDH">�̵㵥��</param>
        /// <returns></returns>
        public static DataSet getHW2DS(string PDDH)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select distinct hw from wms_che_pdd_detail where pddh= '"+PDDH+"' order by HW");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region ���δ�̻�λ�嵥�б�
        /// <summary>
        /// ���δ�̻�λ�嵥�б�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="CKID"></param>
        /// <returns></returns>
        public static DataSet GetHW3DS(string YSDH, string CKID)
        {
            string sql = "SELECT DISTINCT HW FROM WMS_Bms_Inv_Info WHERE (CK ='" + CKID + "') and HW not in ((select distinct HW from WMS_Che_PDD_DETAIL where PDDH in (select PDDH from WMS_Che_PDD where YSDH = '" + YSDH + "')) union (select distinct HW from WMS_CHE_PDD_DJDETAIL where pddh in (select PDDH from WMS_Che_PDD where YSDH = '" + YSDH + "')))";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ��ó��̻�λ2�б�
        /// <summary>
        /// ��ó��̻�λ2�б�
        /// </summary>
        /// <param name="PDDH">�̵㵥��</param>
        /// <returns></returns>
        public static DataSet getHW2XPDS(string PDDH)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select distinct hw from WMS_CHE_PDD_DJDETAIL where pddh= '" + PDDH + "'");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        #endregion

        #region �����½����̵㵥��
        /// <summary>
        /// �����½����̵㵥��
        /// </summary>
        /// <param name="DJLX">��������:��Ϊ"����"��"����"</param>
        /// <returns></returns>
        public static string GetPDDH(string DJLX)
        {
            string objPDDH = "";

            string sql1 = "select MAXORDER from WMS_PUB_ORDERLIST where TABLENAME='WMS_Che_PDD' and FIELDNAME='PDDH'";
            AdoHelper adohlp1 = new SqlHelp();
            int PDDH = Convert.ToInt32(adohlp1.ExecuteScalar(Common.GetConnectString(),CommandType.Text,sql1));
            int PDDHNew = PDDH + 1;
            string sql2 = "update WMS_PUB_ORDERLIST set MAXORDER='" + PDDHNew + "' where TABLENAME='WMS_Che_PDD' and FIELDNAME='PDDH'";
            adohlp1.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql2);

            DateTime sysDate = Convert.ToDateTime(GetSysDate());
            string year = sysDate.Year.ToString();
            string month = sysDate.Month.ToString();
            string day = sysDate.Day.ToString();

            if (month.Length < 2)
            {
                month = "0" + month;
            }
            
            if (day.Length < 2)
            {
                day = "0" + day;
            }

            if (DJLX == "����")
            {
                objPDDH = "CP" + year + month + day + PDDHNew;
            }
            else
            {
                objPDDH = "XP" + year + month + day + PDDHNew;
            }
            return objPDDH;
        }
        #endregion

        #region ���ϵͳʱ��
        /// <summary>
        /// ���ϵͳʱ��
        /// </summary>
        /// <returns></returns>
        public static string GetSysDate()
        {
            string sql = "select getdate()";
            AdoHelper adohlp = new SqlHelp();
            return adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
        }
        #endregion

        #region ��֤ԭʼ���ŵõ�ds
        /// <summary>
        /// ��֤ԭʼ���ŵõ�ds
        /// </summary>
        /// <param name="YSDH">ԭʼ����</param>
        /// <returns></returns>
        public static DataSet TestYSDH(string YSDH)
        {
            string sql = "SELECT WMS_CHE_PDDNC.*, WMS_Pub_Store.CKName AS CKName FROM WMS_CHE_PDDNC LEFT OUTER JOIN WMS_Pub_Store ON WMS_CHE_PDDNC.CK = WMS_Pub_Store.CKID WHERE (WMS_CHE_PDDNC.YSDH = '" + YSDH + "') AND ((WMS_CHE_PDDNC.DJZT ='����') or (WMS_CHE_PDDNC.DJZT ='����'))";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ��֤�̵㵥�ŵõ�ds
        /// <summary>
        /// ��֤�̵㵥�ŵõ�ds
        /// </summary>
        /// <param name="PDDH">�̵㵥��</param>
        /// <returns></returns>
        public static DataSet TestPDDH(string PDDH,string DJLX)
        {
            string sql = "SELECT PDDH,YSDH,CK,(select CKName from WMS_Pub_Store where CKID = CK)CKName,PDRQ,ZDRQ,ZDUser,SHUser,(select UserName from WMS_Pub_Users where UserID = SHUser)SHUserName,SHRQ,DJZT,DJLX FROM WMS_Che_PDD where djlx='"+DJLX+"' and pddh = '" + PDDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �½����޸�ʱ������̵���λ��ϸ
        /// <summary>
        /// �½����޸�ʱ������̵���λ��ϸ
        /// </summary>
        /// <param name="PDDH"></param>
        /// <param name="jldw"></param>
        /// <param name="zldw"></param>
        /// <param name="CKID"></param>
        /// <param name="HW2List"></param>
        public static DataSet LookCPddDetail(string PDDH, string jldw, string zldw, string CKID, string HW2List)
        {
            string sql = "select * into #temptb from wms_che_pdd_detail where 1=2;";
            sql += " insert into #temptb(PDDH,HW,Wlh,WLMC,PCH,GG,SX,vfree1,vfree2,vfree3,PH,ZCSL,JLDW,SHBZ,zczl,zldw) select '" + PDDH + "',hw,wlh,WLMC,pch,gg,sx,vfree1,vfree2,vfree3,ph,count(barcode),'" + jldw + "',0,sum(zl),'" + zldw + "' from WMS_Bms_Inv_Info where ck='" + CKID + "' and (RKType is not null) and hw in(" + HW2List + ") group by hw,wlh,WLMC,pch,gg,sx,ph,VFREE1,VFREE2,VFREE3;";
            sql += " select * from #temptb where pddh= '" + PDDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �½����޸�ʱ������̵���λ��ϸ
        /// <summary>
        /// �½����޸�ʱ������̵���λ��ϸ
        /// </summary>
        /// <param name="PDDH"></param>
        /// <param name="jldw"></param>
        /// <param name="zldw"></param>
        /// <param name="CKID"></param>
        /// <param name="HW2List"></param>
        public static DataSet LookXPddDetail(string PDDH, string jldw, string zldw, string CKID, string HW2List)
        {
            string sql = "select * into #temptb from wms_che_pdd_djdetail where 1=2;";
            sql += " insert into #temptb(PDDH,HW,barcode,Wlh,WLMC,PCH,GG,SX,PH,ZCSL,JLDW,SHBZ,zl,zldw,vfree1,vfree2,vfree3) select '"+PDDH+"',hw,barcode,wlh,WLMC,pch,gg,sx,ph,1,'"+jldw+"',0,zl,'"+zldw+"',vfree1,vfree2,vfree3 from WMS_Bms_Inv_Info where ck='"+CKID+"' and (RKType is not null) and hw in("+HW2List+"); ";
            sql += "select * from #temptb where pddh= '" + PDDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �������̵�
        /// <summary>
        /// �������̵�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="PDDH"></param>
        /// <param name="CKID"></param>
        /// <param name="PDRQ"></param>
        /// <param name="ZDRQ"></param>
        /// <param name="ZDRY"></param>
        /// <param name="jldw"></param>
        /// <param name="zldw"></param>
        /// <param name="HW2List"></param>
        public static string AddCPD(string YSDH, string PDDH, string CKID, string PDRQ, string ZDRQ, string ZDRY,string jldw,string zldw,string HW2List)
        {
            string sqlAddPDD = "insert into wms_che_pdd(PDDH,YSDH,CK,PDRQ,ZDRQ,ZDUser,DJZT,DJLX)values('" + PDDH + "','" + YSDH + "','" + CKID + "','" + Convert.ToDateTime(PDRQ) + "','" + Convert.ToDateTime(ZDRQ) + "','" + ZDRY + "','�½�','����')";
            string sqlDeleteDetail = "delete from wms_che_pdd_detail where pddh= '" + PDDH + "'";
            string sqlAddDetail = "insert into wms_che_pdd_detail(PDDH,HW,Wlh,WLMC,PCH,GG,SX,PH,ZCSL,JLDW,SHBZ,zczl,zldw,vfree1,vfree2,vfree3) select '" + PDDH + "',hw,wlh,WLMC,pch,gg,sx,ph,count(barcode),'" + jldw + "',0,sum(zl),'" + zldw + "',vfree1,vfree2,vfree3 from WMS_Bms_Inv_Info where ck='" + CKID + "' and (RKType is not null) and hw in(" + HW2List + ") group by hw,wlh,WLMC,pch,gg,sx,ph,vfree1,vfree2,vfree3";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlAddPDD);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteDetail);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlAddDetail);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region �������̵�
        /// <summary>
        /// �������̵�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="PDDH"></param>
        /// <param name="CKID"></param>
        /// <param name="PDRQ"></param>
        /// <param name="ZDRQ"></param>
        /// <param name="ZDRY"></param>
        /// <param name="jldw"></param>
        /// <param name="zldw"></param>
        /// <param name="HW2List"></param>
        public static string AddXPD(string YSDH, string PDDH, string CKID, string PDRQ, string ZDRQ, string ZDRY, string jldw, string zldw, string HW2List)
        {
            string sqlAddPDD = "insert into wms_che_pdd(PDDH,YSDH,CK,PDRQ,ZDRQ,ZDUser,DJZT,DJLX)values('" + PDDH + "','" + YSDH + "','" + CKID + "','" + Convert.ToDateTime(PDRQ) + "','" + Convert.ToDateTime(ZDRQ) + "','" + ZDRY + "','�½�','����')";
            string sqlDeleteDetail = "delete from wms_che_pdd_djdetail where pddh= '" + PDDH + "'";
            string sqlAddDetail = "insert into wms_che_pdd_djdetail(PDDH,HW,barcode,Wlh,WLMC,PCH,GG,SX,PH,ZCSL,JLDW,SHBZ,zl,zldw,vfree1,vfree2,vfree3) select '" + PDDH + "',hw,barcode,wlh,WLMC,pch,gg,sx,ph,1,'" + jldw + "',0,zl,'" + zldw + "',vfree1,vfree2,vfree3 from WMS_Bms_Inv_Info where ck='" + CKID + "' and (RKType is not null) and hw in(" + HW2List + ")";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlAddPDD);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteDetail);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlAddDetail);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region �޸Ĵ��̵�
        /// <summary>
        /// �޸Ĵ��̵�
        /// </summary>
        /// <param name="PDDH"></param>
        /// <param name="CKID"></param>
        /// <param name="HW2List"></param>
        /// <param name="jldw"></param>
        /// <param name="zldw"></param>
        public static string ModifyCPD(string PDDH, string CKID, string HW2List,string jldw,string zldw)
        {
            string sqlDeleteDetail = "delete from wms_che_pdd_detail where pddh= '" + PDDH + "'";
            string sqlAddDetail = "insert into wms_che_pdd_detail(PDDH,HW,Wlh,WLMC,PCH,GG,SX,PH,ZCSL,JLDW,SHBZ,zczl,zldw,vfree1,vfree2,vfree3) select '" + PDDH + "',hw,wlh,WLMC,pch,gg,sx,ph,count(barcode),'" + jldw + "',0,sum(zl),'" + zldw + "',vfree1,vfree2,vfree3 from WMS_Bms_Inv_Info where ck='" + CKID + "' and (RKType is not null) and hw in(" + HW2List + ") group by hw,wlh,WLMC,pch,gg,sx,ph,vfree1,vfree2,vfree3";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteDetail);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlAddDetail);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region �޸ĳ��̵�
        /// <summary>
        /// �޸ĳ��̵�
        /// </summary>
        /// <param name="PDDH"></param>
        /// <param name="CKID"></param>
        /// <param name="HW2List"></param>
        /// <param name="jldw"></param>
        /// <param name="zldw"></param>
        public static string ModifyXPD(string PDDH, string CKID, string HW2List, string jldw, string zldw)
        {
            string sqlDeleteDetail = "delete from wms_che_pdd_djdetail where pddh= '" + PDDH + "'";
            string sqlAddDetail = "insert into wms_che_pdd_djdetail(PDDH,HW,barcode,Wlh,WLMC,PCH,GG,SX,PH,ZCSL,JLDW,SHBZ,zl,zldw,vfree1,vfree2,vfree3) select '" + PDDH + "',hw,barcode,wlh,WLMC,pch,gg,sx,ph,1,'" + jldw + "',0,zl,'" + zldw + "',vfree1,vfree2,vfree3 from WMS_Bms_Inv_Info where ck='" + CKID + "' and (RKType is not null) and hw in(" + HW2List + ")";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteDetail);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlAddDetail);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region ɾ�����̵�
        /// <summary>
        /// ɾ�����̵�
        /// </summary>
        /// <param name="PDDH"></param>
        public static string DeleteCPD(string PDDH)
        {
            string sqlDeleteDetail = " delete from WMS_Che_PDD_DETAIL where PDDH = '" + PDDH + "'";
            string sqlDeleteCPD = "delete from  WMS_Che_PDD where PDDH = '" + PDDH + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteDetail);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteCPD);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region ɾ�����̵�
        /// <summary>
        /// ɾ�����̵�
        /// </summary>
        /// <param name="PDDH"></param>
        public static string DeleteXPD(string PDDH)
        {
            string sqlDeleteDetail = " delete from WMS_Che_PDD_djDETAIL where PDDH = '" + PDDH + "'";
            string sqlDeleteXPD = "delete from  WMS_Che_PDD where PDDH = '" + PDDH + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteDetail);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlDeleteXPD);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region �����̵㵥�Ż�õ���״̬
        /// <summary>
        /// �����̵㵥�Ż�õ���״̬
        /// </summary>
        /// <param name="PDDH"></param>
        /// <returns></returns>
        public static string GetDJZT(string PDDH)
        {
            string sql = "select DJZT from WMS_Che_PDD where PDDH = '" + PDDH + "'";
            AdoHelper adohlp = new SqlHelp();
            string DJZT = adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
            return DJZT;
        }
        #endregion

        #region ����ԭʼ���Ż���̵㵥��Ϣ
        /// <summary>
        /// ����ԭʼ���Ż���̵㵥��Ϣ
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static DataSet getPDDInfoByYSDH(string YSDH)
        {
            string sql = "SELECT PDDH,YSDH,CK,(select CKName from WMS_Pub_Store where CKID = CK)CKName,PDRQ,ZDRQ,ZDUser,SHUser,SHRQ,DJZT,DJLX FROM WMS_Che_PDD ";
            sql += " where YSDH = '" + YSDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ����ʴ��������̵���������ȵ����ݼ�
        /// <summary>
        /// ����ʴ��������̵���������ȵ����ݼ�
        /// </summary>
        /// <param name="PDDH"></param>
        /// <returns></returns>
        public static DataSet UnEqualDS(string PDDH)
        {
            string sql = "SELECT * FROM WMS_Che_PDD_DETAIL ";
            sql +=" INNER JOIN WMS_Che_PDD ON WMS_Che_PDD_DETAIL.PDDH = WMS_Che_PDD.PDDH ";
            sql +=" WHERE (WMS_Che_PDD.PDDH = '"+PDDH+"') ";
            sql +=" AND (isnull(WMS_Che_PDD_DETAIL.ZCSL,0) <> isnull(WMS_Che_PDD_DETAIL.SPSL,0))";
            sql +=" AND (ISNULL(WMS_Che_PDD_DETAIL.SPZL, 0) = 0)";
            sql +=" AND (NOT EXISTS (SELECT wlh FROM WMS_Che_PDD_DETAIL AS t, ";
            sql +=" WMS_Che_PDD AS t1 WHERE t1.ysdh = WMS_Che_PDD.ysdh AND t1.pddh=t.pddh ";
            sql +=" and t1.pddh <> WMS_Che_PDD.pddh AND t.hw = WMS_Che_PDD_DETAIL.hw ";
            sql +=" AND t.wlh = WMS_Che_PDD_DETAIL.wlh AND t.pch = WMS_Che_PDD_DETAIL.pch ";
            sql += " AND t.sx = WMS_Che_PDD_DETAIL.sx AND t.shbz = 1))";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �����̵㵥�Ż���̵㵥��Ϣ���ݼ�
        /// <summary>
        /// �����̵㵥�Ż���̵㵥��Ϣ���ݼ�
        /// </summary>
        /// <param name="PDDH"></param>
        /// <returns></returns>
        public static DataSet GetPDDbyPDDH(string PDDH)
        {
            string sql = "select * from WMS_Che_PDD where PDDH = '" + PDDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ����̵㵥
        /// <summary>
        /// ����̵㵥
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="PDDH"></param>
        /// <param name="SHUser"></param>
        public static string shenhePDD(string YSDH, string PDDH, string SHUser)
        {
            string sqlshenhePDD = " update WMS_Che_PDD set SHUser = '" + SHUser + "',SHRQ = (select getdate()),DJZT = '����' where PDDH = '"+PDDH+"'";
            string sqlshenhePDDdetail = "update WMS_Che_PDD_DETAIL set shbz=1 where pddh='"+PDDH+"'";
            sqlshenhePDDdetail += " and (hw not in (select distinct hw from WMS_Che_PDD_DETAIL,WMS_Che_PDD ";
            sqlshenhePDDdetail += " where WMS_Che_PDD_DETAIL.shbz=1 and WMS_Che_PDD_DETAIL.pddh=WMS_Che_PDD.pddh ";
            sqlshenhePDDdetail += " and WMS_Che_PDD.ysdh='"+YSDH+"'))";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlshenhePDD);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sqlshenhePDDdetail);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion
        #region ��˳��̵�
        /// <summary>
        /// ��˳��̵�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="PDDH"></param>
        /// <param name="SHUser"></param>
        /// <param name="jldw"></param>
        /// <param name="zldw"></param>
        public static string shenheXPD(string YSDH, string PDDH,string SHUser,string jldw,string zldw)
        {
            string sql1 = " update WMS_Che_PDD set SHUser = '" + SHUser + "',SHRQ = (select getdate()),DJZT = '����' where PDDH = '" + PDDH + "'";
            string sql2 = "update WMS_Che_PDD_djDETAIL set shbz=1 where pddh='" + PDDH + "' and (hw not in (select distinct hw from WMS_Che_PDD_djDETAIL,WMS_Che_PDD where WMS_Che_PDD_djDETAIL.shbz=1 and WMS_Che_PDD_djDETAIL.pddh=WMS_Che_PDD.pddh and WMS_Che_PDD.ysdh='" + YSDH + "'))";
            string sql3 = "insert into wms_che_pdd_detail(PDDH,HW,Wlh,WLMC,PCH,GG,SX,PH,ZCSL,spsl,pdcy,JLDW,SHBZ,zczl,spzl,zldw,VFREE1,VFREE2,VFREE3,operuser,operdate) select '" + PDDH + "',hw,wlh,WLMC,pch,gg,sx,ph,sum(zcsl),sum(spsl),isnull(sum(spsl),0)-sum(zcsl),'" + jldw + "',1,sum(zcsl*zl),sum(spsl*zl),'" + zldw + "',VFREE1,VFREE2,VFREE3,max(operuser),max(operdate) from wms_che_pdd_djdetail where pddh='" + PDDH + "' and shbz=1 group by hw,wlh,WLMC,pch,gg,sx,ph,VFREE1,VFREE2,VFREE3";
            string sql4 = "update WMS_Che_PDD_DETAIL set shbz=0 where pddh='" + PDDH + "' and shbz=1 AND (EXISTS (SELECT wlh FROM WMS_Che_PDD_DETAIL AS t, WMS_Che_PDD AS t1 WHERE t1.ysdh = '" + YSDH + "' AND  t1.pddh=t.pddh and t1.pddh <> '" + PDDH + "' AND t.hw = WMS_Che_PDD_DETAIL.hw AND t.wlh = WMS_Che_PDD_DETAIL.wlh AND t.pch = WMS_Che_PDD_DETAIL.pch AND t.sx = WMS_Che_PDD_DETAIL.sx AND t.shbz = 1))";
            
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql1);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql2);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql3);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql4);
                //DataSet ds = null;
                //string sqlstr = "select  hw,wlh,pch,gg,sx,ph,sum(zcsl),sum(spsl),VFREE1,VFREE2,VFREE3 from WMS_CHE_PDD_DJDETAIL where pddh = '" + PDDH + "' and shbz=1 group by hw,wlh,pch,gg,sx,ph,VFREE1,VFREE2,VFREE3";
                //ds = adohlp.ExecuteDataset(tra, CommandType.Text, sqlstr);
                //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        string sql5 = "update WMS_Che_PDD_DETAIL set operuser='" + dr["operuser"].ToString() + "',operdate='" + dr["operdate"].ToString() + 
                //            "' where pddh='"+PDDH+"' and hw='"+dr["hw"].ToString()+"' and wlh='"+dr["wlh"].ToString()+"' and pch='"+dr["pch"].ToString()+
                //            "' and sx='"+dr["sx"].ToString()+"' and vfree1='' and vfree2='' and vfree3=''";
                //        adohlp.ExecuteNonQuery(tra, CommandType.Text, sql5);
                //    }
                //}
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region �ſ����̵�
        /// <summary>
        /// �ſ����̵�
        /// </summary>
        /// <param name="PDDH"></param>
        public static void fangkaiPDD(string PDDH)
        {
            string sql = "update wms_che_pdd set djzt='����' where PDDH = '" + PDDH + "'";
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql);
        }
        #endregion

        #region ����ԭʼ���Ż��NC�̵㵥��ϸ
        /// <summary>
        /// ����ԭʼ���Ż��NC�̵㵥��ϸ
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static DataSet GetNCDetail(string YSDH,string sortField)
        {
            string sql = "select ysdh,barcode,pch,sx,vfree1,vfree2,vfree3,zcsl,spsl,pdcy,jldw,CAST(ZCZL as numeric(20,3)) as ZCZL,CAST(SPZL as numeric(20,3)) as SPZL,shbz,zldw from WMS_CHE_PDDNC_DETAIL where ysdh= '" + YSDH + "'";
            if (!string.IsNullOrEmpty(sortField))
            {
                sql += "order by " + sortField;
            }
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �õ�����ִ�е�ת�ⵥ��Ŀ
        /// <summary>
        /// �õ�����ִ�е�ת�ⵥ��Ŀ
        /// </summary>
        /// <returns>����</returns>
        public static int GetExePDDCount()
        {
            string strSql = "SELECT count(*) FROM WMS_Che_PDD where DJZT<>'����'";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
                return Convert.ToInt32(result);
            return 0;
        }
        #endregion

        #region ����̵㵥�ϴ������·�Grid�����ݼ�
        /// <summary>
        /// ����̵㵥�ϴ������·�Grid�����ݼ�
        /// </summary>
        /// <param name="YSDH">ԭʼ����</param>
        /// <param name="PDDH">�̵㵥��</param>
        /// <param name="WLH">���Ϻ�</param>
        /// <param name="PCH">���κ�</param>
        /// <param name="SX">����</param>
        /// <param name="chkNoNCWLisChecked">��NC���ϸ�ѡ���Ƿ�ѡ��</param>
        /// <returns></returns>
        public static DataSet GetPDDdetailDataUp(string YSDH, string PDDH, string WLH, string PCH, string SX, bool chkNoNCWLisChecked,string sort)
        {
            string sql = "select wms_che_pdd_detail.PDDH,WLH,WLMC,HW,PCH,SX,vfree1,vfree2,vfree3,ZCSL,SPSL,"+
                "CAST(ZCZL as numeric(20,3)) as ZCZL,CAST(SPZL as numeric(20,3)) as SPZL,WMS_Pub_Users.UserName,operdate from "+
                "wms_che_pdd_detail,wms_che_pdd,WMS_Pub_Users " +
                "where wms_che_pdd_detail.pddh=wms_che_pdd.pddh and wms_che_pdd_detail.operuser=WMS_Pub_Users.UserID and wms_che_pdd.ysdh='" + YSDH + "'and WMS_Che_PDD_DETAIL.shbz=1";
            if (!string.IsNullOrEmpty(PDDH))
            {
                sql += " and wms_che_pdd.pddh= '" + PDDH + "'";
            }
            if (!string.IsNullOrEmpty(WLH))
            {
                sql += " and wms_che_pdd_detail.wlh='" + WLH + "' and wms_che_pdd_detail.pch='" + PCH + "' and wms_che_pdd_detail.sx='" + SX + "'";
            }
            else
            {
                if (chkNoNCWLisChecked)
                {
                    sql += " AND (NOT EXISTS (SELECT ysdh  FROM wms_che_pddnc_detail WHERE ysdh = '" + YSDH + "' AND wms_che_pddnc_detail.barcode = WMS_CHE_PDD_DETAIL.wlh AND wms_che_pddnc_detail.pch = WMS_CHE_PDD_DETAIL.pch AND wms_che_pddnc_detail.sx = WMS_CHE_PDD_DETAIL.sx)) ";
                }
            }
            if (!string.IsNullOrEmpty(sort))
            {
                sql += "order by " + sort;
            }
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ����̵㵥�ϴ������·�Grid�����ݼ����ڵ���Excel
        /// <summary>
        /// ����̵㵥�ϴ������·�Grid�����ݼ����ڵ���Excel
        /// </summary>
        /// <param name="YSDH">ԭʼ����</param>
        /// <param name="PDDH">�̵㵥��</param>
        /// <param name="WLH">���Ϻ�</param>
        /// <param name="PCH">���κ�</param>
        /// <param name="SX">����</param>
        /// <param name="chkNoNCWLisChecked">��NC���ϸ�ѡ���Ƿ�ѡ��</param>
        /// <returns></returns>
        public static DataSet GetPDDdetailDataUpXls(string YSDH, string PDDH, string WLH, string PCH, string SX, bool chkNoNCWLisChecked, string sort)
        {
            string sql = "select wms_che_pdd_detail.PDDH as ���ݺ�,WLH as ���Ϻ�,WLMC as ��������,HW as ��λ,PCH as ���κ�,SX as ����,ZCSL as �ʴ�����,SPSL as �̵�����,CAST(ZCZL as numeric(20,3)) as �ʴ�����,CAST(SPZL as numeric(20,3)) as ʵ������ from wms_che_pdd_detail,wms_che_pdd where wms_che_pdd_detail.pddh=wms_che_pdd.pddh and wms_che_pdd.ysdh='" + YSDH + "'and WMS_Che_PDD_DETAIL.shbz=1";
            if (!string.IsNullOrEmpty(PDDH))
            {
                sql += " and wms_che_pdd.pddh= '" + PDDH + "'";
            }
            if (!string.IsNullOrEmpty(WLH))
            {
                sql += " and wms_che_pdd_detail.wlh='" + WLH + "' and wms_che_pdd_detail.pch='" + PCH + "' and wms_che_pdd_detail.sx='" + SX + "'";
            }
            else
            {
                if (chkNoNCWLisChecked)
                {
                    sql += " AND (NOT EXISTS (SELECT ysdh  FROM wms_che_pddnc_detail WHERE ysdh = '" + YSDH + "' AND wms_che_pddnc_detail.barcode = WMS_CHE_PDD_DETAIL.wlh AND wms_che_pddnc_detail.pch = WMS_CHE_PDD_DETAIL.pch AND wms_che_pddnc_detail.sx = WMS_CHE_PDD_DETAIL.sx)) ";
                }
            }
            if (!string.IsNullOrEmpty(sort))
            {
                sql += "order by " + sort;
            }
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �ж��Ƿ��ѽ��й���ӯ���
        /// <summary>
        /// �ж��Ƿ��ѽ��й���ӯ���
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static bool DonePYRK(string YSDH)
        {
            string sql = "select isnull(pyrkbz,0) as bz from WMS_CHE_PDDNC where ysdh= '" + YSDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["bz"].ToString() == "2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ���ʵ��λ�����ʴ�λ�ò�����������Ϣ���ݼ�
        /// <summary>
        /// ���ʵ��λ�����ʴ�λ�ò�����������Ϣ���ݼ�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static DataSet GetCuoweiWLinfo(string YSDH)
        {
            string sql = "select pdddj.barcode,pdddj.pch,pdddj.ph,pdddj.gg,pdddj.sx,pdd.ck as pck,pdddj.hw as phw,info.ck as yck,info.hw as yhw from WMS_Che_PDD  pdd,WMS_CHE_PDD_DJDETAIL  pdddj,WMS_Bms_Inv_Info  info where pdd.ysdh='" + YSDH + "' and pdd.pddh=pdddj.pddh and pdddj.shbz=1 and pdddj.zcsl=0 and pdddj.spsl=1 and pdddj.barcode=info.barcode and pdddj.hw<>info.hw ";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region �̵������ϴ�ҳ������
        /// <summary>
        /// �̵������ϴ�ҳ������
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="SHUser"></param>
        public static string shenheDataUp(string YSDH,string SHUser)
        {
            string sql1 = "UPDATE wms_che_pddnc_detail SET spsl = sumspsl, spzl = sumspzl FROM wms_che_pddnc_detail,(SELECT wlh, pch, sx,vfree1,vfree2,vfree3, isnull(SUM(spsl),0) AS sumspsl,isnull(SUM(spzl),0) AS sumspzl FROM wms_che_pdd_detail, wms_che_pdd WHERE wms_che_pdd.pddh = wms_che_pdd_detail.pddh AND wms_che_pdd.ysdh ='" + YSDH + "' AND shbz = 1 GROUP BY wlh, pch, sx,vfree1,vfree2,vfree3) tt WHERE wms_che_pddnc_detail.ysdh='" + YSDH + "' and wms_che_pddnc_detail.sx<>'DP' AND wms_che_pddnc_detail.barcode = tt.wlh AND wms_che_pddnc_detail.pch = tt.pch AND wms_che_pddnc_detail.sx = tt.sx and wms_che_pddnc_detail.vfree1 = tt.vfree1 and wms_che_pddnc_detail.vfree2 = tt.vfree2 and wms_che_pddnc_detail.vfree3 = tt.vfree3";
            string sql2 = "UPDATE wms_che_pddnc_detail SET spsl = sumspsl, spzl = sumspzl FROM wms_che_pddnc_detail,(SELECT  wlh,pch,vfree1,vfree2,vfree3, isnull(SUM(spsl),0) AS sumspsl,isnull(SUM(spzl),0) AS sumspzl FROM wms_che_pdd_detail, wms_che_pdd WHERE wms_che_pdd.pddh = wms_che_pdd_detail.pddh AND wms_che_pdd.ysdh ='" + YSDH + "' AND shbz = 1 GROUP BY wlh, pch,vfree1,vfree2,vfree3) tt WHERE wms_che_pddnc_detail.ysdh='" + YSDH + "' and wms_che_pddnc_detail.sx='DP' AND wms_che_pddnc_detail.barcode = tt.wlh AND  wms_che_pddnc_detail.pch = tt.pch and wms_che_pddnc_detail.vfree1 = tt.vfree1 and wms_che_pddnc_detail.vfree2 = tt.vfree2 and wms_che_pddnc_detail.vfree3 = tt.vfree3";
            string sql3 = "update wms_che_pddnc_detail set spsl=0 where (spsl is null) and (ysdh='" + YSDH + "')";
            string sql4 = "update wms_che_pddnc_detail set spzl=0 where (spzl is null) and (ysdh='" + YSDH + "')";
            string sql5 = "update WMS_CHE_PDDNC set DJZT = '����',SHUSER = '" + SHUser + "',SHDATE = '" + Convert.ToDateTime(GetSysDate()) + "' where YSDH = '" + YSDH + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql1);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql2);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql3);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql4);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql5);
                tra.Commit();
                con.Close();
                return "success";
            }
            catch(Exception ex)
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                return ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region ��֤�̵㵥�Ƿ񱻷��͹�
        /// <summary>
        /// ��֤�̵㵥�Ƿ񱻷��͹�
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool XmlIsSended(string filename)
        {
            string sql = "select ComXML from WMS_Com_Log where ComXML= '" + filename + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ����̵㵥������־
        /// <summary>
        /// ����̵㵥������־
        /// </summary>
        /// <param name="CKID"></param>
        /// <param name="xmlfilename"></param>
        /// <param name="YSDH"></param>
        /// <param name="comdes"></param>
        /// <param name="ComResult"></param>
        public static void AddXmlLog(string CKID, string xmlfilename, string YSDH, string comdes, int ComResult)
        {
            string sql = "insert into WMS_Com_Log(CK,ComXML,DOCID,DOCType,ComResult,ComDes,ComType) values('" + CKID + "','" + xmlfilename + "','" + YSDH + "','4R'," + ComResult + ",'" + comdes + "',0)";
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql);
        }
        #endregion

        #region ����̵㵥xml���ݼ�
        /// <summary>
        /// ����̵㵥xml���ݼ�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static DataSet GetXmldata(string YSDH)
        {
            string sql = "select WLH,PCH,SX,isnull(sum(ZCSL),0) as sumzcsl,isnull(sum(zczl),0) as sumzczl,isnull(sum(spsl),0) as sumspsl,isnull(sum(spzl),0) as sumspzl from WMS_Che_PDD_DETAIL,WMS_Che_PDD where WMS_Che_PDD_DETAIL.pddh=WMS_Che_PDD.pddh and WMS_Che_PDD.ysdh='" + YSDH + "' and WMS_Che_PDD_DETAIL.shbz=1  group by WLH,PCH,SX";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ��ÿ�����ҳ�����ݼ�
        /// <summary>
        /// ��ÿ�����ҳ�����ݼ�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static DataSet GetDSkctz(string YSDH)
        {
            string sql = "select pd.barcode,pd.wlh,pd.wlmc,pd.pch,pd.gg,pd.ph,pd.sx,pd.vfree1,pd.vfree2,pd.vfree3,p.ck,pd.hw,pd.zcsl,pd.spsl,(isnull(pd.spsl,0)-isnull(pd.zcsl,0)) as slcy,CAST(zl as numeric(20,3)) as zl from wms_che_pdd as p,wms_che_pdd_djdetail as pd   where  p.ysdh='" + YSDH + "' and p.pddh=pd.pddh and pd.shbz=1  and isnull(pd.zcsl,0)<>isnull(pd.spsl,0)  and not exists (select barcode from wms_bms_inv_info as  info  where info.barcode=pd.barcode and info.hw<>pd.hw)";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ����̿�������
        /// <summary>
        /// ����̿�������
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static string Getpkckbz(string YSDH)
        {
            string sql = "select isnull(pkckbz,0) as bz from WMS_CHE_PDDNC where ysdh='" + YSDH + "'";
            AdoHelper adohlp = new SqlHelp();
            string pkckbz = adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
            return pkckbz;
        }
        #endregion

        #region �̿�����
        /// <summary>
        /// �̿�����
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="ckdh"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static bool PKCK(string YSDH,int ckdh,string UserID)
        {
            string sql1 = "insert into wms_bms_inv_outinfo(barcode,rkdh,fydh,ckdh,ck,hw,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,zldj,ph,gg,bb,gh,zl,bz,flag,ckry,weightrq,ckcxh,pcinfo,filed1,errseason,filed2) select barcode,wgdh,'" + YSDH + "'," + ckdh + ",ck,hw,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,zldj,ph,gg,bb,gh,zl,bz,'�̿�����','" + UserID + "',weightrq,ckcxh,pcinfo,filed1,errseason,filed2 from wms_bms_inv_info where barcode in (select barcode from wms_che_pdd as p, wms_che_pdd_djdetail as pd where p.ysdh='" + YSDH + "' and p.pddh=pd.pddh and pd.shbz=1 and isnull(pd.spsl,0)=0 and not exists (select barcode from wms_bms_inv_info as  info where info.barcode=pd.barcode and info.hw<>pd.hw))";
            string sql2 = "insert into wms_pic_doc(ckdh,ck,hw,cktype,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,ph,gg,sl,zl,cktime,cph) select '" + YSDH + "',ck,max(hw) as hw,'�̿�����',pch,wlh,max(wlmc) as wlmc,sx,vfree1,vfree2,vfree3,max(ph) as ph,max(gg) as gg,count(barcode),sum(zl),getdate(),'' from wms_bms_inv_info  where barcode in (select barcode from wms_che_pdd as p, wms_che_pdd_djdetail as pd where p.ysdh='" + YSDH + "' and p.pddh=pd.pddh and pd.shbz=1 and isnull(pd.spsl,0)=0 and not exists (select barcode from wms_bms_inv_info as  info where info.barcode=pd.barcode and info.hw<>pd.hw)) group by ck,pch,wlh,sx,vfree1,vfree2,vfree3";
            string sql3 = "delete from wms_bms_inv_info where barcode in (select barcode from wms_che_pdd as p,wms_che_pdd_djdetail as pd where p.ysdh='"+YSDH+"' and p.pddh=pd.pddh and pd.shbz=1 and isnull(pd.spsl,0)=0 and not exists (select barcode from wms_bms_inv_info as  info where info.barcode=pd.barcode and info.hw<>pd.hw))";
            string sql4 = "update WMS_CHE_PDDNC set pkckbz=1 where ysdh='"+YSDH+"'";
            bool result;
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql1);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql2);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql3);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql4);
                tra.Commit();
                con.Close();
                result = true;
                return result;
            }
            catch
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                result = false;
                return result;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region ����̿����ⵥ��
        /// <summary>
        /// ����̿����ⵥ��
        /// </summary>
        /// <returns></returns>
        public static int Getckdh()
        {
            string sql1 = "select MAXORDER from WMS_PUB_ORDERLIST where TABLENAME='WMS_Bms_Pic_FYD' and FIELDNAME='CKDH'";           
            AdoHelper adohlp = new SqlHelp();
            int ckdh = Convert.ToInt32(adohlp.ExecuteScalar(Common.GetConnectString(),CommandType.Text,sql1));
            int ckdhNew = ckdh + 1;
            string sql2 = "update WMS_PUB_ORDERLIST set MAXORDER='" + ckdhNew + "' where TABLENAME='WMS_Bms_Pic_FYD' and FIELDNAME='CKDH'";
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql2);
            return ckdh;
        }
        #endregion

        #region �����ӯ�����
        /// <summary>
        /// �����ӯ�����
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static string GetPyrkbz(string YSDH)
        {
            string sql = "select isnull(pyrkbz,0) as bz from WMS_CHE_PDDNC where ysdh='" + YSDH + "'";
            AdoHelper adohlp = new SqlHelp();
            string pyrkbz = adohlp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, sql).ToString();
            return pyrkbz;
        }
        #endregion

        #region ��ӯ���
        /// <summary>
        /// ��ӯ���
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="UserID"></param>
        public static bool PYRK(string YSDH,string UserID)
        {
            string sql1 = "insert into WMS_Che_Pdd_PYRK(barcode,pddysdh,wgdh,ck,hw,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,zldj,ph,gg,bb,gh,zl,bz,rktype,rkry,weightrq,ckcxh,pcinfo,filed1,errseason,filed2) select wpdj.barcode,wpdd.ysdh,outinfo.RKDH,wpdd.ck,wpdj.hw,wpdj.pch,wpdj.wlh,outinfo.wlmc,wpdj.sx,wpdj.vfree1,wpdj.vfree2,wpdj.vfree3,outinfo.zldj,wpdj.ph,wpdj.gg,outinfo.bb,outinfo.gh,wpdj.zl,outinfo.bz,'��ӯ���','" + UserID + "',outinfo.weightrq,outinfo.ckcxh,outinfo.pcinfo,outinfo.filed1,outinfo.errseason,outinfo.filed2 from (select wms_bms_inv_outinfo.* from wms_bms_inv_outinfo ,(select barcode,ckdh,max(rq) asmaxrq from wms_bms_inv_outinfo group by barcode,ckdh) as t where t.barcode=wms_bms_inv_outinfo.barcode and t.ckdh=wms_bms_inv_outinfo.ckdh) as outinfo,wms_che_pdd as wpdd,wms_che_pdd_djdetail as wpdj where wpdd.ysdh='" + YSDH + "' and wpdd.pddh=wpdj.pddh and wpdj.barcode=outinfo.barcode and wpdj.shbz=1 and wpdj.barcode in (select barcode from wms_che_pdd as p, wms_che_pdd_djdetail as pd where p.ysdh='" + YSDH + "' and p.pddh=pd.pddh and pd.shbz=1 and isnull(pd.zcsl,0)=0 and not exists (select barcode from wms_bms_inv_info as  info where info.barcode=pd.barcode and info.hw<>pd.hw))";
            string sql2 = "update WMS_CHE_PDDNC set pyrkbz=1 where ysdh='" + YSDH + "'";
            bool result;
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql1);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql2);
                tra.Commit();
                con.Close();
                result = true;
                return result;
            }
            catch
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
                result = false;
                return result;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region �����ӯ������ݼ�
        /// <summary>
        /// �����ӯ������ݼ�
        /// </summary>
        /// <param name="YSDH"></param>
        /// <returns></returns>
        public static DataSet GetDSpyrk(string YSDH)
        {
            string sql = "select * from WMS_Che_Pdd_PYRK where PddYsdh='" + YSDH + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ��ð󶨻�λ���ݼ�
        /// <summary>
        /// ��ð󶨻�λ���ݼ�
        /// </summary>
        /// <param name="ck"></param>
        /// <returns></returns>
        public static DataSet GetDShw(string ck)
        {
            string sql = "select hwid from wms_pub_hw where ck='" + ck + "'";
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            return ds;
        }
        #endregion

        #region ���ô洢������֤��λ��ǰ״̬�Ƿ���Դ������
        /// <summary>
        /// ���ô洢������֤��λ��ǰ״̬�Ƿ���Դ������
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="hw"></param>
        /// <param name="pch"></param>
        /// <param name="sx"></param>
        /// <returns></returns>
        public static int HWisOK(string barcode, string hw, string pch,string sx)
        {
            string strSql = "Pdd_HW_ISOK";
            SqlParameter[] parameters = {
                    new SqlParameter("@barcode", SqlDbType.VarChar),
                    new SqlParameter("@pch", SqlDbType.VarChar),
                    new SqlParameter("@sx", SqlDbType.VarChar),
                    new SqlParameter("@HW", SqlDbType.VarChar),
                    new SqlParameter("@ReturnCode", SqlDbType.Int)};

            parameters[0].Value = barcode;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = pch;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = sx;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Value = hw;
            parameters[3].Direction = ParameterDirection.Input;
            parameters[4].Direction = ParameterDirection.ReturnValue;

            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteNonQuery(Common.GetConnectString(),CommandType.StoredProcedure, strSql, parameters);
            result = parameters[4].Value;
            return Convert.ToInt32(result);
        }
        #endregion

        #region �޸Ļ�λ
        /// <summary>
        /// �޸Ļ�λ
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="Barcode"></param>
        /// <param name="HW"></param>
        public static void xiugaiHW(string YSDH, string Barcode, string HW)
        {
            string sql = "update WMS_Che_Pdd_PYRK set HW = '" + HW + "' where Barcode = '" + Barcode + "' and PddYsdh = '" + YSDH + "'";
            AdoHelper adohlp = new SqlHelp();
            adohlp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sql);
        }
        #endregion

        #region ��ӯ���ҳ���������
        /// <summary>
        /// ��ӯ���ҳ���������
        /// </summary>
        /// <param name="YSDH"></param>
        /// <param name="UserID"></param>
        public static void Pyrk_Rkcz(string YSDH, string UserID)
        {
            string sql1 = "insert into WMS_Bms_Inv_Info(barcode,wgdh,ck,hw,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,zldj,ph,gg,bb,gh,zl,bz,RQ,rktype,rkry,weightrq,ckcxh,pcinfo,filed1,errseason,filed2) select barcode,wgdh,ck,hw,pch,wlh,wlmc,sx,vfree1,vfree2,vfree3,zldj,ph,gg,bb,gh,zl,bz,getdate(),rktype,'" + UserID + "',weightrq,ckcxh,pcinfo,filed1,errseason,filed2 from WMS_Che_Pdd_PYRK where pddysdh='" + YSDH + "'";
            string sql2 = "insert into WMS_Rev_Doc(RKDH,CK,HW,RKType,PCH,WLH,WLMC,SX,PH,GG,SL,ZL,CPH,RKTime,vfree1,vfree2,vfree3) select PddYsdh,CK,HW,'��ӯ���',PCH,WLH,WLMC,SX,ph,gg,count(barcode),sum(zl),'',getdate(),vfree1,vfree2,vfree3 from WMS_Che_Pdd_PYRK where pddysdh='" + YSDH + "' group by PddYsdh,CK,HW,PCH,WLH,WLMC,SX,ph,gg,vfree1,vfree2,vfree3 ";
            string sql3 = "update WMS_CHE_PDDNC set pyrkbz=2 where ysdh='" + YSDH + "'";
            SqlConnection con = new SqlConnection(Common.GetConnectString());
            con.Open();
            AdoHelper adohlp = new SqlHelp();
            SqlTransaction tra = con.BeginTransaction();
            try
            {
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql1);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql2);
                adohlp.ExecuteNonQuery(tra, CommandType.Text, sql3);
                tra.Commit();
                con.Close();
            }
            catch
            {
                tra.Rollback();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        #endregion

        #region �̵�ο�
        /// <summary>
        /// </summary>
        /// <param name="ckid">�ֿ�</param>
        public static DataSet GetPDCK(string ckid,string zdrqq,string zdrqz)
        {
            string sqlstrf = "";
            if (zdrqq != "") sqlstrf = " and WMS_CHE_pdd.zdrq>='"+zdrqq+" 00:00:00'";
            if (zdrqz != "") sqlstrf += " and WMS_CHE_pdd.zdrq<='" + zdrqz + " 23:59:59'";
            string sqlstr = "select * from ( "+
                            "select * from  "+
                            "(select hw,case  when count(1) = 1 then '����' else '����' end as b  "+
                            "from (select hw,pch,wlh,wlmc,sx,ph,gg,vfree1,vfree2,vfree3,sum(zl) as  "+
                            "zczl,count(1) as zcsl from WMS_Bms_Inv_Info  "+
                            "where hw is not null  "+
                            "group by hw,pch,wlh,wlmc,sx,zldj,ph,gg,vfree1,vfree2,vfree3) a group by hw) c "+
                            "left join  "+
                            "wms_pub_hw d "+
                            "on d.hwid=c.hw "+
                            "where ck='"+ckid+"')e "+
                            "left join  "+
                            "(select WMS_CHE_pdd_detail.pddh,hw as yphw,'����' as pdtype,djzt from  "+
                            "WMS_CHE_pdd_detail left join WMS_CHE_pdd "+
                            "on WMS_CHE_pdd_detail.pddh=WMS_CHE_pdd.pddh where WMS_CHE_pdd.ck='"+ckid+"' "+sqlstrf+
                            "union all "+
                            "select WMS_CHE_pdd_djdetail.pddh,hw as yphw,'����' as pdtype,djzt from WMS_CHE_pdd_djdetail  "+
                            "left join WMS_CHE_pdd "+
                            "on WMS_CHE_pdd_djdetail.pddh=WMS_CHE_pdd.pddh where  WMS_CHE_pdd.ck='"+ckid+"' "+sqlstrf+") f "+
                            "on e.hw=f.yphw order by hw,b";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            try
            {
                ds = helper.ExecuteDataset(Common.GetConnectString(),CommandType.Text,sqlstr);
            }
            catch
            { 
            }
            return ds;
        }
        #endregion

    }
}
