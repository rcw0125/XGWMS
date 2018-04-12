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
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_StockMan_loadKuCun :AccPageBase
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
                        ds = KCQuery.GetCKID();
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
                case "2"://货位
                    DataSet ds2 = null;
                    try
                    {
                        string ck="";
                        if(!string.IsNullOrEmpty(Request.QueryString["ck"]))
                        {
                            ck=Request.QueryString["ck"].ToString();
                        }
                        ds2 = KCQuery.GetKCHW(ck);
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
                case "3"://获取PCH
                    DataSet ds3 = null;
                    try
                    {
                        ds3 = KCQuery.GetKCPCH();
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
                case "4"://获取属性
                    DataSet ds4 = null;
                    try
                    {
                        ds4 = KCQuery.GetKCSX();
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

                case "5"://获取物料号
                    DataSet ds5 = null;
                    try
                    {
                        ds5 = KCQuery.GetKCWLH();
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
                case "6"://特殊信息
                    DataSet ds6 = null;
                    try
                    {
                        string sqlstr="";
                        string ck="";
                        string pch = "";
                        string hw="";
                        string sx = "";
                        string wlh = "";
                        if(!string.IsNullOrEmpty(Request.QueryString["ck"]))
                        {
                            ck=Request.QueryString["ck"];
                            sqlstr+=" AND ck='"+ck+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["pch"]))
                        {
                            pch = Request.QueryString["pch"];
                            sqlstr+=" AND pch='"+pch+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["sx"]))
                        {
                            sx = Request.QueryString["sx"];
                            sqlstr+=" AND sx='"+sx+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["wlh"]))
                        {
                            wlh = Request.QueryString["wlh"];
                            sqlstr+=" AND wlh='"+wlh+"'";
                        }
                        if (!string.IsNullOrEmpty(Request.QueryString["hw"]))
                        {
                            hw = Request.QueryString["hw"];
                            sqlstr+=" AND hw='"+hw+"'";
                        }
                        ds6 = KCQuery.GetKCTSXX(sqlstr);
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
                case "7"://转出物料
                    DataSet ds7 = null;
                    try
                    {
                        ds7 = RKZBQuery.GetRKWLH();
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
                case "8"://牌号
                    DataSet ds8 = null;
                    try
                    {
                        ds8 = KCQuery.GetKCPH();
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
                case "9"://规格
                    DataSet ds9 = null;
                    try
                    {
                        ds9 = KCQuery.GetKCGG();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds9 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds9.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "10"://条码
                    DataSet ds10= null;
                    try
                    {
                        ds10 = KCQuery.GetKCTM();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds10 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds10.WriteXml(writer);
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
