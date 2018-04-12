using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ACCTRUE.WMSBLL.QueryBll;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.QueryBll
{
    public class HWViewQuery
    {
        /// <summary>
        /// ªÒ»°ø‚¥Ê
        /// </summary>
        /// <param name="ck"></param>
        /// <param name="minRow"></param>
        /// <param name="maxRow"></param>
        /// <param name="minCol"></param>
        /// <param name="maxCol"></param>
        /// <returns></returns>
        public static DataSet GetHWView(string ck, int minRow, int maxRow, int minCol, int maxCol)
        {
            StringBuilder sqlSB=new StringBuilder();
            sqlSB.Append("select wms_pub_hw.ck,hwid,hwcolumn,hwrow,pch,sx,ph,gg,js,DATEDIFF(dd, klrq, GETDATE()) as kl from wms_pub_hw left join ");
            sqlSB.Append("(select ck,hw,pch,sx,ph,gg,count(*) as js,min(WeightRQ) as klrq from wms_bms_inv_info where ck='");
            sqlSB.Append(ck);
            sqlSB.Append("' group by ck,hw,pch,sx,ph,gg ) t on wms_pub_hw.ck=t.ck and wms_pub_hw.hwid=t.hw ");
            sqlSB.Append("where wms_pub_hw.ck='");
            sqlSB.Append(ck);
            sqlSB.Append("' and hwrow>=");
            sqlSB.Append(minRow.ToString());
            sqlSB.Append(" and hwrow<=");
            sqlSB.Append(maxRow.ToString());
            sqlSB.Append(" and HWColumn>=");
            sqlSB.Append(minCol.ToString());
            sqlSB.Append(" and HWColumn<=");
            sqlSB.Append(maxCol.ToString());
            sqlSB.Append(" order by hwcolumn,hwrow");
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlSB.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }

    }
}
