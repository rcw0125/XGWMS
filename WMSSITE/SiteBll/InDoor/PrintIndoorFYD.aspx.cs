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
public partial class SiteBll_InDoor_PrintIndoorFYD : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetReport();
    }

    private void SetReport()
    {
        string FYDH = "";
        string CPH = "";
        string CZ_User = "";
        string CZ_InUser = "";
        string CZ_OtUser = "";
        string InOt = "";
        string Status = "";
        string RQStart = "";
        string RQEnd = "";
        string REVDATETIMEfrom = "";
        string CZ_InTimefrom = "";
        string CZ_OtTimefrom = "";
        string REVDATETIMEto = "";
        string CZ_InTimeto = "";
        string CZ_OtTimeto = "";

        if (!string.IsNullOrEmpty(Request["FYDH"]))
            FYDH = Request["FYDH"];
        if (!string.IsNullOrEmpty(Request["CPH"]))
            CPH = Request["CPH"];
        if (!string.IsNullOrEmpty(Request["CZ_User"]))
            CZ_User = Request["CZ_User"];
        if (!string.IsNullOrEmpty(Request["InOt"]))
            InOt = Request["InOt"];
        if (!string.IsNullOrEmpty(Request["Status"]))
            Status = Request["Status"];
        if (!string.IsNullOrEmpty(Request["RQStart"]))
            RQStart = Request["RQStart"];
        if (!string.IsNullOrEmpty(Request["RQEnd"]))
            RQEnd = Request["RQEnd"];
        if (FYDH == "请选择")
        {
            FYDH = "";
        }
        if (CZ_User == "请选择")
        {
            CZ_User = "";
        }
        if (Status == "请选择")
        {
            Status = "";
        }



        if (!string.IsNullOrEmpty(RQStart))
        {
            RQStart = RQStart + " 00:00:00";
            if ((!string.IsNullOrEmpty(Status)) && (Status != "请选择"))
            {
                switch (Status)
                {
                    case "0":
                        REVDATETIMEfrom = RQStart;
                        break;
                    case "1":
                        CZ_InTimefrom = RQStart;
                        break;
                    case "2":
                        REVDATETIMEfrom = RQStart;
                        break;
                    case "3":
                        CZ_OtTimefrom = RQStart;
                        break;
                    case "4":
                        REVDATETIMEfrom = RQStart;
                        break;
                    case "5":
                        REVDATETIMEfrom = RQStart;
                        break;
                }
            }
            else
            {
                REVDATETIMEfrom = RQStart;
            }
        }
        if (!string.IsNullOrEmpty(RQEnd))
        {
            RQEnd = RQEnd + " 23:59:59";
            if ((!string.IsNullOrEmpty(Status)) && (Status != "请选择"))
            {
                switch (Status)
                {
                    case "0":
                        REVDATETIMEto = RQEnd;
                        break;
                    case "1":
                        CZ_InTimeto = RQEnd;
                        break;
                    case "2":
                        REVDATETIMEto = RQEnd;
                        break;
                    case "3":
                        CZ_OtTimeto = RQEnd;
                        break;
                    case "4":
                        REVDATETIMEto = RQEnd;
                        break;
                    case "5":
                        REVDATETIMEto = RQEnd;
                        break;
                }
            }
            else
            {
                REVDATETIMEto = RQEnd;
            }
        }
        if ((!string.IsNullOrEmpty(CZ_User))&&(CZ_User!="请选择"))
        {
            switch (InOt)
            {
                case "进":
                    CZ_InUser = CZ_User;
                    break;
                case "出":
                    CZ_OtUser = CZ_User;
                    break;
            }
        }









        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/ReportIndoorFYD";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportIndoorFYD";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        ReportView1.SetParameter("FYDH", Server.UrlEncode(FYDH));
        ReportView1.SetParameter("CPH", Server.UrlEncode(CPH));
        ReportView1.SetParameter("CZ_InUser", Server.UrlEncode(CZ_InUser));
        ReportView1.SetParameter("CZ_OtUser", Server.UrlEncode(CZ_OtUser));
        ReportView1.SetParameter("Status", Server.UrlEncode(Status));
        ReportView1.SetParameter("REVDATETIMEfrom", Server.UrlEncode(REVDATETIMEfrom));
        ReportView1.SetParameter("CZ_InTimefrom", Server.UrlEncode(CZ_InTimefrom));
        ReportView1.SetParameter("CZ_OtTimefrom", Server.UrlEncode(CZ_OtTimefrom));
        ReportView1.SetParameter("REVDATETIMEto", Server.UrlEncode(REVDATETIMEto));
        ReportView1.SetParameter("CZ_InTimeto", Server.UrlEncode(CZ_InTimeto));
        ReportView1.SetParameter("CZ_OtTimeto", Server.UrlEncode(CZ_OtTimeto));
    }
}
