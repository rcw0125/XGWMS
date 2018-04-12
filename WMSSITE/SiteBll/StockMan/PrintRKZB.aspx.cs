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
public partial class SiteBll_StockMan_PrintRKZB : AccPageBase
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
            this.ReportView1.ReportPath = "/XGReportO/ReportRKZB";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportRKZB";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;

        if (!string.IsNullOrEmpty(Request["ISRKDH"]))
            ReportView1.SetParameter("ISRKDH", "true");
        if (!string.IsNullOrEmpty(Request["ISCK"]))
            ReportView1.SetParameter("ISCK", "true");
        if (!string.IsNullOrEmpty(Request["ISPCH"]))
            ReportView1.SetParameter("ISPCH", "true");
        if (!string.IsNullOrEmpty(Request["ISSX"]))
            ReportView1.SetParameter("ISSX", "true");
        if (!string.IsNullOrEmpty(Request["ISWLH"]))
            ReportView1.SetParameter("ISWLH", "true");
        if (!string.IsNullOrEmpty(Request["ISPH"]))
            ReportView1.SetParameter("ISPH", "true");
        if (!string.IsNullOrEmpty(Request["ISGG"]))
            ReportView1.SetParameter("ISGG", "true");
        if (!string.IsNullOrEmpty(Request["ISSL"]))
            ReportView1.SetParameter("ISSL", "true");
        if (!string.IsNullOrEmpty(Request["ISZL"]))
            ReportView1.SetParameter("ISZL", "true");
        if (!string.IsNullOrEmpty(Request["ISCPH"]))
            ReportView1.SetParameter("ISCPH", "true");
        if (!string.IsNullOrEmpty(Request["ISRKTime"]))
            ReportView1.SetParameter("ISRKTime", "true");
        if (!string.IsNullOrEmpty(Request["ISRKType"]))
            ReportView1.SetParameter("ISRKType", "true");
        if (!string.IsNullOrEmpty(Request["ISWLMC"]))
            ReportView1.SetParameter("ISWLMC", "true");
        if (!string.IsNullOrEmpty(Request["ISFREE1"]))
            ReportView1.SetParameter("ISFREE1", "true");
        if (!string.IsNullOrEmpty(Request["ISFREE2"]))
            ReportView1.SetParameter("ISFREE2", "true");
        if (!string.IsNullOrEmpty(Request["ISFREE3"]))
            ReportView1.SetParameter("ISFREE3", "true");

        if (!string.IsNullOrEmpty(Request["RKDH"]))
            ReportView1.SetParameter("RKDH", Request["RKDH"]);
        if (!string.IsNullOrEmpty(Request["CK"]))
            ReportView1.SetParameter("CK", Request["CK"]);
        if (!string.IsNullOrEmpty(Request["PCH"]))
            ReportView1.SetParameter("PCH", Request["PCH"]);
        if (!string.IsNullOrEmpty(Request["SX"]))
            ReportView1.SetParameter("SX", Request["SX"]);
        if (!string.IsNullOrEmpty(Request["WLH"]))
            ReportView1.SetParameter("WLH", Request["WLH"]);
        if (!string.IsNullOrEmpty(Request["PH"]))
            ReportView1.SetParameter("PH", Request["PH"]);
        if (!string.IsNullOrEmpty(Request["GG"]))
            ReportView1.SetParameter("GG", Request["GG"]);
        if (!string.IsNullOrEmpty(Request["CPH"]))
            ReportView1.SetParameter("CPH", Request["CPH"]);
        if (!string.IsNullOrEmpty(Request["fromtime"]))
            ReportView1.SetParameter("fromtime", Request["fromtime"]);
        if (!string.IsNullOrEmpty(Request["totime"]))
            ReportView1.SetParameter("totime", Request["totime"]);
        if (!string.IsNullOrEmpty(Request["RKType"]))
            ReportView1.SetParameter("RKType", Request["RKType"]);
        if (!string.IsNullOrEmpty(Request["SCXBM"]))
            ReportView1.SetParameter("scxbm", Request["SCXBM"]);
        if (!string.IsNullOrEmpty(Request["BB"]))
            ReportView1.SetParameter("BB", Request["BB"]);
        if (!string.IsNullOrEmpty(Request["pcinfo"]))
            ReportView1.SetParameter("pcinfo", Request["pcinfo"]);

        if (!string.IsNullOrEmpty(Request["free1"]))
            ReportView1.SetParameter("free1", Request["free1"]);
        if (!string.IsNullOrEmpty(Request["free2"]))
            ReportView1.SetParameter("free2", Request["free2"]);
        if (!string.IsNullOrEmpty(Request["free3"]))
            ReportView1.SetParameter("free3", Request["free3"]);
    }
}
