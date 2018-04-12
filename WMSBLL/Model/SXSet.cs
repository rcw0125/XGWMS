using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class SXSet
    {
        public static DataSet GetSXList(string sqlstrf)
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "select * from WMS_PUB_SXSET where 1=1 "+sqlstrf+" order by sx";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;

        }
        public static string SaveSXSet(string sx, string sxname,string isbatch,string isDefaultDJ,string isKN)
        {
            string ret = "";
            try
            {
                string sqlstr = "delete from WMS_PUB_SXSET where sx='" + sx + "'";
                AdoHelper helper = new SqlHelp();
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                sqlstr = "insert into WMS_PUB_SXSET(SX,SXName,ISBATCH,ISDEFAULTDJ,ISKN) values('" + sx + "','" + sxname + "','" + isbatch + "','"+isDefaultDJ+"','"+isKN+"')";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }
            return ret;
        }
        public static string DeleteSxSet(string sx)
        {
            string ret = "";
            try
            {
                string sqlstr = "delete from WMS_PUB_SXSET where sx='" + sx + "'";
                AdoHelper helper = new SqlHelp();
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }
            return ret;
        }

        public static DataSet GetCZSXList(string sqlstrf)
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "select * from WMS_PUB_CZSX where 1=1 " + sqlstrf + " order by PCSX,ORDERNUM";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;

        }

        public static string SaveSXSetCZ(string pcsx, string mrdj, string dj,string orderNum)
        {
            string ret = "";
            try
            {
                string sqlstr = "delete from WMS_PUB_CZSX where PCSX='" + pcsx + "' and DJSX='"+dj+"' and MRDJSX='"+mrdj+"'";
                AdoHelper helper = new SqlHelp();
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                sqlstr = "insert into WMS_PUB_CZSX(PCSX,DJSX,ORDERNUM,MRDJSX) values('" + pcsx + "','" + dj + "'," + orderNum + ",'" + mrdj + "')";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }
            return ret;
        }


        public static string DeleteSxSetCZ(string pcsx,string mrdj,string dj)
        {
            string ret = "";
            try
            {
                string sqlstr = "delete from WMS_PUB_CZSX where pcsx='" + pcsx + "' and DJSX='" + dj + "' and MRDJSX='" + mrdj + "'";
                AdoHelper helper = new SqlHelp();
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }
            return ret;
        }

    }
}
