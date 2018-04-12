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

public partial class SiteBll_CheckQu_QuWGD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Sqlfilter"] != null)
        {
            string sqlfilter = Server.UrlDecode(Request["Sqlfilter"]);
            DataSet ds = QuCheck.QueryWGD(sqlfilter);
            this.grvWGD.DataSource = ds;
            this.grvWGD.DataBind();
        }
    }
    protected void grvWGD_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick",
                        "SelectDataGridRowSpec('grvWGD',this.rowIndex);");
        }
    }
}
