using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.ReportBll
{
    public class FYDList
    {
        /// <summary>
        /// ��ҳ��ѯ���˵���Ϣ
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="pageSize">ÿҳ������</param>
        /// <param name="pageNum">��ǰ��ʾ��Ϊ�ڼ�ҳ</param>
        /// <returns></returns>
        public static DataSet QueryFYQD(string strWhere, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = " WHERE ((status=2) or (status=3))";
            string oKey = "FYDH";
            int pSize = 20;
            int pNum = 1;
            //����0:�������� 1����ѯ���� 2���ڼ�����¼��ʼ 3���ڼ�����¼����
            string pageSql = "WITH TempDB AS (select *,(select top 1 KHName from WMS_Pub_Customer where KHID=KHBM) AS khname,row_number() OVER (ORDER BY {0}) AS RowNumber FROM WMS_Bms_Pic_FYD {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sWhere+= " AND " + strWhere;
            }
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
        public static int GetPageCount(string strWhere, int pageSize, out int allCount)
        {
            string sqlWhere = "WHERE ((status=2) or (status=3))";
            string strSql = "SELECT count(*) from WMS_Bms_Pic_FYD {0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " AND " + strWhere;
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

        /// <summary>
        /// ��ѯ���˵���ϸ
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetFYDDetail(string strFyd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pch,ph,gg,count(barcode) as sl,sum(zl) as zl from wms_bms_inv_outinfo");
            if (!string.IsNullOrEmpty(strFyd))
                strSql.Append(" where fydh='" + strFyd + "' group by pch,ph,gg");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
    }
}
