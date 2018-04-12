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
using System.Text;
using ACCTRUE.WMSBLL.QueryBll;
using ACCTRUE.WMSBLL;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_StockMan_YYLQuery :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpCK.Attributes.Add("onchange", "ChangeCK();");
            this.drpSX.Attributes.Add("onchange", "ChangeSX();");
            this.drpPH.Attributes.Add("onchange", "ChangePH();");
            this.drpCopyGG.Attributes.Add("onchange", "ChangeCopyGG();");
            this.drpGG.Attributes.Add("onchange", "ChangeGG();");
        }
    }
    private string GetSqlstr()
    {
        string sqlstr = "";
        //仓库
        if (!string.IsNullOrEmpty(hidCK.Value))
        {
            sqlstr += " CK=" + hidCK.Value;
        }
        //属性
        if (!string.IsNullOrEmpty(hidSX.Value))
        {
            if (!string.IsNullOrEmpty(sqlstr))
            {
                sqlstr += " AND SX='" + hidSX.Value + "'";
            }
            else
            {
                sqlstr += " SX='" + hidSX.Value + "'";
            }
        }
        //牌号

        if(!string.IsNullOrEmpty(hidPH.Value))
        {

                if (!string.IsNullOrEmpty(sqlstr))
                {
                    sqlstr += " AND PH like '%" + hidPH.Value + "%'";
                }
                else
                {
                    sqlstr += " PH like '%" + hidPH.Value + "%'";
                }

        }
        //规格
        //规格
        //1.GG为真，COPYGG为真
        if (!string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(hidCopyGG.Value))
        {
            if (!string.IsNullOrEmpty(sqlstr))
            {
                sqlstr += " AND GG>='" + this.hidGG.Value + "' AND GG<='" + this.hidCopyGG.Value + "'";
            }
            else
            {
                sqlstr += " GG>='" + this.hidGG.Value + "' AND GG<='" + this.hidCopyGG.Value + "'";
            }

        }
        //2.GG为真，COPYGG不为真
        if (!string.IsNullOrEmpty(this.hidGG.Value) && string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            if (!string.IsNullOrEmpty(sqlstr))
            {
                sqlstr += " AND GG='" + this.hidGG.Value.Trim() + "'";
            }
            else
            {
                sqlstr += " GG='" + this.hidGG.Value.Trim() + "'";
            }

        }
        //3.GG不为真,COPYGG为真
        if (string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            if (!string.IsNullOrEmpty(sqlstr))
            {
                sqlstr += " AND GG='" + this.hidCopyGG.Value.Trim() + "'";
            }
            else
            {
                sqlstr += " GG='" + this.hidCopyGG.Value.Trim() + "'";
            }     

        }

        return sqlstr;    
    }
//重置
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        hidCK.Value = "";
        hidCopyGG.Value = "";
        hidGG.Value = "";
        hidPH.Value = "";
        hidSX.Value = "";
        drpPH.Text = "";
        drpGG.Text = "";
        drpCopyGG.Text = "";
        this.chkCK.Checked = false;
        this.chkGG.Checked = false;
        this.chkPH.Checked = false;
        this.chkSX.Checked = false;
    }

    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        SetReport();
    }

    //设置报表
    private void SetReport()
    {
        this.ReportView1.ServerUrl = this.ReportURL;
        if (Common.IsOldData)
        {
            this.ReportView1.ReportPath = "/XGReportO/ReportYYL";
        }
        else
            this.ReportView1.ReportPath = "/XGReportC/ReportYYL";
        ReportView1.Parameters = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.DocMap = Acctrue.WM_WES.ReportingServices.ReportView.multiState.False;
        ReportView1.Toolbar = Acctrue.WM_WES.ReportingServices.ReportView.multiState.True;

        if (!this.chkConfigCK.Checked)
            ReportView1.SetParameter("ISCK", "true");
        if (!this.chkConfigPH.Checked)
            ReportView1.SetParameter("ISPH", "true");
        if (!this.chkConfigGG.Checked)
            ReportView1.SetParameter("ISGG", "true");
        if (!this.chkConfigSX.Checked)
            ReportView1.SetParameter("ISSX", "true");
        if (!this.chkConfigWLH.Checked)
            ReportView1.SetParameter("ISWLH", "true");
        if (!this.chkConfigKCSL.Checked)
            ReportView1.SetParameter("ISKCSL", "true");
        if (!this.chkConfigKCZL.Checked)
            ReportView1.SetParameter("ISKCZL", "true");
        if (!this.chkConfigYYSL.Checked)
            ReportView1.SetParameter("ISYYSL", "true");
        if (!this.chkConfigYYZL.Checked)
            ReportView1.SetParameter("ISYYZL", "true");
        if (!this.chkConfigZXSL.Checked)
            ReportView1.SetParameter("ISZXSL", "true");
        if (!this.chkConfigZXZL.Checked)
            ReportView1.SetParameter("ISZXZL", "true");
        if (!this.chkConfigZKYYSL.Checked)
            ReportView1.SetParameter("ISZKYYSL", "true");
        if (!this.chkConfigZKYYZL.Checked)
            ReportView1.SetParameter("ISZKYYZL", "true");
        if (!this.chkConfigZKZXSL.Checked)
            ReportView1.SetParameter("ISZKZXSL", "true");
        if (!this.chkConfigZKZXZL.Checked)
            ReportView1.SetParameter("ISZKZXZL", "true");
        if (!this.chkConfigKYSL.Checked)
            ReportView1.SetParameter("ISKYSL", "true");
        if (!this.chkConfigKYZL.Checked)
            ReportView1.SetParameter("ISKYZL", "true");

        if (this.chkCK.Checked&&!string.IsNullOrEmpty(this.hidCK.Value))
            ReportView1.SetParameter("CK", this.hidCK.Value.Trim());
        if (this.chkPH.Checked&&!string.IsNullOrEmpty(this.drpPH.Text))
            ReportView1.SetParameter("PH", this.drpPH.Text.Trim());
        if (this.chkSX.Checked && !string.IsNullOrEmpty(this.hidSX.Value))
            ReportView1.SetParameter("SX", this.hidSX.Value.Trim());
        if (this.chkGG.Checked)
        {
            if (!string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
            {
                ReportView1.SetParameter("GG", this.hidGG.Value.Trim());
                ReportView1.SetParameter("GGend", this.hidCopyGG.Value.Trim());
            }
            if (!string.IsNullOrEmpty(this.hidGG.Value) && string.IsNullOrEmpty(this.hidCopyGG.Value))
            {
                ReportView1.SetParameter("GG", this.hidGG.Value.Trim());
                ReportView1.SetParameter("GGend", this.hidGG.Value.Trim());
            }
            if (string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
            {
                ReportView1.SetParameter("GG", this.hidCopyGG.Value.Trim());
                ReportView1.SetParameter("GGend", this.hidCopyGG.Value.Trim());
            }
        }
    }
}
