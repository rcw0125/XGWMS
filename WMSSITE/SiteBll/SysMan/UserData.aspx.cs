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
using System.Data.SqlClient;
using ACCTRUE.WMSBLL.Model;
using ACCTRUE.WMSBLL;
using System.Collections.Generic;
public partial class SiteBll_SysMan_UserData : AccPageBase
{
    public string sumid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            CustomerParam customer = new CustomerParam();
            sumid = KHInfo.GetKHCount().ToString();
            //Response.Write(sumid);
        }
    }
    //绑定Gridview1
    private void BindGrid()
    {
        try
        {
            DataSet ds = CustomerParam.GetList("");
            if (ds != null)
            {
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }
        catch
        {
            this.PrintfError("连接数据库出错，请重试！");
            return;
        }
       
    }
    //设定分页显示
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
       

    //导入客户数据
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        int result = KHInfo.InportKHFromNC();
        if (result == -1)
        {
            this.PrintfError("NC数据库访问错误！");
            return;
        }
        if (result == 1)
        {
            this.PrintfError("数据库访问错误！");
            return;
        }
        KHInfo kh = new KHInfo();
        kh.KHID = "0";
        try
        {
            if (!kh.Exists())
            {
                kh.KHName = "邢台钢铁股份有限公司";
                kh.KHLB = "0";
                kh.KHAdress = "河北邢台";
                kh.Add();
                int khCount = KHInfo.GetKHCount();
                sumid = khCount.ToString();
                this.PrintfError("导入数据成功！");
                BindGrid();
            }
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
}
