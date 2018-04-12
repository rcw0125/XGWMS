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
public partial class SiteBll_PDMan_PrintPDCYB : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetReport();
    }
    private void SetReport()
    {
        try
        {
            string YSDH = "";
            string CKID = "";
            if (!string.IsNullOrEmpty(Request["YSDH"]))
                YSDH = Request["YSDH"];
            if (!string.IsNullOrEmpty(Request["CKID"]))
                CKID = Request["CKID"];
            this.ReportView1.ServerUrl = this.ReportURL;
            if (Common.IsOldData)
            {
                this.ReportView1.ReportPath = "/XGReportO/ReportPDCYB";
            }
            else
                this.ReportView1.ReportPath = "/XGReportC/ReportPDCYB";
            ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
            ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
            ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
            ReportView1.SetParameter("YSDH", YSDH);
            ReportView1.SetParameter("CKID", CKID);
        }
        catch
        {
            this.PrintfError("生成报表出错，请重试");
            return;
        }
    }
}
