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
using ACCTRUE.WMSBLL.ReportBll;

public partial class Common_SearchKH :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }

    private void BindGrid()
    {
        try
        {
            DataSet ds = FYDList.GetKHInfo(GetSqlWhere());
            this.grvKHList.DataSource = ds;
            this.grvKHList.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }

    private string GetSqlWhere()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(this.txtKHBM.Text))
        {
            sqlWhere += " KHID like '%" + this.txtKHBM.Text.Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(this.txtKHMC.Text))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND KHName like '%" + this.txtKHMC.Text.Trim() + "%'";
            }
            else
                sqlWhere += " KHName like '%" + this.txtKHMC.Text.Trim() + "%'";
        }
        return sqlWhere;
    }
    protected void grvKHList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grvKHList.PageIndex= e.NewPageIndex;
        BindGrid();
    }
}
