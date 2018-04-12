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

public partial class SiteBll_DataOpern_DataReturn :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Common.IsOldData)
            {
                Response.Redirect("../../Error.aspx?ErrorCode=3");
                return;
            }
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindPCH);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
    }
    protected void grdPCH_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onClick", "SelectDataGridRow('grdPCH',"+ e.Row.RowIndex.ToString()+")");

            ImageButton imgBtnMod = (ImageButton)e.Row.FindControl("imgBtnReturn");
            string strPCH = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PCH"));
            imgBtnMod.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            imgBtnMod.CommandArgument = strPCH.Trim();
        }
    }

    private void BindPCH()
    {
        try
        {
            DataSet ds = DataOperQuery.GetAllPCH(this.txtPCH.Text, "", PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grdPCH.DataSource = ds;
            this.grdPCH.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        SetPageCountView();
        BindPCH();
        return;
    }

    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            int outCount;
            int pageCount = DataOperQuery.GetAllPCHPageCount(this.txtPCH.Text, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }

    //选择分页控件时
    private void SelectPageSizeChange()
    {
        SetPageCountView();
        BindPCH();
        return;
    }

    protected void grdPCH_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string strPCH = (string)e.CommandArgument;
            if (e.CommandName == "imgBtnReturn")
            {
                int i=DataOperQuery.DataReturn(strPCH);
                if (i == -1)
                {
                    this.PrintfError("执行失败");
                }
                else
                {
                    PrintfError("回迁成功!");
                }
                BindPCH();
            }
        }
        catch
        {
            this.PrintfError("数据访问失败，请重试！");
            return;
        }
    }
}
