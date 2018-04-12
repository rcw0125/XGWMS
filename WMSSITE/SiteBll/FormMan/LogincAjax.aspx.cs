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

public partial class SiteBll_FormMan_LogincAjax : System.Web.UI.Page
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
                case "1"://获取完工单查询的批次号条件
                    DataSet ds=null;
                    try
                    {
                        ds = WGDQuery.GetPCHTerm();
                    }
                    catch(Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if(ds!=null)
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
                case "2"://获取完工单查询的特殊信息条件
                    DataSet ds2 = null;
                    try
                    {
                        string pchXX = "";
                        if (!string.IsNullOrEmpty(Request["PCH"]))
                            pchXX = Request["PCH"];
                        ds2 = WGDQuery.GetPCInfo(pchXX);
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
                case "3"://批次属性的查询条件
                    DataSet ds3 = null;
                    try
                    {
                        ds3 = WGDQuery.GetPCSX();
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
                case "4"://物料号的查询条件
                    DataSet ds4= null;
                    try
                    {
                        ds4 = WGDQuery.GetWLH();
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
                case "5"://生产线
                    DataSet ds5 = null;
                    try
                    {
                        ds5 = WGDQuery.GetSCX();
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
                case "6"://生产线
                    DataSet ds6 = null;
                    try
                    {
                        ds6 = WGDQuery.GetPH();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds6!= null)
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
                case "7"://规格
                    DataSet ds7 = null;
                    try
                    {
                        ds7= WGDQuery.GetGG();
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
                case "8"://完工单号
                    DataSet ds8 = null;
                    try
                    {
                        ds8 = WGDQuery.GetWGDH();
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
                case "9"://完工单号
                    DataSet ds9 = null;
                    try
                    {
                        ds9 = WGDQuery.GetZJR();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds9!= null)
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
                case "10":
                    DataSet ds10 = null;
                    string fFYDH=Request["fydh"].ToString();
                    string fck=Request["ck"].ToString();
                    string fstrWLH=Request["wlh"].ToString();
                    string fstrSX=Request["sx"].ToString();
                    string fstrVfree1 = Request["vfree1"].ToString();
                    string fstrVfree2 = Request["vfree2"].ToString();
                    string fstrVfree3 = Request["vfree3"].ToString();
                    string res10 = "";
                    try
                    {
                        ds10 = FYDQuery.GetQueryFYDKYHW(fFYDH, fck, fstrWLH, fstrSX, fstrVfree1, fstrVfree2, fstrVfree3);
                //                        <th>仓库</th>
                //<th>货位</th>
                //<th>物料号</th>
                //<th>物料名称</th>
                //<th>属性</th>
                //<th>牌号</th>
                //<th>规格</th>
                //<th>特殊信息</th>
                //<th>重量</th>
                //<th>数量</th>
                //<th>自由项1</th>
                //<th>自由项2</th>
                //<th>自由项3</th>
                        res10 = "<table width=\"800px;\" id=\"grvstand\" border=\"1\" cellpadding=\"1\" cellspacing=\"0\" bordercolor =\"#dce8f4\">" +
                                         "<thead id=\"djlist\">" +
                                         "<tr>" +
                                         "<th bgcolor=\"#dce8f4\">仓库</th>" +
                                         "<th bgcolor=\"#dce8f4\">货位</th>" +
                                         "<th bgcolor=\"#dce8f4\">物料号</th>" +
                                         "<th bgcolor=\"#dce8f4\" width=\"120px\">称重日期</th>" +
                                         "<th bgcolor=\"#dce8f4\">物料名称</th>" +
                                         "<th bgcolor=\"#dce8f4\">批次号</th>" +
                                         "<th bgcolor=\"#dce8f4\">属性</th>" +
                                         "<th bgcolor=\"#dce8f4\">牌号</th>" +
                                         "<th bgcolor=\"#dce8f4\">规格</th>" +
                                         "<th bgcolor=\"#dce8f4\">特殊信息</th>" +
                            "<th bgcolor=\"#dce8f4\">重量</th>" +
                            "<th bgcolor=\"#dce8f4\">数量</th>" +
                            "<th bgcolor=\"#dce8f4\">自由项1</th>" +
                            "<th bgcolor=\"#dce8f4\">自由项2</th>" +
                            "<th bgcolor=\"#dce8f4\">自由项3</th>" +
                                         "</tr>" +
                                         "</thead><tbody id=\"djlist\">";
                        if (ds10!=null&&ds10.Tables.Count>0&&ds10.Tables[0].Rows.Count>0)
                        {
                            foreach (DataRow dr in ds10.Tables[0].Rows)
                            {
                                res10 += "<tr><td>"+dr["ck"].ToString()+
                                           "</td><td>"+dr["hw"].ToString()+
                                           "</td><td>"+dr["wlh"].ToString()+
                                             "</td><td>" + dr["rq"].ToString() +
                                           "</td><td>"+dr["wlmc"].ToString()+
                                           "</td><td>" + dr["pch"].ToString() +
                                           "</td><td>"+dr["sx"].ToString()+
                                           "</td><td>"+dr["ph"].ToString()+
                                           "</td><td>" + dr["gg"].ToString() +
                                           "</td><td>" + dr["pcinfo"].ToString() +
                                           "</td><td>" + dr["zls"].ToString() +
                                           "</td><td>" + dr["num"].ToString() +
                                           "</td><td>" + dr["vfree1"].ToString() +
                                           "</td><td>" + dr["vfree2"].ToString() +
                                           "</td><td>" + dr["vfree3"].ToString() +
                                           "</td></tr>";
                            }
                        }
                        res10 += "</tbody></table>";
                    }
                    catch (System.Exception ex)
                    {
                        res10="ERROR"+ex.Message;
                    }
                    Response.Write(res10);
                    Response.End();
                    break;
            }
        }
    }
}
