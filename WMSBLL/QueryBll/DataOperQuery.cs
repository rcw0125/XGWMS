using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Acctrue.WM_WES.DataAccess;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class DataOperQuery
    {
        /// <summary>
        /// ��ҳ��ѯ��־��Ϣ
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="pageSize">ÿҳ������</param>
        /// <param name="pageNum">��ǰ��ʾ��Ϊ�ڼ�ҳ</param>
        /// <returns></returns>
        public static DataSet GetDataMoveLog(string strSTime,string strETime, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = " where Beigin_Time>'" + strSTime + "' and Beigin_Time<'" + strETime + "'";
            string oKey = "Beigin_Time";
            int pSize = 20;
            int pNum = 1;
            //����0:�������� 1����ѯ���� 2���ڼ�����¼��ʼ 3���ڼ�����¼����
            string pageSql = "WITH TempDB AS (select *,row_number() OVER (ORDER BY {0} DESC) AS RowNumber FROM WMS_Pub_DataMoveLog {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pageSql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
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
        public static int GetPageCount(string strSTime, string strETime, int pageSize, out int allCount)
        {
            string strSql = "SELECT count(*) FROM WMS_Pub_DataMoveLog where Beigin_Time>'" + strSTime + "' and Beigin_Time<'" + strETime + "'";
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

        /// <summary>
        /// ��ȡ�ϴ�����Ǩ��ʱ��
        /// </summary>
        /// <returns></returns>
        public static string GetLastDataMoveTime()
        {
            string strSql = "select * from WMS_Pub_Param where (CS_Name = 'LastLoadOuttime')";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["CS_Value"].ToString();
            return "";
        }

        /// <summary>
        /// ��ȡ���κ���Ϣ
        /// </summary>
        /// <param name="pch"></param>
        /// <param name="orderKey"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public static DataSet GetAllPCH(string pch,string orderKey, int pageSize, int pageNum)
        {
            string sWhere = " where PCH like '%" + pch + "%' group by pch";
            string oKey = "PCH";
            int pSize = 20;
            int pNum = 1;
            //����0:�������� 1����ѯ���� 2���ڼ�����¼��ʼ 3���ڼ�����¼����
            string pageSql = "WITH TempDB AS (SELECT PCH,row_number() OVER (ORDER BY {0} DESC) AS RowNumber FROM [WMS_Bms_Inv_OutInfo] {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pageSql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
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
        public static int GetAllPCHPageCount(string pch, int pageSize, out int allCount)
        {
            string strSql = "select count(*) from (SELECT PCH FROM WMS_Bms_Inv_OutInfo where PCH like '%" + pch + "%' group by pch) a";
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

        /// <summary>
        /// ��ȡ������ϸ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPCHDetail(string pch)
        {
            string strSql = "SELECT * FROM [WMS_Bms_Inv_OutInfo] where PCH = '" + pch + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ���ݻ�Ǩ
        /// </summary>
        /// <param name="strPCH"></param>
        /// <returns></returns>
        public static int DataReturn(string strPCH)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PCH", SqlDbType.VarChar)};
            parameters[0].Value = strPCH;
            AdoHelper dataHelp = new SqlHelp();
            return dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, "wms_dts_DataReturn", parameters);
        }
    }
}
