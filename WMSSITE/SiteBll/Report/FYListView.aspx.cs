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

public partial class SiteBll_Report_FYListView :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStore();
        }
        this.SetDisplayList1.SCInit(this.grvFYDList, SysBaseConfig.FYQD);
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
    }

    //获取查询条件
    private string GetSqlWhere()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(this.txtFYDH.Text))
        {
            sqlWhere = " FYDH LIKE '%" + this.txtFYDH.Text + "%'";
        }
        if (this.drpStore.SelectedValue != "0")
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " CK ='" + this.drpStore.SelectedValue+"'";
            else
                sqlWhere += " AND CK='" + this.drpStore.SelectedValue + "'";
        }
        if (!string.IsNullOrEmpty(txtKH.Text))
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " khbm like '" + this.txtKH.Text+ "%'";
            else
                sqlWhere += " AND khbm like '" + this.txtKH.Text + "%'";
        }
        if (!string.IsNullOrEmpty(txtCPH.Text))
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " cph like '%" + this.txtCPH.Text + "%'";
            else
                sqlWhere += " AND cph like '%" + this.txtCPH.Text + "%'";
        }
        return sqlWhere;
    }
    //绑定仓库
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

    //绑定GridView
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            string sortEx = this.grvFYDList.Attributes["SortExpression"];
            string sortDirect = this.grvFYDList.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = FYDList.QueryFYQD(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
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

    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetSqlWhere();
            int outCount;
            int pageCount = FYDList.GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
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
        BindGridView();
        return;
    }
    protected void grvFYDList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "JHZL").ToString()))
            {
                string strJHZL = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "JHZL")).ToString("#0.0000");
                e.Row.Cells[12].Text = strJHZL;
            }
            if (!string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "SJZL").ToString()))
            {
                string strSJZL = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SJZL")).ToString("#0.0000");
                e.Row.Cells[14].Text = strSJZL;
            }
        }
    }
    protected void grvFYDList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvFYDList.Attributes["SortExpression"];
            string SortDirection = grvFYDList.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvFYDList.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvFYDList.Columns[i].SortExpression.Trim();
                if (CloExpression == null)
                    continue;
                //找到了排序的列进行处理
                if (SortExpression == CloExpression)
                {
                    string toolTip = (SortDirection == "ASC" ? "升序排列" : "降序排列");
                    string strUnit = (SortDirection == "ASC" ? "5 " : "6 ");
                    TableCell cell = e.Row.Cells[i];
                    Label lblSorted = new Label();
                    lblSorted.Font.Name = "webdings";
                    lblSorted.Font.Size = FontUnit.XSmall;
                    lblSorted.Text = strUnit;
                    cell.Controls.Add(lblSorted);
                    cell.ToolTip = toolTip;
                }
            }
        }
    }
    protected void grvFYDList_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvFYDList.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvFYDList.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvFYDList.Attributes["SortExpression"] = SortExpression;
        this.grvFYDList.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }
}
