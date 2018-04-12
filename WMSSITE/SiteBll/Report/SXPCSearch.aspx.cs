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

public partial class SiteBll_Report_SXPCSearch : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPH();
            BindMCPH();
        }
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
    }
    private void SelectPageSizeChange()
    {
        SetPageCountView();
        BindGridView();
        return;
    }
    private void BindMCPH()
    {
        try
        {
            DataSet ds = Sx.GetMCPH();
            this.drpmcph.DataSource = ds;
            this.drpmcph.DataBind();
            this.drpmcph.Items.Insert(0, new ListItem("请选择", "0"));
            drpmcph.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    private void BindPH()
    {
        try
        {
            DataSet ds = Sx.GetPH();
            this.drpph.DataSource = ds;
            this.drpph.DataBind();
            this.drpph.Items.Insert(0, new ListItem("请选择", "0"));
            drpph.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    private string GetSqlWhere()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(this.txtmcpch.Text))
        {
            sqlWhere = " mcpch LIKE '%" + this.txtmcpch.Text + "%'";
        }
        if (this.drpmcph.SelectedValue != "0")
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " mcph ='" + this.drpmcph.SelectedValue + "'";
            else
                sqlWhere += " AND mcph='" + this.drpmcph.SelectedValue + "'";
        }
        if (!string.IsNullOrEmpty(txtpch.Text))
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " pch like '%" + this.txtpch.Text + "%'";
            else
                sqlWhere += " AND pch like '%" + this.txtpch.Text + "%'";
        }
        if (this.drpph.SelectedValue != "0")
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " ph ='" + this.drpph.SelectedValue + "'";
            else
                sqlWhere += " AND ph='" + this.drpph.SelectedValue + "'";
        }
        if (this.cbdysj.Checked)
        {
            if (txtStartTime.Text!="")
            {
                if (string.IsNullOrEmpty(sqlWhere))
                     sqlWhere = " weightrq>='"+txtStartTime.Text+"'";
                 else sqlWhere += " AND weightrq>='" + txtStartTime.Text + "'";
            }
            if (txtEndTime.Text != "")
            {
                if (string.IsNullOrEmpty(sqlWhere))
                     sqlWhere += " weightrq<='" + txtEndTime.Text + "'";
                 else sqlWhere += " AND weightrq<='" + txtEndTime.Text + "'";
            }
        }
        return sqlWhere;
    }
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            string sortEx = this.grvFYDList.Attributes["SortExpression"];
            string sortDirect = this.grvFYDList.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = Sx.QueryInvMC(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvFYDList.DataSource = ds;
            this.grvFYDList.DataBind();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        SetPageCountView();
        BindGridView();
        return;
    }
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetSqlWhere();
            int outCount;
            int pageCount = Sx.GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    protected void grvFYDList_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grvFYDList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grvFYDList_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}
