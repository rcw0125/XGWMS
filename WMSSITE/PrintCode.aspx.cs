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
using System.IO;
using System.Text;
using ACCTRUE.WMSBLL.Model;

public partial class PrintCode :AccPageBase
{
    private string colHeaders = "<html><head><LINK href=\"CSS/Input.css\" type=\"text/css\" rel=\"stylesheet\"></head><body>" +
            "<object ID='WebBrowser' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'VIEWASTEXT></object>";
    private string colFooder = "</body></html><script languge='javascript'>WebBrowser.ExecWB(7,1); window.opener=null;window.close();</script>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string store = "";
            string sRow = "";
            string sCol = "";
            string tRow = "";
            string tCol = "";
            if (!string.IsNullOrEmpty(Request["STORE"]))
                store = Request["STORE"];
            if (!string.IsNullOrEmpty(Request["SROW"]))
                sRow = Request["SROW"];
            if (!string.IsNullOrEmpty(Request["TROW"]))
                tRow = Request["TROW"];
            if (!string.IsNullOrEmpty(Request["SCOL"]))
                sCol = Request["SCOL"];
            if (!string.IsNullOrEmpty(Request["TCOL"]))
                tCol = Request["TCOL"];
            if (!string.IsNullOrEmpty(store) && !string.IsNullOrEmpty(sRow) && !string.IsNullOrEmpty(tRow) && !string.IsNullOrEmpty(sCol) && !string.IsNullOrEmpty(tCol))
            {
                if (tRow == "0" || tCol == "0")
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("HWID");
                    DataRow row = dt.NewRow();
                    row["HWID"] = store.Trim() + string.Format("{0:d02}", Convert.ToInt32(sRow)) + string.Format("{0:d02}", Convert.ToInt32(sCol));
                    
                    //string midString = CreateImage(row,false);
                    string midString = BarTable(row, false);
                    Response.Write(colHeaders + midString + colFooder);
                }
                else
                {
                    try
                    {
                        DataSet ds = HWinfo.GetHWID(store, sRow, tRow, sCol, tCol);
                        if (ds != null)
                        {
                            StringBuilder sbResponse = new StringBuilder();
                            sbResponse.Append(colHeaders);
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (i == ds.Tables[0].Rows.Count - 1)
                                {
                                    //sbResponse.Append(CreateImage(ds.Tables[0].Rows[i], false));
                                    sbResponse.Append(BarTable(ds.Tables[0].Rows[i], false));
                                }
                                else
                                    //sbResponse.Append(CreateImage(ds.Tables[0].Rows[i], true));
                                    sbResponse.Append(BarTable(ds.Tables[0].Rows[i], true));

                            }
                            sbResponse.Append(colFooder);
                            Response.Write(sbResponse.ToString());
                        }
                        else
                        {
                            this.WriteClientJava("window.alert('不存在要打印的货位信息');");
                            return;
                        }
                    }
                    catch
                    {
                        this.PrintfError("数据访问错误，请重试！");
                    }
                }
            }
        }
    }

    private string CreateImage(DataRow row,bool isReturn)
    {
        string userID = "";
        if (Session[Config.Curren_User] != null)
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            userID = user.UserID;
        }
        DataSet dataset = new DataSet();
        dataset.ReadXml(Server.MapPath("PrintCodeTemplet/HWCodeTeplet.xml"));
        DataTable table = dataset.Tables[0];
        BarCode128Manager codeManage = new BarCode128Manager(table);
        System.Drawing.Image imgae = codeManage.CreateImage(row);
        string sfilename = Guid.NewGuid().ToString() + ".png";
        string sfilepath = CreateDirectory(userID) + "/" + sfilename;
        imgae.Save(sfilepath, System.Drawing.Imaging.ImageFormat.Png);
        string strDate = DateTime.Now.ToShortDateString();
        string ImageUrl = "TempImages/" + userID + "/" + strDate + "/" + sfilename;
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<img src=""" + ImageUrl + @""" width=100% height=100% />");
        if (isReturn == true)
        {
            sb.Append(@"<br clear=all style='page-break-before:always'>");
        }
        return sb.ToString();
    }


    private string CreateDirectory(string userID)
    {
        if (Session[Config.Curren_User] != null)
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            string strDate = DateTime.Now.ToShortDateString();
            string userDirectory = Server.MapPath("TempImages\\" + userID + "\\" + strDate);
            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
            }
            return userDirectory;
        }
        return "";
    }

    private string BarTable(DataRow row, bool isReturn)
    {

        StringBuilder sb = new StringBuilder();
        sb.Append("<img src=BarcodeImage.aspx?BINCODE=");
        sb.Append(row["HWID"].ToString());
        sb.Append(" />");
        if (isReturn == true)
        {
            sb.Append(@"<br clear=all style='page-break-before:always'>");
        }
        return sb.ToString();
    }
}
