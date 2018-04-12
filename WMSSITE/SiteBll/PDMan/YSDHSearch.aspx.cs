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
public partial class SiteBll_PDMan_YSDHSearch : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCK();
            this.hidDJLX.Value = Request["DJLX"].ToString();
            this.hidState.Value = Request["State"];
            this.hidPDDH.Value = Request["PDDH"];
        }
    }

    #region 查询
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckUI())
        {
            BindGridView();
        }
        else
        {
            this.PrintfError("时间格式有误，请重试！");
            return;
        }
    }
    #endregion

    #region 初始化页面时绑定仓库下拉列表
    private void BindCK()
    {
        try
        {
            DataSet ds = Store.GetList("");
            if (ds != null)
            {
                this.drpCK.DataSource = ds;
                this.drpCK.DataTextField = "CKID";
                this.drpCK.ToolTip = "仓库";
                this.drpCK.DataValueField = "CKID";
                this.drpCK.DataBind();
                this.drpCK.Items.Insert(0, "请选择");
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("仓库绑定出现错误，请重试！");
            return;
        }
    }
    #endregion

    #region 绑定查询列表
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            DataSet ds = PDParam.GetPDDNC(sql);
            this.grvYSDHList.DataSource = ds;
            this.grvYSDHList.DataBind();
        }
        catch
        {
            this.PrintfError("查询时绑定出现错误");
            return;
        }
    }
    #endregion

    #region 拼写查询字符串
    private string GetSqlWhere()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(this.txtYSDH.Text))
        {
            sqlWhere += " YSDH like '%" + this.txtYSDH.Text.Trim() + "%' ";
        }
        if ((!string.IsNullOrEmpty(this.drpCK.SelectedValue)) && (this.drpCK.SelectedValue != "请选择"))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " and CK='" + this.drpCK.SelectedValue.Trim() + "'";
            }
            else
                sqlWhere += " CK ='" + this.drpCK.SelectedValue.Trim() + "'";
        }
        if (!string.IsNullOrEmpty(this.PDRQStart.Text.Trim()))
        {
            string MakeStartTime = this.PDRQStart.Text.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND PDRQ >='" + MakeStartTime + "'";
            }
            else
                sqlWhere += " PDRQ >='" + MakeStartTime + "'";
        }
        if (!string.IsNullOrEmpty(this.PDRQEnd.Text.Trim()))
        {
            string MakeEndTime = this.PDRQEnd.Text.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND PDRQ <='" + MakeEndTime + "'";
            }
            else
                sqlWhere += " PDRQ <='" + MakeEndTime + "'";
        }
        return sqlWhere;
    }
    #endregion

    #region 检查时间格式是否正确
    private bool CheckUI()
    {
        try
        {
            if (!string.IsNullOrEmpty(this.PDRQStart.Text.Trim()))
                Convert.ToDateTime(this.PDRQStart.Text.Trim());
            if (!string.IsNullOrEmpty(this.PDRQEnd.Text.Trim()))
                Convert.ToDateTime(this.PDRQEnd.Text.Trim());
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    protected void grvYSDHList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grvYSDHList.PageIndex = e.NewPageIndex;
        BindGridView();
    }
}
