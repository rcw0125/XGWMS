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

public partial class SiteBll_Report_MonthPC :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSCX();
            BindYearMonth();
        }
    }

    //绑定生产线
    private void BindSCX()
    {
        try
        {
            DataSet ds = SCX.GetList("");
            this.drpSCX.DataSource = ds;
            this.drpSCX.DataBind();
            this.drpSCX.Items.Insert(0, new ListItem("请选择", "0"));
            this.drpSCX.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }

    private void BindYearMonth()
    {
        for (int year = 2005; year <= DateTime.Now.Year; year++)
        {
            this.drpYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
        }
        this.drpYear.SelectedValue = DateTime.Now.Year.ToString();
        this.drpMonth.SelectedValue = DateTime.Now.Month.ToString();
    }
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        if (this.drpSCX.SelectedValue == "0")
        {
            this.PrintfError("请选择生产线！");
            return;
        }
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/MonthPC";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/MonthPC";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        ReportView1.SetParameter("scx", this.drpSCX.SelectedValue);
        string date = this.drpYear.SelectedValue + "-" + this.drpMonth.SelectedValue + "-01";
        string strSCXname = this.drpSCX.SelectedItem.Text.Split('|')[1].Trim();
        ReportView1.SetParameter("rpdate", date);
        ReportView1.SetParameter("OrderKey", this.drpOrderKey.SelectedValue);
        ReportView1.SetParameter("scxname", Server.UrlEncode(strSCXname));
        ReportView1.SetParameter("username", Server.UrlEncode(this.CUSER.UserName));
    }
}
