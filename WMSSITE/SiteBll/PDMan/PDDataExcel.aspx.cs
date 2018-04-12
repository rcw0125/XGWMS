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
public partial class SiteBll_PDMan_PDDataExcel : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetReport();
    }

    //设置报表
    private void SetReport()
    {
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/ReportPDDataExcel";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportPDDataExcel";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;

        if (!string.IsNullOrEmpty(Request["YSDH"]))
            ReportView1.SetParameter("YSDH", Request["YSDH"]);
        if (!string.IsNullOrEmpty(Request["PDDH"]))
            ReportView1.SetParameter("PDDH", Request["PDDH"]);
        if (!string.IsNullOrEmpty(Request["WLH"]))
            ReportView1.SetParameter("WLH", Request["WLH"]);
        if (!string.IsNullOrEmpty(Request["PCH"]))
            ReportView1.SetParameter("PCH", Request["PCH"]);
        if (!string.IsNullOrEmpty(Request["SX"]))
            ReportView1.SetParameter("SX", Request["SX"]);
        if (!string.IsNullOrEmpty(Request["chkNoNCWLisChecked"]))
            ReportView1.SetParameter("chkNoNCWLisChecked", Request["chkNoNCWLisChecked"]);
    }
}
