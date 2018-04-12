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

public partial class SiteBll_SysMan_QzsSet : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //bandmgdata();
        banddate();
    }
    private void banddate()
    {
        DataSet ds = QZS.getqzsinfo();
        grvdoor.DataSource = ds;
        grvdoor.DataBind();
    }
    private void bandmgdata()
    {
        if (!IsPostBack)
        {
            DataSet ds = QZS.getqzslist();
            ddlmg.DataSource = ds.Tables[0].DefaultView;
            ddlmg.DataValueField = ds.Tables[0].Columns["qzs_no"].ColumnName;
            ddlmg.DataTextField = ds.Tables[0].Columns["qzs_name"].ColumnName;
            ddlmg.DataBind();
            if (ddlmg.Items.Count > 0)
            {
                htxtmgno.Value = ddlmg.Items[0].Value;
            }
        }
    }
    protected void grvdoor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick",
                        "SelectDataGridRow('grvdoor',this.rowIndex);");
        }
    }
    protected void btnsave_ServerClick(object sender, ImageClickEventArgs e)
    {
        string v = QZS.Saveqzs(hdcno.Value.ToString(),txtdoorno.Value.ToString(), txtdoorname.Value.ToString(),txtip.Value.ToString(),txtport.Value.ToString());
        if (v=="")
        {
            banddate();
            //bandmgdata();
        }
        else
        {
            this.PrintfError("数据访问错误！"+v);
        }
    }
    protected void Image2_ServerClick(object sender, ImageClickEventArgs e)
    {

        bool v = QZS.saveqzscamer(ddlmg.Items[ddlmg.SelectedIndex].Value, hdcno.Value, txtdcname.Value, txtdcip.Value, txtdcport.Value);
        if (v)
        {
            banddate();
        }
    }
    protected void ddlmg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
