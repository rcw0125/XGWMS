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

public partial class SiteBll_FormMan_PrintWGD:AccPageBase
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
            this.ReportView1.ReportPath = "/XGReportO/WGDReport";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/WGDReport";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        if (!string.IsNullOrEmpty(Request["ISWGDH"]))
            ReportView1.SetParameter("ISWGDH","true");
        if (!string.IsNullOrEmpty(Request["ISSCX"]))
            ReportView1.SetParameter("ISSCX", "true");
        if (!string.IsNullOrEmpty(Request["ISPC"]))
            ReportView1.SetParameter("ISPC", "true");
        if (!string.IsNullOrEmpty(Request["ISPCSX"]))
            ReportView1.SetParameter("ISPCSX", "true");
        if (!string.IsNullOrEmpty(Request["ISTSXX"]))
            ReportView1.SetParameter("ISTSXX", "true");
        if (!string.IsNullOrEmpty(Request["ISPCLX"]))
            ReportView1.SetParameter("ISPCLX", "true");
        if (!string.IsNullOrEmpty(Request["ISPH"]))
            ReportView1.SetParameter("ISPH", "true");
        if (!string.IsNullOrEmpty(Request["ISGG"]))
            ReportView1.SetParameter("ISGG", "true");
        if (!string.IsNullOrEmpty(Request["ISWLH"]))
            ReportView1.SetParameter("ISWLH", "true");
        if (!string.IsNullOrEmpty(Request["ISWLMC"]))
            ReportView1.SetParameter("ISWLMC", "true");
        if (!string.IsNullOrEmpty(Request["ISZXBZ"]))
            ReportView1.SetParameter("ISZXBZ", "true");
        if (!string.IsNullOrEmpty(Request["ISFZDW"]))
            ReportView1.SetParameter("ISFZDW", "true");
        if (!string.IsNullOrEmpty(Request["ISPCXH"]))
            ReportView1.SetParameter("ISPCXH", "true");
        if (!string.IsNullOrEmpty(Request["ISZJBZ"]))
            ReportView1.SetParameter("ISZJBZ", "true");
        if (!string.IsNullOrEmpty(Request["ISPGSM"]))
            ReportView1.SetParameter("ISPGSM", "true");
        if (!string.IsNullOrEmpty(Request["ISJSSJ"]))
            ReportView1.SetParameter("ISJSSJ", "true");
        if (!string.IsNullOrEmpty(Request["ISSCWC"]))
            ReportView1.SetParameter("ISSCWSJ", "true");
        if (!string.IsNullOrEmpty(Request["ISRKWC"]))
            ReportView1.SetParameter("ISRKSJ", "true");
        if (!string.IsNullOrEmpty(Request["ISDJZT"]))
            ReportView1.SetParameter("ISDJZT", "true");
        if (!string.IsNullOrEmpty(Request["ISBB"]))
            ReportView1.SetParameter("ISBB", "true");

        if (!string.IsNullOrEmpty(Request["WGDH"]))
            ReportView1.SetParameter("WGDH", Request["WGDH"]);
        if (!string.IsNullOrEmpty(Request["PCH"]))
            ReportView1.SetParameter("PCH", Request["PCH"]);
        if (!string.IsNullOrEmpty(Request["ZJR"]))
            ReportView1.SetParameter("ZJR", Request["ZJR"]);
        if (!string.IsNullOrEmpty(Request["TSXX"]))
            ReportView1.SetParameter("PCINFO", Request["TSXX"]);
        if (!string.IsNullOrEmpty(Request["PCLX"]))
            ReportView1.SetParameter("PCLX", Request["PCLX"]);
        if (!string.IsNullOrEmpty(Request["PCSX"]))
            ReportView1.SetParameter("PCSX", Request["PCSX"]);
        if (!string.IsNullOrEmpty(Request["WLH"]))
            ReportView1.SetParameter("WLH", Request["WLH"]);
        if (!string.IsNullOrEmpty(Request["SCX"]))
            ReportView1.SetParameter("SCX", Request["SCX"]);
        if (!string.IsNullOrEmpty(Request["WCBZ"]))
            ReportView1.SetParameter("WCBZ", Request["WCBZ"]);
        if (!string.IsNullOrEmpty(Request["PH"]))
            ReportView1.SetParameter("PH", Request["PH"]);
        if (!string.IsNullOrEmpty(Request["DP"]))
            ReportView1.SetParameter("DPP", Request["DP"]);
        if (!string.IsNullOrEmpty(Request["GG"]))
            ReportView1.SetParameter("GG", Request["GG"]);
        if (!string.IsNullOrEmpty(Request["SCKS"]))
            ReportView1.SetParameter("PSTIME", Request["SCKS"]);
        if (!string.IsNullOrEmpty(Request["SCJS"]))
            ReportView1.SetParameter("PETIME", Request["SCJS"]);
        if (!string.IsNullOrEmpty(Request["RKWC"]))
            ReportView1.SetParameter("STIME", Request["RKWC"]);
        if (!string.IsNullOrEmpty(Request["RKJS"]))
            ReportView1.SetParameter("ETIME", Request["RKJS"]);
        if (!string.IsNullOrEmpty(Request["PGBZ"]))
            ReportView1.SetParameter("PGBZ", "0");  
    }
}
