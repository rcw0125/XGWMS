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
public partial class SiteBll_PDMan_selhw : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.hidYSDH.Value = Request["YSDH"];
            this.hidbarcode.Value = Request["barcode"];
            this.hidpch.Value = Request["pch"];
            this.hidsx.Value = Request["sx"];
            this.hidck.Value = Request["ck"];
            Bind();
        }
    }
    private void Bind()
    {
        try
        {
            string ck = this.hidck.Value.Trim();
            DataSet ds = PDParam.GetDShw(ck);
            if (ds != null)
            {
                this.drpHW.DataSource = ds;
                this.drpHW.DataTextField = "hwid";
                this.drpHW.ToolTip = "货位";
                this.drpHW.DataValueField = "hwid";
                this.drpHW.DataBind();
                this.drpHW.Items.Insert(0, "请选择");
            }
        }
        catch
        {
            this.PrintfError("数据绑定出现错误，请重试");
            return;
        }
    }
}
