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
public partial class SiteBll_StockMan_CKZBView:AccPageBase
{
    public int i = 1;
    public int SumCK = 0;
    public int SumJS = 0;
    public double SumZL = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpCK.Attributes.Add("onchange", "ChangeCK();");
            this.drpRKSX.Attributes.Add("onchange", "ChangeRKSX();");
            //this.drpRKDH.Attributes.Add("onchange", "ChangeRKDH();");
            this.drpRKPH.Attributes.Add("onchange", "ChangeRKPH();");
            //this.drpRKPCH.Attributes.Add("onchange", "ChangeRKPCH();");
            this.drpRKGG.Attributes.Add("onchange", "ChangeRKGG();");
            this.drpWLH.Attributes.Add("onchange", "ChangeWLH();");
            //this.drpCPH.Attributes.Add("onchange", "ChangeCPH();");
            this.drpRKType.Attributes.Add("onchange", "ChangeRKType();");
            string strdate = DateTime.Now.ToShortDateString();
            this.RKRQ_Start.Text = strdate;
            this.RKRQ_End.Text = strdate;
        }
        this.SetDisplayList1.SCInit(this.grvCKZB, SysBaseConfig.CKZB_Q_PAGE);
    }
 
    //查询条件
    private string GetSqlStr()
    {
        string SqlStr = "";
        //仓库
        if (this.chkCK.Checked && !string.IsNullOrEmpty(hidCK.Value.Trim()))
        {
            SqlStr += " AND CK= '" + this.hidCK.Value.Trim()+"'";
        }
        //出库单号
        if (this.chkRKDH.Checked && !string.IsNullOrEmpty(this.txtCKDH.Text))
        {
            SqlStr += " AND CKDH like '%" + txtCKDH.Text.Trim() + "%'";
        }
        //属性
        if (this.chkRKSX.Checked && !string.IsNullOrEmpty(this.hidRKSX.Value))
        {
            SqlStr += " AND SX like '%" + this.hidRKSX.Value.Trim() + "%'";
        }
        //牌号
        if (this.chkRKPH.Checked && !string.IsNullOrEmpty(this.drpRKPH.Text))
        {
            SqlStr += " AND PH like '%" + this.drpRKPH.Text.Trim() + "%'";
        }
        //批次号
        if (this.chkRKPCH.Checked && !string.IsNullOrEmpty(this.txtPCH.Text))
        {
            SqlStr += " AND PCH like '%" + this.txtPCH.Text.Trim() + "%'";
        }
        //自由项1
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            SqlStr += " AND VFREE1 like '%" + this.txtFree1.Text.Trim() + "%'";
        }
        //自由项2
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            SqlStr += " AND VFREE2 like '%" + this.txtFree2.Text.Trim() + "%'";
        }
        //自由项3
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            SqlStr += " AND VFREE3 like '%" + this.txtFree3.Text.Trim() + "%'";
        }
        //规格
        if (this.chkRKGG.Checked && !string.IsNullOrEmpty(this.drpRKGG.Text))
        {
            SqlStr += " AND GG like '%" + this.drpRKGG.Text.Trim() + "%'";
        }
        //物料号
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            SqlStr += " AND WLH like '%" + this.drpWLH.Text.Trim() + "%'";
        }
        //车牌号
        if (this.chkCPH.Checked && !string.IsNullOrEmpty(this.txtCPH.Text))
        {
            SqlStr += " AND CPH like '%" + this.txtCPH.Text.Trim() + "%'";
        }
        if (this.chkRKType.Checked && !string.IsNullOrEmpty(this.hidRKType.Value.Trim()))
        {
            SqlStr += " AND CKType='" + this.hidRKType.Value.Trim() + "'";
        }
        //入库日期
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_Start.Text.Trim()))
        {
            string RKRQ_Start = this.RKRQ_Start.Text.Trim() + " 00:00:00";
            SqlStr += " AND CKTime>='" + RKRQ_Start + "'";
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_End.Text.Trim()))
        {
            string RKRQ_End = this.RKRQ_End.Text.Trim() + " 23:59:59";
            SqlStr += " AND CKTime<='" + RKRQ_End + "'";

        }

        return SqlStr;
    }
    //查询
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        SetPageCountView();
        BindGridView();
    }
    //重置
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        hidCK.Value = "";
        hidCPH.Value = "";
        hidRKDH.Value = "";
        hidRKGG.Value = "";
        hidRKGG.Value = "";
        hidRKPH.Value = "";
        hidRKRQ.Value = "";
        hidRKSX.Value = "";
        hidRKType.Value = "";
        hidWLH.Value = "";
        hidFree1.Value = "";
        hidFree2.Value = "";
        hidFree3.Value = "";
        drpRKSX.SelectedIndex = -1;
        drpCK.SelectedIndex = -1;
        drpRKGG.Text = "";
        drpRKPH.Text = "";
        drpRKGG.Text = "";
        drpWLH.Text = "";
        drpRKType.SelectedIndex = -1;
        this.txtCKDH.Text = "";        
        this.txtPCH.Text = "";
        this.txtCPH.Text = "";
        this.txtFree1.Text = "";
        this.txtFree2.Text = "";
        this.txtFree3.Text = "";
        this.chkCK.Checked = false;
        this.chkCPH.Checked = false;
        this.chkRKDH.Checked = false;
        this.chkRKGG.Checked = false;
        this.chkRKPCH.Checked = false;
        this.chkRKPH.Checked = false;
        this.chkRKRQ.Checked = false;
        this.chkRKSX.Checked = false;
        this.chkRKType.Checked = false;
        this.chkWLH.Checked = false;
        this.chkFree1.Checked = false;
        this.chkFree2.Checked = false;
        this.chkFree3.Checked = false;
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
    //绑定
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlStr();
            string sortEx = this.grvCKZB.Attributes["SortExpression"];
            string sortDirect = this.grvCKZB.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = CKZBQuery.GetQueryCKZB(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvCKZB.DataSource = ds;
            this.grvCKZB.DataBind();

            this.SetDisplayList1.InitSetListControl(this.grvCKZB, SysBaseConfig.CKZB_Q_PAGE);
            this.SetDisplayList1.SetGridViewDisplay(grvCKZB);

            DataSet dsCount = CKZBQuery.GetCount(sql);
            if (dsCount != null && dsCount.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty((dsCount.Tables[0].Rows[0]["HJZL"]).ToString()))
            {
                this.lblSUM.Text = dsCount.Tables[0].Rows[0]["Count"].ToString();
                this.lblSL.Text = dsCount.Tables[0].Rows[0]["HJSL"].ToString();
                this.lblZL.Text = Convert.ToDecimal(dsCount.Tables[0].Rows[0]["HJZL"]).ToString("#0.0000");
            }
            else
            {
                this.lblSUM.Text = "0";
                this.lblZL.Text = "0";
                this.lblSL.Text = "0";
            }
        }
        catch (Exception ex)
        { 
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    //排序
    protected void grvCKZB_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvCKZB.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvCKZB.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvCKZB.Attributes["SortExpression"] = SortExpression;
        this.grvCKZB.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvCKZB_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvCKZB.Attributes["SortExpression"];
            string SortDirection = grvCKZB.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvCKZB.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvCKZB.Columns[i].SortExpression.Trim();
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
    private void SelectPageSizeChange()
    {

        SetPageCountView();
        BindGridView();
        return;
    }
    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetSqlStr();
            int outCount;
            int pageCount = CKZBQuery.GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }

    ////导出EXCEL
    //protected void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (this.grvCKZB.Rows.Count < 1)
    //    {
    //        this.PrintfError("没有要导出的数据！");
    //        return;
    //    }
    //    try
    //    {
    //        string sqlWhere = GetSqlStr();
    //        DataSet ds = CKZBQuery.QueryCKZBExcel(sqlWhere);
    //        if (ds != null)
    //            this.CreateExcel(ds.Tables[0], "CKZB.xls", PageControl1.GetRecordCount());
    //    }
    //    catch
    //    {
    //        this.PrintfError("数据访问错误，请重试！");
    //        return;
    //    }
    //}
    //打印
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvCKZB.Rows.Count < 1)
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
        sb.Append("PrintCKZB.aspx?TYPE=1");
        if (this.grvCKZB.Columns[0].Visible == false)
            sb.Append("&ISCKDH=true");
        if (this.grvCKZB.Columns[1].Visible == false)
            sb.Append("&ISCK=true");
        if (this.grvCKZB.Columns[2].Visible == false)
            sb.Append("&ISCPH=true");
        if (this.grvCKZB.Columns[3].Visible == false)
            sb.Append("&ISPCH=true");
        if (this.grvCKZB.Columns[4].Visible == false)
            sb.Append("&ISSX=true");
        if (this.grvCKZB.Columns[5].Visible == false)
            sb.Append("&ISWLH=true");
        if (this.grvCKZB.Columns[6].Visible == false)
            sb.Append("&ISPH=true");
        if (this.grvCKZB.Columns[7].Visible == false)
            sb.Append("&ISGG=true");
        if (this.grvCKZB.Columns[8].Visible == false)
            sb.Append("&ISSL=true");
        if (this.grvCKZB.Columns[9].Visible == false)
            sb.Append("&ISZL=true");
        if (this.grvCKZB.Columns[10].Visible == false)
            sb.Append("&ISCKTime=true");
        if (this.grvCKZB.Columns[11].Visible == false)
            sb.Append("&ISCKType=true");
        if (this.grvCKZB.Columns[12].Visible == false)
            sb.Append("&ISHW=true");
        if (this.grvCKZB.Columns[13].Visible == false)
            sb.Append("&ISWLMC=true");

        if (this.grvCKZB.Columns[14].Visible == false)
            sb.Append("&ISFREE1=true");
        if (this.grvCKZB.Columns[15].Visible == false)
            sb.Append("&ISFREE2=true");
        if (this.grvCKZB.Columns[16].Visible == false)
            sb.Append("&ISFREE3=true");

        if (this.chkRKDH.Checked && !string.IsNullOrEmpty(this.txtCKDH.Text))
        {
            sb.Append("&CKDH=" + txtCKDH.Text.Trim());
        }
        if (this.chkCK.Checked && !string.IsNullOrEmpty(this.hidCK.Value))
        {
            sb.Append("&CK=" + hidCK.Value);
        }
        if (this.chkRKPCH.Checked && !string.IsNullOrEmpty(this.txtPCH.Text))
        {
            sb.Append("&PCH=" + txtPCH.Text.Trim());
        }
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            sb.Append("&FREE1=" + txtFree1.Text.Trim());
        }
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            sb.Append("&FREE2=" + txtFree2.Text.Trim());
        }
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            sb.Append("&FREE3=" + txtFree3.Text.Trim());
        }
        if (this.chkRKSX.Checked && !string.IsNullOrEmpty(this.hidRKSX.Value))
        {
            sb.Append("&SX=" + hidRKSX.Value);
        }
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            sb.Append("&WLH=" + drpWLH.Text.Trim());
        }
        if (this.chkRKPH.Checked && !string.IsNullOrEmpty(this.drpRKPH.Text))
        {
            sb.Append("&PH=" + drpRKPH.Text.Trim());
        }
        if (this.chkRKGG.Checked && !string.IsNullOrEmpty(this.drpRKGG.Text))
        {
            sb.Append("&GG=" + drpRKGG.Text.Trim());
        }
        if (this.chkRKGG.Checked && !string.IsNullOrEmpty(this.txtCPH.Text))
        {
            sb.Append("&CPH=" + txtCPH.Text.Trim());
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_Start.Text))
        {
            sb.Append("&fromtime=" + RKRQ_Start.Text.Trim() + " 00:00:00");
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_End.Text))
        {
            sb.Append("&totime=" + RKRQ_End.Text.Trim() + " 23:59:59");
        }
        if (this.chkRKType.Checked && !string.IsNullOrEmpty(this.hidRKType.Value))
        {
            sb.Append("&CKType=" + hidRKType.Value);
        }

        return sb.ToString();
    }
}

