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
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.Model;
//徐慧杰
public partial class SiteBll_ICMan_FYDCheck : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        string khbm = Request["khbm"];
        string cph = Request["cph"];
        if (khbm != "0")
        {
            string sql = " khbm = '" + khbm + "'";
            ICParam icpara = new ICParam();
            DataSet ds = icpara.GetListFYD(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.grdInfo.DataSource = ds;
                this.grdInfo.DataBind();
            }
            else
            {
                this.PrintfError("该IC卡没有发运单信息");
            }
        }
        else
        {
            string sql = " cph = '" + cph + "'";
            ICParam icpara = new ICParam();
            DataSet ds = icpara.GetListFYD(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.grdInfo.DataSource = ds;
                this.grdInfo.DataBind();
            }
            else
            {
                this.PrintfError("该IC卡没有发运单信息");
            }
        }
    }
}
