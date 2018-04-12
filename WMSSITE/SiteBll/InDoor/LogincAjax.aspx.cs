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
using ACCTRUE.WMSBLL.Model;
using System.Xml;
public partial class SiteBll_InDoor_LogincAjax : System.Web.UI.Page
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
                case "1"://发运单号
                    DataSet ds1 = null;
                    try
                    {
                        ds1 = InDoorParam.GetFYDH();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                        Response.Write("ERROR");
                    }
                    if (ds1 != null)
                    {
                        try
                        {
                            XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 4;
                            writer.IndentChar = ' ';
                            ds1.WriteXml(writer);
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
