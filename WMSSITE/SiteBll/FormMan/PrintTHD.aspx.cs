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
public partial class SiteBll_FormMan_PrintTHD : AccPageBase
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
            this.ReportView1.ReportPath = "/XGReportO/ReportTHD";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportTHD";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        if (!string.IsNullOrEmpty(Request["ISCK"]))
            ReportView1.SetParameter("ISCK", "true");
        if (!string.IsNullOrEmpty(Request["ISBarcode"]))
            ReportView1.SetParameter("ISBarcode", "true");
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
        if (!string.IsNullOrEmpty(Request["ISZL"]))
            ReportView1.SetParameter("ISZL", "true");
        if (!string.IsNullOrEmpty(Request["ISCZRQ"]))
            ReportView1.SetParameter("ISCZRQ", "true");
        if (!string.IsNullOrEmpty(Request["ISCZRY"]))
            ReportView1.SetParameter("ISCZRY", "true");
        if (!string.IsNullOrEmpty(Request["ISCKDH"]))
            ReportView1.SetParameter("ISCKDH", "true");
        if (!string.IsNullOrEmpty(Request["ISCKRQ"]))
            ReportView1.SetParameter("ISCKRQ", "true");
        if (!string.IsNullOrEmpty(Request["ISRKDH"]))
            ReportView1.SetParameter("ISRKDH", "true");
        if (!string.IsNullOrEmpty(Request["ISKHBM"]))
            ReportView1.SetParameter("ISKHBM", "true");
        if (!string.IsNullOrEmpty(Request["ISNCZDRY"]))
            ReportView1.SetParameter("ISNCZDRY", "true");
        if (!string.IsNullOrEmpty(Request["ISNCZDRQ"]))
            ReportView1.SetParameter("ISNCZDRQ", "true");
        if (!string.IsNullOrEmpty(Request["ISNCBM"]))
            ReportView1.SetParameter("ISNCBM", "true");
        if (!string.IsNullOrEmpty(Request["ISTHDH"]))
            ReportView1.SetParameter("ISTHDH", "true");

        if (!string.IsNullOrEmpty(Request["CK"]))
            ReportView1.SetParameter("CK", Request["CK"]);
        if (!string.IsNullOrEmpty(Request["NCZDRY"]))
            ReportView1.SetParameter("NCZDRY", Request["NCZDRY"]);
        if (!string.IsNullOrEmpty(Request["CKDH"]))
            ReportView1.SetParameter("CKDH", Request["CKDH"]);
        if (!string.IsNullOrEmpty(Request["NCBM"]))
            ReportView1.SetParameter("NCBM", Request["NCBM"]);
        if (!string.IsNullOrEmpty(Request["THDH"]))
            ReportView1.SetParameter("THDH", Request["THDH"]);
        if (!string.IsNullOrEmpty(Request["PH"]))
            ReportView1.SetParameter("PH", Request["PH"]);
        if (!string.IsNullOrEmpty(Request["WLH"]))
            ReportView1.SetParameter("WLH", Request["WLH"]);
        if (!string.IsNullOrEmpty(Request["GG"]))
            ReportView1.SetParameter("GG", Request["GG"]);
        if (!string.IsNullOrEmpty(Request["SX"]))
            ReportView1.SetParameter("SX", Request["SX"]);
        if (!string.IsNullOrEmpty(Request["KHBM"]))
            ReportView1.SetParameter("KHBM", Request["KHBM"]);
        if (!string.IsNullOrEmpty(Request["ICNumber"]))
            ReportView1.SetParameter("ICNumber", Request["ICNumber"]);
        if (!string.IsNullOrEmpty(Request["CZRQfrom"]))
            ReportView1.SetParameter("CZRQfrom", Request["CZRQfrom"]);
        if (!string.IsNullOrEmpty(Request["CZRQto"]))
            ReportView1.SetParameter("CZRQto", Request["CZRQto"]);
    }
}
