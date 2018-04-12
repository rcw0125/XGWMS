using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.ReportBll
{
    
     public class QTRKReport
    {
         public QTRKReport()
         { }
        //��������
        public static DataSet GetCKLX()
        {
            string strSql = "select  distinct  top 10 flag from WMS_Bms_Inv_OutInfo order by flag";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //�ƺ�
        public static DataSet GetCKPH()
        {
            string strSql = "select  distinct  top 10 PH from WMS_Bms_Inv_OutInfo order by PH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        //���
        public static DataSet GetCKGG()
        {
            string strSql = "select  distinct  top 10 GG from WMS_Bms_Inv_OutInfo order by GG";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //�ֿ�
        public static DataSet GetCKID()
        {
            string strSql = "select CKID as ck from WMS_Pub_Store order by CKID";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        //�õ���λ
        public static DataSet GetCKHW(string sqlwhere)
        {
            string strSql = "select hwid  from WMS_Pub_HW";
            AdoHelper dataHelp = new SqlHelp();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where ck='" + sqlwhere + "' order by hwid";
            }
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// ��ҳ��ѯ���˵���Ϣ
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="pageSize">ÿҳ������</param>
        /// <param name="pageNum">��ǰ��ʾ��Ϊ�ڼ�ҳ</param>
        /// <returns></returns>
        /// 
        public static DataSet GetQueryYTRK(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "Barcode";
            int pSize = 20;
            int pNum = 1;
            //����0:�������� 1����ѯ���� 2���ڼ�����¼��ʼ 3���ڼ�����¼����
            string pagesql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0}) AS RowNumber  from WMS_Bms_Inv_OutInfo{1})SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere += " where 1=1" + Sql_ZKD;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pagesql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;

        }

        /// <summary>
        /// �õ���ҳ�����ͼ�¼������
        /// </summary>
        /// <param name="strWhere">��ѯ����������WHERE</param>
        /// <param name="pageSize">ÿҳ��¼��</param>
        /// <param name="allCount">��¼������</param>
        /// <returns>��ҳ��</returns>
        public static int GetPageCount(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "select count(*) from WMS_Bms_Inv_OutInfo{0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " where 1=1" + strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
            {
                double temp = Convert.ToDouble(result);
                allCount = Convert.ToInt32(temp);
                double pageCount = Math.Ceiling(temp / pageSize);
                return Convert.ToInt32(pageCount);
            }
            allCount = 0;
            return 0;
        }

         //�������
         public static int GetTM(string strWhere)
         {
             string strSql = "select count(1) as fcount from WMS_Bms_Inv_Info";
             if (!string.IsNullOrEmpty(strWhere))
             {
                 strSql += " where barcode='" + strWhere+"'";
             }
             AdoHelper dataHelp = new SqlHelp();
             object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
             if (result != null)
             {
                 return Convert.ToInt32(result.ToString());
             }
             return 0;
         }
         //�̿�����
         public static DataSet GetPKCK(string sqlwhere)
         {
             string strSql = "select djzt from WMS_Che_PDD ";
             AdoHelper dataHelp = new SqlHelp();
             if (!string.IsNullOrEmpty(sqlwhere))
             {
                 strSql += "where ysdh='" + sqlwhere+"'";
             }
             DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
             if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                 return ds;
             return null;
         }
         //���۳���
         public static DataSet GetXSCK(string sqlwhere)
         {
             string strSql = "select status from WMS_Bms_Pic_FYD";
             AdoHelper dataHelp = new SqlHelp();
             if (!string.IsNullOrEmpty(sqlwhere))
             {
                 strSql += " where fydh='" + sqlwhere + "'";
             }
             DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
             if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                 return ds;
             return null;
         }
         //ת������
         public static DataSet GetZHCK(string sqlwhere)
         {
             string strSql = "select OutStatus from WMS_Bms_Tra_ZKD ";
             AdoHelper dataHelp = new SqlHelp();
             if (!string.IsNullOrEmpty(sqlwhere))
             {
                 strSql += "where zkdh='" + sqlwhere + "'";
             }
             DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
             if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                 return ds;
             return null;
         }
         //��������
         public static DataSet GetQTCK(string sqlwhere)
         {
             string strSql = "select status from WMS_CHE_QTCK";
             AdoHelper dataHelp = new SqlHelp();
             if (!string.IsNullOrEmpty(sqlwhere))
             {
                 strSql += " where ckdh='" + sqlwhere + "'";
             }
             DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
             if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                 return ds;
             return null;
         }

         public static int execQTRKHW(string barcode,string hw,string fydh)
         {
             string strSql = "QTRK_HW_ISOK";
             SqlParameter[] parameters = {
					new SqlParameter("@barcode", SqlDbType.VarChar),
					new SqlParameter("@HW", SqlDbType.VarChar),
					new SqlParameter("@FYDH", SqlDbType.VarChar),
                    new SqlParameter("@ReturnCode",SqlDbType.Int)};

             parameters[0].Value = barcode.Trim();
             parameters[0].Direction = ParameterDirection.Input;
             parameters[1].Value = hw.Trim();
             parameters[1].Direction = ParameterDirection.Input;
             parameters[2].Value = fydh.Trim();
             parameters[2].Direction = ParameterDirection.Input;

             parameters[3].Direction = ParameterDirection.ReturnValue;
             AdoHelper dataHelp = new SqlHelp();
             dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, strSql, parameters);
             return Convert.ToInt32(parameters[3].Value);
         }

         public  int ModiQTRK(string str1,string str2,string str3)
         {

             SqlConnection con = new SqlConnection(Common.GetConnectString());
             con.Open();
             AdoHelper adohlp = new SqlHelp();
             SqlTransaction tra = con.BeginTransaction();
             try
             {
                 adohlp.ExecuteNonQuery(tra, CommandType.Text, str1);
                 adohlp.ExecuteNonQuery(tra, CommandType.Text, str2);
                 adohlp.ExecuteNonQuery(tra, CommandType.Text, str3);
                 tra.Commit();
                 con.Close();
             }
             catch
             {
                 tra.Rollback();
                 if (con.State == ConnectionState.Open)
                     con.Close();
                 return -1;
             }
             finally
             {
                 if (con.State == ConnectionState.Open)
                     con.Close();
             }
             return 0;
         }
    }
}
