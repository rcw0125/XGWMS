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
using ACCTRUE.WMSBLL.QueryBll;

public partial class SiteBll_FormMan_FYDItem : AccPageBase
{   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request["FYDH"]))
            {
                string strFYDH = Request["FYDH"];
                try
                {
                    DataSet ds = FYDQuery.GetFYDItems(strFYDH);
                    this.grdGridList.DataSource = ds;
                    this.grdGridList.DataBind();
                    this.lblCount.Text = (ds==null)?"0":ds.Tables[0].Rows.Count.ToString();
                    decimal sZL = 0;
                    if (ds != null)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            sZL += string.IsNullOrEmpty(row["ZL"].ToString()) ? 0 : Convert.ToDecimal(row["ZL"]);
                        }
                    }
                    this.lblSZL.Text = sZL.ToString("#0.0000");
                }
                catch(Exception ex)
                {
                    this.PrintfError("数据访问失败！");
                    return;
                }
            }
        }
    }
    protected void grdGridList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strZL = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ZL")).ToString("#0.0000");
            e.Row.Cells[9].Text = strZL;
        }
    }
}