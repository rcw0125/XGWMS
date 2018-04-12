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
public partial class SiteBll_FormMan_PrintYWD : AccPageBase
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
            this.ReportView1.ReportPath = "/XGReportO/ReportYWD";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportYWD";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        if (!string.IsNullOrEmpty(Request["ISYWDH"]))
            ReportView1.SetParameter("ISYWDH", "true");
        if (!string.IsNullOrEmpty(Request["ISCK"]))
            ReportView1.SetParameter("ISCK", "true");
        if (!string.IsNullOrEmpty(Request["ISSHW"]))
            ReportView1.SetParameter("ISSHW", "true");
        if (!string.IsNullOrEmpty(Request["ISTHW"]))
            ReportView1.SetParameter("ISTHW", "true");
        if (!string.IsNullOrEmpty(Request["ISBarcode"]))
            ReportView1.SetParameter("ISBarcode", "true");
        if (!string.IsNullOrEmpty(Request["ISPCH"]))
            ReportView1.SetParameter("ISPCH", "true");
        if (!string.IsNullOrEmpty(Request["ISWLH"]))
            ReportView1.SetParameter("ISWLH", "true");
        if (!string.IsNullOrEmpty(Request["ISSX"]))
            ReportView1.SetParameter("ISSX", "true");
        if (!string.IsNullOrEmpty(Request["ISPH"]))
            ReportView1.SetParameter("ISPH", "true");
        if (!string.IsNullOrEmpty(Request["ISGG"]))
            ReportView1.SetParameter("ISGG", "true");
        if (!string.IsNullOrEmpty(Request["ISZL"]))
            ReportView1.SetParameter("ISZL", "true");
        if (!string.IsNullOrEmpty(Request["ISCZRY"]))
            ReportView1.SetParameter("ISCZRY", "true");
        if (!string.IsNullOrEmpty(Request["ISCZRQ"]))
            ReportView1.SetParameter("ISCZRQ", "true");

        if (!string.IsNullOrEmpty(Request["YWDH"]))
            ReportView1.SetParameter("YWDH", Request["YWDH"]);
        if (!string.IsNullOrEmpty(Request["CK"]))
            ReportView1.SetParameter("CK", Request["CK"]);
        if (!string.IsNullOrEmpty(Request["SHW"]))
            ReportView1.SetParameter("SHW", Request["SHW"]);
        if (!string.IsNullOrEmpty(Request["THW"]))
            ReportView1.SetParameter("THW", Request["THW"]);
        if (!string.IsNullOrEmpty(Request["Barcode"]))
            ReportView1.SetParameter("Barcode", Request["Barcode"]);
        if (!string.IsNullOrEmpty(Request["PCH"]))
            ReportView1.SetParameter("PCH", Request["PCH"]);
        if (!string.IsNullOrEmpty(Request["WLH"]))
            ReportView1.SetParameter("WLH", Request["WLH"]);
        if (!string.IsNullOrEmpty(Request["SX"]))
            ReportView1.SetParameter("SX", Request["SX"]);
        if (!string.IsNullOrEmpty(Request["PH"]))
            ReportView1.SetParameter("PH", Request["PH"]);
        if (!string.IsNullOrEmpty(Request["GG"]))
            ReportView1.SetParameter("GG", Request["GG"]);
        if (!string.IsNullOrEmpty(Request["CZRY"]))
            ReportView1.SetParameter("CZRY", Request["CZRY"]);
        if (!string.IsNullOrEmpty(Request["CZRQfrom"]))
            ReportView1.SetParameter("CZRQfrom", Request["CZRQfrom"]);
        if (!string.IsNullOrEmpty(Request["CZRQto"]))
            ReportView1.SetParameter("CZRQto", Request["CZRQto"]);
    }
}
