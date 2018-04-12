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

public partial class SiteBll_FormMan_WGDItems :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["WGDH"] != null)
            {
                string strWGDH = Request["WGDH"];
                try
                {
                    DataSet ds = WGDQuery.GetWGDItems(strWGDH);
                    this.grdGridList.DataSource = ds;
                    this.grdGridList.DataBind();
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
