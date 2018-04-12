using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class WGDQuery
    {
        /// <summary>
        /// ��ȡ���κŵĲ�ѯ����
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPCHTerm()
        {
            string sqlPCH = "select distinct TOP 1000 PCH  from WMS_Bms_Rec_WGD order by PCH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ������Ϣ��ѯ����
        /// </summary>
        /// <param name="pch"></param>
        /// <returns></returns>
        public static DataSet GetPCInfo(string pch)
        {
            string sqlPCInfo = "select distinct pcinfo from WMS_Bms_Rec_WGD";
            if (!string.IsNullOrEmpty(pch))
            {
                sqlPCInfo += " WHERE pch='" + pch + "'";
            }
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCInfo);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ�������ԵĲ�ѯ����
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPCSX()
        {
            string sqlPCH = "select Distinct PCSX  from WMS_Bms_Rec_WGD order by PCSX";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ���ϺŵĲ�ѯ����
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWLH()
        {
            string sqlPCH = "select distinct TOP 1000 WLH  from WMS_Bms_Rec_WGD order by WLH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSCX()
        {
            string sqlPCH = "select Distinct SCXBM,SCXName  from WMS_Pub_SCX order by SCXBM";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ�ƺ�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPH()
        {
            string sqlPCH = "select distinct TOP 1000 PH  from WMS_Bms_Rec_WGD order by PH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ���
        /// </summary>
        /// <returns></returns>
        public static DataSet GetGG()
        {
            string sqlPCH = "select distinct TOP 1000 GG  from WMS_Bms_Rec_WGD order by GG DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ�깤����
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWGDH()
        {
            string sqlPCH = "select distinct top 1000 WGDH  from WMS_Bms_Rec_WGD order by WGDH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ�ʼ���
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZJR()
        {
            string sqlPCH = "SELECT distinct a.NCWLBMID,B.USERNAME,a.NCWLBMID+'|'+B.USERNAME AS ZJR FROM WMS_Bms_Rec_WGD a , WMS_PUB_USERS B where ncwlbmid  is not NULL AND A.NCWLBMID =B.USERid ORDER BY B.USERnAME";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ͨ�������߱����ȡ������ID
        /// </summary>
        /// <param name="scxbm">�����߱���</param>
        /// <returns></returns>
        public static string GetSCXID(string scxbm)
        {
            string sql = "select * from WMS_Pub_scx where scxbm='" + scxbm + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["SCXNCID"].ToString();
            return "";
        }
        /// <summary>
        /// ��ҳ��ѯ�깤����Ϣ
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="pageSize">ÿҳ������</param>
        /// <param name="pageNum">��ǰ��ʾ��Ϊ�ڼ�ҳ</param>
        /// <returns></returns>
        public static DataSet QueryWGD(string strWhere,string orderKey,int pageSize,int pageNum)
        {
            string sWhere = "";
            string oKey = "WGDH";
            int pSize = 20;
            int pNum = 1;
            //����0:�������� 1����ѯ���� 2���ڼ�����¼��ʼ 3���ڼ�����¼����
            string pageSql = "WITH TempDB AS (SELECT a.*,case a.pclx when 0 then '��ͨ�߲�' else '�����߲�' end as Desc_pclx,case a.wcbz when 0 then 'δִ��' when 1 then '���ڴ���' when 2 then '�������'else '������'end as Desc_wcbz,b.scxbm as Scxbm,row_number() OVER (ORDER BY {0}) AS RowNumber FROM wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid {1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sWhere = " Where " + strWhere;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pageSql, oKey,sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text,sqlStr.ToString());
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
        public static int GetPageCount(string strWhere,int pageSize, out int allCount)
        {
            string sqlWhere = "";
            string strSql = "SELECT count(*) from wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid {0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE " + strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text,strSql);
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
        /// �õ��ܹ���
        /// </summary>
        /// <param name="strWhere">��ѯ����������WHERE</param>
        /// <returns>�ܹ���</returns>
        public static int GetPaoGouCount(string strWhere)
        {
            string sqlWhere = "";
            string strSql = "SELECT sum(a.PGBZ) from wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid {0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE " + strWhere;
            }
            strSql = string.Format(strSql, sqlWhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        /// <summary>
        /// �����깤���Ż�ȡ�깤����ϸ
        /// </summary>
        /// <param name="strWGDH"></param>
        /// <returns></returns>
        public static DataSet GetWGDItems(string strWGDH)
        {
            string sqlPCH = "SELECT * FROM WMS_Bms_Rec_WGD_Item WHERE WGDH='"+strWGDH+"'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// �����깤���Ż�ȡ�깤����Ϣ
        /// </summary>
        /// <param name="strWGDH"></param>
        /// <returns></returns>
        public static DataSet GetWGDInfo(string strWGDH)
        {
            string sqlPCH = "select * from WMS_Bms_Rec_WGD where wgdh='" + strWGDH + "'";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ����EXCELʱ�Ĳ�ѯ���
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet QueryWGDExcel(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select a.WGDH AS �깤����,b.scxbm AS ������,a.PCH AS ����,a.PCSX AS ��������");
            sbSql.Append(",a.pcinfo AS ������Ϣ,case a.pclx when 0 then '��ͨ�߲�' else '�����߲�' end as �������� ");
            sbSql.Append(",a.PH AS �ƺ�,a.GG AS ���,a.WLH AS ���Ϻ�,a.WLMC AS �������� ");
            sbSql.Append(",a.ZXBZ AS ִ�б�׼,a.FZDW AS ������λ");
            sbSql.Append(",a.PCXH AS ���,a.ZJBZ AS �ʼ��־");
            sbSql.Append(",a.PGBZ as �ܹ���Ŀ,a.Rev_Time AS ����ʱ��,a.PEnd_Time AS �������ʱ��");
            sbSql.Append(",a.End_Time as ������ʱ��,case a.wcbz when 0 then 'δִ��' when 1 then '���ڴ���' when 2 then '�������'else '������'end as ����״̬");
            sbSql.Append(",a.BB AS ��� from wms_bms_rec_wgd a left outer join wms_pub_scx b on a.scx=b.scxncid");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sbSql.Append(" WHERE ");
                sbSql.Append(strWhere);
            }
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sbSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

        /// <summary>
        /// �õ�����ִ�е������깤����Ŀ
        /// </summary>
        /// <returns>����</returns>
        public static int GetExeWGDCount()
        {
            string strSql = "SELECT count(*) FROM WMS_Bms_Rec_WGD where wcbz<3";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
                return Convert.ToInt32(result);
            return 0;
        }
    }
}
