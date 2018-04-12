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
public partial class SiteBll_PDMan_CuoweiWL :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        try
        {
            string YSDH = Request["YSDH"];
            if (!string.IsNullOrEmpty(YSDH))
            {
                DataSet ds = PDParam.GetCuoweiWLinfo(YSDH);
                if (ds != null)
                {
                    this.GridView1.DataSource = ds;
                    this.GridView1.DataBind();
                }
            }
        }
        catch
        {
            this.PrintfError("数据绑定错误，请重试");
            return;
        }
    }
}
