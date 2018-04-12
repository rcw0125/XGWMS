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
public partial class SiteBll_FormMan_PrintZKD : AccPageBase
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
            this.ReportView1.ReportPath = "/XGReportO/ReportZKD";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportZKD";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        if (!string.IsNullOrEmpty(Request["ISZKDH"]))
            ReportView1.SetParameter("ISZKDH", "true");
        if (!string.IsNullOrEmpty(Request["ISCPH"]))
            ReportView1.SetParameter("ISCPH", "true");
        if (!string.IsNullOrEmpty(Request["ISPCH"]))
            ReportView1.SetParameter("ISPCH", "true");
        if (!string.IsNullOrEmpty(Request["ISWLH"]))
            ReportView1.SetParameter("ISWLH", "true");
        if (!string.IsNullOrEmpty(Request["ISSX"]))
            ReportView1.SetParameter("ISSX", "true");
        if (!string.IsNullOrEmpty(Request["ISYCK"]))
            ReportView1.SetParameter("ISYCK", "true");
        if (!string.IsNullOrEmpty(Request["ISYHW"]))
            ReportView1.SetParameter("ISYHW", "true");
        if (!string.IsNullOrEmpty(Request["ISMBCK"]))
            ReportView1.SetParameter("ISMBCK", "true");
        if (!string.IsNullOrEmpty(Request["ISMBHW"]))
            ReportView1.SetParameter("ISMBHW", "true");
        if (!string.IsNullOrEmpty(Request["ISFJLDW"]))
            ReportView1.SetParameter("ISFJLDW", "true");
        if (!string.IsNullOrEmpty(Request["ISZJLDW"]))
            ReportView1.SetParameter("ISZJLDW", "true");
        if (!string.IsNullOrEmpty(Request["ISJHSL"]))
            ReportView1.SetParameter("ISJHSL", "true");
        if (!string.IsNullOrEmpty(Request["ISJHZL"]))
            ReportView1.SetParameter("ISJHZL", "true");
        if (!string.IsNullOrEmpty(Request["ISOutNum"]))
            ReportView1.SetParameter("ISOutNum", "true");
        if (!string.IsNullOrEmpty(Request["ISOutZL"]))
            ReportView1.SetParameter("ISOutZL", "true");
        if (!string.IsNullOrEmpty(Request["ISInNum"]))
            ReportView1.SetParameter("ISInNum", "true");
        if (!string.IsNullOrEmpty(Request["ISInZL"]))
            ReportView1.SetParameter("ISInZL", "true");
        if (!string.IsNullOrEmpty(Request["ISSL"]))
            ReportView1.SetParameter("ISSL", "true");
        if (!string.IsNullOrEmpty(Request["ISZL"]))
            ReportView1.SetParameter("ISZL", "true");
        if (!string.IsNullOrEmpty(Request["ISzhxlb"]))
            ReportView1.SetParameter("ISzhxlb", "true");
        if (!string.IsNullOrEmpty(Request["ISoutstatus"]))
            ReportView1.SetParameter("ISoutstatus", "true");
        if (!string.IsNullOrEmpty(Request["ISCKOperator"]))
            ReportView1.SetParameter("ISCKOperator", "true");
        if (!string.IsNullOrEmpty(Request["ISCKTime"]))
            ReportView1.SetParameter("ISCKTime", "true");
        if (!string.IsNullOrEmpty(Request["ISstatus"]))
            ReportView1.SetParameter("ISstatus", "true");
        if (!string.IsNullOrEmpty(Request["ISRKOperator"]))
            ReportView1.SetParameter("ISRKOperator", "true");
        if (!string.IsNullOrEmpty(Request["ISRKTime"]))
            ReportView1.SetParameter("ISRKTime", "true");
        if (!string.IsNullOrEmpty(Request["ISWLMC"]))
            ReportView1.SetParameter("ISWLMC", "true");

        if (!string.IsNullOrEmpty(Request["ZKDH"]))
            ReportView1.SetParameter("ZKDH", Request["ZKDH"]);
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
        if (!string.IsNullOrEmpty(Request["SCK"]))
            ReportView1.SetParameter("SCK", Request["SCK"]);
        if (!string.IsNullOrEmpty(Request["TCK"]))
            ReportView1.SetParameter("TCK", Request["TCK"]);
        if (!string.IsNullOrEmpty(Request["CPH"]))
            ReportView1.SetParameter("CPH", Request["CPH"]);
        if (!string.IsNullOrEmpty(Request["OutStatus"]))
            ReportView1.SetParameter("OutStatus", Request["OutStatus"]);
        if (!string.IsNullOrEmpty(Request["Status"]))
            ReportView1.SetParameter("Status", Request["Status"]);
        if (!string.IsNullOrEmpty(Request["OtVsIn"]))
            ReportView1.SetParameter("OtVsIn", Request["OtVsIn"]);
        if (!string.IsNullOrEmpty(Request["CKfromTime"]))
            ReportView1.SetParameter("CKfromTime", Request["CKfromTime"]);
        if (!string.IsNullOrEmpty(Request["CKtoTime"]))
            ReportView1.SetParameter("CKtoTime", Request["CKtoTime"]);
        if (!string.IsNullOrEmpty(Request["RKfromTime"]))
            ReportView1.SetParameter("RKfromTime", Request["RKfromTime"]);
        if (!string.IsNullOrEmpty(Request["RKtoTime"]))
            ReportView1.SetParameter("RKtoTime", Request["RKtoTime"]);
    }
}
