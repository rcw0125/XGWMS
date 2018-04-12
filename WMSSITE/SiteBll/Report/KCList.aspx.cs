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
using ACCTRUE.WMSBLL.QueryBll;
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_Report_KCList :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindStore();
    }
    private void BindStore()
    {
        try
        {
            DataSet ds = Store.GetList();
            this.drpStore.DataSource = ds;
            this.drpStore.DataBind();
            this.drpStore.Items.Insert(0, new ListItem("请选择", "0"));
            drpStore.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    protected void drpStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drpStore.SelectedValue != "0")
            BindPCH(this.drpStore.SelectedValue);
    }

    private void BindPCH(string storeID)
    {
        try
        {
            DataSet ds = StoreQuery.GetPCH(storeID);
            if (ds != null)
            {
                this.drpPCH.Items.Clear();
                this.drpPCH.DataSource = ds;
                this.drpPCH.DataTextField = "PCH";
                this.drpPCH.DataValueField = "PCH";
                this.drpPCH.DataBind();
                this.drpPCH.Items.Insert(0, new ListItem("请选择", "0"));
                this.drpPCH.SelectedValue = "0";
            }
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        if (this.drpStore.SelectedValue == "0")
        {
            this.PrintfError("请选择仓库！");
            return;
        }
        SetReport();
    }
    //设置报表
    private void SetReport()
    {
        string store = this.drpStore.SelectedValue;
        string pch = "";
        if (this.drpPCH.SelectedValue == "0")
        {
            pch = Server.UrlEncode("全部");
        }
        else
            pch = this.drpPCH.SelectedValue;
        string orderKey = this.drpOrderBy.SelectedValue;
        
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/KCList";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/KCList";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        ReportView1.SetParameter("ck", store);
        ReportView1.SetParameter("PCH", pch);
        ReportView1.SetParameter("OrderKey", orderKey);
        string[] strCKInfos = this.drpStore.SelectedItem.Text.Split('|');
        string strckName = "("+strCKInfos[0].Trim()+")"+strCKInfos[1];
        ReportView1.SetParameter("ckName", Server.UrlEncode(strckName));
    }
}
