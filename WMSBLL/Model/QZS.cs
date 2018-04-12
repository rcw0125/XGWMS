using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class QZS
    {
        public static DataSet getqzslist()
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "";
            sqlstr = "select * from wms_pub_qzs order by qzs_no";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            return ds;
        }
        public static DataSet getqzsinfo()
        {
            DataSet ds = null;
            AdoHelper helper = new SqlHelp();
            string sqlstr = "";
            sqlstr = "select * from wms_pub_qzs   order by qzs_no";
            ds = helper.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlstr);
            
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            return null;
        }
        public static string Saveqzs(string hdoorno,string doorno, string doorname,string ip,string port)
        {
            AdoHelper helper = new SqlHelp();
            string sqlstr = "";
            try
            {
                sqlstr = "delete from wms_pub_qzs where qzs_no='" + hdoorno + "'";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                if (port.Trim()=="")
                {
                    port = "0";
                }
                sqlstr = "insert into wms_pub_qzs(qzs_no,qzs_name,serverip,port) values('" + doorno + "','" + doorname + "','"+ip+"',"+port+")";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                return "";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

        }
        public static bool saveqzscamer(string doorno, string dc_no, string dc_name, string dc_ip, string dc_port)
        {
            AdoHelper helper = new SqlHelp();
            string sqlstr = "";
            try
            {
                sqlstr = "delete from wms_pub_qzs_camer where qc_no='" + dc_no + "'";
                helper.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, sqlstr);
                sqlstr = "insert into wms_pub_qzs_camer(qc_qzsno,qc_name,qc_ip,qc_port) values('" + doorno +
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
