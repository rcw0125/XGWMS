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

public partial class SiteBll_DataOpern_PCHDetail :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["PCH"] != null)
            {
                string strWGDH = Request["PCH"];
                try
                {
                    DataSet ds = DataOperQuery.GetPCHDetail(strWGDH);
                    this.grdPCHDetails.DataSource = ds;
                    this.grdPCHDetails.DataBind();
                }
                catch
                {
                    this.PrintfError("数据访问失败！");
                    return;
                }
            }
        }
    }
}
