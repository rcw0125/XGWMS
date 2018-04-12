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
public partial class SiteBll_PDMan_PrintPDCY : AccPageBase
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
            DataSet ds = PDParam.GetDSkctz(YSDH);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CK"].ToString()))
            {
                this.lblCKID.Text = ds.Tables[0].Rows[0]["CK"].ToString();
                this.lblYSDH.Text = YSDH;
                this.lblName.Text = this.CUSER.UserName;
                this.lblDate.Text = DateTime.Now.ToShortDateString();
                this.grdPDCY.DataSource = ds;
                this.grdPDCY.DataBind();
            }
        }
        catch
        {
            this.PrintfError("打开盘点差异页时出错，请重试");
            return;
        }
    }
}
