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
public partial class SiteBll_PDMan_PrintPYRK : AccPageBase
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
        try
        {
            string YSDH = Request["YSDH"];
            DataSet ds = PDParam.GetDSpyrk(YSDH);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ck"].ToString()))
            {
                this.lblCKID.Text = ds.Tables[0].Rows[0]["ck"].ToString();
                this.lblYSDH.Text = YSDH;
                this.lblName.Text = this.CUSER.UserName;
                this.lblDate.Text = DateTime.Now.ToShortDateString();
                this.grdPYRK.DataSource = ds;
                this.grdPYRK.DataBind();
            }
        }
        catch
        {
            this.PrintfError("打开盘盈入库打印页面时出错，请重试");
            return;
        }
    }
}
