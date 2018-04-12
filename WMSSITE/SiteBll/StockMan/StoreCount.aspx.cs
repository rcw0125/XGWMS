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

public partial class SiteBll_StockMan_StoreCount :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ReportView1.ServerUrl = this.ReportURL;
       
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/StoreQuery";
        }
        else
        {
            this.ReportView1.ReportPath = "/XGReportC/StoreQuery";
        }
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
    }
}
