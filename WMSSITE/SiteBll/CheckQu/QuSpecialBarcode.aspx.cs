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

public partial class SiteBll_CheckQu_QuSpecialBarcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Sqlfilter"] != null)
        {
            string sqlfilter = Server.UrlDecode(Request["Sqlfilter"]);
            DataSet ds = QuCheck.getbarcode("0", sqlfilter);
            this.grdGridList.DataSource = ds;
            this.grdGridList.DataBind();
        }
    }
    protected void grdGridList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick",
                        "SelectDataGridRowSpec('grdGridList',this.rowIndex);");
        }
    }
}
