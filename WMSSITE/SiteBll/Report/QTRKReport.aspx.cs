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
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_Report_QTRKReport :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinddrpCK();
            BinddrpGG();
            BinddrpPH();
            BindRKCK();
            BindRKHW();
        }

    }
    //绑定drop出库类型
    private void BinddrpCK()
    {
        try
        {
            DataSet ds = QTRKReport.GetCKLX();
            if (ds != null)
            {
                this.drpCKType.DataSource = ds;
                this.drpCKType.DataTextField = "flag";
                this.drpCKType.ToolTip = "请选择仓库类型";
                this.drpCKType.DataValueField = "flag";
                this.drpCKType.DataBind();
            }
            this.drpCKType.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    //牌号
    private void BinddrpPH()
    {
        try
        {

            DataSet ds = QTRKReport.GetCKPH();
            if (ds != null)
            {
                this.drpPH.DataSource = ds;
                this.drpPH.DataTextField = "PH";
                this.drpPH.ToolTip = "请选择牌号";
                this.drpPH.DataValueField = "PH";
                this.drpPH.DataBind();
            }
            this.drpPH.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错");
            return;
        }
    }
    //规格
    private void BinddrpGG()
    {
        try
        {
            DataSet ds = QTRKReport.GetCKGG();
            if (ds != null)
            {
                this.drpGG.DataSource = ds;
                this.drpGG.DataTextField = "GG";
                this.drpGG.ToolTip = "请选择规格";
                this.drpGG.DataValueField = "GG";
                this.drpGG.DataBind();
            }
            this.drpGG.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错");
            return;
        }
    }
    //仓库
    private void BindRKCK()
    {
        //try
        //{
            DataSet ds = QTRKReport.GetCKID();
            if (ds != null)
            {
                this.drpRKCK.DataSource = ds;
                this.drpRKCK.DataTextField = "CK";
                this.drpRKCK.ToolTip = "请选择仓库";
                this.drpRKCK.DataValueField = "CK";
                this.drpRKCK.DataBind();
            }
            this.drpRKCK.Items.Insert(0, "请选择");
        //}
        //catch
        //{
        //    this.PrintfError("访问数据出错");
        //    return;
        //}
    }
    //货位
    private void BindRKHW()
    {
        //try
        //{
        string ckid = this.drpRKCK.SelectedValue;
        if(ckid=="请选择")
        {
            ckid = "";
        }
            DataSet ds = QTRKReport.GetCKHW(ckid);
            if (ds != null)
            {
                this.drpRKHW.DataSource = ds;
                this.drpRKHW.DataTextField = "hwid";
                this.drpRKHW.ToolTip = "请选择货位";
                this.drpRKHW.DataValueField = "hwid";
                this.drpRKHW.DataBind();
            }
            this.drpRKHW.Items.Insert(0, "请选择");
        //}
        //catch
        //{
        //    this.PrintfError("访问数据出错");
        //    return;
        //}
    }
    private string Getsqlstr()
    {
        string sqlstr = "";
        if(this.drpCKType.SelectedIndex!=0)
        {
            sqlstr+=" AND flag='"+this.drpCKType.SelectedValue+"'";
        }
        if (!string.IsNullOrEmpty(this.txtDJuHao.Text))
        {
            sqlstr += " AND fydh='" + this.txtDJuHao.Text.Trim().ToString()+"'";
        }
        if (!string.IsNullOrEmpty(txtPCH.Text))
        {
            sqlstr += " AND pch='" + this.txtPCH.Text.Trim().ToString()+"'";
        }
        if (!string.IsNullOrEmpty(txtWLH.Text))
        {
            sqlstr += " AND wlh='" + this.txtWLH.Text.Trim().ToString()+"'";
        }
        if (this.drpPH.SelectedIndex != 0)
        {
            sqlstr += " AND ph='" + this.drpPH.SelectedValue+"'";
        }
        if (this.drpGG.SelectedIndex != 0)
        {
            sqlstr += " AND gg='" + this.drpGG.SelectedValue+"'";
        }
        if (this.drpSX.SelectedValue != "0")
        {
            sqlstr += " AND sx='" + this.drpSX.SelectedValue+"'";
        }
        if (!string.IsNullOrEmpty(this.txtDJuanHao.Text))
        {
            sqlstr += " AND barcode='" + this.txtDJuanHao.Text.Trim().ToString()+"'";
        }
        return sqlstr;
    }
    //查询
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (this.drpCKType.SelectedIndex == 0)
        {
            this.PrintfError("请指定出库类型！");
            return;
        }
        string sql = Getsqlstr();
        Response.Write(sql);
        SetPageCountView();
        BindGridView();
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
    private void SelectPageSizeChange()
    {

        SetPageCountView();
        BindGridView();
        return;
    }
    //设置分页控件显示
    private void SetPageCountView()
    {
        //try
        //{
        string sqlWhere = Getsqlstr();
        int outCount;
        int pageCount = QTRKReport.GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
        PageControl1.SetInitView(pageCount, outCount);
        //}
        //catch
        //{
        //    this.PrintfError("数据访问错误，请重试！");
        //    return;
        //}
    }
    //绑定
    private void BindGridView()
    {
        //try
        //{
        string sql = Getsqlstr();
        DataSet ds=QTRKReport.GetQueryYTRK(sql, "", PageControl1.GetPageSize(), PageControl1.GetCurrPage());
        this.grvQTRK.DataSource = ds;
        this.grvQTRK.DataBind();

        //}
        //catch (Exception ex)
        //{
        //    String strEx = ex.Message;
        //    this.PrintfError("数据访问错误，请重试！");
        //}
    }

    protected void drpRKCK_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRKHW();
    }
}
