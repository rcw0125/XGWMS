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
public partial class SiteBll_FormMan_QDPP : AccPageBase
{
    public int SumJS;
    public Double SumZL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpCKH.Attributes.Add("onchange", "ChangeCKH();");
            //this.drpWLH.Attributes.Add("onchange", "ChangeWLH();");
            //this.drpHW.Attributes.Add("onchange", "ChangeHW();");
            //this.drpPCH.Attributes.Add("onchange", "ChangePCH();");
            this.drpSX.Attributes.Add("onchange", "ChangeSX();");
            //this.drpPH.Attributes.Add("onchange", "ChangePH();");
            this.drpGG.Attributes.Add("onchange", "ChangeGG();");
            this.drpCopyGG.Attributes.Add("onchange", "ChangeCopyGG();");
            //this.drpTSXX.Attributes.Add("onchange", "ChangeTSXX();");
            string strdate = DateTime.Now.ToShortDateString();
            this.RuKu_Start.Text = strdate;
            this.RuKu_End.Text = strdate;
        }
    }
    private string GetsqlDPP()
    {
        string Sql_DPP = "";
        //仓库
        if (this.chkCKH.Checked && !string.IsNullOrEmpty(this.hidCKH.Value))
        {
            Sql_DPP += " and CK= '" + this.hidCKH.Value+"'";
        }
        //物料号
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            Sql_DPP += " AND WLH like '%" + this.drpWLH.Text.Trim() + "%'";
        }
        //货位
        if (this.chkHW.Checked && !string.IsNullOrEmpty(this.txtHW.Text))
        {
            Sql_DPP += " AND HW like '%" + this.txtHW.Text.Trim() + "%'";
        }
        //批次号
        if (this.chkPCH.Checked && !string.IsNullOrEmpty(this.drpPCH.Text))
        {
            Sql_DPP += " AND PCH like '%" + this.drpPCH.Text.Trim() + "%'";
        }
        //属性
        if (this.chkSX.Checked && !string.IsNullOrEmpty(this.hidSX.Value))
        {
            Sql_DPP += " AND SX='" + this.hidSX.Value.Trim()+"'";
        }
        //牌号
        if (this.chkPH.Checked && !string.IsNullOrEmpty(this.drpPH.Text))
        {
            Sql_DPP += " AND PH like '%" + this.drpPH.Text.Trim() + "%'";
        }
        //规格
        //1.GG为真，COPYGG为真
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(hidCopyGG.Value))
        {
           string startgg = this.hidGG.Value.Trim();
           string endgg = this.hidCopyGG.Value.Trim();
           Sql_DPP += " AND (Convert(float,substring(GG,2,len(GG)-3)) >= Convert(float,substring('" + startgg + "',2,Len('" + startgg + "') -3)))";
           Sql_DPP += " AND (Convert(float,substring(GG,2,len(GG)-3)) <= Convert(float,substring('" + endgg + "',2,Len('" + endgg + "')-3)))";
        }
          //2.GG为真，COPYGG不为真
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.hidGG.Value) && string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            Sql_DPP += " AND GG='" + this.hidGG.Value.Trim()+"'";
        }
        //3.GG不为真,COPYGG为真
        if (this.chkGG.Checked && string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            Sql_DPP += " AND GG='" + this.hidCopyGG.Value.Trim()+"'";
        }

        //特殊信息
        if (this.chkTSXX.Checked && !string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            Sql_DPP += " AND pcinfo like '%" + this.drpTSXX.Text.Trim()+ "%'";
        }

        //入库日期
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.hidRKRQ.Value))
        {
            string RuKu_Start = this.RuKu_Start.Text.Trim() + " 00:00:00";
            Sql_DPP += " AND RKRQ >='" + RuKu_Start + "'";
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.hidRKRQ.Value))
        {
            string RuKu_End = this.RuKu_End.Text.Trim() + " 23:59:59";
            Sql_DPP += " AND RKRQ <='" + RuKu_End + "'";
        }
        //未改判
        if (string.IsNullOrEmpty(this.hidWGP.Value))
        {
            Sql_DPP += " AND zpdjbz<2 ";
        }
        else
        {
            Sql_DPP += " AND zpdjbz>=2 ";
        }
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            Sql_DPP += " AND vfree1 like '%"+this.txtFree1.Text+"%'";
        }
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            Sql_DPP += " AND vfree2 like '%" + this.txtFree2.Text + "%'";
        }
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            Sql_DPP += " AND vfree3 like '%" + this.txtFree3.Text + "%'";
        }
        return Sql_DPP;
    }


    //绑定GridView
    private void BindGridView()
    {
        try
        {
            string sql = GetsqlDPP();
            string sortEx = this.grvDPP.Attributes["SortExpression"];
            string sortDirect = this.grvDPP.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = DPPQuery.GetQueryDPP(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvDPP.DataSource = ds;
            this.grvDPP.DataBind();
            DataSet dsCount = DPPQuery.GetCount(sql);
            if (dsCount != null && dsCount.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty((dsCount.Tables[0].Rows[0]["HJZL"]).ToString()))
            {
                this.lblSum.Text = dsCount.Tables[0].Rows[0]["countAll"].ToString();
                this.lblSL.Text = this.GetckdSL().ToString();
                this.lblZL.Text = Convert.ToDecimal(dsCount.Tables[0].Rows[0]["HJZL"]).ToString("#0.0000");
            }
            else
            {
                this.lblSum.Text = "0";
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
    //设置分页控件显示
    private void SetPageCountView()
    {
        //try
        //{
            string sql = GetsqlDPP();
            int outCount;
            int pageCount = DPPQuery.GetPageCount(sql, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        //}
        //catch
        //{
        //    this.PrintfError("数据访问错误，请重试！");
        //    return;
        //}
    }

    private int GetckdSL()
    {
        int i = 0;
        string sql = GetsqlDPP();
        i = DPPQuery.GetzongSL("sl", "view_dp_qry", sql);
        return i;

    }
    //重量
    private Double GetckdZL()
    {
        Double j = 0;
        string sql = GetsqlDPP();
        j = DPPQuery.GetzongZL("ZL","view_dp_qry", sql);
        return j;
    }
    //查询
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        //string sql = GetsqlDPP();
        //Response.Write(sql);
        SetPageCountView();
        BindGridView();
    }
   

    //重置
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        hidCKH.Value = "";
        hidWLH.Value = "";
        drpWLH.Text = "";
        hidHW.Value = "";
        hidPCH.Value = "";
        drpPCH.Text = "";
        hidSX.Value = "";
        drpSX.Text = "";
        drpPH.Text = "";
        hidPH.Value = "";
        hidTSXX.Value = "";
        drpTSXX.Text = "";
        hidRKRQ.Value = "";

    }
    //打印
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvDPP.Rows.Count < 1)
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
        sb.Append("PrintDPP.aspx?TYPE=1");
        if (this.grvDPP.Columns[0].Visible == false)
            sb.Append("&ISCK=true");
        if (this.grvDPP.Columns[1].Visible == false)
            sb.Append("&ISHW=true");
        if (this.grvDPP.Columns[2].Visible == false)
            sb.Append("&ISWLH=true");
        if (this.grvDPP.Columns[3].Visible == false)
            sb.Append("&ISWLMC=true");
        if (this.grvDPP.Columns[4].Visible == false)
            sb.Append("&ISPCH=true");
        if (this.grvDPP.Columns[5].Visible == false)
            sb.Append("&ISPH=true");
        if (this.grvDPP.Columns[6].Visible == false)
            sb.Append("&ISGG=true");
        if (this.grvDPP.Columns[7].Visible == false)
            sb.Append("&ISSX=true");
        if (this.grvDPP.Columns[8].Visible == false)
            sb.Append("&ISSL=true");
        if (this.grvDPP.Columns[9].Visible == false)
            sb.Append("&ISZL=true");

        if (this.chkCKH.Checked&&!string.IsNullOrEmpty(this.hidCKH.Value))
        {
            sb.Append("&CK=" + hidCKH.Value);
        }
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            sb.Append("&WLH=" + drpWLH.Text.Trim());
        }
        if (this.chkHW.Checked && !string.IsNullOrEmpty(this.txtHW.Text))
        {
            sb.Append("&HW=" + txtHW.Text.Trim());
        }
        if (this.chkPCH.Checked && !string.IsNullOrEmpty(this.drpPCH.Text))
        {
            sb.Append("&PCH=" + this.drpPCH.Text.Trim());
        }
        if (this.chkSX.Checked && !string.IsNullOrEmpty(this.hidSX.Value))
        {
            sb.Append("&SX=" + this.hidSX.Value.Trim());
        }
        if (this.chkPH.Checked && !string.IsNullOrEmpty(this.drpPH.Text))
        {
            sb.Append("&PH=" + this.drpPH.Text.Trim());
        }
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            sb.Append("&GG=" + this.hidGG.Value.Trim() + "&GGcopy=" + this.hidCopyGG.Value.Trim());
        }
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.hidGG.Value) && string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            sb.Append("&GG=" + this.hidGG.Value.Trim() + "&GGcopy=" + this.hidGG.Value.Trim());
        }
        if (this.chkGG.Checked && string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            sb.Append("&GG=" + this.hidCopyGG.Value.Trim() + "&GGcopy=" + this.hidCopyGG.Value.Trim());
        }
        if (this.chkTSXX.Checked && !string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            sb.Append("&pcinfo=" + this.drpTSXX.Text.Trim());
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.hidRKRQ.Value))
        {
            string startTime = this.RuKu_Start.Text.Trim() + " 00:00:00";
            sb.Append("&RKRQfrom=" + startTime);
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.hidRKRQ.Value))
        {
            string endTime = this.RuKu_End.Text.Trim() + " 23:59:59";
            sb.Append("&RKRQto=" + endTime);
        }
        if (string.IsNullOrEmpty(this.hidWGP.Value))
        {
            sb.Append("&zpdjbz=2");
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
    protected void grvDPP_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvDPP.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvDPP.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvDPP.Attributes["SortExpression"] = SortExpression;
        this.grvDPP.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvDPP_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvDPP.Attributes["SortExpression"];
            string SortDirection = grvDPP.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvDPP.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvDPP.Columns[i].SortExpression.Trim();
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
            if (!string.IsNullOrEmpty(RuKu_Start.Text))
            {
                Convert.ToDateTime(RuKu_Start.Text);
            }
            if (!string.IsNullOrEmpty(RuKu_End.Text))
            {
                Convert.ToDateTime(RuKu_End.Text);
            }
            return true;
        }
        catch
        {
            return false;
        }

    }
}
