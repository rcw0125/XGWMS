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
using ACCTRUE.WMSBLL;
using System.Data.SqlClient;
using System.Collections.Generic;
public partial class SiteBll_SysMan_ProductInfo : AccPageBase
{
    public string WLCOUNT;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindGrid();
        }
    }
    //绑定gridview1
    private void BindGrid()
    {
        try
        {
            DataSet ds = WlbaseInfo.GetList("");
            if (ds != null)
            {
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
                WLCOUNT = WlbaseInfo.GetWLCount().ToString();
            }
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
     
    }
    //导入物料基础数据
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        int result = WlbaseInfo.InportWLFromNC();
        if (result == -1)
        {
            this.PrintfError("NC数据库访问错误!");
            return;
        }
        if (result == 1)
        {
            this.PrintfError("数据库访问错误!");
            return;
        }
        try
        {
            BindGrid();
            this.PrintfError("物料数据导入成功！");
        }
        catch
        {
            this.PrintfError("数据访问错误");
        }
    }
       
}
