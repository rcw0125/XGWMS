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
using ACCTRUE.WMSBLL.QueryBll;
using ACCTRUE.WMSBLL.Model;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_StockMan_Query_QTCK :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinddrpCK();
            BinddrpCKLX();
            BinddrpMDD();
            BinddrpNCDJ();
            BinddrpPCH();
            BinddrpZDR();
            string strdate = DateTime.Now.ToShortDateString();
            txtZDRQ1.Text = strdate;
            txtZDRQ2.Text = strdate;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Write(sql);
        BindgrvCKDMX();
    }
    //绑定仓库
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
    //绑定出库类型
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
    //绑定单据
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
            this.drpNCDJ.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }

    //绑定制单人
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


    //绑定目的地
    private void BinddrpMDD()
    {
        try
        {
            DataSet ds = QTCKQuery.GetCHE_QTCK("AimAdress", "");
            if (ds != null)
            {
                this.drpMDD.DataSource = ds;
                this.drpMDD.DataTextField = "AimAdress";
                this.drpMDD.DataValueField = "AimAdress";
                this.drpMDD.DataBind();
            }
            this.drpMDD.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    //绑定批次号
    private void BinddrpPCH()
    {
        try
        {
            DataSet ds = QTCKQuery.GetCHE_QTCKPCH("pch","", "");
            if (ds != null)
            {
                this.drpPCH.DataSource = ds;
                this.drpPCH.DataTextField = "pch";
                this.drpPCH.DataValueField = "pch";
                this.drpPCH.DataBind();
            }
            this.drpPCH.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    //绑定gvdview
    private void BindgrvCKDMX()
    {
        try
        {
            string sql = GetQueryStr();
            DataSet liuds = QTCKQuery.QTCK_Query(sql);
            this.grvCKDMX.DataSource = liuds;
            this.grvCKDMX.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    private string GetQueryStr()
    {
        string Querystr = "";
        if (!string.IsNullOrEmpty(txtCKDH.Text))
        {
            Querystr += " and ckdh like '%" + txtCKDH.Text + "%'";
        }
        if (!string.IsNullOrEmpty(txtCPH.Text))
        {
            Querystr += " and cph like '%" + txtCPH.Text + "%'";
        }
        if (drpMDD.SelectedValue != "请选择" && !string.IsNullOrEmpty(drpMDD.SelectedValue))
        {
            Querystr += " and AimAdress like '%" + drpMDD.SelectedValue.ToString() + "%'";
        }
        if (drpCK.SelectedValue != "请选择" && !string.IsNullOrEmpty(drpCK.SelectedValue))
        {
            Querystr += " and ck='" + drpCK.SelectedValue.ToString() + "'";
        }
        if (drpStatus.SelectedValue != "请选择" && !string.IsNullOrEmpty(drpStatus.SelectedValue))
        {
            Querystr += " and STATUS=" + drpStatus.SelectedValue.ToString();
        }
        if (drpZDR.SelectedValue != "请选择" && !string.IsNullOrEmpty(drpZDR.SelectedValue))
        {
            Querystr += " and zdr='" + drpZDR.SelectedValue.ToString() + "'";
        }
        if (drpCKLX.SelectedValue != "请选择" && !string.IsNullOrEmpty(drpCKLX.SelectedValue))
        {
            Querystr += " and cklx='" + drpCKLX.SelectedValue.ToString() + "'";
        }
        if (drpNCDJ.SelectedValue != "请选择" && !string.IsNullOrEmpty(drpNCDJ.SelectedValue))
        {
            Querystr += " and NCDJ='" + drpNCDJ.SelectedValue.ToString() + "'";
        }
        if (!string.IsNullOrEmpty(this.hidZDRQ.Value))
        {
            string ZDRQ1 = txtZDRQ1.Text + " 00:00:00";
            string ZDRQ2 = txtZDRQ2.Text + " 23:59:59";
            Querystr += " and (zdrq>='" + ZDRQ1 + "' and zdrq<='" + ZDRQ2 + "')";
        }
        if (drpPCH.SelectedValue != "请选择")
        {
            string strpch = "";
            DataSet ds = QTCKQuery.GetCHE_QTCKPCH("ckdh", "pch", this.drpPCH.SelectedValue);

            if (ds != null)
            {
                int i = 0;
                while (i < ds.Tables[0].Rows.Count)
                {
                    strpch += ds.Tables[0].Rows[i][0].ToString() + ",";
                    i++;
                }
                strpch = strpch.Remove(strpch.Length - 1, 1);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    Querystr += " and ckdh in('" + strpch + "')";
                }
            }
        }
        return Querystr;
    }

}
