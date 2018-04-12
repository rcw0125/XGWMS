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
public partial class SiteBll_FormMan_QRUKU : AccPageBase
{
    public int i=1;
    public int PCSum=0;
    public int JHSumJS;
    public Double JHSumZL;
    public int DCSumJS;
    public Double DCsumZL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpZKDH.Attributes.Add("onchange", "ChangeZKDH();");
            this.drpWLH.Attributes.Add("onchange", "ChangeWLH();");
            this.drpSX.Attributes.Add("onchange","ChangeSX();");
            this.drpPH.Attributes.Add("onchange","ChangePH();");
            this.drpGG.Attributes.Add("onchange", "ChangeGG();");
            this.drpZCCK.Attributes.Add("onchange", "ChangeZCCK();");
            this.drpZRCK.Attributes.Add("onchange", "ChangeZRCK();");
            this.drpCPH.Attributes.Add("onchange", "ChangeCPH();");
            this.drpZCZT.Attributes.Add("onchange", "ChangeZCZT();");
            this.drpZRZT.Attributes.Add("onchange", "ChangeZRZT();");
            string strDate = DateTime.Now.ToShortDateString();
            this.ZCSJ_Start.Text = strDate;
            this.ZCSJ_End.Text = strDate;
            this.ZRSJ_Start.Text = strDate;
            this.ZRSJ_End.Text = strDate;



        }
        this.SetDisplayList1.SCInit(this.grvZKD, SysBaseConfig.ZKD_Q_PAGE);
    }
    private string GetSqlZKD()
    {
        string Sql_ZKD = "";
        //转库单号
        if (this.chkZKDH.Checked && !string.IsNullOrEmpty(this.drpZKDH.Text))
        {
            Sql_ZKD += " ZKDH like '%" + this.drpZKDH.Text + "%' ";
        }
        //批次号
        if (this.chkPCH.Checked&&!string.IsNullOrEmpty(this.txtPCH.Text))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND pch like '%" + this.txtPCH.Text.Trim() + "%'";
            }
            else
                Sql_ZKD += " pch like '%" + this.txtPCH.Text.Trim() + "%'";
        }
        //物料号hidWLH
        if (this.chkWLH.Checked&&!string.IsNullOrEmpty(this.drpWLH.Text))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND wlh like '%" + this.drpWLH.Text.Trim() + "%'";
            }
            else
                Sql_ZKD += " wlh like '%" + this.drpWLH.Text.Trim() + "%'";
        }
        //属性hidSX
        if (!string.IsNullOrEmpty(this.hidSX.Value))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND sx='" + this.hidSX.Value.Trim() + "'";
            }
            else
                Sql_ZKD += " sx ='" + this.hidSX.Value.Trim() + "'";
        }
        //牌号ph

        if (this.chkPH.Checked&&!string.IsNullOrEmpty(this.drpPH.Text))
        {
          
                if (!string.IsNullOrEmpty(Sql_ZKD))
                {
                    Sql_ZKD += " AND ph like '%" + this.drpPH.Text.Trim() + "%'";
                }
                else
                    Sql_ZKD += " ph like '%" + this.drpPH.Text.Trim() + "%'";
            
           
        }
        //规格
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.drpGG.Text))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND gg like '%" + this.drpGG.Text.Trim() + "%'";
            }
            else
                Sql_ZKD += " gg like '%" + this.drpGG.Text.Trim() + "%'";
        }
        //转出仓库
        if (!string.IsNullOrEmpty(this.hidZCCK.Value))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND SCK='" + this.hidZCCK.Value.Trim() + "'";
            }
            else
                Sql_ZKD += " SCK='" + this.hidZCCK.Value.Trim() + "'";

        }
        //转入仓库
        if (!string.IsNullOrEmpty(this.hidZRCK.Value))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND TCK='"+this.hidZRCK.Value.Trim()+"'";
            }
            else
                Sql_ZKD+=" TCK='"+this.hidZRCK.Value.Trim()+"'";
        }
       //车牌号
        if (this.chkCPH.Checked && !string.IsNullOrEmpty(this.drpCPH.Text))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND CPH like '%" + this.drpCPH.Text.Trim() + "%'";
            }
            else
                Sql_ZKD += " CPH like '%" + this.drpCPH.Text.Trim() + "%'";
        
        }
        //转出状态
        if (!string.IsNullOrEmpty(this.hidZCZT.Value))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            { 
                Sql_ZKD+=" AND OutStatus='"+this.hidZCZT.Value.Trim()+"'";
            }
            else
                Sql_ZKD+=" OutStatus='"+this.hidZCZT.Value.Trim()+"'";
        
        }
        //转入状态
        if (!string.IsNullOrEmpty(this.hidZRZT.Value))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD+=" AND Status='"+this.hidZRZT.Value.Trim()+"'";
            }
            else
                Sql_ZKD+=" Status='"+this.hidZRZT.Value.Trim()+"'";
        }
        //不等于
        if (!string.IsNullOrEmpty(this.hidBDY.Value))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND OutNum <> INNum";
            }
            else
                Sql_ZKD += "OutNum <> INNum";

        }
        //转出时间
        if (!string.IsNullOrEmpty(this.hidZCSJ.Value.ToString()))
        {
            string ZCSJ_Start = this.ZCSJ_Start.Text.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND CKTime >='" + ZCSJ_Start + "'";
            }
            else
                Sql_ZKD += " CKTime >='" + ZCSJ_Start + "'";
        }
        if (!string.IsNullOrEmpty(this.hidZCSJ.Value.ToString()))
        {
            string ZCSJ_End = this.ZCSJ_End.Text.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND CKTime <='" + ZCSJ_End + "'";
            }
            else
                Sql_ZKD += " CKTime >='" + ZCSJ_End + "'";
        }
        //转入时间
        if (!string.IsNullOrEmpty(this.hidZRSJ.Value.ToString()))
        {
            string ZRSJ_Start = this.ZRSJ_Start.Text.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND RKTime >='" + ZRSJ_Start + "'";
            }
            else
                Sql_ZKD += " RKTime >='" + ZRSJ_Start + "'";
        }
        if (!string.IsNullOrEmpty(this.hidZRSJ.Value.ToString()))
        {
            string ZRSJ_End = this.ZRSJ_End.Text.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND RKTime <='" + ZRSJ_End + "'";
            }
            else
                Sql_ZKD += " RKTime >='" + ZRSJ_End + "'";
        }

        //自由项
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND vfree1 like '%" + this.txtFree1.Text.Trim() + "%'";
            }
            else
                Sql_ZKD += " vfree1 like '%" + this.txtFree1.Text.Trim() + "%'";
        }

        //自由项
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND vfree2 like '%" + this.txtFree2.Text.Trim() + "%'";
            }
            else
                Sql_ZKD += " pch vfree2 '%" + this.txtFree2.Text.Trim() + "%'";
        }

        //自由项
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            if (!string.IsNullOrEmpty(Sql_ZKD))
            {
                Sql_ZKD += " AND vfree3 like '%" + this.txtFree3.Text.Trim() + "%'";
            }
            else
                Sql_ZKD += " vfree3 like '%" + this.txtFree3.Text.Trim() + "%'";
        }
        return Sql_ZKD;
    }
     //绑定gridview
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlZKD();
            string sortEx = this.grvZKD.Attributes["SortExpression"];
            string sortDirect = this.grvZKD.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = ZKDQuery.GetQueryZKD(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvZKD.DataSource = ds;
            this.grvZKD.DataBind();

            this.SetDisplayList1.InitSetListControl(this.grvZKD, SysBaseConfig.ZKD_Q_PAGE);
            this.SetDisplayList1.SetGridViewDisplay(grvZKD);
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
        //try
        //{
            string sql = GetSqlZKD();
            int outCount;
            int pageCount = ZKDQuery.GetPageCount(sql, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        //}
        //catch
        //{
        //    this.PrintfError("数据访问错误，请重试！");
        //    return;
        //}
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
   // 数量
       
    private int GetckdSL()
    {
        int i = 0;
        string sql = GetSqlZKD();
        i = ZKDQuery.GetCKDSL("SL", sql);
        return i;
    }
    //重量
    private Double GetckdZL()
    {
        Double j = 0;
       string sql = GetSqlZKD();
        j = ZKDQuery.GetCKDZL("ZL", sql);
        return j;
    }
    // 数量

    private int GetckdJHSL()
    {
        int i = 0;
        string sql = GetSqlZKD();
        i = ZKDQuery.GetCKDSL("JHSL", sql);
        return i;
    }
    //重量
    private Double GetckdJHZL()
    {
        Double j = 0;
        string sql = GetSqlZKD();
        j = ZKDQuery.GetCKDZL("JHZL", sql);
        return j;
    }
    //查询
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (checksj())
            {
                string sql = GetSqlZKD();
                if (!string.IsNullOrEmpty(sql))
                {
                    //Response.Write(sql);
                    SetPageCountView();
                    BindGridView();
                    lblSUM.Text = PageControl1.GetRecordCount().ToString();
                    lblSL.Text = GetckdSL().ToString();
                    lblZL.Text = GetckdZL().ToString();
                    lblJHSL.Text = GetckdJHSL().ToString();
                    lblJHZL.Text = GetckdJHZL().ToString();
                    //lblCount.Text = PageControl1.GetRecordCount().ToString();
                }
                else
                {
                    this.PrintfError("请输入查询条件!");
                    return;
                }
            }
            else
            {
                this.PrintfError("时间有误，请重新输入");
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
        hidZKDH.Value = "";
        drpZKDH.Text = "";

        this.chkPCH.Checked = false;
        this.txtPCH.Text = "";

        hidWLH.Value = "";
        drpWLH.Text = "";

        hidPH.Value = "";
        drpPH.Text = "";

        hidCPH.Value = "";
        drpCPH.Text = "";

        hidGG.Value = "";
        drpGG.Text = "";

        hidBDY.Value = "";
        hidCPH.Value = "";
        hidGG.Value = "";
        hidPH.Value = "";
        hidSX.Value = "";
        hidWLH.Value = "";
        hidZCCK.Value = "";
        hidZCZT.Value = "";
        hidZKDH.Value = "";
        hidZRSJ.Value = "";
        hidZRZT.Value = "";
        hidZRCK.Value = "";
        hidZCSJ.Value = "";
        drpCPH.Text = "";
       
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
    ////导出EXCEL
    protected void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvZKD.Rows.Count < 1)
        {
            this.PrintfError("没有要导出的数据！");
        }
        try
        {
            string sqlWhere = GetSqlZKD();
            DataSet ds = ZKDQuery.QueryZKDExcel(sqlWhere);
            if (ds != null)
                this.CreateExcel(ds.Tables[0], "ZKD.xls", PageControl1.GetRecordCount());
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    //打印
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvZKD.Rows.Count < 1)
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
        sb.Append("PrintZKD.aspx?TYPE=1");
        if (this.grvZKD.Columns[1].Visible == false)
            sb.Append("&ISZKDH=true");
        if (this.grvZKD.Columns[2].Visible == false)
            sb.Append("&ISCPH=true");
        if (this.grvZKD.Columns[3].Visible == false)
            sb.Append("&ISPCH=true");
        if (this.grvZKD.Columns[4].Visible == false)
            sb.Append("&ISWLH=true");
        if (this.grvZKD.Columns[5].Visible == false)
            sb.Append("&ISSX=true");
        if (this.grvZKD.Columns[6].Visible == false)
            sb.Append("&ISYCK=true");
        if (this.grvZKD.Columns[7].Visible == false)
            sb.Append("&ISYHW=true");
        if (this.grvZKD.Columns[8].Visible == false)
            sb.Append("&ISMBCK=true");
        if (this.grvZKD.Columns[9].Visible == false)
            sb.Append("&ISMBHW=true");
        if (this.grvZKD.Columns[10].Visible == false)
            sb.Append("&ISFJLDW=true");
        if (this.grvZKD.Columns[11].Visible == false)
            sb.Append("&ISZJLDW=true");
        if (this.grvZKD.Columns[12].Visible == false)
            sb.Append("&ISJHSL=true");
        if (this.grvZKD.Columns[13].Visible == false)
            sb.Append("&ISJHZL=true");
        if (this.grvZKD.Columns[14].Visible == false)
            sb.Append("&ISOutNum=true");
        if (this.grvZKD.Columns[15].Visible == false)
            sb.Append("&ISOutZL=true");
        if (this.grvZKD.Columns[16].Visible == false)
            sb.Append("&ISInNum=true");
        if (this.grvZKD.Columns[17].Visible == false)
            sb.Append("&ISInZL=true");
        if (this.grvZKD.Columns[18].Visible == false)
            sb.Append("&ISSL=true");
        if (this.grvZKD.Columns[19].Visible == false)
            sb.Append("&ISZL=true");
        if (this.grvZKD.Columns[20].Visible == false)
            sb.Append("&ISzhxlb=true");
        if (this.grvZKD.Columns[21].Visible == false)
            sb.Append("&ISoutstatus=true");
        if (this.grvZKD.Columns[22].Visible == false)
            sb.Append("&ISCKOperator=true");
        if (this.grvZKD.Columns[23].Visible == false)
            sb.Append("&ISCKTime=true");
        if (this.grvZKD.Columns[24].Visible == false)
            sb.Append("&ISstatus=true");
        if (this.grvZKD.Columns[25].Visible == false)
            sb.Append("&ISRKOperator=true");
        if (this.grvZKD.Columns[26].Visible == false)
            sb.Append("&ISRKTime=true");
        if (this.grvZKD.Columns[27].Visible == false)
            sb.Append("&ISWLMC=true");

        if (this.chkZKDH.Checked && !string.IsNullOrEmpty(this.drpZKDH.Text))
        {
            sb.Append("&ZKDH=" + this.drpZKDH.Text);
        }
        if (this.chkPCH.Checked&&!string.IsNullOrEmpty(this.txtPCH.Text))
        {
            sb.Append("&PCH=" + this.txtPCH.Text);
        }
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            sb.Append("&WLH=" + this.drpWLH.Text.Trim());
        }
        if (!string.IsNullOrEmpty(this.hidSX.Value))
        {
            sb.Append("&SX=" + this.hidSX.Value);
        }
        if (this.chkPH.Checked && !string.IsNullOrEmpty(this.drpPH.Text))
        {
            sb.Append("&PH=" + this.drpPH.Text);
        }
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.drpGG.Text))
        {
            sb.Append("&GG=" + this.drpGG.Text);
        }
        if (!string.IsNullOrEmpty(this.hidZCCK.Value))
        {
            sb.Append("&SCK=" + this.hidZCCK.Value);
        }
        if (!string.IsNullOrEmpty(this.hidZRCK.Value))
        {
            sb.Append("&TCK=" + this.hidZRCK.Value);
        }
        if (this.chkCPH.Checked && !string.IsNullOrEmpty(this.drpCPH.Text))
        {
            sb.Append("&CPH=" + this.drpCPH.Text);
        }
        if (!string.IsNullOrEmpty(this.hidZCZT.Value))
        {
            sb.Append("&OutStatus=" + hidZCZT.Value);
        }
        if (!string.IsNullOrEmpty(this.hidZRZT.Value))
        {
            sb.Append("&Status=" + this.hidZRZT.Value);
        }
        if (!string.IsNullOrEmpty(this.hidBDY.Value))
        {
            sb.Append("&OtVsIn=true");
        }
        if (this.chkZCSJ.Checked && !string.IsNullOrEmpty(this.hidZCSJ.Value))
        {
            string startTime = this.ZCSJ_Start.Text.Trim() + " 00:00:00";
            sb.Append("&CKfromTime=" + startTime);
        }
        if (this.chkZCSJ.Checked && !string.IsNullOrEmpty(this.hidZCSJ.Value))
        {
            string endTime = this.ZCSJ_End.Text.Trim() + " 23:59:59";
            sb.Append("&CKtoTime=" + endTime);
        }
        if (this.chkZRSJ.Checked && !string.IsNullOrEmpty(this.hidZRSJ.Value))
        {
            string startTime = this.ZRSJ_Start.Text.Trim() + " 00:00:00";
            sb.Append("&RKfromTime=" + startTime);
        }
        if (this.chkZRSJ.Checked && !string.IsNullOrEmpty(this.hidZRSJ.Value))
        {
            string endTime = this.ZRSJ_End.Text.Trim() + " 23:59:59";
            sb.Append("&RKtoTime=" + endTime);
        }

        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            sb.Append("&Free1="+this.txtFree1.Text);
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




    //排序
    protected void grvZKD_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvZKD.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvZKD.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvZKD.Attributes["SortExpression"] = SortExpression;
        this.grvZKD.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvZKD_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvZKD.Attributes["SortExpression"];
            string SortDirection = grvZKD.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvZKD.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvZKD.Columns[i].SortExpression.Trim();
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
            if (!string.IsNullOrEmpty(ZCSJ_Start.Text))
            {
                Convert.ToDateTime(ZCSJ_Start.Text);
            }
            if (!string.IsNullOrEmpty(ZCSJ_End.Text))
            {
                Convert.ToDateTime(ZCSJ_End.Text);
            }
            return true;
        }
        catch
        {
            return false;
        }
        
    }

}
