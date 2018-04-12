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
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_FormMan_QTHD :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpCKH.Attributes.Add("onchange", "ChangeCKH();");
            this.drpZDR.Attributes.Add("onchange", "ChangeZDR();");
            this.drpFYDH.Attributes.Add("onchange", "ChangeFYDH();");
            this.drpBM.Attributes.Add("onchange", "ChangeBM();");
            this.drpTHDH.Attributes.Add("onchange", "ChangeTHDH();");
            this.drpPH.Attributes.Add("onchange", "ChangePH();");
            this.drpWLH.Attributes.Add("onchange", "ChangeWlh();");
            this.drpGG.Attributes.Add("onchange", "ChangeGG();");
            this.drpSX.Attributes.Add("onchange", "ChangeSX();");
            this.drpKHH.Attributes.Add("onchange", "ChangeKHH();");
            this.txtICKH.Attributes.Add("onchange", "ChangeICKH();");
            string strDate = DateTime.Now.ToShortDateString();
            TuiHuo_Start.Text = strDate;
            TuiHuo_End.Text = strDate;            
        }
        this.SetDisplayList1.SCInit(this.grvTHD, SysBaseConfig.THD_Q_PAGE);
    }
    private string GetSqlTHD()
    {
        string Sql_THD = "";
        //仓库
        if (!string.IsNullOrEmpty(this.hidCKH.Value))
        {
            Sql_THD += " CK ='" + hidCKH.Value + "' ";
        }
        //制单人
        if (!string.IsNullOrEmpty(this.hidZDR.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND NCZDRY='" + this.hidZDR.Value.Trim() + "'";
            }
            else
                Sql_THD += " NCZDRY ='" + this.hidZDR.Value.Trim() + "'";
        }
        //发运单
        if (!string.IsNullOrEmpty(this.hidFYDH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND CKDH like '%" + this.hidFYDH.Value.Trim() + "%'";
            }
            else
                Sql_THD += " CKDH like '%" + this.hidFYDH.Value.Trim() + "%'";
        }
        //部门
        if (!string.IsNullOrEmpty(this.hidBM.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND NCBM='" + this.hidBM.Value.Trim() + "'";
            }
            else
                Sql_THD += " NCBM ='" + this.hidBM.Value.Trim() + "'";
        }
        //退货单
        if (!string.IsNullOrEmpty(this.hidTHDH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND THDH like '%" + this.hidTHDH.Value.Trim() + "%'";
            }
            else
                Sql_THD += " THDH like '%" + this.hidTHDH.Value.Trim() + "%'";
        }
        //牌号
        if (!string.IsNullOrEmpty(this.hidPH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND PH like '%" + this.hidPH.Value.Trim() + "%'";
            }
            else
                Sql_THD += " PH like '%" + this.hidPH.Value.Trim() + "%'";
        }
        //物料号
        if (!string.IsNullOrEmpty(this.hidWLH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND WLH like '%" + this.hidWLH.Value.Trim() + "%'";
            }
            else
                Sql_THD += " WLH like '%" + this.hidWLH.Value.Trim() + "%'";
        }
        //规格
        if (!string.IsNullOrEmpty(this.hidGG.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND GG like '%" + this.hidGG.Value.Trim() + "%'";
            }
            else
                Sql_THD += " GG like '%" + this.hidGG.Value.Trim() + "%'";
        }
        //属性
        if (!string.IsNullOrEmpty(this.hidSX.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND SX like '%" + this.hidSX.Value.Trim() + "%'";
            }
            else
                Sql_THD += " SX like '%" + this.hidSX.Value.Trim() + "%'";
        } 
        //客户号
        if (!string.IsNullOrEmpty(this.hidKHH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND KHBM like '%" + this.hidKHH.Value.Trim() + "%'";
            }
            else
                Sql_THD += " KHBM ='%" + this.hidKHH.Value.Trim() + "%'";
        }
        //IC卡号
        if (!string.IsNullOrEmpty(this.hidICKH.Value)) 
        {
            string ickhbm = "ACCTRUEWMS";
            try
            {
                DataSet ds = THDQuery.GetTHDIC(this.hidICKH.Value.Trim());
                if (ds != null)
                {
                    ickhbm = ds.Tables[0].Rows[0]["KHID"].ToString();
                }
            }
            catch
            {
                this.PrintfError("访问数据错误！");
            }
            if(!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD+=" and KHBM='"+ickhbm+"'";
            }
            else
            {
                Sql_THD+=" KHBM='"+ickhbm+"'";
            }
        }

        //退货日期
        if (this.chkTuiHuoRQ.Checked && !string.IsNullOrEmpty(this.TuiHuo_Start.Text))
        {
            string TuiHuo_Start = this.TuiHuo_Start.Text.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND CZRQ >='" + TuiHuo_Start + "'";
            }
            else
                Sql_THD += " CZRQ >='" + TuiHuo_Start + "'";
        }
        if (this.chkTuiHuoRQ.Checked && !string.IsNullOrEmpty(this.TuiHuo_End.Text.Trim()))
        {
            string TuiHuo_End = this.TuiHuo_End.Text.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND CZRQ <='" + TuiHuo_End + "'";
            }
            else
                Sql_THD += " CZRQ >='" + TuiHuo_End + "'";
        }
        //自由项1
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND vfree1 like '%" + this.txtFree1.Text.Trim() + "%'";
            }
            else
                Sql_THD += " vfree1 like '%" + this.txtFree1.Text.Trim() + "%'";
        }
        //自由项2
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND vfree2 like '%" + this.txtFree2.Text.Trim() + "%'";
            }
            else
                Sql_THD += " vfree2 like '%" + this.txtFree2.Text.Trim() + "%'";
        }
        //自由项3
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            if (!string.IsNullOrEmpty(Sql_THD))
            {
                Sql_THD += " AND vfree3 like '%" + this.txtFree3.Text.Trim() + "%'";
            }
            else
                Sql_THD += " vfree3 like '%" + this.txtFree3.Text.Trim() + "%'";
        }
        return Sql_THD;
    }
    //帮定grvTHD
    private void BindGridView()
    {
        try
        {
            string sql =GetSqlTHD();
            string sortEx = this.grvTHD.Attributes["SortExpression"];
            string sortDirect = this.grvTHD.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = THDQuery.GetQueryTHD(sql, strSort, PageControl2.GetPageSize(), PageControl2.GetCurrPage());
            this.grvTHD.DataSource = ds;
            this.grvTHD.DataBind();

            this.SetDisplayList1.InitSetListControl(this.grvTHD, SysBaseConfig.THD_Q_PAGE);
            this.SetDisplayList1.SetGridViewDisplay(grvTHD);
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }

    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            string sql =GetSqlTHD();
            int outCount;
            int pageCount = THDQuery.GetPageCount(sql,PageControl2.GetPageSize(), out outCount);
            PageControl2.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl2.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl2.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
    private void SelectPageSizeChange()
    {
        try
        {
            SetPageCountView();
            BindGridView();
            return;
        }
        catch
        {
            this.PrintfError("数据访问失败!");
            return;
        }
    }
    //查询
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            SetPageCountView();
            BindGridView();
        }
        catch
        {
            this.PrintfError("数据访问失败！");
            return;
        }
    }
    //重置
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        hidBM.Value = "";
        hidCKH.Value = "";
        hidFYDH.Value = "";
        hidGG.Value = "";
        hidICKH.Value = "";
        hidKHH.Value = "";
        hidPH.Value = "";
        hidSX.Value = "";
        hidTHDH.Value = "";
        hidTuiHuo.Value = "";
        hidWLH.Value = "";
        hidZDR.Value = "";
    }
   //排序
    protected void grvTHD_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvTHD.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvTHD.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvTHD.Attributes["SortExpression"] = SortExpression;
        this.grvTHD.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvTHD_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvTHD.Attributes["SortExpression"];
            string SortDirection = grvTHD.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvTHD.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvTHD.Columns[i].SortExpression.Trim();
                if (CloExpression == null)
                    continue;
                //找到了排序的列进行处理
                if (SortExpression == CloExpression)
                {
                    string toolTip = (SortDirection == "ASC" ? "升序排列" : "降序排列");
                    string strUnit = (SortDirection == "ASC" ? "5 " : "6 ");
                    TableCell cell = e.Row.Cells[i];
                    Label lblSorted = new Label();
                    lblSorted.Font.Name = "webdings";
                    lblSorted.Font.Size = FontUnit.XSmall;
                    lblSorted.Text = strUnit;
                    cell.Controls.Add(lblSorted);
                    cell.ToolTip = toolTip;
                }
            }
        }
    }

    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvTHD.Rows.Count < 1)
        {
            this.PrintfError("没有要打印的记录！");
            return;
        }
        string url = CreateUrl();
        string strClient = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
        this.WriteClientJava(strClient);
    }
    private string CreateUrl()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("PrintTHD.aspx?TYPE=1");
        if (this.grvTHD.Columns[0].Visible == false)
            sb.Append("&ISCK=true");
        if (this.grvTHD.Columns[1].Visible == false)
            sb.Append("&ISBarcode=true");
        if (this.grvTHD.Columns[2].Visible == false)
            sb.Append("&ISPCH=true");
        if (this.grvTHD.Columns[3].Visible == false)
            sb.Append("&ISSX=true");
        if (this.grvTHD.Columns[4].Visible == false)
            sb.Append("&ISWLH=true");
        if (this.grvTHD.Columns[5].Visible == false)
            sb.Append("&ISPH=true");
        if (this.grvTHD.Columns[6].Visible == false)
            sb.Append("&ISGG=true");
        if (this.grvTHD.Columns[7].Visible == false)
            sb.Append("&ISZL=true");
        if (this.grvTHD.Columns[8].Visible == false)
            sb.Append("&ISCZRQ=true");
        if (this.grvTHD.Columns[9].Visible == false)
            sb.Append("&ISCZRY=true");
        if (this.grvTHD.Columns[10].Visible == false)
            sb.Append("&ISCKDH=true");
        if (this.grvTHD.Columns[11].Visible == false)
            sb.Append("&ISCKRQ=true");
        if (this.grvTHD.Columns[12].Visible == false)
            sb.Append("&ISRKDH=true");
        if (this.grvTHD.Columns[13].Visible == false)
            sb.Append("&ISKHBM=true");
        if (this.grvTHD.Columns[14].Visible == false)
            sb.Append("&ISNCZDRY=true");
        if (this.grvTHD.Columns[15].Visible == false)
            sb.Append("&ISNCZDRQ=true");
        if (this.grvTHD.Columns[16].Visible == false)
            sb.Append("&ISNCBM=true");
        if (this.grvTHD.Columns[17].Visible == false)
            sb.Append("&ISTHDH=true");

        if (!string.IsNullOrEmpty(this.hidCKH.Value))
        {
            sb.Append("&CK=" + hidCKH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidZDR.Value))
        {
            sb.Append("&NCZDRY=" + hidZDR.Value);
        }
        if (!string.IsNullOrEmpty(this.hidFYDH.Value))
        {
            sb.Append("&CKDH=" + hidFYDH.Value.Trim());
        }
        if (!string.IsNullOrEmpty(this.hidBM.Value))
        {
            sb.Append("&NCBM=" + this.hidBM.Value);
        }
        if (!string.IsNullOrEmpty(this.hidTHDH.Value))
        {
            sb.Append("&THDH=" + this.hidTHDH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidPH.Value))
        {
            sb.Append("&PH=" + this.hidPH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidWLH.Value))
        {
            sb.Append("&WLH=" + this.hidWLH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidGG.Value))
        {
            sb.Append("&GG=" + this.hidGG.Value);
        }
        if (!string.IsNullOrEmpty(this.hidSX.Value))
        {
            sb.Append("&SX=" + hidSX.Value);
        }
        if (!string.IsNullOrEmpty(this.hidKHH.Value))
        {
            sb.Append("&KHBM=" + hidKHH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidICKH.Value))
        {
            sb.Append("&ICNumber=" + this.txtICKH.Text.Trim());
        }
        if (this.chkTuiHuoRQ.Checked && !string.IsNullOrEmpty(this.TuiHuo_Start.Text))
        {
            string startTime = this.TuiHuo_Start.Text.Trim() + " 00:00:00";
            sb.Append("&CZRQfrom=" + startTime);
        }
        if (this.chkTuiHuoRQ.Checked && !string.IsNullOrEmpty(this.TuiHuo_End.Text))
        {
            string endTime = this.TuiHuo_End.Text.Trim() + " 23:59:59";
            sb.Append("&CZRQto=" + endTime);
        }
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            sb.Append("&Free1=" + this.txtFree1.Text);
        }
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            sb.Append("&Free2=" + this.txtFree2.Text);
        }
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            sb.Append("&Free3=" + this.txtFree3.Text);
        }
        return sb.ToString();
    }
}
