using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;
//货位规则
namespace ACCTRUE.WMSBLL.Model
{
    public class HWGZ
    {
        public static DataSet GetHWGZList()
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "select *,case PHSET when 0 then '无' when 1 then '相同' when 2 then '不同' when 3 then '特定' end as " +
                            " PHSETMS,case GGSET when 0 then '无' when 1 then '相同' when 2 then '不同' when 3 then '特定' end as " +
                            " GGSETMS,case PCHSET when 0 then '无' when 1 then '相同' when 2 then '不同' when 3 then '特定' end as " +
                            " PCHSETMS,case SXSET when 0 then '无' when 1 then '相同' when 2 then '不同' when 3 then '特定' end as " +
                            " SXSETMS,case PCINFOSET when 0 then '无' when 1 then '相同' when 2 then '不同' when 3 then '特定' end as " +
                            " PCINFOSETMS,case WLHSET when 0 then '无' when 1 then '相同' when 2 then '不同' when 3 then '特定' end as " +
                            " WLHSETMS from WMS_PUB_HWSET order by yxj";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;

        }
        public static string SaveHWSet(string fid,string PHSET,string PH,string GGSET,string GG,string PCHSET,string PCH,string SXSET,string SX,string PCINFOSET,string PCINFO,string WLHSET,string WLH,string YX,string YXJ)
        {
            string ret = "";
            string sqlstr = "";
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();

            if (fid != "")//修改
            {
                sqlstr = "update WMS_PUB_HWSET set PHSET='" + PHSET + "',PH='" + PH + "',GGSET='" + GGSET + "',GG='" + GG + "',PCHSET='" + PCHSET + "',PCH='" + PCH +
                    "',SXSET='" + SXSET + "',SX='" + SX + "',YX='" + YX + "',PCINFOSET='"+PCINFOSET+"',PCINFO='"+PCINFO+"',WLHSET='"+WLHSET+"',WLH='"+WLH+"',YXJ="+YXJ+"  where fid=" + fid;
                ret = fid;
            }
            else//新增
            {
                sqlstr = "insert into WMS_PUB_HWSET(PHSET,PH,GGSET,GG,PCHSET,PCH,SXSET,SX,PCINFOSET,PCINFO,WLHSET,WLH,YX,YXJ) values('" + PHSET + "','" + PH + "','" + GGSET + "','" + GG + "','" + PCHSET +
                    "','"+PCH+"','"+SXSET+"','"+SX+"','"+PCINFOSET+"','"+PCINFO+"','"+WLHSET+"','"+WLH+"','"+YX+"',"+YXJ+")";   
            }
            try
            {
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (fid == "")
                {
                    ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, "select max(fid) as fid from WMS_PUB_HWSET");
                    ret = ds.Tables[0].Rows[0]["fid"].ToString();
                }
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }

            return ret;
        }
        public static string DeleteHWSET(string fid)
        {
            string ret = "";
            string sqlstr = "";
            AdoHelper helper = new SqlHelp();
            sqlstr = "delete from WMS_PUB_HWSET where fid=" + fid;
            try
            {
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:"+ex.Message;
            }
            return ret;
        }
    }
}
