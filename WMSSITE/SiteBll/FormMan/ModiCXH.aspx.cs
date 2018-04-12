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
using ACCTRUE.WMSBLL.QueryBll;

public partial class SiteBll_FormMan_ModiCXH :AccPageBase
{
    public string fydh;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fydh = Request.QueryString["FYDH"].ToString();
            //Response.Write(fydh);
        }

    }
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        this.txtCXH.Text = "";
    }
    protected void imgBtnQuery_Click1(object sender, ImageClickEventArgs e)
    {
        //Response.Write (fydh);
    }
}
