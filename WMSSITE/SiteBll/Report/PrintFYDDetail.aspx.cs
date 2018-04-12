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
using ACCTRUE.WMSBLL.ReportBll;

public partial class SiteBll_Report_PrintFYDDetail :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strFydh = "";
            string strCPH = "";
            string strType = "";
            string strKHname = "";
            string strJBR = this.CUSER.UserName;
            string strRQ = DateTime.Now.ToShortDateString();
            if (!string.IsNullOrEmpty(Request["FYDH"]))
                strFydh = Request["FYDH"];
            if (!string.IsNullOrEmpty(Request["TYPE"]))
                strType = Request["TYPE"];
            if (!string.IsNullOrEmpty(Request["CPH"]))
                strCPH = Request["CPH"];
            if (!string.IsNullOrEmpty(Request["KHNAME"]))
                strKHname = Request["KHNAME"];
            BindGridView(strFydh);
            this.lblCH.Text = strCPH;
            if (strType == "1")
                this.lblType.Text = "汽车";
            if (strType == "2")
                this.lblType.Text = "火车";
            this.lblUnit.Text = strKHname;
            this.lblName.Text = strJBR;
            this.lblDate.Text = strRQ;
        }
    }
    private void BindGridView(string strFydh)
    {
        try
        {
            DataSet ds = FYDList.GetFYDDetail(strFydh);
            decimal strSL = 0;
            decimal strZL = 0;
            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if(!string.IsNullOrEmpty(row["sl"].ToString()))
                        strSL+=Convert.ToDecimal(row["sl"]);
                    if(!string.IsNullOrEmpty(row["zl"].ToString()))
                        strZL+=Convert.ToDecimal(row["zl"].ToString());
                }
            }
            this.lblSL.Text=Convert.ToInt32(strSL).ToString();
            this.lblZL.Text=strZL.ToString("#0.0000");
            this.grdFYDetail.DataSource = ds;
            this.grdFYDetail.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
    protected void grdFYDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strSZL = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ZL")).ToString("#0.0000");
            e.Row.Cells[4].Text = strSZL;
        }
    }
}
