using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
   public class SCX
    {
       public SCX()
		{}
        #region Model
        private string _scxncid;
        private string _scxbm;
        private string _scxname;
        private decimal _scxparamrestkg;
        private int _scxparamrests;
        private int _scxparamuptime;
        private bool _scxparamweightdown;
        private bool _weightup;
        private decimal _zerohight;
        private decimal _zerolow;
        private int _autogetweightnum;
        private bool _autogetweightflag;
        /// <summary>
        /// 
        /// </summary>
        public string SCXNCID
        {
            set { _scxncid = value; }
            get { return _scxncid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCXBM
        {
            set { _scxbm = value; }
            get { return _scxbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCXName
        {
            set { _scxname = value; }
            get { return _scxname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SCXParamRestKg
        {
            set { _scxparamrestkg = value; }
            get { return _scxparamrestkg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SCXParamRests
        {
            set { _scxparamrests = value; }
            get { return _scxparamrests; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SCXParamUptime
        {
            set { _scxparamuptime = value; }
            get { return _scxparamuptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SCXParamWeightDown
        {
            set { _scxparamweightdown = value; }
            get { return _scxparamweightdown; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool WeightUp
        {
            set { _weightup = value; }
            get { return _weightup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ZeroHight
        {
            set { _zerohight = value; }
            get { return _zerohight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ZeroLow
        {
            set { _zerolow = value; }
            get { return _zerolow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AutoGetWeightNum
        {
            set { _autogetweightnum = value; }
            get { return _autogetweightnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AutoGetWeightFlag
        {
            set { _autogetweightflag = value; }
            get { return _autogetweightflag; }
        }
        #endregion Model
      

        /// <summary>
        /// 获得生产线
        /// </summary>
       public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ,SCXBM+' | '+SCXName as SCXDESC from WMS_Pub_SCX ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SCXNCID ");
            AdoHelper adoHelp = new SqlHelp();
            DataSet ds = adoHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            return ds;
        }
        
    }
}
