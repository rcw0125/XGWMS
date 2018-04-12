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
using System.Text;
using ACCTRUE.WMSBLL.QueryBll;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_StockMan_PICIQuery :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindgrvRKJL);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange1);

        this.PageControl2.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindgrvCKJL);
        this.PageControl2.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange2);
    }
    private void SelectPageSizeChange1()
    {

        SetPageCountView1();
        BindgrvRKJL();
        return;
    }
    private void SelectPageSizeChange2()
    {

        SetPageCountView2();
        BindgrvCKJL();
        return;
    }
    //设置分页控件显示
    private void SetPageCountView1()
    {
        try
        {
            string sqlWhere = GetSqlStr();
            int outCount;
            int pageCount = PICIQuery.GetPageCount1(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    private void SetPageCountView2()
    {
        try
        {
            string sqlWhere = GetSqlStr();
            int outCount;
            int pageCount = PICIQuery.GetPageCount2(sqlWhere, PageControl2.GetPageSize(), out outCount);
            PageControl2.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(txtPCH.Text))
        {
            this.PrintfError("请输入批次号");
            return;
        }
        else
        {
            SetPageCountView1();
            BindgrvRKJL();
            SetPageCountView2();
            BindgrvCKJL();
        }
    }
    private string GetSqlStr()
    {
        string sqlstr = "";
        sqlstr = " PCH like '%" + txtPCH.Text.Trim() + "%'";
        return sqlstr;
    }
    //绑定
    private void BindgrvRKJL()
    {
        try
        {
            string sql = GetSqlStr();
            DataSet ds = PICIQuery.GetRKJL(sql, "", PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvRKJL.DataSource = ds;
            this.grvRKJL.DataBind();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    //绑定
    private void BindgrvCKJL()
    {
        try
        {
            string sql = GetSqlStr();
            DataSet ds = PICIQuery.GetCKJL(sql, "", PageControl2.GetPageSize(), PageControl2.GetCurrPage());
            this.grvCKJL.DataSource = ds;
            this.grvCKJL.DataBind();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
}
