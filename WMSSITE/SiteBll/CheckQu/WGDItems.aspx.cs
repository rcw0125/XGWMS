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

public partial class SiteBll_FormMan_WGDItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["PCH"] != null)
            {
                string strPCH = Request["PCH"];
                DataSet ds = QuCheck.GetWGDItems(strPCH);
                this.grdGridList.DataSource = ds;
                this.grdGridList.DataBind();
            }
        }
    }
}
