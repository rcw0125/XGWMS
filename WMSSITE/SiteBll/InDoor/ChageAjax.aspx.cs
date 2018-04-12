using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_InDoor_ChageAjax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Request["TYPE"]))
                return;
            string icNum = Request["ICNUM"];
            string icPass = Request["ICPASS"];
            ICParam par = new ICParam();
            par.ChangeICPass(icNum, icPass);
        }
    }
}
