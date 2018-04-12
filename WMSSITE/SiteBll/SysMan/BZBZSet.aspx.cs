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

public partial class SiteBll_SysMan_BZBZSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSCX();
        }
    }

    private void BindSCX()
    {
        DataSet ds = SCX.GetList("");
        this.drpProductLine.DataSource = ds;
        this.drpProductLine.DataBind();
        this.drpProductLine.Items.Insert(0, new ListItem("请选择", "0"));
        this.drpProductLine.SelectedIndex = 0;
    }
}
