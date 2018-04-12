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
using ACCTRUE.WMSBLL.Model;
using ACCTRUE.WMSBLL.QueryBll;

public partial class SiteBll_DataOpern_DataMoveBrowse:AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Common.IsOldData)
            {
                Response.Redirect("../../Error.aspx?ErrorCode=2");
                return;
            }
            this.txtSTime.Text = DateTime.Now.ToShortDateString();
            this.txtETime.Text = DateTime.Now.ToShortDateString();
            try
            {
                this.lblLastTime.Text = DataOperQuery.GetLastDataMoveTime();
            }
            catch
            {
                this.PrintfError("数据访问异常！");
            }
        }
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
    }
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        SetPageCountView();
        BindGridView();
    }

    private bool CheckUI()
    {
        try
        {
            Convert.ToDateTime(this.txtSTime.Text);
            Convert.ToDateTime(this.txtETime.Text);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void BindGridView()
    {
        if (CheckUI())
        {
            String strEndTime = this.txtETime.Text + " 23:59:59";
            try
            {
                DataSet ds = DataOperQuery.GetDataMoveLog(this.txtSTime.Text, strEndTime, "", PageControl1.GetPageSize(), PageControl1.GetCurrPage());
                this.grvDataMoveLog.DataSource = ds;
                this.grvDataMoveLog.DataBind();
            }
            catch
            {
                PrintfError("数据访问错误！");
            }
        }
        else
            this.PrintfError("时间格式不正确！");
    }

    //设置分页控件显示
    private void SetPageCountView()
    {
        if (CheckUI())
        {
            try
            {
                String strEndTime = this.txtETime.Text + " 23:59:59";
                int outCount;
                int pageCount = DataOperQuery.GetPageCount(this.txtSTime.Text,strEndTime, PageControl1.GetPageSize(), out outCount);
                PageControl1.SetInitView(pageCount, outCount);
            }
            catch
            {
                this.PrintfError("数据访问错误，请重试！");
                return;
            }
        }
    }

    //选择分页控件时
    private void SelectPageSizeChange()
    {
        SetPageCountView();
        BindGridView();
        return;
    }
}
