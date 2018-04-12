using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class ZLYY
    {
        public static DataSet GetZLYY(string sqlstrf)
        {
            string sqlstr = "select * from WMS_PUB_SX_HPReason where 1=1 "+sqlstrf+" order by Reason";
            AdoHelper helper = new SqlHelp();
            DataSet ds = null;
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;
        }
        public static DataSet GetGPZLYY(string sqlstrf)
        {
            string sqlstr = "select * from WMS_PUB_SX_GPReason where 1=1 " + sqlstrf + " order by Reason";
            AdoHelper helper = new SqlHelp();
            DataSet ds = null;
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;
        }
        public static string SaveSXZLYY(string sx, string reason,string ysx,string yreason)
        {
            string sqlstr = "";
            string ret = ""; 
            AdoHelper helper = new SqlHelp();
            try
            {
                sqlstr = "delete from WMS_PUB_SX_HPReason where sx='"+ysx+"' and reason='"+yreason+"'";
                helper.ExecuteNonQuery(Common.GetConnectString(),CommandType.Text,sqlstr);
                sqlstr = "insert into WMS_PUB_SX_HPReason(sx,reason)values('"+sx+"','"+reason+"')";
                helper.ExecuteNonQuery(Common.GetConnectString(),CommandType.Text,sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }
            return ret;
        }
        public static string saveGPZLYY(string reason,string yzlyy)
        {
            string sqlstr = "";
            string ret = "";
            AdoHelper helper = new SqlHelp();
            try
            {
                sqlstr = "delete from WMS_PUB_SX_GPReason where reason='" + yzlyy + "'";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                sqlstr = "insert into WMS_PUB_SX_GPReason(reason)values('" + reason + "')";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }
            return ret;
        }
        public static string delSXZLYY(string sx, string reason)
        {
            string sqlstr = "";
            string ret = "";
            AdoHelper helper = new SqlHelp();
            try
            {
                sqlstr = "delete from WMS_PUB_SX_HPReason where sx='" + sx + "' and reason='" + reason + "'";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
            }
            catch (Exception ex)
            {
                ret = "ERROR:" + ex.Message;
            }
            return ret;
        }
        public static string delGPZLYY(string reason)
        {
            string sqlstr = "";
            string ret = "";
            AdoHelper helper = new SqlHelp();
            try
            {
                sqlstr = "delete from WMS_PUB_SX_GPReason where reason='" + reason + "'";
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
