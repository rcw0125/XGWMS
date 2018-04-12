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
public partial class SiteBll_ICMan_PrintIC : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetReport();
    }

    private void SetReport()
    {
        string ICID = "";
        string KHName = "";
        string CPH = "";
        string Proposer = "";
        string UserName = this.CUSER.UserName;
        if (!string.IsNullOrEmpty(Request["ICID"]))
            ICID = Request["ICID"];
        if (!string.IsNullOrEmpty(Request["KHName"]))
            KHName = Request["KHName"];
        if (!string.IsNullOrEmpty(Request["CPH"]))
            CPH = Request["CPH"];
        if (!string.IsNullOrEmpty(Request["Proposer"]))
            Proposer = Request["Proposer"];
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/ReportIC";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportIC";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        ReportView1.SetParameter("ICID", Server.UrlEncode(ICID));
        ReportView1.SetParameter("KHName", Server.UrlEncode(KHName));
        ReportView1.SetParameter("CPH", Server.UrlEncode(CPH));
        ReportView1.SetParameter("Proposer", Server.UrlEncode(Proposer));
        ReportView1.SetParameter("ZBR", Server.UrlEncode(UserName));
    }
}
