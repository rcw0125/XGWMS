using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using System.IO.Ports;
using System.Drawing;
using Lephone.Data;
using System.Data;

namespace WeightApp
{
    public class Public
    {
        public static string userno = "";
        public static string usermangno = "";
        public static string userdd = "";
        public static bool ismanager = false;


        public static bool getWeightManageAuthority(string username, string aut)
        {
            string sqlstr = "";
            sqlstr = "select " + aut + " from WMS_Bms_Rec_WGD_Manage where username='" + username + "'";
            DataSet ds = null;

            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!Convert.ToBoolean(ds.Tables[0].Rows[0][aut]))
                {
                    return false;
                }
                else return true;
            }
            else return false;
        }

        public static void ShowFlash()
        {
            SplashObject SplashObj;
            SplashObj = SplashObject.GetSplash();
            Thread.Sleep(3000);
            SplashObj.Dispose();
        }

        public static string GetXmlValue(string NodeName)
        {
            XmlDocument xmldoc = new XmlDocument();
            string xmlpath = "config.xml";
            xmldoc.Load(xmlpath);
            XmlNode nd = xmldoc.DocumentElement.SelectSingleNode(NodeName);
            if (nd == null)
                return "";
            return nd.InnerText;
        }
        
        public static void SetXmlValue(string NodeName, string value)
        {
            XmlDocument xmldoc = new XmlDocument();
            string xmlpath = "config.xml";
            xmldoc.Load(xmlpath);
            XmlNode nd = xmldoc.DocumentElement.SelectSingleNode(NodeName);
            nd.InnerText = value;
            xmldoc.Save(xmlpath);
        }
        public static string GetXmlNodeAttr(string NodeName, string AttrName)
        {
            XmlDocument xmldoc = new XmlDocument();
            string xmlpath = "config.xml";
            xmldoc.Load(xmlpath);
            XmlNode nd = xmldoc.DocumentElement.SelectSingleNode(NodeName);
            return nd.Attributes[AttrName].Value;
        }
        public static void SetXmlNodeAttr(string NodeName, string AttrName,string AttrValue)
        {
            XmlDocument xmldoc = new XmlDocument();
            string xmlpath = "config.xml";
            xmldoc.Load(xmlpath);
            XmlNode nd = xmldoc.DocumentElement.SelectSingleNode(NodeName);
            nd.Attributes[AttrName].Value = AttrValue;
            xmldoc.Save(xmlpath);
        }
        public static Boolean openCom(SerialPort s)
        {
            if (s.IsOpen) s.Close();
            try
            {
                s.PortName = GetXmlValue("port");
                s.StopBits = (StopBits)Enum.Parse(typeof(StopBits), GetXmlValue("StopBits"));
                s.BaudRate = int.Parse(GetXmlValue("baudrate"));
                s.DataBits = int.Parse(GetXmlValue("ByteSize"));
                s.Parity = (Parity)Enum.Parse(typeof(Parity), GetXmlValue("Parity"));
                if (GetXmlNodeAttr("HandShake", "isuse") == "Y")
                    s.Handshake = (Handshake)Enum.Parse(typeof(Handshake), GetXmlValue("HandShake"));
                if (GetXmlNodeAttr("RtsEnable", "isuse") == "Y")
                    s.RtsEnable = Boolean.Parse(GetXmlValue("RtsEnable"));
                if (GetXmlNodeAttr("DtrEnable", "isuse") == "Y")
                    s.DtrEnable = Boolean.Parse(GetXmlValue("DtrEnable"));

                //int v = int.Parse(GetXmlValue("DataLen"));
                //s.ReceivedBytesThreshold = v;
                s.Open();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }

        public static void SetLampStatus(bool connected, LFY.UI.Controls.Glass.GlassLamp lamp)
        {
            if (connected)
            {
                lamp.Error = true;
                lamp.ErrorEx = true;
                lamp.DisabledGradient.Top = Color.Green;
                lamp.DisabledGradient.Bottom = Color.Green;
            }
            else
            {
                lamp.Error = false;
                lamp.ErrorEx = false;
                lamp.DisabledGradient.Top = Color.White;
                lamp.DisabledGradient.Bottom = Color.White;
            }
        }

        public static string getWMSParam(string ParamName)
        {
            string sqlstr = "select * from WMS_Pub_Param where CS_Name='"+ParamName+"'";
            DataSet ds = DbEntry.Context.ExecuteDataset(sqlstr);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["CS_VALUE"].ToString();
            }
            else
                return "";
        }
        public static DataSet GetSCXINfo(string scxid)
        {
            DataSet ds = null;
            string sqlstr = "select * from WMS_Pub_SCX where scxncid='"+scxid+"'";
            ds = DbEntry.Context.ExecuteDataset(sqlstr);
            return ds;
        }

        public static void WriteManLog(string barcode,double zl,string sx,int gh,double yzl,string ysx,int ygh,string opetype,string user)
        {
            string strSql = "insert into WMS_Bms_Rec_WGD_ManageLog(barcode,zl,sx,gh,yzl,ysx,ygh,opetype,oper,opetime) values ('"+
                barcode+"',"+zl.ToString()+",'"+sx+"',"+gh.ToString()+","+yzl.ToString()+",'"+ysx+"',"+ygh.ToString()+",'"+opetype+"','"+user+"',getdate())";
            DbEntry.Context.ExecuteNonQuery(strSql);
        }
    }
}
