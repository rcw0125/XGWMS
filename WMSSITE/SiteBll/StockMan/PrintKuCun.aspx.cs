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
public partial class SiteBll_StockMan_PrintKuCun : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetReport();
    }

    //设置报表
    private void SetReport()
    {
        string type = Request["TYPE"];
        this.ReportView1.ServerUrl = this.ReportURL;
        switch (type)
        {
            case "0":
                if (Common.IsOldData)
                {
                    this.ReportView1.ReportPath = "/XGReportO/ReportKC_PCH";
                }
                else
                {
                    this.ReportView1.ReportPath = "/XGReportC/ReportKC_PCH";
                }
                break;
            case "1":
                if (Common.IsOldData)
                {
                    this.ReportView1.ReportPath = "/XGReportO/ReportKC_HW";
                }
                else
                {
                    this.ReportView1.ReportPath = "/XGReportC/ReportKC_HW";
                }
                break;
            case "2":
                if (Common.IsOldData)
                {
                    this.ReportView1.ReportPath = "/XGReportO/ReportKC_Barcode";
                }
                else
                {
                    this.ReportView1.ReportPath = "/XGReportC/ReportKC_Barcode";
                }
                break;
            case "3":
                if (Common.IsOldData)
                {
                    this.ReportView1.ReportPath = "/XGReportO/ReportKC_WLH";
                }
                else
                {
                    this.ReportView1.ReportPath = "/XGReportC/ReportKC_WLH";
                }
                break;
        }
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        switch (type)
        {
            case "0":
                if (!string.IsNullOrEmpty(Request["ISPCH"]))
                    ReportView1.SetParameter("ISPCH", "true");
                if (!string.IsNullOrEmpty(Request["ISCK"]))
                    ReportView1.SetParameter("ISCK", "true");
                if (!string.IsNullOrEmpty(Request["ISSX"]))
                    ReportView1.SetParameter("ISSX", "true");
                if (!string.IsNullOrEmpty(Request["ISPH"]))
                    ReportView1.SetParameter("ISPH", "true");
                if (!string.IsNullOrEmpty(Request["ISGG"]))
                    ReportView1.SetParameter("ISGG", "true");
                if (!string.IsNullOrEmpty(Request["ISWLH"]))
                    ReportView1.SetParameter("ISWLH", "true");
                if (!string.IsNullOrEmpty(Request["ISSL"]))
                    ReportView1.SetParameter("ISSL", "true");
                if (!string.IsNullOrEmpty(Request["ISSUMZL"]))
                    ReportView1.SetParameter("ISSUMZL", "true");
                if (!string.IsNullOrEmpty(Request["ISRKRQ"]))
                    ReportView1.SetParameter("ISRKRQ", "true");
                if (!string.IsNullOrEmpty(Request["ISWLMC"]))
                    ReportView1.SetParameter("ISWLMC", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE1"]))
                    ReportView1.SetParameter("ISFREE1", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE2"]))
                    ReportView1.SetParameter("ISFREE2", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE3"]))
                    ReportView1.SetParameter("ISFREE3", "true");
                break;
            case "1":
                if (!string.IsNullOrEmpty(Request["ISHW"]))
                    ReportView1.SetParameter("ISHW", "true");
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
                if (!string.IsNullOrEmpty(Request["ISSUMZL"]))
                    ReportView1.SetParameter("ISSUMZL", "true");
                if (!string.IsNullOrEmpty(Request["ISRKRQ"]))
                    ReportView1.SetParameter("ISRKRQ", "true");
                if (!string.IsNullOrEmpty(Request["ISWLMC"]))
                    ReportView1.SetParameter("ISWLMC", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE1"]))
                    ReportView1.SetParameter("ISFREE1", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE2"]))
                    ReportView1.SetParameter("ISFREE2", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE3"]))
                    ReportView1.SetParameter("ISFREE3", "true");
                break;
            case "2":
                if (!string.IsNullOrEmpty(Request["ISBarcode"]))
                    ReportView1.SetParameter("ISBarcode", "true");
                if (!string.IsNullOrEmpty(Request["ISHW"]))
                    ReportView1.SetParameter("ISHW", "true");
                if (!string.IsNullOrEmpty(Request["ISPCH"]))
                    ReportView1.SetParameter("ISPCH", "true");
                if (!string.IsNullOrEmpty(Request["ISWLH"]))
                    ReportView1.SetParameter("ISWLH", "true");
                if (!string.IsNullOrEmpty(Request["ISSX"]))
                    ReportView1.SetParameter("ISSX", "true");
                if (!string.IsNullOrEmpty(Request["ISErrSeason"]))
                    ReportView1.SetParameter("ISErrSeason", "true");
                if (!string.IsNullOrEmpty(Request["ISPH"]))
                    ReportView1.SetParameter("ISPH", "true");
                if (!string.IsNullOrEmpty(Request["ISGG"]))
                    ReportView1.SetParameter("ISGG", "true");
                if (!string.IsNullOrEmpty(Request["ISZL"]))
                    ReportView1.SetParameter("ISZL", "true");
                if (!string.IsNullOrEmpty(Request["ISBZ"]))
                    ReportView1.SetParameter("ISBZ", "true");
                if (!string.IsNullOrEmpty(Request["ISRQ"]))
                    ReportView1.SetParameter("ISRQ", "true");
                if (!string.IsNullOrEmpty(Request["ISWGDH"]))
                    ReportView1.SetParameter("ISWGDH", "true");
                if (!string.IsNullOrEmpty(Request["ISGH"]))
                    ReportView1.SetParameter("ISGH", "true");
                if (!string.IsNullOrEmpty(Request["ISBB"]))
                    ReportView1.SetParameter("ISBB", "true");
                if (!string.IsNullOrEmpty(Request["ISRKType"]))
                    ReportView1.SetParameter("ISRKType", "true");
                if (!string.IsNullOrEmpty(Request["ISRKRY"]))
                    ReportView1.SetParameter("ISRKRY", "true");
                if (!string.IsNullOrEmpty(Request["ISpcinfo"]))
                    ReportView1.SetParameter("ISpcinfo", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE1"]))
                    ReportView1.SetParameter("ISFREE1", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE2"]))
                    ReportView1.SetParameter("ISFREE2", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE3"]))
                    ReportView1.SetParameter("ISFREE3", "true");
                break;
            case "3":
                if (!string.IsNullOrEmpty(Request["ISCK"]))
                    ReportView1.SetParameter("ISCK", "true");
                if (!string.IsNullOrEmpty(Request["ISWLH"]))
                    ReportView1.SetParameter("ISWLH", "true");
                if (!string.IsNullOrEmpty(Request["ISWLMC"]))
                    ReportView1.SetParameter("ISWLMC", "true");
                if (!string.IsNullOrEmpty(Request["ISHW"]))
                    ReportView1.SetParameter("ISHW", "true");
                if (!string.IsNullOrEmpty(Request["ISPCH"]))
                    ReportView1.SetParameter("ISPCH", "true");
                if (!string.IsNullOrEmpty(Request["ISSX"]))
                    ReportView1.SetParameter("ISSX", "true");
                if (!string.IsNullOrEmpty(Request["ISPH"]))
                    ReportView1.SetParameter("ISPH", "true");
                if (!string.IsNullOrEmpty(Request["ISGG"]))
                    ReportView1.SetParameter("ISGG", "true");
                if (!string.IsNullOrEmpty(Request["ISSL"]))
                    ReportView1.SetParameter("ISSL", "true");
                if (!string.IsNullOrEmpty(Request["ISSUMZL"]))
                    ReportView1.SetParameter("ISSUMZL", "true");
                if (!string.IsNullOrEmpty(Request["ISRKRQ"]))
                    ReportView1.SetParameter("ISRKRQ", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE1"]))
                    ReportView1.SetParameter("ISFREE1", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE2"]))
                    ReportView1.SetParameter("ISFREE2", "true");
                if (!string.IsNullOrEmpty(Request["ISFREE3"]))
                    ReportView1.SetParameter("ISFREE3", "true");
                break;
        }

        if (!string.IsNullOrEmpty(Request["CK"]))
            ReportView1.SetParameter("CK", Request["CK"]);
        if (!string.IsNullOrEmpty(Request["PCH"]))
            ReportView1.SetParameter("PCH", Request["PCH"]);
        if (!string.IsNullOrEmpty(Request["SX"]))
            ReportView1.SetParameter("SX", Request["SX"]);
        if (!string.IsNullOrEmpty(Request["WLH"]))
            ReportView1.SetParameter("WLH", Request["WLH"]);
        if (!string.IsNullOrEmpty(Request["FREE1"]))
            ReportView1.SetParameter("FREE1", Server.UrlEncode(Request["FREE1"]));
        if (!string.IsNullOrEmpty(Request["FREE2"]))
            ReportView1.SetParameter("FREE2", Server.UrlEncode(Request["FREE2"]));
        if (!string.IsNullOrEmpty(Request["FREE3"]))
            ReportView1.SetParameter("FREE3", Server.UrlEncode(Request["FREE3"]));
        if (!string.IsNullOrEmpty(Request["HW"]))
            ReportView1.SetParameter("HW", Request["HW"]);
        if (!string.IsNullOrEmpty(Request["pcinfo"]))
            ReportView1.SetParameter("pcinfo", Request["pcinfo"]);
        if (!string.IsNullOrEmpty(Request["PHMH"]))
            ReportView1.SetParameter("PHMH", Request["PHMH"]);
        if (!string.IsNullOrEmpty(Request["PH"]))
            ReportView1.SetParameter("PH", Request["PH"]);
        if (!string.IsNullOrEmpty(Request["Barcode"]))
            ReportView1.SetParameter("Barcode", Request["Barcode"]);
        if (!string.IsNullOrEmpty(Request["RQfrom"]))
            ReportView1.SetParameter("RQfrom", Request["RQfrom"]);
        if (!string.IsNullOrEmpty(Request["RQto"]))
            ReportView1.SetParameter("RQto", Request["RQto"]);
        if (!string.IsNullOrEmpty(Request["WRQfrom"]))
            ReportView1.SetParameter("WRQfrom", Request["WRQfrom"]);
        if (!string.IsNullOrEmpty(Request["WRQto"]))
            ReportView1.SetParameter("WRQto", Request["WRQto"]);
        if (!string.IsNullOrEmpty(Request["GG"]))
            ReportView1.SetParameter("GG", Request["GG"]);
        if (!string.IsNullOrEmpty(Request["GGcopy"]))
            ReportView1.SetParameter("GGcopy", Request["GGcopy"]);
    }
}
