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
public partial class SiteBll_StockMan_RKZBView :AccPageBase
{
    public int i=1;
    public int SumCK=0;
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
            this.drpRKscx.Attributes.Add("onchange", "ChangeRKscx();");
            this.drpBB.Attributes.Add("onchange", "ChangeBB();");
            this.drpTSXX.Attributes.Add("onchange", "ChangeTSXX();");
            string strdate = DateTime.Now.ToShortDateString().ToString();
            RKRQ_Start.Text = strdate;
            RKRQ_End.Text = strdate;
        }
        this.SetDisplayList1.SCInit(this.grvRKZB, SysBaseConfig.RKZB_Q_PAGE);
    }

    private string GetSqlStr()
    {
        string SqlStr = "";
        if(this.chkCK.Checked&&!string.IsNullOrEmpty(hidCK.Value.Trim()))
        {
            SqlStr += " AND CK= '" + this.hidCK.Value.Trim() +"'";
        }
        if (this.chkRKDH.Checked && !string.IsNullOrEmpty(this.txtRKDH.Text))
        {
            SqlStr += " AND RKDH like '%" + this.txtRKDH.Text.Trim() + "%'";
        }
        if (this.chkRKSX.Checked && !string.IsNullOrEmpty(this.hidRKSX.Value.Trim()))
        {
            SqlStr+=" AND SX like '%"+this.hidRKSX.Value.Trim()+"%'";
        }
        if (this.chkRKPH.Checked && !string.IsNullOrEmpty(this.drpRKPH.Text))
        {
            SqlStr += " AND PH like '%" + this.drpRKPH.Text.Trim() + "%'";
        }
        if (this.chkRKPCH.Checked && !string.IsNullOrEmpty(this.txtPCH.Text))
        {
            SqlStr += " AND PCH like '%" + this.txtPCH.Text.Trim() + "%'";
        }
        if (this.chkRKGG.Checked && !string.IsNullOrEmpty(this.drpRKGG.Text))
        {
            SqlStr += " AND GG like '%" + this.drpRKGG.Text.Trim() + "%'";
        }
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            SqlStr += " AND WLH like '%" + this.drpWLH.Text.Trim() + "%'";
        }
        if (this.chkCPH.Checked && !string.IsNullOrEmpty(this.txtCPH.Text))
        {
            SqlStr += " AND CPH like '%" + this.txtCPH.Text.Trim() + "%'";
        }
        if (this.chkRKType.Checked && !string.IsNullOrEmpty(this.hidRKType.Value.Trim()))
        {
            SqlStr += " AND RKType='" + this.hidRKType.Value.Trim() + "'";
        }
        //入库日期
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_Start.Text))
        {
            string RKRQ_Start = this.RKRQ_Start.Text.Trim() + " 00:00:00";
            SqlStr += " AND RKTime>='" + RKRQ_Start + "'";
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_End.Text))
        {
            string RKRQ_End = this.RKRQ_End.Text.Trim() + " 23:59:59";
            SqlStr += " AND RKTime<='" + RKRQ_End + "'";

        }
        //生产线
        if (this.chkRKscx.Checked && !string.IsNullOrEmpty(this.hidRKscx.Value.Trim()))
        {
            SqlStr += " AND EXISTS (SELECT 1 FROM wms_bms_rec_wgd,WMS_Pub_SCX WHERE wms_bms_rec_wgd.scx = WMS_Pub_SCX.scxncid and wms_bms_rec_wgd.wgdh = WMS_Rev_Doc.rkdh AND WMS_Pub_SCX.scxbm ='" + this.hidRKscx.Value.Trim() + "'";
            if (this.chkBB.Checked && !string.IsNullOrEmpty(this.hidBB.Value.Trim()))
            {
                SqlStr += " AND wms_bms_rec_wgd.bb='" + this.hidBB.Value.Trim() + "'";
            }
                SqlStr = SqlStr + ")";

            
        }
        else if (this.chkBB.Checked && !string.IsNullOrEmpty(this.hidBB.Value.Trim()))
        {
            SqlStr += " AND EXISTS (SELECT 1 FROM wms_bms_rec_wgd WHERE  wms_bms_rec_wgd.bb='" + this.hidBB.Value.Trim() + "' and wms_bms_rec_wgd.wgdh = WMS_Rev_Doc.rkdh)";
 
        }
        //特殊信息
        if (this.chkTSXX.Checked && !string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            SqlStr += " and EXISTS (select 1 from wms_bms_rec_wgd where wms_bms_rec_wgd.pcinfo like '%" + this.drpTSXX.Text.Trim() + "%' and wms_bms_rec_wgd.wgdh = WMS_Rev_Doc.rkdh)";
        }
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            SqlStr += "and vfree1 like '%"+this.txtFree1.Text+"%'";
        }
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            SqlStr += "and vfree2 like '%" + this.txtFree2.Text + "%'";
        }
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            SqlStr += "and vfree3 like '%" + this.txtFree3.Text + "%'";
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
        this.hidBB.Value = "";
        this.hidCK.Value = "";
        this.hidCPH.Value = "";
        this.hidRKDH.Value = "";
        this.hidRKGG.Value = "";
        this.hidRKPCH.Value = "";
        this.hidRKPH.Value = "";
        this.hidRKscx.Value = "";
        this.hidRKSX.Value = "";
        drpRKSX.Text = "";
        this.hidRKType.Value = "";
        this.hidTSXX.Value = "";
        this.hidWLH.Value = "";
        drpRKPH.Text = "";
        drpRKGG.Text = "";
        drpWLH.Text = "";
        drpTSXX.Text = "";
        hidRKRQ.Value = "";
        this.txtFree1.Text = "";
        this.txtFree2.Text = "";
        this.txtFree3.Text = "";
        
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
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
            string sqlWhere=GetSqlStr();
            int outCount;
            int pageCount = RKZBQuery.GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    //绑定
    private void BindGridView()
    {
        try
        {
        string sql = GetSqlStr();
        string sortEx = this.grvRKZB.Attributes["SortExpression"];
        string sortDirect = this.grvRKZB.Attributes["SortDirection"];
        string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
        DataSet ds = RKZBQuery.GetQueryRKZB(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
        this.grvRKZB.DataSource = ds;
        this.grvRKZB.DataBind();

        this.SetDisplayList1.InitSetListControl(this.grvRKZB, SysBaseConfig.RKZB_Q_PAGE);
        this.SetDisplayList1.SetGridViewDisplay(grvRKZB);

        DataSet dsCount = RKZBQuery.GetCount(sql);
        if (dsCount != null && dsCount.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty((dsCount.Tables[0].Rows[0]["HJZL"]).ToString()))
        {
            this.lblSUM.Text = dsCount.Tables[0].Rows[0]["countAll"].ToString();
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
  
    ////导出EXCEL
    //protected void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (this.grvRKZB.Rows.Count < 1)
    //    {
    //        this.PrintfError("没有要导出的数据！");
    //        return;
    //    }
    //    try
    //    {
    //        string sqlWhere = GetSqlStr();
    //        DataSet ds = RKZBQuery.QueryRKZBExcel(sqlWhere); 
    //        if (ds != null)
    //            this.CreateExcel(ds.Tables[0], "RKZB.xls", PageControl1.GetRecordCount());
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
        if (this.grvRKZB.Rows.Count < 1)
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
        sb.Append("PrintRKZB.aspx?TYPE=1");
        if (this.grvRKZB.Columns[0].Visible == false)
            sb.Append("&ISRKDH=true");
        if (this.grvRKZB.Columns[1].Visible == false)
            sb.Append("&ISCK=true");
        if (this.grvRKZB.Columns[2].Visible == false)
            sb.Append("&ISPCH=true");
        if (this.grvRKZB.Columns[3].Visible == false)
            sb.Append("&ISSX=true");
        if (this.grvRKZB.Columns[4].Visible == false)
            sb.Append("&ISWLH=true");
        if (this.grvRKZB.Columns[5].Visible == false)
            sb.Append("&ISPH=true");
        if (this.grvRKZB.Columns[6].Visible == false)
            sb.Append("&ISGG=true");
        if (this.grvRKZB.Columns[7].Visible == false)
            sb.Append("&ISSL=true");
        if (this.grvRKZB.Columns[8].Visible == false)
            sb.Append("&ISZL=true");
        if (this.grvRKZB.Columns[9].Visible == false)
            sb.Append("&ISCPH=true");
        if (this.grvRKZB.Columns[10].Visible == false)
            sb.Append("&ISRKTime=true");
        if (this.grvRKZB.Columns[11].Visible == false)
            sb.Append("&ISRKType=true");
        if (this.grvRKZB.Columns[12].Visible == false)
            sb.Append("&ISWLMC=true");
        if (this.grvRKZB.Columns[13].Visible == false)
            sb.Append("&ISFREE1=true");
        if (this.grvRKZB.Columns[14].Visible == false)
            sb.Append("&ISFREE2=true");
        if (this.grvRKZB.Columns[15].Visible == false)
            sb.Append("&ISFREE3=true");

        if (this.chkRKDH.Checked && !string.IsNullOrEmpty(this.txtRKDH.Text))
        {
            sb.Append("&RKDH=" + txtRKDH.Text.Trim());
        }
        if (this.chkCK.Checked && !string.IsNullOrEmpty(this.hidCK.Value))
        {
            sb.Append("&CK=" + hidCK.Value);
        }
        if (this.chkRKPCH.Checked && !string.IsNullOrEmpty(this.txtPCH.Text))
        {
            sb.Append("&PCH=" + txtPCH.Text.Trim());
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
        if (this.chkCPH.Checked && !string.IsNullOrEmpty(this.txtCPH.Text))
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
            sb.Append("&RKType=" + hidRKType.Value);
        }
        if (this.chkRKscx.Checked && !string.IsNullOrEmpty(this.hidRKscx.Value))
        {
            sb.Append("&SCXBM=" + hidRKscx.Value);
        }
        if (this.chkBB.Checked && !string.IsNullOrEmpty(this.hidBB.Value))
        {
            sb.Append("&BB=" + hidBB.Value);
        }
        if (this.chkTSXX.Checked && !string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            sb.Append("&pcinfo=" + drpTSXX.Text.Trim());
        }
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            sb.Append("&free1=" + Server.UrlEncode(this.txtFree1.Text.Trim()));
        }
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            sb.Append("&free2=" + Server.UrlEncode(this.txtFree2.Text.Trim()));
        }
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            sb.Append("&free3=" + Server.UrlEncode(this.txtFree3.Text.Trim()));
        }
        return sb.ToString();
    }


    protected void grvRKZB_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvRKZB.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvRKZB.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvRKZB.Attributes["SortExpression"] = SortExpression;
        this.grvRKZB.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvRKZB_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvRKZB.Attributes["SortExpression"];
            string SortDirection = grvRKZB.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvRKZB.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvRKZB.Columns[i].SortExpression.Trim();
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
}
