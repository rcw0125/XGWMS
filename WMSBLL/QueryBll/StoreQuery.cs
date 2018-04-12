using System;
using System.Collections.Generic;
using System.Text;
using Acctrue.WM_WES.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class StoreQuery
    {
        /// <summary>
        /// 获取批次号
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public static  DataSet GetPCH(string storeId)
        {
            string sqlPCH = "select distinct PCH  from VIEW_RP_KCMX WHERE CK='"+storeId+"'" +" ORDER by PCH DESC";
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlPCH);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
    }
}
