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

public partial class SiteBll_StockMan_CuCunQuery :AccPageBase
{
    public string ViewID = "";
    public int SUMCK;
    public int i=1;
    public int SUMSL;
    public double SUMZL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.drpCK.Attributes.Add("onchange", "ChangeCK();");
            //this.drpHW.Attributes.Add("onchange", "ChangeHW();");
            //this.drpRKPCH.Attributes.Add("onchange", "ChangeRKPCH();");
            this.drpRKPH.Attributes.Add("onchange", "ChangeRKPH();");
            this.drpRKSX.Attributes.Add("onchange", "ChangeRKSX();");
            //this.drpWLH.Attributes.Add("onchange", "ChangeWLH();");
            this.drpTSXX.Attributes.Add("onchange", "ChangeTSXX();");
            this.drpGG.Attributes.Add("onchange", "ChangeGG();");
            this.drpCopyGG.Attributes.Add("onchange", "ChangeCopyGG();");
            //this.drpTM.Attributes.Add("onchange", "ChangeTM();");
            string strdate = DateTime.Now.ToShortDateString();
            RKRQ_Start.Text = strdate;
            RKRQ_End.Text = strdate;
        }
        //if (this.chkHW.Checked)
        //{
        //    this.txtHW.ReadOnly = false;
        //}
        //else
        //{
        //    this.txtHW.ReadOnly = true;
        //}
        //if (this.chkRKPCH.Checked)
        //{
        //    this.txtPCH.ReadOnly = false;
        //}
        //else
        //{
        //    this.txtPCH.ReadOnly = true;
        //}
        //if (this.chkTM.Checked)
        //{
        //    this.txtBarcode.ReadOnly = false;
        //}
        //else
        //{
        //    this.txtBarcode.ReadOnly = true;
        //}
        //if (this.chkWLH.Checked)
        //{
        //    this.txtWLH.ReadOnly = false;
        //}
        //else
        //{
        //    this.txtWLH.ReadOnly = true;
        //}
        this.SetDisplayList1.SCInit(this.grvKC_PCH, SysBaseConfig.KC_Q_PAGE);
    }
    //查询条件
    private string GetSqlstr()
    {
        string sqlstr = "";
        if (this.chkCK.Checked&&!string.IsNullOrEmpty(hidCK.Value))
        {
            sqlstr += "AND CK='" + hidCK.Value + "'";
        }
        if (this.chkRKPCH.Checked&&!string.IsNullOrEmpty(this.txtPCH.Text))
        {
            sqlstr += " AND PCH like '%" + this.txtPCH.Text.Trim() + "%'";
        }
        if (this.chkRKSX.Checked && !string.IsNullOrEmpty(hidRKSX.Value))
        {
                sqlstr += " AND SX='" + hidRKSX.Value + "'";
        }
        if (this.chkWLH.Checked&&!string.IsNullOrEmpty(this.txtWLH.Text.Trim()))
        {
            sqlstr += " AND WLH like '" + this.txtWLH.Text.Trim() + "%'";
        }
        if (this.chkFree1.Checked && !string.IsNullOrEmpty(this.txtFree1.Text.Trim()))
        {
            sqlstr += " AND VFREE1 like '" + this.txtFree1.Text.Trim() + "%'";
        }
        if (this.chkFree2.Checked && !string.IsNullOrEmpty(this.txtFree2.Text.Trim()))
        {
            sqlstr += " AND VFREE2 like '" + this.txtFree2.Text.Trim() + "%'";
        }
        if (this.chkFree3.Checked && !string.IsNullOrEmpty(this.txtFree3.Text.Trim()))
        {
            sqlstr += " AND VFREE3 like '" + this.txtFree3.Text.Trim() + "%'";
        }
        if (this.chkHW.Checked&&!string.IsNullOrEmpty(this.txtHW.Text))
        {
            sqlstr += " AND HW like '%" + this.txtHW.Text.Trim() + "%'";
        }
  
        //特殊信息
        if (this.chkTSXX.Checked&&!string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            sqlstr += " AND pcinfo like '%" + drpTSXX.Text.Trim() + "%'";

        }
        //牌号精确查询
        if (this.chkRKPH.Checked&&!string.IsNullOrEmpty(this.drpRKPH.Text) && !this.chkPHMH.Checked)
        {
            sqlstr += " AND PH = '" + drpRKPH.Text.Trim() + "'";
        }
        //牌号模糊查询
        if (this.chkRKPH.Checked && !string.IsNullOrEmpty(this.drpRKPH.Text) && this.chkPHMH.Checked)
        {
            sqlstr += " AND PH like '%" + drpRKPH.Text.Trim() + "%'";
        }
        //条码
        if (this.chkTM.Checked&&!string.IsNullOrEmpty(this.txtBarcode.Text))
        {
            sqlstr += " AND Barcode like '%" + txtBarcode.Text.Trim() + "%'";
        }
        //规格
        //1.GG为真，COPYGG为真
        if (this.chkGG.Checked&&!string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
           string startgg = this.hidGG.Value.Trim();
           string endgg = this.hidCopyGG.Value.Trim();
           sqlstr += " AND (Convert(float,substring(GG,2,len(GG)-3)) >= Convert(float,substring('" + startgg + "',2,Len('" + startgg + "') -3)))";
           sqlstr += " AND (Convert(float,substring(GG,2,len(GG)-3)) <= Convert(float,substring('" + endgg + "',2,Len('" + endgg + "')-3)))";
        }
        //2.GG为真，COPYGG不为真
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.hidGG.Value) && string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            sqlstr += " AND GG='" + this.hidGG.Value.Trim() + "'";
        }
        //3.GG不为真,COPYGG为真
        if (this.chkGG.Checked && string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
        {

            sqlstr += " AND GG='" + this.hidCopyGG.Value.Trim() + "'";

        }
        //时间
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_Start.Text))
        {
            string RKRQ_Start = this.RKRQ_Start.Text.Trim() + " 00:00:00";
            sqlstr += " AND RQ >='" + RKRQ_Start + "'";

        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.RKRQ_End.Text))
        {
            string RKRQ_End = this.RKRQ_End.Text.Trim() + " 23:59:59";
            sqlstr += " AND RQ <='" + RKRQ_End + "'";
        }
        //称重时间
        if (this.chkWRQ.Checked && !string.IsNullOrEmpty(this.txtWRQfrom.Text))
        {
            string WRQfrom = this.txtWRQfrom.Text.Trim() + " 00:00:00";
            sqlstr += " AND weightRQ >='" + WRQfrom + "'";

        }
        if (this.chkWRQ.Checked && !string.IsNullOrEmpty(this.txtWRQto.Text))
        {
            string WRQto = this.txtWRQto.Text.Trim() + " 23:59:59";
            sqlstr += " AND weightRQ <='" + WRQto + "'";
        }
        return sqlstr;
    }
    //查询
    protected void imgBtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        //string sql = GetSqlstr();     ---徐慧杰 2008.1.7修改,注释掉了此句
        ViewID = this.drpVIEW.SelectedValue;
        switch (ViewID)
        {
            case "0":
                SetPagePCH();
                BindgrvKC_PCH();
                break;
            case "1":
                SetPageHW();
                BindgrvKC_HW();
                break;
            case "2":
                SetPageTM();
                BindgrvKC_TM();
                break;
            case "3":
                SetPageWLH();
                BindgrvKC_WLH();
                break;
        }
        this.hidRKPH.Value = this.drpRKPH.Text.Trim();
    }
    protected override void OnPreInit(EventArgs e)
    {
        
            this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindgrvKC_PCH);
            this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChangePCH);
               
            this.PageControl2.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindgrvKC_HW);
            this.PageControl2.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChangeHW);
        
            this.PageControl3.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindgrvKC_TM);
            this.PageControl3.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChangeTM);

            this.PageControl4.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindgrvKC_WLH);
            this.PageControl4.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChangeWLH);
           
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
    private void SelectPageSizeChangePCH()
    {
        SetPagePCH();
        BindgrvKC_PCH();
    }
    private void SelectPageSizeChangeHW()
    {
        SetPageHW();
        BindgrvKC_HW();
    }
    private void SelectPageSizeChangeTM()
    {
        SetPageTM();
        BindgrvKC_TM();
    }
    private void SelectPageSizeChangeWLH()
    {
        SetPageWLH();
        BindgrvKC_WLH();
    }
    //设置分页控件显示
    private void SetPagePCH()
    {
        try
        {
        string sqlWhere = GetSqlstr();
        int outCount;
        int pageCount = KCQuery.GetPageCount_PCH(sqlWhere, PageControl1.GetPageSize(), out outCount);
        PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    private void SetPageHW()
    {
        try
        {
            string sqlWhere = GetSqlstr();
            int outCount;
            int pageCount = KCQuery.GetPageCount_HW(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl2.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    private void SetPageTM()
    {
        try
        {
            string sqlWhere = GetSqlstr();
            int outCount;
            int pageCount = KCQuery.GetPageCount_TM(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl3.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    private void SetPageWLH()
    {
        try
        {
            string sqlWhere = GetSqlstr();
            int outCount;
            int pageCount = KCQuery.GetPageCount_WLH(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl4.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    //绑定grvKC_PCH
    private void BindgrvKC_PCH()
    {
        try
        {
            string sql = GetSqlstr();
            string sortEx = this.grvKC_PCH.Attributes["SortExpression"];
            string sortDirect = this.grvKC_PCH.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = KCQuery.GetQueryKC_PCH(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvKC_PCH.DataSource = ds;
            this.grvKC_PCH.DataBind();
            DataSet dsCount = KCQuery.GetCountKC_PCH(sql);
            if (dsCount != null && dsCount.Tables[0].Rows.Count > 0 && dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString() != "0")
            {
                this.lblCount.Text = dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString();
                this.lblSL.Text = dsCount.Tables[0].Rows[0]["HJSL"].ToString();
                this.lblZL.Text = Convert.ToDecimal(dsCount.Tables[0].Rows[0]["HJZL"]).ToString("#0.0000");
            }
            else
            {
                this.lblCount.Text = "0";
                this.lblSL.Text = "0";
                this.lblZL.Text = "0.0000";
            }
            this.SetDisplayList1.InitSetListControl(this.grvKC_PCH, SysBaseConfig.KC_Q_PAGE);
            this.SetDisplayList1.SetGridViewDisplay(grvKC_PCH);
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    //绑定grvKC_HW
    private void BindgrvKC_HW()
    {
        try
        {
            string sql = GetSqlstr();
            string sortEx = this.grvKC_HW.Attributes["SortExpression"];
            string sortDirect = this.grvKC_HW.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = KCQuery.GetQueryKC_HW(sql, strSort, PageControl2.GetPageSize(), PageControl2.GetCurrPage());
            this.grvKC_HW.DataSource = ds;
            this.grvKC_HW.DataBind();
            DataSet dsCount = KCQuery.GetCountKC_HW(sql);
            if (dsCount != null && dsCount.Tables[0].Rows.Count > 0 && dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString() != "0")
            {
                this.lblCount.Text = dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString();
                this.lblSL.Text = dsCount.Tables[0].Rows[0]["HJSL"].ToString();
                this.lblZL.Text = Convert.ToDecimal(dsCount.Tables[0].Rows[0]["HJZL"]).ToString("#0.0000");
            }
            else
            {
                this.lblCount.Text = "0";
                this.lblSL.Text = "0";
                this.lblZL.Text = "0.0000";
            }
            this.SetDisplayList1.InitSetListControl(this.grvKC_PCH, SysBaseConfig.KC_Q_PAGE);
            this.SetDisplayList1.SetGridViewDisplay(grvKC_PCH);
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    //绑定grvKC_TM
    private void BindgrvKC_TM()
    {
        try
        {
            string sql = GetSqlstr();
            string sortEx = this.grvKC_TM.Attributes["SortExpression"];
            string sortDirect = this.grvKC_TM.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = KCQuery.GetQueryKC_TM(sql, strSort, PageControl3.GetPageSize(), PageControl3.GetCurrPage());
            this.grvKC_TM.DataSource = ds;
            this.grvKC_TM.DataBind();
            DataSet dsCount = KCQuery.GetCountKC_TM(sql);
            if (dsCount != null && dsCount.Tables[0].Rows.Count > 0 && dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString() != "0")
            {
                this.lblCount.Text = dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString();
                this.lblSL.Text = dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString();
                this.lblZL.Text = Convert.ToDecimal(dsCount.Tables[0].Rows[0]["HJZL"]).ToString("#0.0000");
            }
            else
            {
                this.lblCount.Text = "0";
                this.lblSL.Text = "0";
                this.lblZL.Text = "0.0000";
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    //绑定grvKC_WLH
    private void BindgrvKC_WLH()
    {
        try
        {
            string sql = GetSqlstr();
            string sortEx = this.grvKC_WLH.Attributes["SortExpression"];
            string sortDirect = this.grvKC_WLH.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = KCQuery.GetQueryKC_WLH(sql, strSort, PageControl4.GetPageSize(), PageControl4.GetCurrPage());
            this.grvKC_WLH.DataSource = ds;
            this.grvKC_WLH.DataBind();
            DataSet dsCount = KCQuery.GetCountKC_WLH(sql);
            if (dsCount != null && dsCount.Tables[0].Rows.Count > 0 && dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString() != "0")
            {
                this.lblCount.Text = dsCount.Tables[0].Rows[0]["HJCOUNT"].ToString();
                this.lblSL.Text = dsCount.Tables[0].Rows[0]["HJSL"].ToString();
                this.lblZL.Text = Convert.ToDecimal(dsCount.Tables[0].Rows[0]["HJZL"]).ToString("#0.0000");
            }
            else
            {
                this.lblCount.Text = "0";
                this.lblSL.Text = "0";
                this.lblZL.Text = "0.0000";
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }

    //重置
    protected void imgBtnCancle_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBarcode.Text = "";
        this.txtHW.Text = "";
        this.txtPCH.Text = "";
        this.txtWLH.Text = "";
        this.txtFree1.Text = "";
        this.txtFree2.Text = "";
        this.txtFree3.Text = "";
        this.hidCK.Value = "";
        this.hidCopyGG.Value = "";
        this.hidGG.Value = "";
        this.hidQuery.Value = "";
        this.hidRKPH.Value = "";
        this.hidRKRQ.Value = "";
        this.hidRKSX.Value = "";
        this.hidTSXX.Value = "";
        this.drpCK.Items.Clear();
        this.drpCopyGG.Items.Clear();
        this.drpCopyGG.Text = "";
        this.drpGG.Items.Clear();
        this.drpGG.Text = "";
        this.drpRKPH.Items.Clear();
        this.drpRKPH.Text = "";
        this.drpRKSX.Items.Clear();
        this.drpTSXX.Items.Clear();
        this.drpTSXX.Text = "";
        this.chkCK.Checked = false;
        this.chkGG.Checked = false;
        this.chkHW.Checked = false;
        this.chkRKPCH.Checked = false;
        this.chkRKPH.Checked = false;
        this.chkRKRQ.Checked = false;
        this.chkRKSX.Checked = false;
        this.chkTM.Checked = false;
        this.chkTSXX.Checked = false;
        this.chkWLH.Checked = false;
        this.chkFree1.Checked = false;
        this.chkFree2.Checked = false;
        this.chkFree3.Checked = false;
        this.grvKC_HW.DataSource = null;
        this.grvKC_PCH.DataSource = null;
        this.grvKC_TM.DataSource = null;
        this.grvKC_WLH.DataSource = null;
        this.grvKC_PCH.DataBind();
        this.grvKC_TM.DataBind();
        this.grvKC_HW.DataBind();
        this.grvKC_WLH.DataBind();
        PageControl1.SetInitView(0, 0);
        PageControl2.SetInitView(0, 0);
        PageControl3.SetInitView(0, 0);
        PageControl4.SetInitView(0, 0);
    }
    //打印
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        ViewID = drpVIEW.SelectedValue.Trim();
        string url = "";
        switch (ViewID)
        {
            case "0":
                if (this.grvKC_PCH.Rows.Count < 1)
                {
                    this.PrintfError("没有要打印的记录！");
                    return;
                }
                url = CreateUrl("0");
                break;
            case "1":
                if (this.grvKC_HW.Rows.Count < 1)
                {
                    this.PrintfError("没有要打印的记录！");
                    return;
                }
                url = CreateUrl("1");
                break;
            case "2":
                if (this.grvKC_TM.Rows.Count < 1)
                {
                    this.PrintfError("没有要打印的记录！");
                    return;
                }
                url = CreateUrl("2");
                break;
            case "3":
                if (this.grvKC_WLH.Rows.Count < 1)
                {
                    this.PrintfError("没有要打印的记录！");
                    return;
                }
                url = CreateUrl("3");
                break;
        }
        string strClient = "window.open(\"" + url + "\",\"\",\"toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes\")";
        this.WriteClientJava(strClient);
    }

    private string CreateUrl(string Type)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("PrintKuCun.aspx?TYPE=" + Type);
        switch (Type)
        {
            case "0":
                if (this.grvKC_PCH.Columns[0].Visible == false)
                    sb.Append("&ISPCH=true");
                if (this.grvKC_PCH.Columns[1].Visible == false)
                    sb.Append("&ISCK=true");
                if (this.grvKC_PCH.Columns[2].Visible == false)
                    sb.Append("&ISSX=true");
                if (this.grvKC_PCH.Columns[3].Visible == false)
                    sb.Append("&ISPH=true");
                if (this.grvKC_PCH.Columns[4].Visible == false)
                    sb.Append("&ISGG=true");
                if (this.grvKC_PCH.Columns[5].Visible == false)
                    sb.Append("&ISWLH=true");
                if (this.grvKC_PCH.Columns[6].Visible == false)
                    sb.Append("&ISSL=true");
                if (this.grvKC_PCH.Columns[7].Visible == false)
                    sb.Append("&ISSUMZL=true");
                if (this.grvKC_PCH.Columns[8].Visible == false)
                    sb.Append("&ISRKRQ=true");
                if (this.grvKC_PCH.Columns[9].Visible == false)
                    sb.Append("&ISWLMC=true");
                if (this.grvKC_PCH.Columns[10].Visible == false)
                    sb.Append("&ISFREE1=true");
                if (this.grvKC_PCH.Columns[11].Visible == false)
                    sb.Append("&ISFREE2=true");
                if (this.grvKC_PCH.Columns[12].Visible == false)
                    sb.Append("&ISFREE3=true");
                break;
            case "1":
                if (this.grvKC_HW.Columns[0].Visible == false)
                    sb.Append("&ISHW=true");
                if (this.grvKC_HW.Columns[1].Visible == false)
                    sb.Append("&ISCK=true");
                if (this.grvKC_HW.Columns[2].Visible == false)
                    sb.Append("&ISPCH=true");
                if (this.grvKC_HW.Columns[3].Visible == false)
                    sb.Append("&ISSX=true");
                if (this.grvKC_HW.Columns[4].Visible == false)
                    sb.Append("&ISWLH=true");
                if (this.grvKC_HW.Columns[5].Visible == false)
                    sb.Append("&ISPH=true");
                if (this.grvKC_HW.Columns[6].Visible == false)
                    sb.Append("&ISGG=true");
                if (this.grvKC_HW.Columns[7].Visible == false)
                    sb.Append("&ISSL=true");
                if (this.grvKC_HW.Columns[8].Visible == false)
                    sb.Append("&ISSUMZL=true");
                if (this.grvKC_HW.Columns[9].Visible == false)
                    sb.Append("&ISRKRQ=true");
                if (this.grvKC_HW.Columns[10].Visible == false)
                    sb.Append("&ISWLMC=true");
                if (this.grvKC_PCH.Columns[10].Visible == false)
                    sb.Append("&ISFREE1=true");
                if (this.grvKC_PCH.Columns[11].Visible == false)
                    sb.Append("&ISFREE2=true");
                if (this.grvKC_PCH.Columns[12].Visible == false)
                    sb.Append("&ISFREE3=true");
                break;
            case "2":
                if (this.grvKC_TM.Columns[0].Visible == false)
                    sb.Append("&ISBarcode=true");
                if (this.grvKC_TM.Columns[1].Visible == false)
                    sb.Append("&ISHW=true");
                if (this.grvKC_TM.Columns[2].Visible == false)
                    sb.Append("&ISPCH=true");
                if (this.grvKC_TM.Columns[3].Visible == false)
                    sb.Append("&ISWLH=true");
                if (this.grvKC_TM.Columns[4].Visible == false)
                    sb.Append("&ISSX=true");
                if (this.grvKC_TM.Columns[5].Visible == false)
                    sb.Append("&ISErrSeason=true");
                if (this.grvKC_TM.Columns[6].Visible == false)
                    sb.Append("&ISPH=true");
                if (this.grvKC_TM.Columns[7].Visible == false)
                    sb.Append("&ISGG=true");
                if (this.grvKC_TM.Columns[8].Visible == false)
                    sb.Append("&ISZL=true");
                if (this.grvKC_TM.Columns[9].Visible == false)
                    sb.Append("&ISBZ=true");
                if (this.grvKC_TM.Columns[10].Visible == false)
                    sb.Append("&ISRQ=true");
                if (this.grvKC_TM.Columns[11].Visible == false)
                    sb.Append("&ISWGDH=true");
                if (this.grvKC_TM.Columns[12].Visible == false)
                    sb.Append("&ISGH=true");
                if (this.grvKC_TM.Columns[13].Visible == false)
                    sb.Append("&ISBB=true");
                if (this.grvKC_TM.Columns[14].Visible == false)
                    sb.Append("&ISRKType=true");
                if (this.grvKC_TM.Columns[15].Visible == false)
                    sb.Append("&ISRKRY=true");
                if (this.grvKC_TM.Columns[16].Visible == false)
                    sb.Append("&ISpcinfo=true");
                if (this.grvKC_TM.Columns[17].Visible == false)
                    sb.Append("&ISweightRQ=true");
                if (this.grvKC_PCH.Columns[10].Visible == false)
                    sb.Append("&ISFREE1=true");
                if (this.grvKC_PCH.Columns[11].Visible == false)
                    sb.Append("&ISFREE2=true");
                if (this.grvKC_PCH.Columns[12].Visible == false)
                    sb.Append("&ISFREE3=true");
                break;
            case "3":
                if (this.grvKC_WLH.Columns[0].Visible == false)
                    sb.Append("&ISCK=true");
                if (this.grvKC_WLH.Columns[1].Visible == false)
                    sb.Append("&ISWLH=true");
                if (this.grvKC_WLH.Columns[2].Visible == false)
                    sb.Append("&ISWLMC=true");
                if (this.grvKC_WLH.Columns[3].Visible == false)
                    sb.Append("&ISHW=true");
                if (this.grvKC_WLH.Columns[4].Visible == false)
                    sb.Append("&ISPCH=true");
                if (this.grvKC_WLH.Columns[5].Visible == false)
                    sb.Append("&ISSX=true");
                if (this.grvKC_WLH.Columns[6].Visible == false)
                    sb.Append("&ISPH=true");
                if (this.grvKC_WLH.Columns[7].Visible == false)
                    sb.Append("&ISGG=true");
                if (this.grvKC_WLH.Columns[8].Visible == false)
                    sb.Append("&ISSL=true");
                if (this.grvKC_WLH.Columns[9].Visible == false)
                    sb.Append("&ISSUMZL=true");
                if (this.grvKC_WLH.Columns[10].Visible == false)
                    sb.Append("&ISRKRQ=true");
                if (this.grvKC_PCH.Columns[10].Visible == false)
                    sb.Append("&ISFREE1=true");
                if (this.grvKC_PCH.Columns[11].Visible == false)
                    sb.Append("&ISFREE2=true");
                if (this.grvKC_PCH.Columns[12].Visible == false)
                    sb.Append("&ISFREE3=true");
                break;
        }

        if (this.chkCK.Checked && !string.IsNullOrEmpty(this.hidCK.Value))
        {
            sb.Append("&CK=" + hidCK.Value);
        }
        if (this.chkRKPCH.Checked&&!string.IsNullOrEmpty(this.txtPCH.Text))
        {
            sb.Append("&PCH=" + txtPCH.Text.Trim());
        }
        if (!string.IsNullOrEmpty(this.hidRKSX.Value))
        {
            sb.Append("&SX=" + hidRKSX.Value);
        }
        if (this.chkWLH.Checked&&!string.IsNullOrEmpty(this.txtWLH.Text))
        {
            sb.Append("&WLH=" + txtWLH.Text.Trim());
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
            sb.Append("&FREE3=" + txtFree1.Text.Trim());
        }
        if (this.chkHW.Checked&&!string.IsNullOrEmpty(this.txtHW.Text))
        {
            sb.Append("&HW=" + txtHW.Text.Trim());
        }
        if (this.chkTSXX.Checked&&!string.IsNullOrEmpty(this.drpTSXX.Text))
        {
            sb.Append("&pcinfo=" + drpTSXX.Text.Trim());
        }
        //if (this.chkRKPH.Checked&&!string.IsNullOrEmpty(this.drpRKPH.Text))
        //{
        //    sb.Append("&PH=" + drpRKPH.Text);
        //}


        //牌号精确查询
        if (this.chkRKPH.Checked && !string.IsNullOrEmpty(this.drpRKPH.Text) && !this.chkPHMH.Checked)
        {
            sb.Append("&PH=" + drpRKPH.Text);
        }
        //牌号模糊查询
        if (this.chkRKPH.Checked && !string.IsNullOrEmpty(this.drpRKPH.Text) && this.chkPHMH.Checked)
        {
            sb.Append("&PHMH=" + drpRKPH.Text);
        }


        if (this.chkTM.Checked&&!string.IsNullOrEmpty(this.txtBarcode.Text))
        {
            sb.Append("&Barcode=" + txtBarcode.Text.Trim());
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.hidRKRQ.Value))
        {
            sb.Append("&RQfrom=" + RKRQ_Start.Text.Trim() + " 00:00:00");
        }
        if (this.chkRKRQ.Checked && !string.IsNullOrEmpty(this.hidRKRQ.Value))
        {
            sb.Append("&RQto=" + RKRQ_End.Text.Trim() + " 23:59:59");
        }
        if (this.chkWRQ.Checked && !string.IsNullOrEmpty(this.txtWRQfrom.Text))
        {
            sb.Append("&WRQfrom=" + txtWRQfrom.Text.Trim() + " 00:00:00");
        }
        if (this.chkWRQ.Checked && !string.IsNullOrEmpty(this.txtWRQto.Text))
        {
            sb.Append("&WRQto=" + txtWRQto.Text.Trim() + " 23:59:59");
        }
        if (this.chkGG.Checked&&!string.IsNullOrEmpty(this.hidGG.Value)&&!string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            sb.Append("&GG=" + hidGG.Value.Trim() + "&GGcopy=" + this.hidCopyGG.Value.Trim());
        }
        if (this.chkGG.Checked && !string.IsNullOrEmpty(this.hidGG.Value) && string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            sb.Append("&GG=" + this.hidGG.Value.Trim() + "&GGcopy=" + this.hidGG.Value.Trim());
        }
        if (this.chkGG.Checked && string.IsNullOrEmpty(this.hidGG.Value) && !string.IsNullOrEmpty(this.hidCopyGG.Value))
        {
            sb.Append("&GG=" + this.hidCopyGG.Value.Trim() + "&GGcopy=" + this.hidCopyGG.Value.Trim());
        }

        return sb.ToString();
    }


    protected void drpVIEW_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewID = drpVIEW.SelectedValue.ToString();
        switch (ViewID)
        {
            case "0":
                    grvKC_PCH.Visible = true;
                    this.PageControl1.Visible = true;
                    SetPagePCH();
                    BindgrvKC_PCH();
                    grvKC_HW.Visible = false;
                    grvKC_TM.Visible = false;
                    grvKC_WLH.Visible = false;
                    this.PageControl2.Visible = false;
                    this.PageControl3.Visible = false;
                    this.PageControl4.Visible = false;
                    break;
            case"1":
                this.PageControl2.Visible = true;
                grvKC_PCH.Visible = false;
                grvKC_HW.Visible = true;
                SetPageHW();
                BindgrvKC_HW();
                grvKC_TM.Visible = false;
                grvKC_WLH.Visible = false;
                this.PageControl1.Visible = false;
                this.PageControl3.Visible = false;
                this.PageControl4.Visible = false;
                break;
            case"2":
                this.PageControl3.Visible = true;
                grvKC_PCH.Visible = false;
                grvKC_HW.Visible = false;
                grvKC_TM.Visible = true;
                SetPageTM();
                BindgrvKC_TM();
                grvKC_WLH.Visible = false;
                this.PageControl1.Visible = false;
                this.PageControl2.Visible = false;
                this.PageControl4.Visible = false;
                break;
            case"3":
                this.PageControl4.Visible = true;
                grvKC_PCH.Visible = false;
                grvKC_HW.Visible = false;
                grvKC_TM.Visible = false;
                grvKC_WLH.Visible = true;
                this.PageControl1.Visible = false;
                this.PageControl2.Visible = false;
                this.PageControl3.Visible = false;
                SetPageWLH();
                BindgrvKC_WLH();
                break;   
        }
    }

    protected void grvKC_PCH_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvKC_PCH.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvKC_PCH.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvKC_PCH.Attributes["SortExpression"] = SortExpression;
        this.grvKC_PCH.Attributes["SortDirection"] = SortDirection;
        SetPagePCH();
        BindgrvKC_PCH();
    }
    protected void grvKC_HW_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvKC_HW.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvKC_HW.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvKC_HW.Attributes["SortExpression"] = SortExpression;
        this.grvKC_HW.Attributes["SortDirection"] = SortDirection;
        SetPageHW();
        BindgrvKC_HW();
    }
    protected void grvKC_TM_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvKC_TM.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvKC_TM.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvKC_TM.Attributes["SortExpression"] = SortExpression;
        this.grvKC_TM.Attributes["SortDirection"] = SortDirection;
        SetPageTM();
        BindgrvKC_TM();
    }
    protected void grvKC_WLH_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvKC_WLH.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvKC_WLH.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvKC_WLH.Attributes["SortExpression"] = SortExpression;
        this.grvKC_WLH.Attributes["SortDirection"] = SortDirection;
        SetPageWLH();
        BindgrvKC_WLH();
    }
}
