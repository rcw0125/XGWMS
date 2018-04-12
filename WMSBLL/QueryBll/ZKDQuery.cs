using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class ZKDQuery
    {
         public ZKDQuery()
		{}
        public ZKDQuery(string ZKDH, string PCH, string SX)
        {
         
         this._ZKDH = ZKDH;
         this._PCH = PCH;
         this._SX = SX;
        }

        private string _ZKDH;
        private string _PCH;
        private string _SX;
        /// <summary>
        /// 
        /// </summary>
        public string ZKDH
        {
            set { _ZKDH = value; }
            get { return _ZKDH; }
        }
            public string PCH
            {
                set{_PCH=value;}
                get{return _PCH;}
            }
            public string SX
            {
                set{_SX=value;}
                get{return _SX;}
            }
       
        	
        /// <summary>
        /// ��ȡת�ⵥ��
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDID()
        {
            string strSql = "select distinct TOP 1000 ZKDH  from WMS_Bms_Tra_ZKD  order by ZKDH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ���κ�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetPCHID()
        {
            string strSql = "select distinct TOP 1000 pch  from WMS_Bms_Tra_ZKD_Detail  order by pch";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ�ֿ�ID
        /// </summary>
        /// <returns></returns>
        public static DataSet GetCKID()
        {
            string strSql = "select CKID from WMS_Pub_Store order by CKID";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ���Ϻ�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetWLHID()
        {
            string strSql = "select distinct TOP 1000 wlh  from WMS_Bms_Tra_ZKD  order by wlh";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDSX()
        {
            string strSql = "select distinct TOP 1000 sx  from WMS_Bms_Tra_ZKD  order by sx";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ�ƺ�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDPH()
        {
            string strSql = "select distinct TOP 1000 ph  from WMS_Bms_Tra_ZKD  order by ph";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ���
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDGG()
        {
            string strSql = "select distinct TOP 1000 gg  from WMS_Bms_Tra_ZKD  order by gg";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡ���ƺ�
        /// </summary>
        /// <returns></returns>
        public static DataSet GetZKDCPH()
        {
            string strSql = "select distinct TOP 1000 CPH  from WMS_Bms_Tra_ZKD_Detail  order by CPH";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        /// <summary>
        /// ��ȡת�ⵥ��ϸ
        /// </summary>
        /// <param name="strWGDH"></param>
        /// <returns></returns>
        public static DataSet GetZKDItems(string strZKDH)
        {
            string sqlPCH = "SELECT * FROM WMS_Bms_Tra_ZKD_Detail WHERE ZKDH='" + strZKDH + "' order by zkdh";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
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
            string strSql = "SELECT count(*) from VIEW_ZKD_Total_CPH{0}";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlWhere += " WHERE " + strWhere;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetQueryZKD(string Sql_ZKD, string orderKey, int pageSize, int pageNum)
        {
            string sWhere = "";
            string oKey = "ZKDH";
            int pSize = 20;
            int pNum = 1;
              //����0:�������� 1����ѯ���� 2���ڼ�����¼��ʼ 3���ڼ�����¼����
            string pagesql = "WITH TempDB AS (select *,case status when 0 then 'δת��' else 'ת�����' end as desc_status,case outstatus when 0 then 'δת��' else 'ת�����' end as desc_outstatus,case zhxlb when 0 then '����ת��' when 1 then '����ת��' else 'δת��' end as desc_zhxlb,row_number() OVER (ORDER BY {0}) AS RowNumber from VIEW_ZKD_Total_CPH{1}) SELECT * FROM TempDB WHERE RowNumber BETWEEN {2} and {3}";
          if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                sWhere = " Where " + Sql_ZKD;
            }
            if (!string.IsNullOrEmpty(orderKey))
                oKey = orderKey;
            if (pageSize > 0)
                pSize = pageSize;
            if (pageNum > 0)
                pNum = pageNum;
            string sqlStr = string.Format(pagesql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text,sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        
        }

        /// <summary>
        /// ����EXCELʱ�Ĳ�ѯ���
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet QueryZKDExcel(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select ZKDH AS ת�ⵥ��,cph AS ���ƺ�,pch as ����,wlh as ���Ϻ�");
            sbSql.Append(",SX as ����,substring(YHW,1,3) as ԭ�ֿ�,YHW as ԭ��λ,substring(MBHW,1,3) as Ŀ�Ĳֿ�");
            sbSql.Append(",MBHW AS Ŀ���λ, FJLDW AS ��������λ");
            sbSql.Append(",ZJLDW AS ��������λ,JHSL AS �ƻ�����");
            sbSql.Append(",OutNum as ����ת���ܼ�,OutZL as ����ת���ܼ�,InNum as ת������ܼ�,SL as ��������,ZL as ��������");
            //sbSql.Append(",OutNum as ����(ת���ܼ�));
            sbSql.Append(",case zhxlb when 0 then '����ת��' when 1 then '����ת��' else 'δת��' end as ת�����");
            sbSql.Append(",case outstatus when 0 then 'δת��' else 'ת�����' end as ת��״̬");
            sbSql.Append(",CKOperator as �������,CKTime as ת��ʱ��");
            sbSql.Append(",case status when 0 then 'δת��' else 'ת�����'end as ת��״̬");
            sbSql.Append(",RKOperator as ������,RKTime as ת��ʱ��,WLMC as �������� from VIEW_ZKD_Total_CPH");
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
        /// ����һ��������Ϣ
        /// </summary>
        public void UpdteZKD(string zhdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WMS_Bms_Tra_ZKD set status=1,outstatus=1");
            strSql.Append(" where zkdh='" + zhdh + "'");
            AdoHelper DbHelperSQL = new SqlHelp();
            DbHelperSQL.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
        }
        public int execZKD()
        {
            string strSql = "ZKD_Reset";
            SqlParameter[] parameters = {
					new SqlParameter("@ZKDH", SqlDbType.VarChar),
					new SqlParameter("@PCH", SqlDbType.VarChar),
					new SqlParameter("@SX", SqlDbType.VarChar),
                    new SqlParameter("@return_value",SqlDbType.Int)};
            parameters[0].Value = this.ZKDH; ;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = this.PCH;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = this.SX;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Direction = ParameterDirection.ReturnValue;
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, strSql, parameters);
            result = parameters[3].Value;
            return Convert.ToInt32(result);
        
        }
        public static int chongzhiZKD(string zkdh, string pch, string sx)
        {
            string strSql = "ZKD_Reset";
            SqlParameter[] parameters = {
              		new SqlParameter("@ZKDH", SqlDbType.VarChar),
					new SqlParameter("@PCH", SqlDbType.VarChar),
					new SqlParameter("@SX", SqlDbType.VarChar),
                    new SqlParameter("@return_value",SqlDbType.Int)};

            parameters[0].Value = zkdh;
            parameters[0].Direction = ParameterDirection.Input;
            parameters[1].Value = pch;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[2].Value = sx;
            parameters[2].Direction = ParameterDirection.Input;
            parameters[3].Direction = ParameterDirection.ReturnValue;

            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.StoredProcedure, strSql, parameters);
            result = parameters[3].Value;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// �õ�����ִ�е�ת�ⵥ��Ŀ
        /// </summary>
        /// <returns>����</returns>
        public static int GetExeZKDCount()
        {
            string strSql = "SELECT count(*) FROM WMS_Bms_Tra_ZKD where status<>1 or outstatus<>1";
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (result != null)
                return Convert.ToInt32(result);
            return 0;
        }
        /// <summary>
        /// �õ�����
        /// </summary>
        /// <returns>����</returns>
        public static int GetCKDSL(string col, string sqlwhere)
        {
            AdoHelper dataHelp = new SqlHelp();
            string strSql = "SELECT sum(" + col + ") from VIEW_ZKD_Total_CPH";
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where " + sqlwhere;
            }
            strSql = string.Format(strSql, sqlwhere);
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (!string.IsNullOrEmpty(result.ToString()))
                return Convert.ToInt32(result);
            return 0;
        }
        /// <summary>
        /// �õ�����
        /// </summary>
        /// <returns>����</returns>
        public static double GetCKDZL(string col, string sqlwhere)
        {
            string strSql = "SELECT sum(" + col + ") from VIEW_ZKD_Total_CPH";
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                strSql += " where " + sqlwhere;
            }
            strSql = string.Format(strSql, sqlwhere);
            AdoHelper dataHelp = new SqlHelp();
            Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
            if (!string.IsNullOrEmpty(result.ToString()))
                return Convert.ToDouble(result);
            return 0;
        }
    }
}
