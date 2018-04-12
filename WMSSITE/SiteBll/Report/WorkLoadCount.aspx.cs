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
using ACCTRUE.WMSBLL.ReportBll;
using System.Web.Caching;
using ACCTRUE.WMSBLL;

public partial class SiteBll_Report_WorkLoadCount :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUser();
            BindOperType();
            this.txtStartTime.Text = DateTime.Now.ToShortDateString();
            this.txtEndTime.Text = this.txtStartTime.Text;
        }
    }

    private void BindUser()
    {
        try
        {
            DataSet ds = ACCTRUE.WMSBLL.Model.User.GetList("");
            this.drpOpern.DataSource = ds;
            this.drpOpern.DataBind();
            this.drpOpern.Items.Insert(0, new ListItem("请选择", "0"));
            this.drpOpern.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    private void BindOperType()
    {
        try
        {
            DataSet ds=null;
            if (Cache["OPERTYPE"] != null)
            {
                ds = (DataSet)Cache["OPERTYPE"];
            }
            else
            {
                ds = WorkLoadQ.GetOperType();
                Cache.Add("OPERTYPE", ds, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Normal, null);
            }
            this.drpType.DataSource = ds;
            this.drpType.DataBind();
            this.drpType.Items.Insert(0, new ListItem("请选择", "0"));
            this.drpType.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckUI())
        {
            SetReprotUrl();
        }
    }

    private void SetReprotUrl()
    {
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/WorkLoad";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/WorkLoad";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;
        string oper = "";
        if (this.drpOpern.SelectedIndex == 0)
            oper = "全部";
        else
            oper = this.drpOpern.SelectedValue;
        string type = "";
        if (this.drpType.SelectedIndex == 0)
            type = "全部";
        else
            type = this.drpType.SelectedValue;
        ReportView1.SetParameter("Oper", Server.UrlEncode(oper));
        ReportView1.SetParameter("OperType", Server.UrlEncode(type));
        ReportView1.SetParameter("StartDate", this.txtStartTime.Text);
        ReportView1.SetParameter("EndDate", this.txtEndTime.Text) ;
    }

    private bool CheckUI()
    {
        try
        {
            Convert.ToDateTime(this.txtStartTime.Text);
            Convert.ToDateTime(this.txtEndTime.Text);
            return true;
        }
        catch
        {
            return false;
        }
    }

}
