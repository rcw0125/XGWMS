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
using ACCTRUE.WMSBLL.ReportBll;
using System.Web.Caching;
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.QueryBll;
using System.Text;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_StockMan_Query_print :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinddrpCK();
            BinddrpCKLX();
            BinddrpNCDJ();
            BinddrpCYS();
            BinddrpZDR();
            BinddrpSHDW();
            string strdate = DateTime.Now.ToShortDateString();
            txtZDRQ1.Text = strdate;
            txtZDRQ2.Text = strdate;
            this.hidCKDH.Value = Request["CKDH"];
            if (!string.IsNullOrEmpty(this.hidCKDH.Value))
            {
                string CKDH = this.hidCKDH.Value.Trim();
                DataSet ds = QTCKQuery.GetPrintDS("and CKDH = '" + CKDH + "'");
                this.grvPrintCKDMX.DataSource = ds;
                this.grvPrintCKDMX.DataBind();
                this.frameItem.Attributes["src"] = "PrintQTCKItem.aspx?CKDH=" + CKDH;
            }
        }
    }

    #region 绑定仓库
    private void BinddrpCK()
    {
        try
        {
            DataSet ds = QTCKQuery.GetCKID();
            if (ds != null)
            {
                this.drpCK.DataSource = ds;
                this.drpCK.DataTextField = "CKID";
                this.drpCK.ToolTip = "请选择仓库类型";
                this.drpCK.DataValueField = "CKID";
                this.drpCK.DataBind();
            }
            this.drpCK.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    #endregion

    #region 绑定出库类型
    private void BinddrpCKLX()
    {
        try
        {
            DataSet ds = QTCKQuery.GetCHE_QTCK("cklx", "");
            if (ds != null)
            {
                this.drpCKLX.DataSource = ds;
                this.drpCKLX.DataTextField = "cklx";
                this.drpCKLX.ToolTip = "请选择出库类型";
                this.drpCKLX.DataValueField = "cklx";
                this.drpCKLX.DataBind();
            }
            this.drpCKLX.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    #endregion

    #region 绑定NC单据
    private void BinddrpNCDJ()
    {
        try
        {
            DataSet ds = QTCKQuery.GetCHE_QTCK("ncdj", "");
            if (ds != null)
            {
                this.drpNCDJ.DataSource = ds;
                this.drpNCDJ.DataTextField = "ncdj";
                this.drpNCDJ.DataValueField = "ncdj";
                this.drpNCDJ.DataBind();
            }
            Bestcomy.Web.UI.WebControls.ComboItem value = new Bestcomy.Web.UI.WebControls.ComboItem("请选择");
            this.drpNCDJ.Items.Insert(0, value);
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    #endregion

    #region 绑定承运商
    private void BinddrpCYS()
    {
        try
        {
            DataSet ds2 = QTCKQuery.GetCHE_QTCK("cys", "cys");
            if (ds2 != null)
            {
                this.drpCYS.DataSource = ds2;
                this.drpCYS.DataTextField = "cys";
                this.drpCYS.DataValueField = "cys";
                this.drpCYS.DataBind();
            }
            this.drpCYS.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错");
            return;

        }
    }
    #endregion

    #region 绑定制单人
    private void BinddrpZDR()
    {
        try
        {
            DataSet ds = QTCKQuery.GetCHE_QTCK("ZDR", "");
            if (ds != null)
            {
                this.drpZDR.DataSource = ds;
                this.drpZDR.DataTextField = "ZDR";
                this.drpZDR.DataValueField = "ZDR";
                this.drpZDR.DataBind();
            }
            this.drpZDR.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    #endregion

    #region 收货单位
    private void BinddrpSHDW()
    {
        try
        {
            DataSet ds3 = QTCKQuery.GetCHE_QTCK("shdw", "shdw");
            if (ds3 != null)
            {
                this.drpSHDW.DataSource = ds3;
                this.drpSHDW.DataTextField = "shdw";
                this.drpSHDW.DataValueField = "shdw";
                this.drpSHDW.DataBind();
            }
            this.drpSHDW.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    #endregion

    #region 构造字符串
    /// <summary>
    /// 构造字符串
    /// </summary>
    /// <returns></returns>
    private string GetStrWhere()
    {
        string sqlstr = "";
        if (!string.IsNullOrEmpty(txtCKDH.Text))
        {
            sqlstr += " and ckdh like '%" + txtCKDH.Text + "%'";
        }
        if (!string.IsNullOrEmpty(txtCPH.Text))
        {
            sqlstr += " and cph like '%" + txtCPH.Text + "%'";
        }
        if (!string.IsNullOrEmpty(drpNCDJ.Text)&&drpNCDJ.Text!="请选择")
        {
            sqlstr += " and ncdj like '%" + drpNCDJ.Text.Trim() + "%'";
        }
        if (drpCKLX.SelectedValue != "请选择")
        {
            sqlstr+=" and cklx='"+drpCKLX.SelectedValue+"'";
        }
        if (drpCYS.SelectedValue != "请选择")
        {
            sqlstr += " and cys='" + drpCYS.SelectedValue + "'";
        }
        if (drpCK.SelectedValue != "请选择")
        {
            sqlstr += " and ck='" + drpCK.SelectedValue + "'";
        }
        if (drpStatus.SelectedValue != "请选择")
        {
            sqlstr += " and status='" + drpStatus.SelectedValue + "'";
        }
        if (drpZDR.SelectedValue != "请选择")
        {
            sqlstr += " and zdr='" + drpZDR.SelectedValue + "'";
        }
        if (drpSHDW.SelectedValue != "请选择")
        {
            sqlstr += " and shdw='" + drpSHDW.SelectedValue + "'";
        }
        if (!string.IsNullOrEmpty(this.txtZDRQ1.Text))
        {
            string RKRQ_Start = this.txtZDRQ1.Text.Trim() + " 00:00:00";
            sqlstr += " AND ZDRQ >='" + RKRQ_Start + "'";

        }
        if (!string.IsNullOrEmpty(this.txtZDRQ2.Text))
        {
            string RKRQ_End = this.txtZDRQ2.Text.Trim() + " 23:59:59";
            sqlstr += " AND ZDRQ <='" + RKRQ_End + "'";
        }
        return sqlstr;
    }
    #endregion

    #region 点击进行查询
    protected void btnQuery_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string strWhere = GetStrWhere();
            DataSet ds = QTCKQuery.GetPrintDS(strWhere);
            this.grvPrintCKDMX.DataSource = ds;
            this.grvPrintCKDMX.DataBind();
        }
        catch
        {
            this.PrintfError("查询出现错误");
            return;
        }
    }
    #endregion

    #region 点击打印报表
    protected void BtnPrintOK_Click(object sender, ImageClickEventArgs e)
    {
        string PrintType = this.drpPrintType.SelectedValue;
        string CKDH = this.hidCKDH.Value.Trim();
        if (string.IsNullOrEmpty(CKDH)&&this.drpPrintType.SelectedValue == "0")
        {
            this.PrintfError("当前打印类型必须选中一个其他出库单");
            return;
        }
        string url = CreateUrl(PrintType);
        string strClient = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
        this.WriteClientJava(strClient);
    }
    #endregion

    #region 构造传值Url
    private string CreateUrl(string Type)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("PrintQTCKD.aspx?TYPE=" + Type);
        if (Type == "0")
        {
            sb.Append("&hidCKDH=" + this.hidCKDH.Value.Trim());
        }
        if (!string.IsNullOrEmpty(this.txtCKDH.Text))
        {
            sb.Append("&CKDH=" + txtCKDH.Text.Trim());
        }
        if (!string.IsNullOrEmpty(this.txtCPH.Text))
        {
            sb.Append("&CPH=" + txtCPH.Text);
        }
        if (!string.IsNullOrEmpty(drpNCDJ.Text) && drpNCDJ.Text != "请选择")
        {
            sb.Append("&ncdj=" + drpNCDJ.Text);
        }
        if (drpCKLX.SelectedValue != "请选择")
        {
            sb.Append("&CKLX=" + drpCKLX.SelectedValue);
        }
        if (drpCYS.SelectedValue != "请选择")
        {
            sb.Append("&CYS=" + drpCYS.SelectedValue);
        }
        if (drpCK.SelectedValue != "请选择")
        {
            sb.Append("&CK=" + drpCK.SelectedValue);
        }
        if (drpStatus.SelectedValue != "请选择")
        {
            sb.Append("&status=" + drpStatus.SelectedValue);
        }
        if (drpZDR.SelectedValue != "请选择")
        {
            sb.Append("&ZDR=" + drpZDR.SelectedValue);
        }
        if (drpSHDW.SelectedValue != "请选择")
        {
            sb.Append("&SHDW=" + drpSHDW.SelectedValue);
        }
        if (!string.IsNullOrEmpty(this.txtZDRQ1.Text))
        {
            sb.Append("&ZDRQfrom=" + txtZDRQ1.Text.Trim() + " 00:00:00");
        }
        if (!string.IsNullOrEmpty(this.txtZDRQ2.Text))
        {
            sb.Append("&ZDRQto=" + txtZDRQ2.Text.Trim() + " 23:59:59");
        }

        return sb.ToString();
    }
    #endregion
}
