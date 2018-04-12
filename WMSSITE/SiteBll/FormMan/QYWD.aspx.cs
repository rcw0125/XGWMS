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
/// 移库单查询
/// 柴艳亮
/// </summary>
public partial class SiteBll_FormMan_QYWD : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpCKH.Attributes.Add("onchange", "ChangeCKH();");
            this.drpYCHW.Attributes.Add("onchange","ChangeYCHW();");
            this.drpDH.Attributes.Add("onchange", "ChangeDH();");
            this.drpYRHW.Attributes.Add("onchange", "ChangeYRHW();");
            this.drpYWRY.Attributes.Add("onchange", "ChangeYWRY();");
            this.drpSX.Attributes.Add("onchange", "ChangeSX();");
            this.drpPH.Attributes.Add("onchange", "ChangePH();");
            this.drpWLH.Attributes.Add("onchange", "ChangeWLH();");
            this.drpGG.Attributes.Add("onchange","ChangeGG();");
            this.txtJH.Attributes.Add("onchange", "ChangeJH();");
            string strDate = DateTime.Now.ToShortDateString();
            YWDRQ_Start.Text = strDate;
            YWDRQ_End.Text = strDate;

           
        }
        this.SetDisplayList1.SCInit(this.grvYWD, SysBaseConfig.YWD_Q_PAGE);
    }
    private string GetSqlWhere()
    {
        string Sql_YWD = "";
        //仓库号
        if (!string.IsNullOrEmpty(hidCKH.Value))
        {
            Sql_YWD += " CK ='" + hidCKH.Value + "' ";
        }
        //移出货位
        if (!string.IsNullOrEmpty(this.hidYCHW.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND SHW='" + this.hidYCHW.Value.Trim() + "'";
            }
            else
                Sql_YWD += " SHW='" + this.hidYCHW.Value.Trim() + "'";
        }
        //单号
        if (!string.IsNullOrEmpty(this.hidDH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND YWDH like '%" + this.hidDH.Value.Trim() + "%'";
            }
            else
                Sql_YWD += " YWDH like '%" + this.hidDH.Value.Trim() + "%'";
        }
        //移入货位THW
        if (!string.IsNullOrEmpty(this.hidYRHW.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND THW='" + this.hidYRHW.Value.Trim() + "'";
            }
            else
                Sql_YWD += " THW='" + this.hidYRHW.Value.Trim() + "'";
        }
        //批次
        if (this.chkPCH.Checked&&!string.IsNullOrEmpty(this.txtPCH.Text))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND PCH like '%" + this.txtPCH.Text.Trim() + "%'";
            }
            else
                Sql_YWD += " PCH like '%" + this.txtPCH.Text.Trim() + "%'";
        }
        //移位人员
        if (!string.IsNullOrEmpty(this.hidYWRY.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND CZRY='" + this.hidYWRY.Value.Trim() + "'";
            }
            else
                Sql_YWD += " CZRY='" + this.hidYWRY.Value.Trim() + "'";
        }
        //属性
        if (!string.IsNullOrEmpty(this.hidSX.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND SX='" + this.hidSX.Value.Trim() + "'";
            }
            else
                Sql_YWD += " SX='" + this.hidSX.Value.Trim() + "'";
        }
        //牌号
        if (!string.IsNullOrEmpty(this.hidPH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND PH like '%" + this.hidPH.Value.Trim() + "%'";
            }
            else
                Sql_YWD += " PH like '%" + this.hidPH.Value.Trim() + "%'";
        }
        //物料号
        if (!string.IsNullOrEmpty(this.hidWLH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND WLH like '%" + this.hidWLH.Value.Trim() + "%'";
            }
            else
                Sql_YWD += " WLH like '%" + this.hidWLH.Value.Trim() + "%'";
        }
        //规格
        if (!string.IsNullOrEmpty(this.hidGG.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND GG like '%" + this.hidGG.Value.Trim() + "%'";
            }
            else
                Sql_YWD += " GG like '%" + this.hidGG.Value.Trim() + "%'";
        }
        //卷号
        if (!string.IsNullOrEmpty(this.hidJH.Value))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD+=" AND Barcode like '%"+hidJH.Value.Trim()+"%'";
            }
            else
                Sql_YWD += " Barcode like '%" + hidJH.Value.Trim() + "%'";
        }
        //移位单日期
        if (!string.IsNullOrEmpty(this.hidYWDRQ.Value))
        {
            string YWDRQ_Start = this.YWDRQ_Start.Text.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND CZRQ >='" + YWDRQ_Start + "'";
            }
            else
                Sql_YWD += " CZRQ >='" + YWDRQ_Start + "'";
        }
        if (!string.IsNullOrEmpty(this.hidYWDRQ.Value))
        {
            string YWDRQ_End = this.YWDRQ_End.Text.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND CZRQ <='" + YWDRQ_End + "'";
            }
            else
                Sql_YWD += " CZRQ >='" + YWDRQ_End + "'";
        }
        //自由项1
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND vfree1 like '%" + this.txtFree1.Text.Trim() + "%'";
            }
            else
                Sql_YWD += " vfree1 like '%" + this.txtFree1.Text.Trim() + "%'";
        }
        //自由项2
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND vfree2 like '%" + this.txtFree2.Text.Trim() + "%'";
            }
            else
                Sql_YWD += " vfree2 like '%" + this.txtFree2.Text.Trim() + "%'";
        }
        //自由项3
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            if (!string.IsNullOrEmpty(Sql_YWD))
            {
                Sql_YWD += " AND vfree3 like '%" + this.txtFree3.Text.Trim() + "%'";
            }
            else
                Sql_YWD += " vfree3 like '%" + this.txtFree3.Text.Trim() + "%'";
        }
        return Sql_YWD;
    }
    //绑定GridView
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            string sortEx = this.grvYWD.Attributes["SortExpression"];
            string sortDirect = this.grvYWD.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = YWDQuery.GetQueryYWD(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvYWD.DataSource = ds;
            this.grvYWD.DataBind();
            //SetSumInfo();
            this.SetDisplayList1.InitSetListControl(this.grvYWD, SysBaseConfig.YWD_Q_PAGE);
            this.SetDisplayList1.SetGridViewDisplay(grvYWD);
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
            string sql =GetSqlWhere();
            int outCount;
            int pageCount = YWDQuery.GetPageCount(sql, PageControl1.GetPageSize(), out outCount);
            
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
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
    //重量
    private Double GetckdJHZL()
    {
        Double j = 0;
        string sql = GetSqlWhere();
        j = YWDQuery.GetYWDZL("ZL", sql);
        return j;
    }
    //查询
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (checksj())
            {
                SetPageCountView();
                BindGridView();
                lblSUM.Text = PageControl1.GetRecordCount().ToString();
                lblZL.Text = GetckdJHZL().ToString();
            }
            else
            {
                PrintfError("输入日期有误！");
                return;
            }
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
        hidCKH.Value = "";

        hidYCHW.Value="";
        drpYCHW.Text="";
        
        hidDH.Value = "";
        drpDH.Text = "";

        drpGG.Text = "";
        hidGG.Value = "";

        hidYWRY.Value = "";
        drpYWRY.Text = "";

        this.txtPCH.Text = "";
        this.chkPCH.Checked = false;

        hidYRHW.Value = "";
        drpYRHW.Text = "";
        hidSX.Value = "";
        hidPH.Value = "";
        drpPH.Text = "";
        hidWLH.Value = "";
        drpWLH.Text = "";
        hidGG.Value = "";
        drpGG.Text = "";
        txtJH.Text = "";
        hidYWDRQ.Value = "";
        hidJH.Value = "";
    }
    protected void grvYWD_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvYWD.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvYWD.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvYWD.Attributes["SortExpression"] = SortExpression;
        this.grvYWD.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvYWD_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvYWD.Attributes["SortExpression"];
            string SortDirection = grvYWD.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvYWD.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvYWD.Columns[i].SortExpression.Trim();
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
    private bool checksj()
    {
        try
        {
            if (!string.IsNullOrEmpty(YWDRQ_Start.Text))
            {
                Convert.ToDateTime(YWDRQ_Start.Text);
            }
            if (!string.IsNullOrEmpty(YWDRQ_End.Text))
            {
                Convert.ToDateTime(YWDRQ_End.Text);
            }
            return true;
        }
        catch
        {
            return false;
        }

    }
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvYWD.Rows.Count < 1)
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
        sb.Append("PrintYWD.aspx?TYPE=1");
        if (this.grvYWD.Columns[0].Visible == false)
            sb.Append("&ISYWDH=true");
        if (this.grvYWD.Columns[1].Visible == false)
            sb.Append("&ISCK=true");
        if (this.grvYWD.Columns[2].Visible == false)
            sb.Append("&ISSHW=true");
        if (this.grvYWD.Columns[3].Visible == false)
            sb.Append("&ISTHW=true");
        if (this.grvYWD.Columns[4].Visible == false)
            sb.Append("&ISBarcode=true");
        if (this.grvYWD.Columns[5].Visible == false)
            sb.Append("&ISPCH=true");
        if (this.grvYWD.Columns[6].Visible == false)
            sb.Append("&ISWLH=true");
        if (this.grvYWD.Columns[7].Visible == false)
            sb.Append("&ISSX=true");
        if (this.grvYWD.Columns[8].Visible == false)
            sb.Append("&ISPH=true");
        if (this.grvYWD.Columns[9].Visible == false)
            sb.Append("&ISGG=true");
        if (this.grvYWD.Columns[10].Visible == false)
            sb.Append("&ISZL=true");
        if (this.grvYWD.Columns[11].Visible == false)
            sb.Append("&ISCZRY=true");
        if (this.grvYWD.Columns[12].Visible == false)
            sb.Append("&ISCZRQ=true");

        if (!string.IsNullOrEmpty(this.hidDH.Value))
        {
            sb.Append("&YWDH=" + hidDH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidCKH.Value))
        {
            sb.Append("&CK=" + hidCKH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidYCHW.Value))
        {
            sb.Append("&SHW=" + hidYCHW.Value.Trim());
        }
        if (!string.IsNullOrEmpty(this.hidYRHW.Value))
        {
            sb.Append("&THW=" + this.hidYRHW.Value);
        }
        if (!string.IsNullOrEmpty(this.hidJH.Value))
        {
            sb.Append("&Barcode=" + this.hidJH.Value);
        }
        if (this.chkPCH.Checked && !string.IsNullOrEmpty(this.txtPCH.Text))
        {
            sb.Append("&PCH=" + this.txtPCH.Text);
        }
        if (!string.IsNullOrEmpty(this.hidWLH.Value))
        {
            sb.Append("&WLH=" + this.hidWLH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidSX.Value))
        {
            sb.Append("&SX=" + this.hidSX.Value);
        }
        if (!string.IsNullOrEmpty(this.hidPH.Value))
        {
            sb.Append("&PH=" + hidPH.Value);
        }
        if (!string.IsNullOrEmpty(this.hidGG.Value))
        {
            sb.Append("&GG=" + hidGG.Value);
        }
        if (!string.IsNullOrEmpty(this.hidYWRY.Value))
        {
            sb.Append("&CZRY=" + this.hidYWRY.Value);
        }
        if (this.chkYWDRQ.Checked && !string.IsNullOrEmpty(this.hidYWDRQ.Value))
        {
            string startTime = this.YWDRQ_Start.Text.Trim() + " 00:00:00";
            sb.Append("&CZRQfrom=" + startTime);
        }
        if (this.chkYWDRQ.Checked && !string.IsNullOrEmpty(this.hidYWDRQ.Value))
        {
            string endTime = this.YWDRQ_End.Text.Trim() + " 23:59:59";
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
