using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;


namespace ACCTRUE.WMSBLL.Model
{
    public class Door
    {
        public static DataSet getdoorlist()
        {
            DataSet ds = null;
            AdoHelper helper=new SqlHelp();
            string sqlstr = "";
            sqlstr = "select * from wms_pub_door order by doorno";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;
        }
        public static DataSet getdoorinfo()
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "";
            sqlstr = "select * from wms_pub_door  order by doorno";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else return null;
        }
        public static bool Savedoor(string hdoorno,string doorno, string doorname,string serverip,string port)
        {
            AdoHelper helper = new SqlHelp();
            string sqlstr = "";
            try
            {
                sqlstr = "delete from wms_pub_door where doorno='" + hdoorno + "'";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (port.Trim()=="")
                {
                    port = "0";
                }
                sqlstr = "insert into wms_pub_door(doorno,doorname,serverip,port) values('"+doorno+"','"+doorname+"','"+serverip+"',"+port.ToString()+")";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
            
        }
        public static bool savedoorcamer(string doorno, string dc_no, string dc_name, string dc_ip, string dc_port)
        {
            AdoHelper helper = new SqlHelp();
            string sqlstr = "";
            try
            {
                sqlstr = "delete from wms_pub_door_camer where dc_no='"+dc_no+"'";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                sqlstr = "insert into wms_pub_door_camer(dc_doorno,dc_name,dc_ip,dc_port) values('" + doorno +
                    "','" + dc_name + "','" + dc_ip + "','" + dc_port + "')";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
