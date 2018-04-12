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
using ACCTRUE.WMSBLL.Model;

public partial class SiteBll_CheckQu_QuFydQr : AccPageBase
{
    public int i = 1;
    public int CKSum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCK();
            BindZDR();
            BindBM();
            BindSX();
            BindGG();

            string strDate = DateTime.Now.ToShortDateString();
            this.MakeStartTime.Text = strDate;
            this.MakeEndTime.Text = strDate;
            this.ChuKuEndTime.Text = strDate;
            this.ChuKuStartTime.Text = strDate;
            this.GoStartTime.Text = strDate;
            this.GoEndtime.Text = strDate;
            this.InEndTime.Text = strDate;
            this.InStartTime.Text = strDate;
            //this.imgBtnFei.Attributes.Add("onclick", " if(!confirm(\"是否作废该发运单\")) return false;");
            this.btnCancle.Attributes.Add("onclick", " if(!confirm(\"将终端结束的发运单置成正在装车状态，是否取消完成?\")) return false;");
        }
        this.SetDisplayList1.SCInit(this.grvFYD, SysBaseConfig.FYD_Q_PAGE);
    }
    private void BindCK()
    {
        try
        {
            DataSet ds = Store.GetList();
            this.drpCKH.DataSource = ds;
            this.drpCKH.DataBind();
            this.drpCKH.Items.Insert(0, "请选择");
            this.drpCKH.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    private void BindZDR()
    {
        try
        {
            DataSet ds = FYDQuery.GetZDRY();
            this.drpZDR.DataSource = ds;
            this.drpZDR.DataBind();
            this.drpZDR.Items.Insert(0, "请选择");
            this.drpZDR.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    private void BindBM()
    {
        try
        {
            DataSet ds = FYDQuery.GetBMY();
            this.drpBM.DataSource = ds;
            this.drpBM.DataBind();
            this.drpBM.Items.Insert(0, "请选择");
            this.drpBM.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    private void BindSX()
    {
        try
        {
            DataSet ds = FYDQuery.GetSX();
            this.drpSX.DataSource = ds;
            this.drpSX.DataBind();
            this.drpSX.Items.Insert(0, "请选择");
            this.drpSX.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    private void BindGG()
    {
        try
        {
            DataSet ds = FYDQuery.GetGG();
            this.drpGG.DataSource = ds;
            this.drpGG.DataBind();
            this.drpGG.Items.Insert(0, "请选择");
            this.drpGG.SelectedIndex = 0;
            this.drpCopyGG.DataSource = ds;
            this.drpCopyGG.DataBind();
            this.drpCopyGG.Items.Insert(0, "请选择");
            this.drpCopyGG.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
        }
    }
    //查询
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckUI())
        {
            string sql = GetSqlWhere();
            if (!string.IsNullOrEmpty(sql))
            {
                SetPageCountView();
                BindGridView();
                try
                {
                    DataSet dsCount = FYDQuery.GetFYDCollectionQR(sql);
                    this.lblCount.Text = (string.IsNullOrEmpty(dsCount.Tables[0].Rows[0]["fCount"].ToString())) ? "0" : dsCount.Tables[0].Rows[0]["fCount"].ToString();
                    this.jhsl.Text = (string.IsNullOrEmpty(dsCount.Tables[0].Rows[0]["sjhsl"].ToString())) ? "0" : dsCount.Tables[0].Rows[0]["sjhsl"].ToString();
                    this.jhzl.Text = (string.IsNullOrEmpty(dsCount.Tables[0].Rows[0]["sjhzl"].ToString())) ? "0" : Convert.ToDecimal(dsCount.Tables[0].Rows[0]["sjhzl"]).ToString("#0.0000");
                    this.sjsl.Text = (string.IsNullOrEmpty(dsCount.Tables[0].Rows[0]["ssjsl"].ToString())) ? "0" : dsCount.Tables[0].Rows[0]["ssjsl"].ToString();
                    this.sjzl.Text = (string.IsNullOrEmpty(dsCount.Tables[0].Rows[0]["ssjzl"].ToString())) ? "0" : Convert.ToDecimal(dsCount.Tables[0].Rows[0]["ssjzl"]).ToString("#0.0000");
                }
                catch
                {
                    this.PrintfError("数据访问错误！");
                }
                return;
            }
            this.PrintfError("请输入查询条件！");
            return;
        }
        else
        {
            PrintfError("输入时间日期格式有误！");
            return;
        }

    }
    //查询条件
    private string GetSqlWhere()
    {

        string sqlWhere = "";
        //hidFYD发运单
        if (this.chkFYD.Checked && !string.IsNullOrEmpty(this.drpFYD.Text) && this.drpFYD.Text.Trim() != "")
        {
            this.hidFYD.Value = this.drpFYD.Text;
            sqlWhere += " AND a.FYDH like '%" + this.hidFYD.Value.Trim() + "%'";
        }
        //仓库ID1
        if (this.chkCKH.Checked && this.drpCKH.SelectedIndex != 0)
        {
            sqlWhere += " AND a.CK ='" + this.drpCKH.SelectedValue + "' ";
        }
        //客户号1
        if (this.chkKHH.Checked && !string.IsNullOrEmpty(this.drpKHH.Text))
        {
            string[] strKHH = this.drpKHH.Text.Split('|');
            sqlWhere += " AND a.KHBM like '%" + strKHH[0].Trim() + "%'";

        }
        //车牌号
        if (this.chkCPH.Checked && !string.IsNullOrEmpty(this.drpCPH.Text))
        {
            this.hidCPH.Value = this.drpCPH.Text;
            sqlWhere += " AND a.CPH like '%" + this.hidCPH.Value.Trim() + "%'";
        }
        //物料号
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            this.hidWLH.Value = this.drpWLH.Text;
            sqlWhere += " AND a.WLH like '%" + this.hidWLH.Value.Trim() + "%'";
        }
        //属性
        if (this.chkSX.Checked && this.drpSX.SelectedIndex != 0)
        {
            sqlWhere += " AND a.SX='" + this.drpSX.SelectedValue + "'";
        }
        //特殊信息
        if (this.chkTSXX.Checked && !string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            this.hidTSXX.Value = this.drpTSXX.Text;
            sqlWhere += " AND a.pcinfo like '%" + this.drpTSXX.Text + "%'";
        }
        //批次号
        if (!string.IsNullOrEmpty(this.txtPC.Text) && this.chktxtPC.Checked)
        {
            sqlWhere += " AND EXISTS (SELECT 1 from wms_bms_inv_outinfo where wms_bms_inv_outinfo.fydh=a.fydh and wms_bms_inv_outinfo.pch like '%" + this.txtPC.Text.Trim() + "%')";
        }

        //牌号
        if (this.chkPH.Checked && !string.IsNullOrEmpty(this.drpPH.Text.Trim()))
        {
            this.hidPH.Value = this.drpPH.Text;
            sqlWhere += " AND a.PH like '%" + this.hidPH.Value.Trim() + "%'";
        }
        //进门卡号
        if (!string.IsNullOrEmpty(this.txtJMKH.Text) && this.chkJMKH.Checked)
        {
            sqlWhere += " AND a.indoorid like '%" + this.txtJMKH.Text.Trim() + "%'";
        }

        //出门卡号
        if (!string.IsNullOrEmpty(this.txtCMKH.Text) && this.chkCMKH.Checked)
        {
            sqlWhere += " AND a.outdoorid like '%" + this.txtCMKH.Text.Trim() + "%'";
        }
        //规格
        //1.GG为真，COPYGG为真
        if (drpGG.SelectedValue != "0" && this.drpCopyGG.SelectedValue != "0" && this.chkGG.Checked)
        {
            string startgg = this.drpGG.SelectedValue.Trim();
            string endgg = this.drpCopyGG.SelectedValue.Trim();
            sqlWhere += " AND (Convert(float,substring(a.GG,2,len(a.GG)-3)) >= Convert(float,substring('" + startgg + "',2,Len('" + startgg + "') -3)))";
            sqlWhere += " AND (Convert(float,substring(a.GG,2,len(a.GG)-3)) <= Convert(float,substring('" + endgg + "',2,Len('" + endgg + "')-3)))";
        }
        //2.GG为真，COPYGG不为真
        if (drpGG.SelectedValue != "0" && this.drpCopyGG.SelectedValue == "0" && this.chkGG.Checked)
        {
            sqlWhere += " AND a.GG='" + this.drpGG.SelectedValue.Trim() + "'";
        }
        //3.GG不为真,COPYGG为真
        if (drpGG.SelectedValue == "0" && drpCopyGG.SelectedValue != "0" && this.chkGG.Checked)
        {

            sqlWhere += " AND a.GG='" + this.drpCopyGG.SelectedValue + "'";
        }

        //运输
        if (this.chkChuanShu.Checked && this.drpChuanShu.SelectedIndex != 0)
        {
            sqlWhere += " AND a.YSLB=" + this.drpChuanShu.SelectedValue;
        }
        //制单人
        if (this.chkZDR.Checked && this.drpZDR.SelectedValue != "0")
        {

            sqlWhere += " AND a.NCZDRY='" + this.drpZDR.SelectedValue.Trim() + "'";
        }

        //部门hidBM
        if (this.chkBM.Checked && this.drpBM.SelectedValue != "0")
        {
            sqlWhere += " AND a.NCBM='" + this.drpBM.SelectedValue.Trim() + "'";
        }


        //状态
        //if (this.chkWCBZ.Checked && this.drpWCBZ.SelectedValue != "-1")
        //{
        //    sqlWhere += " AND a.status=" + this.drpWCBZ.SelectedValue.Trim();
        //}
        //if (!this.chkWCBZ.Checked)
        //{
        //    sqlWhere += " and a.status<>4";
        //}
        //地址
        if (this.chkADD.Checked && !string.IsNullOrEmpty(this.drpADD.Text) && this.drpADD.Text != "请选择")
        {
            sqlWhere += " AND a.AimAdress like '%" + this.drpADD.Text.Trim() + "%'";
        }

        

        //制单日期
        if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeStartTime.Text.Trim()))
        {
            string MakeStartTime = this.MakeStartTime.Text.Trim() + " 00:00:00";
            sqlWhere += " AND a.NCZDRQ >='" + MakeStartTime + "'";
        }
        if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeEndTime.Text.Trim()))
        {
            string MakeEndTime = this.MakeEndTime.Text.Trim() + " 23:59:59";
            sqlWhere += " AND a.NCZDRQ <='" + MakeEndTime + "'";
        }
        //出库时间
        if (this.chkChuKuTime.Checked && !string.IsNullOrEmpty(this.ChuKuStartTime.Text))
        {
            string ChuKuStartTime = this.ChuKuStartTime.Text.Trim() + " 00:00:00";
            sqlWhere += " AND a.CKRQ >='" + ChuKuStartTime + "'";

        }
        if (this.chkChuKuTime.Checked && !string.IsNullOrEmpty(this.ChuKuEndTime.Text))
        {
            string ChuKuEndTime = this.ChuKuEndTime.Text.Trim() + " 23:59:59";
            sqlWhere += " AND a.CKRQ <='" + ChuKuEndTime + "'";
        }
        //出门时间
        //if (this.chkGoTime.Checked && !string.IsNullOrEmpty(this.GoStartTime.Text))
        //{
        //    string GoStartTime = this.GoStartTime.Text.Trim() + " 00:00:00";
        //    sqlWhere += " AND a.CZ_OTTime >='" + GoStartTime + "'";
        //}
        //if (this.chkGoTime.Checked && !string.IsNullOrEmpty(this.GoEndtime.Text))
        //{
        //    string GoEndtime = this.GoEndtime.Text.Trim() + " 23:59:59";
        //    sqlWhere += " AND a.CZ_OTTime <='" + GoEndtime + "'";

        //}
        //入门时间
        if (this.chkInTime.Checked && !string.IsNullOrEmpty(this.InStartTime.Text))
        {
            string InStartTime = this.InStartTime.Text.Trim() + " 00:00:00";
            sqlWhere += " AND a.CZ_INTime >='" + InStartTime + "'";

        }
        if (this.chkInTime.Checked && !string.IsNullOrEmpty(this.InEndTime.Text))
        {
            string InEndTime = this.InEndTime.Text.Trim() + " 23:59:59";
            sqlWhere += " AND a.CZ_INTime <='" + InEndTime + "'";
        }
        //实发数0
        //if (this.chkSFS0.Checked)
        //{
        //    sqlWhere += " AND sjsl<=0";
        //}

        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            sqlWhere += " AND vfree1 like '%" + this.txtFree1.Text + "%'";
        }
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            sqlWhere += " AND vfree2 like '%" + this.txtFree2.Text + "%'";
        }
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            sqlWhere += " AND vfree3 like '%" + this.txtFree3.Text + "%'";
        }

        sqlWhere += " and a.ckrq>=convert(varchar(19),getdate()-7,21)";

        return sqlWhere;

    }
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        this.chkCKH.Checked = false;
        this.drpCKH.Enabled = false;
        this.drpCKH.SelectedIndex = 0;

        this.chkZDR.Checked = false;
        this.drpZDR.Enabled = false;
        this.drpZDR.SelectedIndex = 0;

        this.chkFYD.Checked = false;
        this.drpFYD.Text = "";
        this.hidFYD.Value = "";

        this.chkBM.Checked = false;
        this.drpBM.Enabled = false;
        this.drpBM.SelectedIndex = 0;

        this.chkCPH.Checked = false;
        this.drpCPH.Text = "";
        this.hidCPH.Value = "";

        this.chkWLH.Checked = false;
        this.drpWLH.Text = "";
        this.hidWLH.Value = "";

        this.chkWCBZ.Checked = false;
        this.drpWCBZ.Enabled = false;
        this.drpWCBZ.SelectedIndex = -1;

        this.chkPH.Checked = false;
        this.drpPH.Text = "";
        this.hidPH.Value = "";

        this.chkSX.Checked = false;
        this.drpSX.Enabled = false;
        this.drpSX.SelectedIndex = 0;

        this.chkGG.Checked = false;
        this.drpGG.Enabled = false;
        this.drpCopyGG.Enabled = false;

        this.chkTSXX.Checked = false;
        this.drpTSXX.Text = "";
        this.hidTSXX.Value = "";

        this.chkKHH.Checked = false;
        this.drpKHH.Text = "";
        this.hidKHH.Value = "";

        this.chkADD.Checked = false;
        this.hidADD.Value = "";
        this.drpADD.Text = "";

        this.chktxtPC.Checked = false;
        this.txtPC.Text = "";

        this.chkJMKH.Checked = false;
        this.txtJMKH.Text = "";

        this.chkCMKH.Checked = false;
        this.txtCMKH.Text = "";

        this.chkMakeTime.Checked = false;
        this.MakeStartTime.Enabled = false;
        this.MakeEndTime.Enabled = false;

        this.chkChuKuTime.Checked = false;
        this.ChuKuStartTime.Enabled = false;
        this.ChuKuEndTime.Enabled = false;

        this.chkGoTime.Checked = false;
        this.GoStartTime.Enabled = false;
        this.GoEndtime.Enabled = false;

        this.chkInTime.Checked = false;
        this.InStartTime.Enabled = false;
        this.InEndTime.Enabled = false;

        this.chkChuanShu.Checked = false;
        this.drpChuanShu.SelectedIndex = 0;
        this.drpChuanShu.Enabled = false;

        this.chkSFS0.Checked = false;
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            string sortEx = this.grvFYD.Attributes["SortExpression"];
            string sortDirect = this.grvFYD.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = FYDQuery.GetQueryFYDQR(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvFYD.DataSource = ds;
            this.grvFYD.DataBind();

            //this.SetDisplayList1.InitSetListControl(this.grvFYD, SysBaseConfig.FYD_Q_PAGE);
            //this.SetDisplayList1.SetGridViewDisplay(grvFYD);
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    public bool IsNumberic(string oText)
    {
        try
        {
            int var1 = Convert.ToInt32(oText);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool IsDouble(string oText)
    {
        try
        {
            Double var1 = Convert.ToDouble(oText);
            return true;
        }
        catch
        {
            return false;
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
            int pageCount = FYDQuery.GetPageCountQR(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    //检查时间格式是否正确
    private bool CheckUI()
    {
        try
        {
            if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeStartTime.Text.Trim()))
                Convert.ToDateTime(this.MakeStartTime.Text.Trim());
            if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeEndTime.Text.Trim()))
                Convert.ToDateTime(this.MakeEndTime.Text.Trim());
            if (this.chkChuKuTime.Checked && !string.IsNullOrEmpty(this.ChuKuEndTime.Text.Trim()))
                Convert.ToDateTime(this.ChuKuEndTime.Text.Trim());
            if (this.chkChuKuTime.Checked && !string.IsNullOrEmpty(this.GoStartTime.Text.Trim()))
                Convert.ToDateTime(this.GoStartTime.Text.Trim());

            if (this.chkGoTime.Checked && !string.IsNullOrEmpty(this.GoStartTime.Text.Trim()))
                Convert.ToDateTime(this.GoStartTime.Text.Trim());
            if (this.chkGoTime.Checked && !string.IsNullOrEmpty(this.GoEndtime.Text.Trim()))
                Convert.ToDateTime(this.GoEndtime.Text.Trim());
            if (this.chkInTime.Checked && !string.IsNullOrEmpty(this.InEndTime.Text.Trim()))
                Convert.ToDateTime(this.InEndTime.Text.Trim());
            if (this.chkInTime.Checked && !string.IsNullOrEmpty(this.InStartTime.Text.Trim()))
                Convert.ToDateTime(this.InStartTime.Text.Trim());
            return true;
        }
        catch
        {
            return false;
        }
    }

    //导出EXCEL
    protected void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        if (this.grvFYD.Rows.Count < 1)
        {
            this.PrintfError("没有要导出的数据！");
            return;
        }
        try
        {
            string sqlWhere = GetSqlWhere();
            DataSet ds = new DataSet();
            if (ds != null)
                this.CreateExcel(ds.Tables[0], "FYD.xls", PageControl1.GetRecordCount());
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }

    protected void grvFYD_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvFYD.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvFYD.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvFYD.Attributes["SortExpression"] = SortExpression;
        this.grvFYD.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvFYD_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvFYD.Attributes["SortExpression"];
            string SortDirection = grvFYD.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvFYD.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvFYD.Columns[i].SortExpression.Trim();
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
    protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    {
        if (!this.CUSER.USERFUNCTION.FYD_CancelFinish)
        {
            this.PrintfError("您没有取消发运单完成的权限!");
            return;
        }
        bool isCheck = false;
        foreach (GridViewRow row in this.grvFYD.Rows)
        {
            CheckBox chBox = (CheckBox)row.FindControl("chkCFYD");
            HtmlInputHidden hidStatus = (HtmlInputHidden)row.FindControl("strStatus");

            HtmlInputHidden hidYSLB = (HtmlInputHidden)row.FindControl("strYSLB");
            HtmlInputHidden hidFYDH = (HtmlInputHidden)row.FindControl("strFYDH");
            HtmlInputHidden hidCK = (HtmlInputHidden)row.FindControl("strCK");
            HtmlInputHidden hidWLH = (HtmlInputHidden)row.FindControl("strWLH");
            HtmlInputHidden hidSX = (HtmlInputHidden)row.FindControl("strSX");
            if (chBox.Checked)
            {
                isCheck = true;
                if (hidStatus.Value != "2")
                {
                    this.PrintfError("不能取消完成！");
                    return;
                }
                FYDQuery fydQ = new FYDQuery();
                try
                {
                    int result = fydQ.CancleWC(hidFYDH.Value, hidCK.Value, hidWLH.Value, hidSX.Value, this.CUSER.UserID);
                    if (result == -1)
                    {
                        PrintfError("取消完成失败！");
                        return;
                    }
                    PrintfError("取消完成成功！");
                    BindGridView();
                }
                catch
                {
                    PrintfError("数据访问错误！");
                    return;
                }
            }
        }
        if (isCheck == false)
        {
            PrintfError("没有选中的发运单！");
            return;
        }
    }
    protected void btnSCXH_Click(object sender, ImageClickEventArgs e)
    {
        string zcsl = txtCXH.Text.Trim();
        if (string.IsNullOrEmpty(txtCXH.Text.Trim()))
        {
            this.PrintfError("请输入装车数量！");
            return;
        }
        try
        {
            int v = int.Parse(zcsl);
        }
        catch (System.Exception ex)
        {
            this.PrintfError("装车数量必须为整数！");
            return;	
        }
        string fydh = hidFYDHitem.Value.Trim();
        string result = QuCheck.checkfydqr(fydh);
        if (result!="")
        {
            this.PrintfError(result);
            return;
        }
        ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
        result = QuCheck.zhqr(fydh, user.UserID, int.Parse(zcsl));
        if (result!="")
        {
            this.PrintfError(result);
            return;
        }
        else
        {
            PrintfError("操作成功！");
            BindGridView(); 
        }
        //bool isCheck = false;
        //foreach (GridViewRow row in this.grvFYD.Rows)
        //{
        //    CheckBox chBox = (CheckBox)row.FindControl("chkCFYD");
        //    HtmlInputHidden hidFYDH = (HtmlInputHidden)row.FindControl("strFYDH");
        //    if (chBox.Checked)
        //    {
        //        isCheck = true;
        //        try
        //        {
        //            int result = FYDQuery.UpdateFYDCPH(hidFYDH.Value.Trim(), this.txtCXH.Text.Trim());
        //            if (result == 1)
        //            {
        //                PrintfError("车厢号修改失败！");
        //                return;
        //            }
        //            PrintfError("车厢号修改成功！");
        //            BindGridView();
        //            this.hidItem.Value = "";
        //            return;
        //        }
        //        catch
        //        {
        //            PrintfError("数据访问错误！");
        //            return;
        //        }
        //    }
        //}
        //if (isCheck == false)
        //{
        //    PrintfError("没有选中要修改车厢号的发运单");
        //    return;
        //}
    }
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
       
        string url = "PrintFYD.aspx";
        if (this.rdoReport.SelectedValue == "1")
        {
            url += "?TYPE=1";
            url += CreateParams();
            string strClient = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
            this.WriteClientJava(strClient);
            return;
        }
        bool isCheck = false;
        foreach (GridViewRow row in this.grvFYD.Rows)
        {
            CheckBox chBox = (CheckBox)row.FindControl("chkCFYD");
            HtmlInputHidden hidFYDH = (HtmlInputHidden)row.FindControl("strFYDH");
            HtmlInputHidden hidYSLB = (HtmlInputHidden)row.FindControl("strYSLB");
            HtmlInputHidden hidCPH = (HtmlInputHidden)row.FindControl("strCPH");
            if (chBox.Checked)
            {
                isCheck = true;
                this.hidItem.Value = "";

                if (this.rdoReport.SelectedValue == "0")
                {
                    url += "?TYPE=0";
                    url += "&FYDH=" + hidFYDH.Value;
                    url += "&YSLB=" + hidYSLB.Value;
                    url += "&CPH=" + Server.UrlEncode(hidCPH.Value);
                    string strClient1 = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
                    this.WriteClientJava(strClient1);
                    return; 
                }
                if (this.rdoReport.SelectedValue == "2")
                {
                    url += "?TYPE=2";
                    url += "&FYDH=" + hidFYDH.Value;
                    url += "&YSLB=" + hidYSLB.Value;
                    url += "&CPH=" + Server.UrlEncode(hidCPH.Value);
                    string strClient1 = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
                    this.WriteClientJava(strClient1);
                    return;
                }
                if (this.rdoReport.SelectedValue == "3")
                {
                    url += "?TYPE=3";
                    url += "&FYDH=" + hidFYDH.Value;
                    url += "&YSLB=" + hidYSLB.Value;
                    url += "&CPH=" + Server.UrlEncode(hidCPH.Value);
                    string strClient1 = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
                    this.WriteClientJava(strClient1);
                    return;
                }
            }
        }
        this.hidItem.Value = "";
        if (isCheck == false)
        {
            PrintfError("没有选中要打印的发运单信息");
            return;
        }
    }

    private string CreateParams()
    {
        StringBuilder sb = new StringBuilder();
        //hidFYD发运单
        if (this.chkFYD.Checked && !string.IsNullOrEmpty(this.drpFYD.Text) && this.drpFYD.Text.Trim() != "")
        {
            sb.Append("&FYDH=");
            sb.Append(this.drpFYD.Text.Trim());
        }
        //仓库ID1
        if (this.chkCKH.Checked && this.drpCKH.SelectedIndex != 0)
        {
            sb.Append("&CK=");
            sb.Append(this.drpCKH.SelectedValue);
        }
        //客户号1
        if (this.chkKHH.Checked && !string.IsNullOrEmpty(this.drpKHH.Text))
        {
            sb.Append("&KHH=");
            sb.Append(this.drpKHH.Text);
        }
        //车牌号
        if (this.chkCPH.Checked && !string.IsNullOrEmpty(this.drpCPH.Text))
        {
            sb.Append("&CPH=");
            sb.Append(Server.UrlEncode(this.drpCPH.Text));
        }
        //物料号
        if (this.chkWLH.Checked && !string.IsNullOrEmpty(this.drpWLH.Text))
        {
            sb.Append("&WLH=");
            sb.Append(this.drpWLH.Text);
        }
        //属性
        if (this.chkSX.Checked && this.drpSX.SelectedIndex != 0)
        {
            sb.Append("&SX=");
            sb.Append(Server.UrlEncode(this.drpSX.SelectedValue));
        }
        //特殊信息
        if (this.chkTSXX.Checked && !string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            sb.Append("&TSXX=");
            sb.Append(Server.UrlEncode(this.drpTSXX.Text));
        }
        //批次号
        if (!string.IsNullOrEmpty(this.txtPC.Text) && this.chktxtPC.Checked)
        {
            sb.Append("&PC=");
            sb.Append(this.txtPC.Text);
        }

        //牌号
        if (this.chkPH.Checked && !string.IsNullOrEmpty(this.drpPH.Text.Trim()))
        {
            sb.Append("&PH=");
            sb.Append(this.drpPH.Text);
        }
        //进门卡号
        if (!string.IsNullOrEmpty(this.txtJMKH.Text) && this.chkJMKH.Checked)
        {
            sb.Append("&JMKH=");
            sb.Append(this.txtJMKH.Text);
        }

        //出门卡号
        if (!string.IsNullOrEmpty(this.txtCMKH.Text) && this.chkCMKH.Checked)
        {
            sb.Append("&CMKH=");
            sb.Append(this.txtCMKH.Text);
        }
        //规格
        //1.GG为真，COPYGG为真
        if (drpGG.SelectedValue != "0" && this.drpCopyGG.SelectedValue != "0" && this.chkGG.Checked)
        {
            sb.Append("&MIGG=");
            sb.Append(Server.UrlEncode(this.drpGG.SelectedValue));
            sb.Append("&MAGG=");
            sb.Append(Server.UrlEncode(this.drpCopyGG.SelectedValue));
        }
        //2.GG为真，COPYGG不为真
        if (drpGG.SelectedValue != "0" && this.drpCopyGG.SelectedValue == "0" && this.chkGG.Checked)
        {
            sb.Append("&GG=");
            sb.Append(this.drpGG.SelectedValue);
        }
        //3.GG不为真,COPYGG为真
        if (drpGG.SelectedValue == "0" && drpCopyGG.SelectedValue != "0" && this.chkGG.Checked)
        {
            sb.Append("&GG=");
            sb.Append(this.drpCopyGG.SelectedValue);
        }

        //运输
        if (this.chkChuanShu.Checked && this.drpChuanShu.SelectedIndex != 0)
        {
            sb.Append("&YSLB=");
            sb.Append(this.drpChuanShu.SelectedValue);
        }
        //制单人
        if (this.chkZDR.Checked && this.drpZDR.SelectedValue != "0")
        {
            sb.Append("&ZDR=");
            sb.Append(Server.UrlEncode(this.drpZDR.SelectedValue));
        }

        //部门hidBM
        if (this.chkBM.Checked && this.drpBM.SelectedValue != "0")
        {
            sb.Append("&BM=");
            sb.Append(this.drpBM.SelectedValue);
        }

        //状态
        if (this.chkWCBZ.Checked && this.drpWCBZ.SelectedValue != "-1")
        {
            sb.Append("&STATUS=");
            sb.Append(this.drpWCBZ.SelectedValue);
        }
        if (!this.chkWCBZ.Checked)
        {
            sb.Append("&CSTATUS=");
            sb.Append("4");
        }

        //地址
        if (this.chkADD.Checked && !string.IsNullOrEmpty(this.drpADD.Text) && this.drpADD.Text != "请选择")
        {
            sb.Append("&ADD=");
            sb.Append(Server.UrlEncode(this.drpADD.Text));
        }



        //制单日期
        if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeStartTime.Text.Trim()))
        {
            sb.Append("&SNCZDRQ=");
            string MakeStartTime = this.MakeStartTime.Text.Trim() + " 00:00:00";
            sb.Append(MakeStartTime);
        }
        if (this.chkMakeTime.Checked && !string.IsNullOrEmpty(this.MakeEndTime.Text.Trim()))
        {
            sb.Append("&ENCZDRQ=");
            string MakeEndTime = this.MakeEndTime.Text.Trim() + " 23:59:59";
            sb.Append(MakeEndTime);
        }
        //出库时间
        if (this.chkChuKuTime.Checked && !string.IsNullOrEmpty(this.ChuKuStartTime.Text))
        {
            sb.Append("&SCKRQ=");
            string ChuKuStartTime = this.ChuKuStartTime.Text.Trim() + " 00:00:00";
            sb.Append(ChuKuStartTime);
        }
        if (this.chkChuKuTime.Checked && !string.IsNullOrEmpty(this.ChuKuEndTime.Text))
        {
            sb.Append("&ECKRQ=");
            string ChuKuEndTime = this.ChuKuEndTime.Text.Trim() + " 23:59:59";
            sb.Append(ChuKuEndTime);
        }
        //出门时间
        if (this.chkGoTime.Checked && !string.IsNullOrEmpty(this.GoStartTime.Text))
        {
            sb.Append("&SCZ_OTTime=");
            string GoStartTime = this.GoStartTime.Text.Trim() + " 00:00:00";
            sb.Append(GoStartTime);
        }
        if (this.chkGoTime.Checked && !string.IsNullOrEmpty(this.GoEndtime.Text))
        {
            sb.Append("&ECZ_OTTime=");
            string GoEndtime = this.GoEndtime.Text.Trim() + " 23:59:59";
            sb.Append(GoEndtime);
        }
        //入门时间
        if (this.chkInTime.Checked && !string.IsNullOrEmpty(this.InStartTime.Text))
        {
            sb.Append("&SCZ_INTime=");
            string InStartTime = this.InStartTime.Text.Trim() + " 00:00:00";
            sb.Append(InStartTime);
        }
        if (this.chkInTime.Checked && !string.IsNullOrEmpty(this.InEndTime.Text))
        {
            sb.Append("&ECZ_INTime=");
            string InEndTime = this.InEndTime.Text.Trim() + " 23:59:59";
            sb.Append(InEndTime);
        }
        //实发数0
        if (this.chkSFS0.Checked)
        {
            sb.Append("&sjsl=0");
        }
        //自由项1
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text))
        {
            sb.Append("&free1=");
            sb.Append(Server.UrlEncode(this.txtFree1.Text));
        }
        //自由项2
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text))
        {
            sb.Append("&free2=");
            sb.Append(Server.UrlEncode(this.txtFree2.Text));
        }

        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text))
        {
            sb.Append("&free3=");
            sb.Append(Server.UrlEncode(this.txtFree3.Text));
        }
        return sb.ToString();
    }
    protected void btn_camer_Click(object sender, ImageClickEventArgs e)
    {
        //string userid = Config.Curuserid;
        ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
        string fydh = hidFYDHitem.Value.Trim();
        string v = QuCheck.sendcmd(fydh,user.UserID);
        if (v != "")
        {
            PrintfError("拍照失败！" + v);
            return;
        }
        else PrintfError("拍照成功！");
    }
}
