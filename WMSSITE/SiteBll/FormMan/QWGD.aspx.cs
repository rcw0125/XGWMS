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
/// 完工单查询
/// author ：张俊刚
/// company：北京爱创
/// creatDate ：2007-10-30
/// </summary>
public partial class SiteBll_FormMan_QWGD :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpPCH.Attributes.Add("onchange", "ChangePCH();");
            this.drpTSXX.Attributes.Add("onchange", "ChangeTSXX();");
            this.drpPLX.Attributes.Add("onchange", "ChangePLX();");
            this.drpPCSX.Attributes.Add("onchange", "ChangePCSX();");
            this.drpWLH.Attributes.Add("onchange", "ChangeWLH();");
            this.drpSCX.Attributes.Add("onchange", "ChangeSCX();");
            this.drpWCBZ.Attributes.Add("onchange", "ChangeWCBZ();");
            this.drpPH.Attributes.Add("onchange", "ChangePH();");
            this.drpGG.Attributes.Add("onchange", "ChangeGG();");
            this.drpWGDH.Attributes.Add("onchange", "ChangeWGDH();");
            this.drpDPP.Attributes.Add("onchange", "ChangeDPP();");
            this.drpZJR.Attributes.Add("onchange", "ChangeZJR();");
            string strDate = DateTime.Now.ToShortDateString();
            this.txtPStartTime.Text = strDate;
            this.txtPEndTime.Text = strDate;
            this.txtRStartTime.Text = strDate;
            this.txtREndTime.Text = strDate;

            this.chkPTime.Attributes.Add("onClick", "PTimeCan();");
            this.chkRTime.Attributes.Add("onClick", "RTimeCan();");
        }
        this.SetDisplayList1.SCInit(this.grvWGD, SysBaseConfig.WGD_Q_PAGE);
        SetSumInfo();
    }
    //获取查询条件
    private  string GetSqlWhere()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(hidWGDH.Value) && this.chkWGDH.Checked)
        {
            sqlWhere += "a.WGDH like '%" + hidWGDH.Value + "%' ";
        }
        else
        {
            this.hidWGDH.Value = "";
            this.drpWGDH.Text = "";
        }
        //批次号
        if (!string.IsNullOrEmpty(hidPCH.Value) && this.chkPCH.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.PCH like '%" + hidPCH.Value + "%'";
            }
            else
                sqlWhere += " a.PCH like '%" + hidPCH.Value + "%'";
        }
        else
        {
            this.hidPCH.Value = "";
            this.drpPCH.Text = "";
        }
        //质检人
        if (!string.IsNullOrEmpty(this.hidZJR.Value))
        {
            string[] strZJR = this.hidZJR.Value.Split('|');
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.NCWLBMID ='" + strZJR[0].Trim()+ "'";
            }
            else
                sqlWhere += " a.NCWLBMID ='" + strZJR[0].Trim() + "'";
        }
        //特殊信息
        if (!string.IsNullOrEmpty(this.hidTSXX.Value) && this.chkTSXX.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.pcinfo like '%" + this.hidTSXX.Value.Trim() + "%'";
            }
            else
                sqlWhere += " a.pcinfo like '%" + this.hidTSXX.Value.Trim() + "%'";
        }
        else
        {
            this.hidTSXX.Value = "";
            this.drpTSXX.Text = "";
        }
        //批次类型
        if (!string.IsNullOrEmpty(hidPLX.Value))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.PCLX=" + hidPLX.Value.Trim();
            }
            else
                sqlWhere += " a.PCLX =" + hidPLX.Value.Trim();
        }
        //批次属性
        if (!string.IsNullOrEmpty(hidPCSX.Value))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.PCSX='" + hidPCSX.Value.Trim() + "'";
            }
            else
                sqlWhere += " a.PCSX ='" + hidPCSX.Value.Trim() + "'";
        }
        //物料号
        if (!string.IsNullOrEmpty(hidWLH.Value)&&this.chkWLH.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.WLH like '%" + hidWLH.Value.Trim() + "%'";
            }
            else
                sqlWhere += " a.WLH like '%" + hidWLH.Value.Trim() + "%'";
        }
        else
        {
            this.hidWLH.Value = "";
            this.drpWLH.Text = "";
        }
        //生产线
        if (!string.IsNullOrEmpty(this.hidSCX.Value))
        {
            string tempStr= "ACCTRUE";
            string strSCXID = WGDQuery.GetSCXID(this.hidSCX.Value.Trim());
            if (!string.IsNullOrEmpty(strSCXID))
                tempStr = strSCXID;
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.SCX='" + tempStr+ "'";
            }
            else
                sqlWhere += " a.SCX ='" + tempStr + "'";
        }
        //完成标志
        if (!string.IsNullOrEmpty(this.hidWCBZ.Value))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.wcbz=" + this.hidWCBZ.Value.Trim();
            }
            else
                sqlWhere += " a.wcbz =" + this.hidWCBZ.Value.Trim();
        }
        //牌号
        if (!string.IsNullOrEmpty(this.hidPH.Value)&&this.chkPH.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.PH like '%" + this.hidPH.Value.Trim() + "%'";
            }
            else
                sqlWhere += " a.PH like '%" + this.hidPH.Value.Trim() + "%'";
        }
        else
        {
            this.hidPH.Value = "";
            this.drpPH.Text = "";
        }
        //待判
        if (!string.IsNullOrEmpty(this.hidDPP.Value))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.pcsx ='DP' and a.zpdjbz='" + this.hidDPP.Value.Trim() + "'";
            }
            else
                sqlWhere += " a.pcsx ='DP' and a.zpdjbz='" + this.hidDPP.Value.Trim() + "'";
        }
        //规格
        if (!string.IsNullOrEmpty(hidGG.Value)&&this.chkGG.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.GG like '%" + hidGG.Value.Trim() + "%'";
            }
            else
                sqlWhere += " a.GG like '%" + hidGG.Value.Trim() + "%'";
        }
        else
        {
            this.hidGG.Value = "";
            this.drpGG.Text = "";
        }
        //生产开始时间
        if(this.chkPTime.Checked && !string.IsNullOrEmpty(txtPStartTime.Text.Trim()))
        {
            string startTime=this.txtPStartTime.Text.Trim()+" 00:00:00";
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.PEnd_Time >='" + startTime + "'";
            }
            else
                sqlWhere += " a.PEnd_Time >='" + startTime + "'";
        }
        //生产结束时间
        if(this.chkPTime.Checked && !string.IsNullOrEmpty(txtPEndTime.Text.Trim()))
        {
            string endTime=this.txtPEndTime.Text.Trim()+" 23:59:59";
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.PEnd_Time<='" + endTime + "'";
            }
            else
                sqlWhere += " a.PEnd_Time<='" + endTime + "'";
        }
        //入库完成时间
        if (this.chkRTime.Checked &&!string.IsNullOrEmpty(txtRStartTime.Text.Trim()))
        {
            string startTime = this.txtRStartTime.Text.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.End_Time >='" + startTime + "'";
            }
            else
                sqlWhere += " a.End_Time >='" + startTime + "'";
        }
        //入库结束时间
        if (this.chkRTime.Checked && !string.IsNullOrEmpty(txtREndTime.Text.Trim()))
        {
            string endTime = this.txtREndTime.Text.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND a.End_Time<='" + endTime + "'";
            }
            else
                sqlWhere += " a.End_Time<='" + endTime + "'";
        }
        if (this.chkPaoGou.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " and a.PGBZ > 0 ";
            }
            else
                sqlWhere += " a.PGBZ > 0 ";
        }
        if (this.chkFree1.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " and a.vfree0 like '%"+this.txtFree1.Text+"%'";
            }
            else
                sqlWhere += " a.vfree0 like '%" + this.txtFree1.Text + "%'";
        }
        if (this.chkFree2.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " and a.vfree1 like '%" + this.txtFree2.Text + "%'";
            }
            else
                sqlWhere += " a.vfree1 like '%" + this.txtFree2.Text + "%'";
        }
        if (this.chkFree3.Checked)
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " and a.vfree2 like '%" + this.txtFree3.Text + "%'";
            }
            else
                sqlWhere += " a.vfree2 like '%" + this.txtFree3.Text + "%'";
        }
        return sqlWhere;
    }
    //检查时间格式是否正确
    private bool CheckUI()
    {
        try
        {
            if (this.chkPTime.Checked && !string.IsNullOrEmpty(this.txtPStartTime.Text.Trim()))
                Convert.ToDateTime(this.txtPStartTime.Text.Trim());
            if (this.chkPTime.Checked && !string.IsNullOrEmpty(this.txtPEndTime.Text.Trim()))
                Convert.ToDateTime(this.txtPEndTime.Text.Trim());
            if (this.chkRTime.Checked &&　!string.IsNullOrEmpty(this.txtRStartTime.Text.Trim()))
                Convert.ToDateTime(this.txtRStartTime.Text.Trim());
            if (this.chkRTime.Checked && !string.IsNullOrEmpty(this.txtREndTime.Text.Trim()))
                Convert.ToDateTime(this.txtREndTime.Text.Trim());
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        this.chkPCH.Checked = false;
        this.drpPCH.Items.Clear();
        this.drpPCH.Text = "";
        this.hidPCH.Value = "";

        this.chkTSXX.Checked = false;
        this.drpTSXX.Text = "";
        this.drpTSXX.Items.Clear();
        this.hidTSXX.Value = "";

        this.chkPLX.Checked = false;
        this.drpPLX.Items.Clear();
        this.drpPLX.Enabled = false;
        this.hidPLX.Value = "";

        this.chkPCSX.Checked = false;
        this.drpPCSX.Enabled = false;

        this.chkWLH.Checked = false;
        this.drpWLH.Items.Clear();
        this.drpWLH.Text = "";
        this.hidWLH.Value = "";

        this.chkPH.Checked = false;
        this.drpPH.Items.Clear();
        this.drpPH.Text = "";
        this.hidPH.Value = "";

        this.chkWCBZ.Checked = false;
        this.drpWCBZ.Items.Clear();
        this.drpWCBZ.Enabled = false;
        this.hidWCBZ.Value = "";

        this.chkSCX.Checked = false;
        this.drpSCX.Items.Clear();
        this.drpSCX.Enabled = false;
        this.hidSCX.Value = "";

        this.chkGG.Checked = false;
        this.drpSCX.Enabled = false;
        this.hidSCX.Value = "";

        this.chkWGDH.Checked = false;
        this.drpWGDH.Text = "";
        this.hidWGDH.Value = "";

        this.chkDPP.Checked = false;
        this.drpDPP.Enabled = false;
        this.hidDPP.Value = "";

        this.chkZJR.Checked = false;
        this.drpZJR.Enabled = false;
        this.hidZJR.Value = "";

        this.chkPTime.Checked = false;
        this.txtPStartTime.Text = DateTime.Now.ToShortDateString();
        this.txtPStartTime.Enabled = false;
        this.txtPEndTime.Enabled = false;
        this.txtPEndTime.Text = DateTime.Now.ToShortDateString();

        this.chkPaoGou.Checked = false;

        this.chkRTime.Checked = false;
        this.txtRStartTime.Text = DateTime.Now.ToShortDateString();
        this.txtREndTime.Text = DateTime.Now.ToShortDateString();
        this.txtRStartTime.Enabled = false;
        this.txtREndTime.Enabled = false;
        this.grvWGD.DataSource = null;
        this.grvWGD.DataBind();
        this.PageControl1.SetInitView(0, 0);

        this.labCount.Text = "0";
        this.lblPaoGou.Text = "0";

        this.chkFree1.Checked = false;
        this.chkFree2.Checked = false;
        this.chkFree3.Checked = false;
        this.txtFree1.Text = "";
        this.txtFree2.Text = "";
        this.txtFree3.Text = "";
    }

    //查询按钮
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckUI())
        {
            string sql = GetSqlWhere();
            //if (string.IsNullOrEmpty(sql))
            //{
            //    this.PrintfError("请选择查询条件！");
            //    return;
            //}
            SetPageCountView();
            BindGridView();
            return;
        }
        this.PrintfError("时间格式有误，请重试！");
        return;
    }

    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }

    //绑定GridView
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            if (string.IsNullOrEmpty(sql))
            {
                this.PrintfError("请选择查询条件！");
                return;
            }
            string sortEx = this.grvWGD.Attributes["SortExpression"];
            string sortDirect = this.grvWGD.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = WGDQuery.QueryWGD(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvWGD.DataSource = ds;
            this.grvWGD.DataBind();
            SetSumInfo();
            this.SetDisplayList1.InitSetListControl(this.grvWGD, SysBaseConfig.WGD_Q_PAGE);
            this.SetDisplayList1.SetGridViewDisplay(grvWGD);
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }

    private void SelectPageSizeChange()
    {
        if (CheckUI())
        {
            SetPageCountView();
            BindGridView();
            return;
        }
        this.PrintfError("时间格式有误，请重试！");
        return;
    }
    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetSqlWhere();
            int outCount;
            int pageCount = WGDQuery.GetPageCount(sqlWhere,PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    //导出EXCEL
    protected void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvWGD.Rows.Count < 1)
        {
            this.PrintfError("没有要导出的数据！");
        }
        try
        {
            string sqlWhere = GetSqlWhere();
            DataSet ds = WGDQuery.QueryWGDExcel(sqlWhere);
            if (ds != null)
                this.CreateExcel(ds.Tables[0], "WGD.xls", PageControl1.GetRecordCount());
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
        if (this.grvWGD.Rows.Count < 1)
        {
            this.PrintfError("没有要打印的记录！");
            return;
        }
        //string sql = GetSqlWhere();
        //sql = Server.UrlEncode(sql);
        string url = CreateUrl();
        string strClient = "window.open(\""+url+"\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
        this.WriteClientJava(strClient);
    }

    //设置总计信息和跑钩数
    private void SetSumInfo()
    {
        if (this.grvWGD.Rows.Count > 0)
        {
            this.labCount.Text = PageControl1.GetRecordCount().ToString();
            try
            {
                this.lblPaoGou.Text = WGDQuery.GetPaoGouCount(GetSqlWhere()).ToString();
            }
            catch
            {
                this.lblPaoGou.Text = "0";
            }
        }
    }

    private string CreateUrl()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("PrintWGD.aspx?TYPE=1");
        if (this.grvWGD.Columns[1].Visible == false)
            sb.Append("&ISWGDH=true");
        if (this.grvWGD.Columns[2].Visible == false)
            sb.Append("&ISSCX=true");
        if (this.grvWGD.Columns[3].Visible == false)
            sb.Append("&ISPC=true");
        if (this.grvWGD.Columns[4].Visible == false)
            sb.Append("&ISPCSX=true");
        if (this.grvWGD.Columns[5].Visible == false)
            sb.Append("&ISTSXX=true");
        if (this.grvWGD.Columns[6].Visible == false)
            sb.Append("&ISPCLX=true");
        if (this.grvWGD.Columns[7].Visible == false)
            sb.Append("&ISPH=true");
        if (this.grvWGD.Columns[8].Visible == false)
            sb.Append("&ISGG=true");
        if (this.grvWGD.Columns[9].Visible == false)
            sb.Append("&ISWLH=true");
        if (this.grvWGD.Columns[10].Visible == false)
            sb.Append("&ISWLMC=true");
        if (this.grvWGD.Columns[11].Visible == false)
            sb.Append("&ISZXBZ=true");
        if (this.grvWGD.Columns[12].Visible == false)
            sb.Append("&ISFZDW=true");
        if (this.grvWGD.Columns[13].Visible == false)
            sb.Append("&ISPCXH=true");
        if (this.grvWGD.Columns[14].Visible == false)
            sb.Append("&ISZJBZ=true");
        if (this.grvWGD.Columns[15].Visible == false)
            sb.Append("&ISPGSM=true");
        if (this.grvWGD.Columns[16].Visible == false)
            sb.Append("&ISJSSJ=true");
        if (this.grvWGD.Columns[17].Visible == false)
            sb.Append("&ISSCWC=true");
        if (this.grvWGD.Columns[18].Visible == false)
            sb.Append("&ISRKWC=true");
        if (this.grvWGD.Columns[19].Visible == false)
            sb.Append("&ISDJZT=true");
        if (this.grvWGD.Columns[20].Visible == false)
            sb.Append("&ISBB=true");

        if (!string.IsNullOrEmpty(hidWGDH.Value))
        {
            sb.Append("&WGDH=" + hidWGDH.Value);
        }
        //批次号
        if (!string.IsNullOrEmpty(hidPCH.Value))
        {
            sb.Append("&PCH=" + hidPCH.Value);
        }
        //质检人
        if (!string.IsNullOrEmpty(this.hidZJR.Value))
        {
            string[] strZJR = this.hidZJR.Value.Split('|');
            sb.Append("&ZJR=" + strZJR[0].Trim());
        }
        //特殊信息
        if (!string.IsNullOrEmpty(this.hidTSXX.Value))
        {
            sb.Append("&TSXX=" + this.hidTSXX.Value);
        }
        //批次类型
        if (!string.IsNullOrEmpty(hidPLX.Value))
        {
            sb.Append("&PCLX=" + this.hidPLX.Value);
        }
        //批次属性
        if (!string.IsNullOrEmpty(hidPCSX.Value))
        {
            sb.Append("&PCSX=" + this.hidPCSX.Value);
        }
        //物料号
        if (!string.IsNullOrEmpty(hidWLH.Value))
        {
            sb.Append("&WLH=" + this.hidWLH.Value);
        }
        //生产线
        if (!string.IsNullOrEmpty(this.hidSCX.Value))
        {
            string tempStr = "ACCTRUE";
            string strSCXID = WGDQuery.GetSCXID(this.hidSCX.Value.Trim());
            if (!string.IsNullOrEmpty(strSCXID))
                tempStr = strSCXID;
            sb.Append("&SCX=" + tempStr);
        }
        //完成标志
        if (!string.IsNullOrEmpty(this.hidWCBZ.Value))
        {
            sb.Append("&WCBZ=" + hidWCBZ.Value);
        }
        //牌号
        if (!string.IsNullOrEmpty(this.hidPH.Value))
        {
            sb.Append("&PH=" + hidPH.Value);
        }
        //待判
        if (!string.IsNullOrEmpty(this.hidDPP.Value))
        {
            sb.Append("&DP=" + this.hidDPP.Value);
        }
        //规格
        if (!string.IsNullOrEmpty(hidGG.Value))
        {
            sb.Append("&GG=" + this.hidGG.Value);
        }
        //生产开始时间
        if (this.chkPTime.Checked && !string.IsNullOrEmpty(txtPStartTime.Text.Trim()))
        {
            string startTime = this.txtPStartTime.Text.Trim() + " 00:00:00";
            sb.Append("&SCKS=" + startTime);
        }
        //生产结束时间
        if (this.chkPTime.Checked && !string.IsNullOrEmpty(txtPEndTime.Text.Trim()))
        {
            string endTime = this.txtPEndTime.Text.Trim() + " 23:59:59";
            sb.Append("&SCJS=" + endTime);
        }
        //入库完成时间
        if (this.chkRTime.Checked && !string.IsNullOrEmpty(txtRStartTime.Text.Trim()))
        {
            string startTime = this.txtRStartTime.Text.Trim() + " 00:00:00";
            sb.Append("&RKWC=" + startTime);
        }
        //入库结束时间
        if (this.chkRTime.Checked && !string.IsNullOrEmpty(txtREndTime.Text.Trim()))
        {
            string endTime = this.txtREndTime.Text.Trim() + " 23:59:59";
            sb.Append("&RKJS=" + endTime);
        }
        if (this.chkPaoGou.Checked)
        {
            sb.Append("&PGBZ=1");
        }

        return sb.ToString();
    }

   
    protected void grvWGD_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvWGD.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvWGD.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvWGD.Attributes["SortExpression"] = SortExpression;
        this.grvWGD.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvWGD_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvWGD.Attributes["SortExpression"];
            string SortDirection = grvWGD.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvWGD.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvWGD.Columns[i].SortExpression.Trim();
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
