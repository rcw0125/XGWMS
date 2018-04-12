using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Web.Caching;
using System.Web;

namespace ACCTRUE.WMSBLL.ReportBll
{
    public class WorkLoadQ
    {
        //获取操作类型
        public static DataSet GetOperType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct opetype from wms_pub_workload");
            AdoHelper adohlp = new SqlHelp();
            DataSet ds = adohlp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
    }
}
