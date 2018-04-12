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

public partial class SiteBll_SysMan_ParamSet : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Imagebutton1.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            BindSysParam();
        }
    }

    private void BindSysParam()
    {
        DataSet ds = SysParam.GetList("");
        if (ds != null)
        {
            this.grdInfo.DataSource = ds;
            this.grdInfo.DataBind();
        }
    }
    protected void Imagebutton1_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(this.hidCValue.Value))
        {
            this.PrintfError("没有选择要修改的纪录！");
            this.txtExp.Text = "";
            this.txtValue.Text = "";
            this.hidCValue.Value = "";
            return;
        }
        if (string.IsNullOrEmpty(this.txtValue.Text) || string.IsNullOrEmpty(this.txtExp.Text))
        {
            this.PrintfError("参数值和参数名不能为空！");
            return;
        }
        try
        {
            SysParam parm = new SysParam(this.hidCValue.Value, this.txtValue.Text, this.txtExp.Text);
            parm.Update();
            this.txtExp.Text = "";
            this.txtValue.Text = "";
            this.hidCValue.Value = "";
            BindSysParam();
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
}
