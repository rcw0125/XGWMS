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
public partial class SiteBll_ICMan_KHSearch : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void BindKHParam()
    {
        try
        {
            DataSet ds = CustomerParam.GetList("");
            if (ds != null)
            {
                this.grdKHInfo.DataSource = ds;
                this.grdKHInfo.DataBind();
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CustomerParam cstpara = new CustomerParam();
            if (!string.IsNullOrEmpty(this.txtKHID.Text))
            {
                cstpara.KHID = this.txtKHID.Text.Trim();
            }
            if (!string.IsNullOrEmpty(this.txtKHName.Text))
            {
                cstpara.KHName = this.txtKHName.Text.Trim();
            }
            DataSet ds = cstpara.GetListByEnter();
            if (ds != null)
            {
                this.grdKHInfo.DataSource = ds;
                this.grdKHInfo.DataBind();
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
}
