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
public partial class SiteBll_PDMan_WPHWlist : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        try
        {
            string CKID = Request["CKID"];
            string YSDH = Request["YSDH"];
            if (!string.IsNullOrEmpty(CKID) && !string.IsNullOrEmpty(YSDH))
            {
                DataSet ds = PDParam.GetHW3DS(YSDH, CKID);
                ListBox1.DataSource = ds;
                ListBox1.DataTextField = "HW";
                ListBox1.DataValueField = "HW";

                ListBox1.DataBind();
            }
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试");
            return;
        }
    }
}
