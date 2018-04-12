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

public partial class SiteBll_FormMan_DanJuSearch : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddrpCK();
            CopyBindGridView();
        }
    }
    private void binddrpCK()
    {
        try
        {
            DataSet ds=XTZHQuery.GetXTZHCKID();
            if (ds!=null)
            {
                this.drpCK.DataSource=ds;
                this.drpCK.DataTextField = "CKID";
                this.drpCK.DataValueField="CKID";
                this.drpCK.DataBind();
                this.drpCK.Items.Insert(0, "--全部仓库--");
            }

        }
        catch
        {
            this.PrintfError("数据错误！");
            return;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDJCZ.PageIndex = e.NewPageIndex;
        BindGridView();

    }
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlStr();
            DataSet ds = XTZHQuery.GetDJXTZHYC(sql);
            if (ds != null)
            {
                this.grvDJCZ.DataSource = ds;
                this.grvDJCZ.DataBind();
            }
        }
        catch
        {
            this.PrintfError("数据错误！");
            return;
        }
    }
    private void CopyBindGridView()
    {
         try
        {
           
            DataSet ds =XTZHQuery.GetXTZHYC();
            if (ds != null)
            {
                this.grvDJCZ.DataSource = ds;
                this.grvDJCZ.DataBind();
            }
        }
        catch
        {
            this.PrintfError("数据错误！");
            return;
        }
    }
    //查询条件
    private string GetSqlStr()
    {
        string SqlStr = "";

        if (!string.IsNullOrEmpty(txtDJH.Text.Trim().ToString()))
        { //lsqlstr:=Lsqlstr+' and zhdh like '''+trim(edt_djh.Text)+'%''';
            SqlStr += " AND zhdh like '%" + txtDJH.Text.Trim().ToString() + "%'";
        }
        if (!string.IsNullOrEmpty(txtPCH.Text.Trim().ToString()))
        {
            SqlStr += " AND pch like '%" + txtPCH.Text.Trim().ToString() + "%'";
        }
        string ckid = drpCK.SelectedValue.ToString();
        if (ckid.ToString() != "--全部仓库--")
        {
            SqlStr += " AND ck=" + ckid.ToString();
        }
        return SqlStr;
    }
    //查询
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BindGridView();

    }
}
