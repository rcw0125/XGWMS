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
using ACCTRUE.WMSBLL.QueryBll;
using System.Text;
using ACCTRUE.WMSBLL.DataOper;
using System.IO;
using ACCTRUE.WMSBLL;

public partial class SiteBll_DataOpern_LogDelete :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCK();
            this.txtSTime.Text = DateTime.Now.ToShortDateString();
            this.txtETime.Text = DateTime.Now.ToShortDateString();
            this.checkAll.Attributes.Add("onclick", "checkAllInput();");
            this.imgBtnDelC.Attributes.Add("onclick", "if(!confirm('确定要删除选中日志？')) return false;");
            this.imgBtnDelA.Attributes.Add("onclick", "if(!confirm('确定要删除查询结果的日志信息？')) return false;");
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
    }

    //绑定仓库
    private void BindCK()
    {
        try
        {
            DataSet ds = Store.GetList();
            this.drpCK.DataSource = ds;
            this.drpCK.DataBind();
            this.drpCK.Items.Insert(0, new ListItem("请选择", "0"));
            drpCK.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    private string GetWhere()
    {
        string strWhere = "";
        if (this.drpCK.SelectedValue != "0")
            strWhere += " AND CK='" + this.drpCK.SelectedValue + "' ";
        if (this.drpType.SelectedValue != "0")
            strWhere += " AND DOCType='" + this.drpType.SelectedValue + "' ";
        if (!string.IsNullOrEmpty(this.txtCode.Text))
            strWhere += " AND DOCID LIKE '%" + this.txtCode.Text + "%'";
        if (!string.IsNullOrEmpty(this.txtSTime.Text))
            strWhere += " AND DATEDIFF(day,convert(datetime,'" + this.txtSTime.Text + "',21),ComTime)>=0";
        if (!string.IsNullOrEmpty(this.txtETime.Text))
            strWhere += " AND DATEDIFF(day,convert(datetime,'" + this.txtETime.Text + "',21),ComTime)<=0";
        return strWhere;
    }

    private bool CheckUI()
    {
        try
        {
            Convert.ToDateTime(this.txtSTime.Text);
            Convert.ToDateTime(this.txtETime.Text);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckUI())
        {
            SetPageCountView();
            BindGridView();
        }
        else
            this.PrintfError("时间日期格式不对！");
    }

    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetWhere();
            int outCount;
            int pageCount = DayReport.GetLogPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }

    private void BindGridView()
    {
        try
        {
            string sql = GetWhere();
            DataSet ds = DayReport.QueryLOG(sql, "", this.PageControl1.GetPageSize(), this.PageControl1.GetCurrPage());
            this.grdLog.DataSource = ds;
            this.grdLog.DataBind();
            this.checkAll.Checked = false;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }

    //选择分页控件时
    private void SelectPageSizeChange()
    {
        SetPageCountView();
        BindGridView();
        return;
    }
    protected void grdLog_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strComDes = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ComDes"));
            StringBuilder toolTip = new StringBuilder();
            toolTip.Append("发送结果：" + strComDes);
            e.Row.Attributes["title"] = toolTip.ToString().Trim();

            CheckBox chekBox = (CheckBox)e.Row.Cells[0].FindControl("chk_Delete");
            chekBox.Attributes.Add("onClick", "SelectSinger();");
        }
    }
    protected void imgBtnDelC_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            bool isChecked = false;
            foreach (GridViewRow row in this.grdLog.Rows)
            {
                CheckBox check = (CheckBox)row.Cells[0].FindControl("chk_Delete");
                if (check.Checked)
                {
                    isChecked = true;
                    string docId = row.Cells[1].Text.Trim();
                    DataOperClass.DeleteSingerDoc(docId);
                }
            }
            if (isChecked == false)
            {
                PrintfError("没有选择要删除的日志信息！");
                return;
            }
            this.PrintfError("删除成功！");
            SetPageCountView();
            BindGridView();
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }

    protected void imgBtnDelA_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string sql = GetWhere();
            DataOperClass.DeleteQueryDoc(sql);
            this.PrintfError("删除成功！");
            SetPageCountView();
            BindGridView();
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }
}
