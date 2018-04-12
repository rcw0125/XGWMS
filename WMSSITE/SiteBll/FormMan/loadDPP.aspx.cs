using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ACCTRUE.WMSBLL.QueryBll;
using System.Xml;
public partial class SiteBll_FormMan_loadDPP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string type = "";
            if (Request["TYPE"] == null)
            {
                return;
            }
            type = Request["TYPE"];
            switch (type)
            {
                case "1"://获取仓库
                    DataSet ds = null;
                    try
                    {
                        ds = DPPQuery.GetCKHID(); 
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "2"://物料号
                    DataSet ds2 = null;
                    try
                    {

                        ds2 = DPPQuery.GetWLHID();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds2 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds2.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "3"://货位
                    DataSet ds3 = null;
                    try
                    {
                        string strck="";
                        if(!string.IsNullOrEmpty(Request.QueryString["ckid"]))
                        {
                            strck=Request.QueryString["ckid"];
                        }

                        ds3 = DPPQuery.GetHWID(strck);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds3 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds3.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "4":
                    DataSet ds4 = null;
                    try
                    {
                        ds4 = DPPQuery.GetPCHID();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds4 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds4.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "5":
                    DataSet ds5 = null;
                    try
                    {
                        ds5 = DPPQuery.GetSX();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds5 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds5.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "6":
                    DataSet ds6 = null;
                    try
                    {
                        ds6 = DPPQuery.GetPH();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds6 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds6.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "7":
                    DataSet ds7 = null;
                    try
                    {
                        ds7 = DPPQuery.GetGG();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds7 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds7.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "8":
                    DataSet ds8 = null;
                    try
                    {
                        string sqlstr = "";
                        if (!string.IsNullOrEmpty(Request.QueryString["ckh"]))
                        {
                            sqlstr += " and ck='" + Request.QueryString["ckh"]+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["pch"]))
                        {
                            sqlstr += " and pch='" + Request.QueryString["pch"]+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["sx"]))
                        {
                            sqlstr += " and sx='" + Request.QueryString["sx"]+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["wlh"]))
                        {
                            sqlstr += " and wlh='" + Request.QueryString["wlh"]+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["hw"]))
                        {
                            sqlstr += " and hw='" + Request.QueryString["hw"]+"'";
                        }
                        ds8 = DPPQuery.GetTSXX(sqlstr);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds8 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds8.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                
            }
        }
    }
}
