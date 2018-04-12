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
using ACCTRUE.WMSBLL.Model;
using ACCTRUE.WMSBLL;

public partial class SiteBll_CheckQu_infobarcode :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetReportURL();
        }
    }

    private void SetReportURL()
    {
        this.ReportView1.ServerUrl = this.ReportURL;
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;

        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/InfoBar";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/InfoBar";

        if (!string.IsNullOrEmpty(Request["ck"]))
            ReportView1.SetParameter("CK", Request["ck"]);
        if (!string.IsNullOrEmpty(Request["sx"]))
            ReportView1.SetParameter("SX", Server.UrlEncode(Request["sx"]));
        if (!string.IsNullOrEmpty(Request["wlh"]))
            ReportView1.SetParameter("WLH", Request["wlh"]);
        if (!string.IsNullOrEmpty(Request["ph"]))
            ReportView1.SetParameter("PH", Server.UrlEncode(Request["ph"]));
        if (!string.IsNullOrEmpty(Request["hw"]))
            ReportView1.SetParameter("HW", Request["hw"]);
        if (!string.IsNullOrEmpty(Request["gg"]))
            ReportView1.SetParameter("GG", Server.UrlEncode(Request["gg"]));
        if (!string.IsNullOrEmpty(Request["bb"]))
            ReportView1.SetParameter("BB", Server.UrlEncode(Request["bb"]));
        if (!string.IsNullOrEmpty(Request["gh"]))
            ReportView1.SetParameter("GH", Request["gh"]);
        if (!string.IsNullOrEmpty(Request["ErrSeason"]))
            ReportView1.SetParameter("ErrSeason", Request["ErrSeason"]);
        if (!string.IsNullOrEmpty(Request["SCXBM"]))
            ReportView1.SetParameter("SCXBM", Request["SCXBM"]);
        if (!string.IsNullOrEmpty(Request["pcinfo"]))
            ReportView1.SetParameter("pcinfo", Request["pcinfo"]);
        if (!string.IsNullOrEmpty(Request["barcode"]))
            ReportView1.SetParameter("barcode", Server.UrlEncode(Request["barcode"]));
        if (!string.IsNullOrEmpty(Request["free1"]))
            ReportView1.SetParameter("free1", Server.UrlEncode(Request["free1"]));
        if (!string.IsNullOrEmpty(Request["free2"]))
            ReportView1.SetParameter("free2", Server.UrlEncode(Request["free2"]));
        if (!string.IsNullOrEmpty(Request["free3"]))
            ReportView1.SetParameter("free3", Server.UrlEncode(Request["free3"]));

        if (!string.IsNullOrEmpty(Request["MPCH"]))
            ReportView1.SetParameter("MPCH", Server.UrlEncode(Request["MPCH"]));
        if (!string.IsNullOrEmpty(Request["MIPCH"]))
            ReportView1.SetParameter("MIPCH", Server.UrlEncode(Request["MIPCH"]));
        if (!string.IsNullOrEmpty(Request["PCH"]))
            ReportView1.SetParameter("PCH", Request["PCH"]);
        if (!string.IsNullOrEmpty(Request["MP"]))
            ReportView1.SetParameter("MP", Server.UrlEncode(Request["MP"]));
        if (!string.IsNullOrEmpty(Request["MIP"]))
            ReportView1.SetParameter("MIP", Request["MIP"]);
    }
}
