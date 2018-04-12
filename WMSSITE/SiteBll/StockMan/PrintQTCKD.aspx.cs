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
using ACCTRUE.WMSBLL.QueryBll;
public partial class SiteBll_StockMan_PrintQTCKD : AccPageBase
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

        string Type = Request["TYPE"];
        string hidCKDH = Request["hidCKDH"];
        switch (Type)
        {
            case "0":
                if (Common.IsOldData)
                {
                    this.ReportView1.ReportPath = "/XGReportO/ReportQTCK";
                }
                else
                    this.ReportView1.ReportPath = "/XGReportC/ReportQTCK";
                break;
            case "1":
                if (Common.IsOldData)
                {
                    this.ReportView1.ReportPath = "/XGReportO/ReportQTCKDJHJ";
                }
                else
                    this.ReportView1.ReportPath = "/XGReportC/ReportQTCKDJHJ";
                break;
            case "2":
                if (Common.IsOldData)
                {
                    this.ReportView1.ReportPath = "/XGReportO/ReportQTCKHJ";
                }
                else
                    this.ReportView1.ReportPath = "/XGReportC/ReportQTCKHJ";
                break;
        }
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;

        switch (Type)
        {
            case "0":
                DataSet ds = QTCKQuery.GetPrintDS("and CKDH='" + hidCKDH + "'");
                if (!string.IsNullOrEmpty(hidCKDH))
                    ReportView1.SetParameter("CKDH", hidCKDH);
                if (ds.Tables[0].Rows[0]["CPH"] != null)
                {
                    ReportView1.SetParameter("CPH", Server.UrlEncode(ds.Tables[0].Rows[0]["CPH"].ToString()));
                }
                if (ds.Tables[0].Rows[0]["SHDW"] != null)
                {
                    ReportView1.SetParameter("SHDW", Server.UrlEncode(ds.Tables[0].Rows[0]["SHDW"].ToString()));
                }
                if (ds.Tables[0].Rows[0]["ZDR"] != null)
                {
                    ReportView1.SetParameter("ZDR", Server.UrlEncode(ds.Tables[0].Rows[0]["ZDR"].ToString()));
                }
                if (ds.Tables[0].Rows[0]["FYSJ"] != null)
                {
                    ReportView1.SetParameter("FYRQ", ds.Tables[0].Rows[0]["FYSJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NCDJ"] != null)
                {
                    ReportView1.SetParameter("NCDJ", ds.Tables[0].Rows[0]["NCDJ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CYS"] != null)
                {
                    ReportView1.SetParameter("CYS", Server.UrlEncode(ds.Tables[0].Rows[0]["CYS"].ToString()));
                }
                if (ds.Tables[0].Rows[0]["AimAdress"] != null)
                {
                    ReportView1.SetParameter("MDD", Server.UrlEncode(ds.Tables[0].Rows[0]["AimAdress"].ToString()));
                }
                if (ds.Tables[0].Rows[0]["ZDRQ"] != null)
                {
                    ReportView1.SetParameter("ZDRQ", ds.Tables[0].Rows[0]["ZDRQ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CK"] != null)
                {
                    ReportView1.SetParameter("CK", ds.Tables[0].Rows[0]["CK"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CKLX"] != null)
                {
                    ReportView1.SetParameter("CKLX", Server.UrlEncode(ds.Tables[0].Rows[0]["CKLX"].ToString()));
                }
                break;
            case "1":
                if (!string.IsNullOrEmpty(Request["CKDH"]))
                    ReportView1.SetParameter("CKDH", Request["CKDH"]);
                if (!string.IsNullOrEmpty(Request["CPH"]))
                    ReportView1.SetParameter("CPH", Request["CPH"]);
                if (!string.IsNullOrEmpty(Request["ncdj"]))
                    ReportView1.SetParameter("ncdj", Request["ncdj"]);
                if (!string.IsNullOrEmpty(Request["CKLX"]))
                    ReportView1.SetParameter("CKLX", Request["CKLX"]);
                if (!string.IsNullOrEmpty(Request["CYS"]))
                    ReportView1.SetParameter("CYS", Request["CYS"]);
                if (!string.IsNullOrEmpty(Request["CK"]))
                    ReportView1.SetParameter("CK", Request["CK"]);
                if (!string.IsNullOrEmpty(Request["status"]))
                    ReportView1.SetParameter("status", Request["status"]);
                if (!string.IsNullOrEmpty(Request["ZDR"]))
                    ReportView1.SetParameter("ZDR", Request["ZDR"]);
                if (!string.IsNullOrEmpty(Request["SHDW"]))
                    ReportView1.SetParameter("SHDW", Request["SHDW"]);
                if (!string.IsNullOrEmpty(Request["ZDRQfrom"]))
                    ReportView1.SetParameter("ZDRQfrom", Request["ZDRQfrom"]);
                if (!string.IsNullOrEmpty(Request["ZDRQto"]))
                    ReportView1.SetParameter("ZDRQto", Request["ZDRQto"]);
                break;
            case "2":
                if (!string.IsNullOrEmpty(Request["CKDH"]))
                    ReportView1.SetParameter("CKDH", Request["CKDH"]);
                if (!string.IsNullOrEmpty(Request["CPH"]))
                    ReportView1.SetParameter("CPH", Request["CPH"]);
                if (!string.IsNullOrEmpty(Request["ncdj"]))
                    ReportView1.SetParameter("ncdj", Request["ncdj"]);
                if (!string.IsNullOrEmpty(Request["CKLX"]))
                    ReportView1.SetParameter("CKLX", Request["CKLX"]);
                if (!string.IsNullOrEmpty(Request["CYS"]))
                    ReportView1.SetParameter("CYS", Request["CYS"]);
                if (!string.IsNullOrEmpty(Request["CK"]))
                    ReportView1.SetParameter("CK", Request["CK"]);
                if (!string.IsNullOrEmpty(Request["status"]))
                    ReportView1.SetParameter("status", Request["status"]);
                if (!string.IsNullOrEmpty(Request["ZDR"]))
                    ReportView1.SetParameter("ZDR", Request["ZDR"]);
                if (!string.IsNullOrEmpty(Request["SHDW"]))
                    ReportView1.SetParameter("SHDW", Request["SHDW"]);
                if (!string.IsNullOrEmpty(Request["ZDRQfrom"]))
                    ReportView1.SetParameter("ZDRQfrom", Request["ZDRQfrom"]);
                if (!string.IsNullOrEmpty(Request["ZDRQto"]))
                    ReportView1.SetParameter("ZDRQto", Request["ZDRQto"]);
                break;
        }
    }
}
