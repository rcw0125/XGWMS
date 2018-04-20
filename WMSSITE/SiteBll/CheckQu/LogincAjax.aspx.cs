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
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_FormMan_LogincAjax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string type = "";
            string fname = "";
            if (Request["TYPE"] == null)
            {
                return;
            }
            type = Request["TYPE"];
            fname = Request["fname"];
            if (fname != null)
                fname = fname.Trim();
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
                    try
                    {
                        string stype = "0";
                        if (Request["STYPE"] != null)
                        {
                            stype = Request["STYPE"];
                            ds10 = QuCheck.GetWLSXNEW(fname.Trim(), stype);
                        }
                        else
                            ds10 = QuCheck.GetWLSX(fname.Trim());
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
                case "11":
                    DataSet ds11 = null;
                    try
                    {
                        ds11 = QuCheck.GetPHZXBZ(fname);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds11 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds11.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "12":
                    DataSet ds12=null;
                    try
                    {
                        ds12 = QuCheck.GetWGDItemZH(fname, Request["ph"]);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds12 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds12.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "13":
                    DataSet ds13 = null;
                    try
                    {
                        ds13 = QuCheck.getWgdStatus(fname);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds13 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds13.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "14":
                    DataSet ds14 = null;
                    try
                    {
                        ds14 = QuCheck.getwgdzjbxx(fname);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds14 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds14.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "15":
                    string res15 = "";
                    try
                    {
                        res15 = QuCheck.isgp(fname);
                        Response.Write(res15);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "16":
                    DataSet ds16 = null;
                    try
                    {
                        ds16 = QuCheck.getWgdSCZT(fname);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds16 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds16.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "17":
                    string res17 = null;
                    try
                    {
              //          var url = "LogincAjax.aspx?TYPE=17&fname=" + strpch + "&pch=" + hpch.value + "&pclx=" + pclx + "&pcsx=" + encodeURI(pcsx) + "&zxbz=" + encodeURI(zxbz) +
              //"&isgp=" + isgp + "&zpdjbz=" + zpdj + "&itemwlh=" + wgditemwlh + "&itemph=" + encodeURI(wgditemph) + "&itemgg=" + encodeURI(wgditemgg) + "&itemzxbz="
                        //+ encodeURI(wgditemzxbz) + "&itemsx=" + encodeURI(wgditemsx) + "&userno=" + userno.valuesxqgz="+encodeURI(selsxqgz.value)+"&sxqgg="+encodeURI(selsxqgg.value)+
                    //    "&wlhper=" + selsxqwlhper.value + "&selsxqvfree=" + encodeURI(selsxqvfree.value); ;
                        res17 = QuCheck.CheckQu(Request["pch"], Request["pclx"], Request["pcsx"], Request["zxbz"], Request["isgp"], Request["zpdjbz"], Request["itemwlh"], Request["itemph"], Request["itemgg"], Request["itemzxbz"], Request["itemsx"], Request["userno"], Request["free1"], Request["free2"], Request["free3"], Request["sxqgz"], Request["wlhper"], Request["sxqgg"], Request["selsxqvfree"]);
                        Response.Write(res17);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "18":
                    DataSet ds18 = null;
                    try
                    {
                        ds18 = QuCheck.GetBhgReason(fname);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds18 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds18.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "19":
                    //var url = "LogincAjax.aspx?TYPE=19&fname=" + encodeURI(txtreason.value) + "&itype=0&reasontype=" + reasontype +
                    //     "&oldreason=" + document.getElementById("htxtreason").value;
                    string res19 = "";
                    try
                    {
                        res19 = QuCheck.saveReason(Request["itype"], Request["reasontype"], Request["fname"], Request["oldreason"]);
                        Response.Write(res19);
                        Response.End();
                    }
                    catch
                    {}
                    break;
                case "20":
                    //"LogincAjax.aspx?TYPE=20&fname="+encodeURI(txtreason.value)+"&reasontype="+reasontype;
                    string res20 = "";
                    try
                    {
                        res20 = QuCheck.delReason(Request["reasontype"],Request["fname"]);
                        Response.Write(res20);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "21":
                    DataSet ds21 = null;
                    try
                    {
                        ds21 = QuCheck.getPHZXBZ();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds21 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds21.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "22":
                    //var url = "LogincAjax.aspx?TYPE=22&ph="+encodeURI(txtph.value)+"&opetype=0&zxbz="+encodeURI(txtzxbz.value)+
                    //"&oldph="+encodeURI(htxtph.value)+"&oldzxbz="+encodeURI(htxtzxbz.value);
                    string res22 = null;
                    try
                    {
                        res22 = QuCheck.savezxbz(Request["zxbz"], Request["ph"], Request["opetype"], Request["oldph"], Request["oldzxbz"]);
                        Response.Write(res22);
                        Response.End();
                    }
                    catch 
                    { }
                    break;
                case "23":
                    //var url = "LogincAjax.aspx?TYPE=23&ph="+encodeURI(txtph.value)+"&zxbz="+encodeURI(txtzxbz.value);
                    string res23 = null;
                    try
                    {
                        res23 = QuCheck.delzxbz(Request["zxbz"], Request["ph"]);
                        Response.Write(res23);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "24":
                    DataSet ds24 = null;
                    try
                    {
                        ds24 = QuCheck.getseleds(Request["fname"], Request["tbname"]);

                    }
                    catch(Exception ex)
                    {
                        string aa = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds24 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds24.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "25":
                    string res25 = null;
                    try
                    {
                        
                        res25 = QuCheck.SetPcInfo(Request["itype"], Request["pch"], Request["barcode"], Request["selpcinfo"], Request["newpcinfo"], Request["sx"]);
                        Response.Write(res25);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "26":
                    DataSet ds26 = null;
                    try
                    {
                        ds26 = QuCheck.GetWGDItemsPH(Request["pch"]);

                    }
                    catch (Exception ex)
                    {
                        string aa = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds26 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds26.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "27":
                    try
                    {
                        string defaultitemstr = QuCheck.GetDefaultItem(Request["pch"], Request["ph"]);
                        Response.Write(defaultitemstr);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "28":
                    try
                    {
                        string defaultSx = QuCheck.GetDefaultSx(Request["pch"]);
                        Response.Write(defaultSx);
                        Response.End();

                    }
                    catch
                    { }
                    break;
                case "29":
                    DataSet ds29 = null;
                    try
                    {
                        ds29 = QuCheck.getWgdGZ(Request["wlhper"].ToString());
                    }
                    catch (Exception ex)
                    {
                        string aa = ex.Message;
                        Response.Write("ERROR");
                        Response.End();
                    }
                    if (ds29 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds29.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "2901":
                    //2901&wlhper="+selsxqwlhper.value+"&sxqgz="+selsxqgz.value;
                    DataSet ds2901 = null;
                    try
                    {
                        ds2901 = QuCheck.getWgdgg(Request["wlhper"].ToString(), Request["sxqgz"].ToString());
                    }
                    catch (Exception ex)
                    {
                        string aa = ex.Message;
                        Response.Write("ERROR");
                        Response.End();
                    }
                    if (ds2901 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds2901.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break; 
                case "2902":
                    DataSet ds2902 = null;
                    try
                    {
                        ds2902 = QuCheck.getWgdvfree(Request["wlhper"].ToString(), Request["sxqgz"].ToString(),Request["sxqgg"].ToString());
                    }
                    catch (Exception ex)
                    {
                        string aa = ex.Message;
                        Response.Write("ERROR");
                        Response.End();
                    }
                    if (ds2902 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds2902.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break; 
                case "30":
                    DataSet ds30 = null;
                    try
                    {
                        ds30 = QuCheck.getQPInfo(Request["wlhper"]);
                    }
                    catch (System.Exception ex)
                    {
                        Response.Write("ERROR:" + ex.Message);
                    	
                    }
                    if (ds30 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds30.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "301":
                    DataSet ds301 = null;
                    try
                    {
                        ds301 = QuCheck.getQPBzbz(Request["wlhstr"]);
                    }
                    catch (System.Exception ex)
                    {
                        Response.Write("ERROR:" + ex.Message);

                    }
                    if (ds301 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds301.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "302":
                    string qpwlh = Request["wlh"].ToString();
                    string res302 = QuCheck.setall(qpwlh);
                    Response.Write(res302);
                    Response.End();
                    break;
                case "303":
                    string qpwlh1 = Request["wlh"].ToString();
                    string qpbzbz = Request["bzbz"].ToString();
                    string qpope = Request["ope"].ToString();
                    string res303 = QuCheck.setbzbz(qpwlh1,qpbzbz,qpope);
                    Response.Write(res303);
                    Response.End();
                    break;
                case "31":
                    string res31 = "";
                    try
                    {
                        //"../CheckQu/LogincAjax.aspx?TYPE=31&wlh="+encodeURI(txtwlh.value)+"&opetype=0&isqp="+ckqps;
                        res31 = QuCheck.saveqp(Request["wlh"], Request["isqp"], Request["oldwlh"], Request["opetype"]);
                        Response.Write(res31);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "32":
                    try
                    {
                        //"../CheckQu/LogincAjax.aspx?TYPE=31&wlh="+encodeURI(txtwlh.value)+"&opetype=0&isqp="+ckqps;
                        res31 = QuCheck.delwlh(Request["wlh"]);
                        Response.Write(res31);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "33":
                    DataSet ds33 = null;
                    try
                    {
                        ds33 = QuCheck.getBZBZInfo();
                    }
                    catch (System.Exception ex)
                    {
                        Response.Write("ERROR:" + ex.Message);

                    }
                    if (ds33 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds33.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "34":
                    string res34 = "";
                    try
                    {
                 //       "../CheckQu/LogincAjax.aspx?TYPE=34&txtbzbz=" + encodeURI(txtbzbz.value) +
                 //"&opetype=0&bzxx=" + bzxx.value + "&bzsx=" + bzsx.value + "&clkz=" + clkz.value + "&bz=" + bz.value + "&fid=''";
                        res34 = QuCheck.savebzbz(Request["txtbzbz"], Request["bzxx"], Request["bzsx"], Request["clkz"], Request["bz"], Request["fid"], Request["opetype"], Request["scx"]);
                        Response.Write(res34);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "35":
                    string res35 = "";
                    try
                    {
                        res31 = QuCheck.delbzbz(Request["fid"]);
                        Response.Write(res35);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "36":
                    try
                    {
                        string res36 = "";
                        DataSet ds36 = null;
                        ds36 = QuCheck.getwlh();
                        if (ds36!=null)
                        {
                            try
                            {
                                XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                                writer.Formatting = Formatting.Indented;
                                writer.Indentation = 4;
                                writer.IndentChar = ' ';
                                ds36.WriteXml(writer);
                                writer.Flush();
                                writer.Close();
                                Response.End();
                            }
                            catch
                            { }
                        }

                    }
                    catch (System.Exception ex)
                    {
                    	
                    }
                    break;
                case "37":
                    string res37 = QuCheck.setQp(Request["wlh"]);
                    Response.Write(res37);
                    Response.End();
                    break;
                case "38":
                    string res38 = QuCheck.checkfydqr(Request["fydh"]);
                    Response.Write(res38);
                    Response.End();
                    break;
                case "39":
                    string res39 = QuCheck.checkfydOutqr(Request["fydh"]);
                    Response.Write(res39);
                    Response.End();
                    break;           
                case "401":
                    DataSet ds401 = null;
                    try
                    {
                        string wlh = Request["wlh"];

                        if (wlh == "A")
                        {


                            if (Session["wlhcx"] != null && Session["wlhnull"] == "0")
                            {
                                string wl = Session["wlhcx"].ToString();
                                ds401 = QuCheck.getKCTW(wl);
                            }
                            else
                            {
                                 ds401 = QuCheck.getKCTW();
                            }
                            
                           
                            Session["wlhnull"] = "1";
                        }
                        else
                        {
                            //记录查询的wlh
                            Session["wlhcx"] = wlh;
                            Session["wlhnull"] = "0";
                            ds401 = QuCheck.getKCTW(wlh);
                        }

                        
                    }
                    catch (System.Exception ex)
                    {
                        Response.Write("ERROR:" + ex.Message);

                    }
                    if (ds401 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds401.WriteXml(writer);
                            writer.Flush();
                            writer.Close();
                            Response.End();
                        }
                        catch
                        { }
                    }
                    break;
                case "402":
                    string res402 = "";
                    try
                    {
                        string userID = "";
                        if (Session[Config.Curren_User] != null)
                        {
                            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
                            if (user != null)
                            {
                                userID = user.UserID;
                            }
                        }
                        res402 = QuCheck.saveKCTW(Request["opetype"], Request["wlh"], Request["ph"], Request["gg"], Request["pprice"], Request["fprice"], Request["twzl"],GetUserId());
                        Response.Write(res402);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "403":
                    string res403 = "";
                    try
                    {
                        res403 = QuCheck.delKCTW(Request["wlh"],GetUserId());
                        Response.Write(res403);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "404":
                    string res404 = "";
                    try
                    {
                        res404 = WlbaseInfo.GetPHGG(Request["wlh"]);
                        //res404 = Request["wlh"]+"svr";// QuCheck.delKCTW(Request["wlh"]);
                        Response.Write(res404);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "405":
                    string res405 = "";
                    try
                    {
                        res405 = QuCheck.setKCTWStatus(Request["wlh"], Request["inuse"], GetUserId());
                        //res404 = Request["wlh"]+"svr";// QuCheck.delKCTW(Request["wlh"]);
                        Response.Write(res405);
                        Response.End();
                    }
                    catch
                    { }
                    break;
                case "406":
                    string res406 = "";
                    try
                    {
                        res406 = QuCheck.setKCTWStatus(Request["inuse"], GetUserId());
                        Response.Write(res406);
                        Response.End();
                    }
                    catch
                    { }
                    break;
            }
        }
    }

    private string GetUserId()
    {
        string userID = "";
        if (Session[Config.Curren_User] != null)
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            if (user != null)
            {
                userID = user.UserID;
            }
        }
        return userID;
    }
}
