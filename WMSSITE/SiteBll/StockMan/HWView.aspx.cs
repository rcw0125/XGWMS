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

public partial class SiteBll_StockMan_HWView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStore();
        }
    }
    private void BindStore()
    {
        DataSet ds = Store.GetList();
        this.drpStore.DataSource = ds;
        this.drpStore.DataBind();
        this.drpStore.Items.Insert(0, new ListItem("请选择", "0"));
        drpStore.SelectedIndex = 0;
    }
}
