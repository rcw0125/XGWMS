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
public partial class SiteBll_PDMan_KCadjust : AccPageBase
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
            string YSDH = Request["YSDH"];
            this.hidYSDH.Value = YSDH;
            DataSet ds = PDParam.GetDSkctz(YSDH);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试");
            return;
        }
    }
}
