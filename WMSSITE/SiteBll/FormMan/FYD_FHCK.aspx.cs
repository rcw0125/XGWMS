using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACCTRUE.WMSBLL.QueryBll;
using System.Data;

public partial class SiteBll_FormMan_FYD_FHCK : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strWLH = Request["FYDH"];
            DataSet ds = new DataSet();
            ds = FYDQuery.GetQueryFYDFHCK(strWLH);
            this.grvFYD.DataSource = ds;
            this.grvFYD.DataBind();
        }
    }
}
