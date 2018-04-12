using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.Model
{
    public class HWinfo
    {
        public HWinfo()
        { }
        public HWinfo(string ck,string hwid,int hwcolumn,int hwrow,string hwbz)
		{
            this._ck = ck;
            this._hwid = hwid;
            this._hwcolumn = hwcolumn;
            this._hwrow = hwrow;
            this._hwbz = hwbz;
        }
        #region Model
        private string _ck;
        private string _hwid;
        private int _hwcolumn;
        private int _hwrow;
        private string _hwbz;
        /// <summary>
        /// 
        /// </summary>
        public string CK
        {
            set { _ck = value; }
            get { return _ck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HWID
        {
            set { _hwid = value; }
            get { return _hwid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HWColumn
        {
            set { _hwcolumn = value; }
            get { return _hwcolumn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HWRow
        {
            set { _hwrow = value; }
            get { return _hwrow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HWBZ
        {
            set { _hwbz = value; }
            get { return _hwbz; }
        }
        #endregion Model
        /// <summary>
        /// 获得货位数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_HW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where CK=" + strWhere);
            }
            AdoHelper adohelp = new SqlHelp();
            DataSet ds=adohelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        /// <summary>
        /// 获取货位信息
        /// </summary>
        /// <param name="ck">仓库</param>
        /// <param name="sRow">开始行</param>
        /// <param name="eRow">结束行</param>
        /// <param name="sCol">开始列</param>
        /// <param name="tCol">结束列</param>
        /// <returns></returns>
        public static DataSet GetHWID(string ck, string sRow, string eRow, string sCol, string tCol)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_HW ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(ck))
            {
                strSql.Append(" and CK='" + ck+"'");
            }
            if (!string.IsNullOrEmpty(sRow))
            {
                strSql.Append(" and hwrow>=" +sRow);
            }
            if (!string.IsNullOrEmpty(eRow))
            {
                strSql.Append(" and hwrow<=" + eRow);
            }
            if (!string.IsNullOrEmpty(sCol))
            {
                strSql.Append(" and hwcolumn>=" + sCol);
            }
            if (!string.IsNullOrEmpty(tCol))
            {
                strSql.Append(" and hwcolumn<=" + tCol);
            }
            strSql.Append(" order by HWID");
            AdoHelper adohelp = new SqlHelp();
            DataSet ds = adohelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        /// <summary>
        /// 增加一个货位
        /// </summary>
        public void Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_Pub_HW(");
			strSql.Append("CK,HWID,HWColumn,HWRow,HWBZ)");
			strSql.Append(" values (");
			strSql.Append("@CK,@HWID,@HWColumn,@HWRow,@HWBZ)");
			SqlParameter[] parameters = {
					new SqlParameter("@CK", SqlDbType.VarChar),
					new SqlParameter("@HWID", SqlDbType.VarChar),
					new SqlParameter("@HWColumn", SqlDbType.Int),
					new SqlParameter("@HWRow", SqlDbType.Int),
					new SqlParameter("@HWBZ", SqlDbType.VarChar)};
			parameters[0].Value = this.CK;
			parameters[1].Value = this.HWID;
			parameters[2].Value = this.HWColumn;
			parameters[3].Value = this.HWRow;
			parameters[4].Value = this.HWBZ;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}
		/// <summary>
		/// 删除一条货位数据
		/// </summary>
		public void Delete(string CK,string HWID)
		{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("delete WMS_Pub_HW ");
				strSql.Append(" where CK='"+CK+"'and HWID='"+HWID+"'");
                AdoHelper DbHelperSQL = new SqlHelp();
                DbHelperSQL.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString());
		}
        /// <summary>
        /// 货位编号是否存在
        /// </summary>
        public bool Exists(string HWID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WMS_Pub_HW where HWID='" + HWID + "'");
            AdoHelper dataHelp = new SqlHelp();
            Object obj = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString());
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
        /// 获得货位的个数
        /// </summary>
        public int GetSumId(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(HWID) from WMS_Pub_HW");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where CK=" + strWhere);
            }
            AdoHelper DbhelperSQL = new SqlHelp();
            object obj = DbhelperSQL.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
		
    }
}
