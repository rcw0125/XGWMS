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
using System.Text;
using ACCTRUE.WMSBLL.QueryBll;
using System.Xml;
/// <summary>
/// 发运单查询
/// 柴艳亮
/// 
/// 
/// </summary>
public partial class SiteBll_FormMan_loadZKD :AccPageBase
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
                case "1"://获取转库单号
                    DataSet ds = null;
                    try
                    {
                        ds = ZKDQuery.GetZKDID();
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
                case "2"://获取批次号
                    DataSet ds2 = null;
                    try
                    {

                        ds2 = ZKDQuery.GetPCHID();
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
                case "3"://获取物料号
                    DataSet ds3 = null;
                    try
                    {
                        ds3 = ZKDQuery.GetWLHID();
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
                        ds4 = ZKDQuery.GetZKDSX();
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

                case "5"://获取牌号
                    DataSet ds5 = null;
                    try
                    {
                        ds5 = ZKDQuery.GetZKDPH();
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
                case "6"://获取规格
                    DataSet ds6 = null;
                    try
                    {
                        ds6 = ZKDQuery.GetZKDGG();
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
                case "7"://转出仓库
                    DataSet ds7 = null;
                    try
                    {
                        ds7 = ZKDQuery.GetCKID();
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
                case "8"://转入仓库
                    DataSet ds8 = null;
                    try
                    {
                        ds8 = ZKDQuery.GetCKID();
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
                case "9"://车牌号
                    DataSet ds9 = null;
                    try
                    {
                        ds9 = ZKDQuery.GetZKDCPH();
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
                case "chongzhi":
                    if (Request["ZKDH"] != null)
                    {
                        try
                        {
                            string strSX = "";
                            string strZKDH = Request.QueryString["ZKDH"];
                            string strPCH = Request.QueryString["PCH"];
                                    strSX = Request.QueryString["SX"];
                            int result = ZKDQuery.chongzhiZKD(strZKDH, strPCH, strSX);

                            if (result == 0)
                            {
                                Response.Write("success");
                            }
                        }
                        catch
                        {
                            Response.Write("wrongcz");
                        }
                       

                    }
                    break;
                case "closedj":

                    if (Request["ZKDH"] != null)
                    {
                        string strZKDH = Request["ZKDH"];
                        try
                        {
                            ZKDQuery zkdquery = new ZKDQuery();
                            zkdquery.UpdteZKD(strZKDH);
                            Response.Write("close");
                            //Response.Write("<script>alert('单据已关闭');window.location='QZKD.aspx';</script>");
                        }
                        catch
                        {
                            this.PrintfError("数据访问失败！");
                            return;
                        }

                    }
                    break;
            }
        }
    }
}
