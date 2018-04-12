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
using ACCTRUE.WMSBLL;

public partial class SiteBll_Report_DayReport :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetReport();
       
    }
    private void SetReport()
    {
        string store = "";
        string date = "";
        string orderKey = "";
        if (!string.IsNullOrEmpty(Request["STORE"]))
            store = Request["STORE"];
        if (!string.IsNullOrEmpty(Request["DATE"]))
        {
            date = Request["DATE"];
            try
            {
                Convert.ToDateTime(date);
            }
            catch
            {
                this.PrintfError("日期格式错误！");
                return;
            }
        }
        if (!string.IsNullOrEmpty(Request["ORDERKEY"]))
            orderKey = Request["ORDERKEY"];
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/DayReport";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/DayReport";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        ReportView1.SetParameter("ck", store);
        int year = Convert.ToDateTime(date).Year;
        int month = Convert.ToDateTime(date).Month;
        string startDate = year.ToString() + "-" + month.ToString() + "-" + "1";
        ReportView1.SetParameter("startdate", startDate);
        ReportView1.SetParameter("enddate", date);
        ReportView1.SetParameter("username", Server.UrlEncode(this.CUSER.UserName));
    }
}
