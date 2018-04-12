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
using ACCTRUE.WMSBLL.Model;
public partial class SiteBll_PDMan_PrintCPD :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetReport();
    }

    private void SetReport()
    {
        string PDDH = "";
        string CKID = "";
        string UserName = this.CUSER.UserName;
        string DJZT = "";
        if (!string.IsNullOrEmpty(Request["PDDH"]))
            PDDH = Request["PDDH"];
        DataSet ds = PDParam.GetList("PDDH = '" + PDDH + "'");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            CKID = ds.Tables[0].Rows[0]["CK"].ToString();
            DJZT = ds.Tables[0].Rows[0]["DJZT"].ToString();
        }
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/ReportCPD";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportCPD";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        ReportView1.SetParameter("CKID", CKID);
        ReportView1.SetParameter("PDDH", PDDH);
        ReportView1.SetParameter("ZBR", Server.UrlEncode(UserName));
        ReportView1.SetParameter("DJZT", Server.UrlEncode(DJZT));
    }
}
