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
public partial class SiteBll_FormMan_PrintDPP : AccPageBase
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
            this.ReportView1.ReportPath = "/XGReportO/ReportDPP";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportDPP";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        if (!string.IsNullOrEmpty(Request["ISCK"]))
            ReportView1.SetParameter("ISCK", "true");
        if (!string.IsNullOrEmpty(Request["ISHW"]))
            ReportView1.SetParameter("ISHW", "true");
        if (!string.IsNullOrEmpty(Request["ISWLH"]))
            ReportView1.SetParameter("ISWLH", "true");
        if (!string.IsNullOrEmpty(Request["ISWLMC"]))
            ReportView1.SetParameter("ISWLMC", "true");
        if (!string.IsNullOrEmpty(Request["ISPCH"]))
            ReportView1.SetParameter("ISPCH", "true");
        if (!string.IsNullOrEmpty(Request["ISPH"]))
            ReportView1.SetParameter("ISPH", "true");
        if (!string.IsNullOrEmpty(Request["ISGG"]))
            ReportView1.SetParameter("ISGG", "true");
        if (!string.IsNullOrEmpty(Request["ISSX"]))
            ReportView1.SetParameter("ISSX", "true");
        if (!string.IsNullOrEmpty(Request["ISSL"]))
            ReportView1.SetParameter("ISSL", "true");
        if (!string.IsNullOrEmpty(Request["ISZL"]))
            ReportView1.SetParameter("ISZL", "true");

        if (!string.IsNullOrEmpty(Request["CK"]))
            ReportView1.SetParameter("CK", Request["CK"]);
        if (!string.IsNullOrEmpty(Request["WLH"]))
            ReportView1.SetParameter("WLH", Request["WLH"]);
        if (!string.IsNullOrEmpty(Request["HW"]))
            ReportView1.SetParameter("HW", Request["HW"]);
        if (!string.IsNullOrEmpty(Request["PCH"]))
            ReportView1.SetParameter("PCH", Request["PCH"]);
        if (!string.IsNullOrEmpty(Request["SX"]))
            ReportView1.SetParameter("SX", Request["SX"]);
        if (!string.IsNullOrEmpty(Request["PH"]))
            ReportView1.SetParameter("PH", Request["PH"]);
        if (!string.IsNullOrEmpty(Request["GG"]))
            ReportView1.SetParameter("GG", Request["GG"]);
        if (!string.IsNullOrEmpty(Request["GGcopy"]))
            ReportView1.SetParameter("GGcopy", Request["GGcopy"]);
        if (!string.IsNullOrEmpty(Request["pcinfo"]))
            ReportView1.SetParameter("pcinfo", Request["pcinfo"]);
        if (!string.IsNullOrEmpty(Request["RKRQfrom"]))
            ReportView1.SetParameter("RKRQfrom", Request["RKRQfrom"]);
        if (!string.IsNullOrEmpty(Request["RKRQto"]))
            ReportView1.SetParameter("RKRQto", Request["RKRQto"]);
        if (!string.IsNullOrEmpty(Request["zpdjbz"]))
            ReportView1.SetParameter("zpdjbz", Request["zpdjbz"]);
    }
}
