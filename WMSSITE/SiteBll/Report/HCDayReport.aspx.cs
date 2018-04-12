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
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_Report_HCDayReport :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStore();
            this.txtTime.Text = DateTime.Now.ToShortDateString();
        }
    }
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        BindGridView();
    }
    private void BindStore()
    {
        try
        {
            DataSet ds = Store.GetList();
            this.drpStore.DataSource = ds;
            this.drpStore.DataBind();
            this.drpStore.Items.Insert(0, new ListItem("请选择", "0"));
            drpStore.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    private void BindGridView()
    {
        if (this.drpStore.SelectedValue == "0")
        {
            this.PrintfError("请选择仓库");
            return;
        }
        if (CheckUI())
        {
            try
            {
                DataSet ds = DayReport.GetDayReport(this.drpStore.SelectedValue, this.txtTime.Text, (this.drpOrderBy.SelectedValue == "0") ? "" : this.drpOrderBy.SelectedValue);
                SetSum(ds);
                this.grdDayReport.DataSource = ds;
                this.grdDayReport.DataBind();
            }
            catch
            {
                this.PrintfError("数据访问错误！");
                return;
            }
        }
        else
        {
            this.PrintfError("日期格式不对！");
            return;
        }
    }
    //检查时间时间格式是否正确
    private bool CheckUI()
    {
        try
        {
            DateTime date = Convert.ToDateTime(txtTime.Text);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void SetSum(DataSet ds)
    {
        double qcjs = 0;
        double qczl = 0;
        double rcrjs = 0;
        double rcljs = 0;
        double rcrzl = 0;
        double rclzl = 0;
        double xsrjs = 0;
        double xsljs = 0;
        double xsrzl = 0;
        double xslzl = 0;
        double kcjs = 0;
        double kczl = 0;
        double cljs = 0;
        double clzl = 0;
        double dp = 0;
        double xy = 0;
        double buhe = 0;
        if (ds != null)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                qcjs += Convert.ToDouble(row["qcsl"]);
                qczl += Convert.ToDouble(row["qczl"]);
                rcrjs += Convert.ToDouble(row["rkrjs"]);
                rcljs += Convert.ToDouble(row["rkyljjs"]);
                rcrzl += Convert.ToDouble(row["rkrzl"]);
                rclzl += Convert.ToDouble(row["rkyljzl"]);
                xsrjs += Convert.ToDouble(row["ckrjs"]);
                xsljs += Convert.ToDouble(row["ckyljjs"]);
                xsrzl += Convert.ToDouble(row["ckrzl"]);
                xslzl += Convert.ToDouble(row["ckyljzl"]);
                kcjs += Convert.ToDouble(row["kcsl"]);
                kczl += Convert.ToDouble(row["kczl"]);
                cljs += Convert.ToDouble(row["clsl"]);
                clzl += Convert.ToDouble(row["clzl"]);
                dp += Convert.ToDouble(row["dpsl"]);
                xy += Convert.ToDouble(row["xysl"]);
                buhe += Convert.ToDouble(row["bhgsl"]);
            }
        }
        this.lblSqcjs.Text = qcjs.ToString();
        this.lblSqczl.Text = qczl.ToString();
        this.lblSrcrjs.Text = rcrjs.ToString();
        this.lblSrklzl.Text = rcrzl.ToString();
        this.lblSrkljs.Text = rcljs.ToString();
        this.lblSrklzl.Text = rclzl.ToString();
        this.lblXrjs.Text = xsrjs.ToString();
        this.lblXrzl.Text = xsrzl.ToString();
        this.lblXljs.Text = xsljs.ToString();
        this.lblXlzl.Text = xslzl.ToString();
        this.lblKCjs.Text = kcjs.ToString();
        this.lblKCzl.Text = kczl.ToString();
        this.lblCljs.Text = cljs.ToString();
        this.lblClzl.Text = clzl.ToString();
        this.lblDp.Text = dp.ToString();
        this.lblXY.Text = xy.ToString();
        this.lblBhg.Text = buhe.ToString();
    }
    protected void grdDayReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strQczl = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "qczl")).ToString("#0.0000");
            string strRkrzl = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "rkrzl")).ToString("#0.0000");
            string strRkljzl = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "rkyljzl")).ToString("#0.0000");
            string strCkrzl = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ckrzl")).ToString("#0.0000");
            string strCkyljzl = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ckyljzl")).ToString("#0.0000");
            string strKczl = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "kczl")).ToString("#0.0000");
            string strClzl = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "clzl")).ToString("#0.0000");

            e.Row.Cells[3].Text = strQczl;
            e.Row.Cells[6].Text = strRkrzl;
            e.Row.Cells[7].Text = strRkljzl;
            e.Row.Cells[10].Text = strCkrzl;
            e.Row.Cells[11].Text = strCkyljzl;
            e.Row.Cells[13].Text = strKczl;
            e.Row.Cells[15].Text = strClzl;
        }
    }
}
