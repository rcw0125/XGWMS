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
using ACCTRUE.WMSBLL.Model;
public partial class SiteBll_PDMan_ZYPDData : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCK();
            BindZDR();

            string strDate = DateTime.Now.ToShortDateString();
            this.MakeStartTime.Text = strDate;
            this.MakeEndTime.Text = strDate;
        }   
    }
    private void BindCK()
    {
        try
        {
            DataSet ds = Store.GetList();
            this.drpCKH.DataSource = ds;
            this.drpCKH.DataBind();
            this.drpCKH.Items.Insert(0, "请选择");
            this.drpCKH.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    private void BindZDR()
    {
        try
        {
            DataSet ds = ZYPdd.GetZDRY();
            this.drpZDR.DataSource = ds;
            this.drpZDR.DataBind();
            this.drpZDR.Items.Insert(0, "请选择");
            this.drpZDR.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    private string GetSqlWhere()
    {

        string sqlWhere = "";
        //仓库ID1
        if (this.chkCKH.Checked && this.drpCKH.SelectedIndex != 0)
        {
            sqlWhere += " AND substring(a.hw,1,3) ='" + this.drpCKH.SelectedValue + "' ";
        }


        //制单人
        if (this.chkZDR.Checked && this.drpZDR.SelectedValue != "0")
        {

            sqlWhere += " AND a.PDUSER='" + this.drpZDR.SelectedValue.Trim() + "'";
        }

        

        //状态
        if (this.chkWCBZ.Checked && this.drpWCBZ.SelectedValue != "-1")
        {
            sqlWhere += " AND a.statue=" + this.drpWCBZ.SelectedValue.Trim();
        }



        //制单日期
        if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeStartTime.Text.Trim()))
        {
            string MakeStartTime = this.MakeStartTime.Text.Trim() + " 00:00:00";
            sqlWhere += " AND a.PDTimeStar >='" + MakeStartTime + "'";
        }
        if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeEndTime.Text.Trim()))
        {
            string MakeEndTime = this.MakeEndTime.Text.Trim() + " 23:59:59";
            sqlWhere += " AND a.PDTimeStar <='" + MakeEndTime + "'";
        }

        return sqlWhere;

    }
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        string sql = GetSqlWhere();
        if (!string.IsNullOrEmpty(sql))
        {
            SetPageCountView();
            BindGridView();
            
            return;
        }
        this.PrintfError("请输入查询条件！");
        return;
    }
    private void SelectPageSizeChange()
    {
            SetPageCountView();
            BindGridView();
            return;
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetSqlWhere();
            int outCount;
            int pageCount = ZYPdd.GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            string sortEx = this.grvFYD.Attributes["SortExpression"];
            string sortDirect = this.grvFYD.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = ZYPdd.GetQueryFYD(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvFYD.DataSource = ds;
            this.grvFYD.DataBind();

        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
}
