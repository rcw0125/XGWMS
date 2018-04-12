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
using System.Web.Caching;
using ACCTRUE.WMSBLL;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_Report_QTRKReport :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BinddrpCK();
            BinddrpGG();
            BinddrpPH();
            BindRKCK();
            BindRKHW();
            drpRKHW.Attributes.Add("onchange", "ChangeRKHW();");
            //ImagRKButton.Attributes.Add("onclick", "if(!confirm('是否入库?')) return false");

        }

    }
    //排序
    protected void grvQTRK_Sorting(object sender, GridViewSortEventArgs e)
    {
        string SortExpression = e.SortExpression.ToString();  //获得当前排序表达式
        string SortDirection = "ASC"; //为排序方向变量赋初值
        if (SortExpression == this.grvQTRK.Attributes["SortExpression"])  //如果为当前排序列
        {
            SortDirection = (this.grvQTRK.Attributes["SortDirection"].ToString() == SortDirection ? "DESC" : "ASC");     //获得下一次的排序状态

        }
        this.grvQTRK.Attributes["SortExpression"] = SortExpression;
        this.grvQTRK.Attributes["SortDirection"] = SortDirection;
        SetPageCountView();
        BindGridView();
    }

    protected void grvQTRK_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //点击表头进行排序时安装升序和降序加载特殊字符。完成每次显示升序或降序的图标
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string SortExpression = this.grvQTRK.Attributes["SortExpression"];
            string SortDirection = grvQTRK.Attributes["SortDirection"];
            if (SortExpression == null) //当前没有排序则推出
                return;
            for (int i = 0; i < grvQTRK.Columns.Count; i++)
            {
                //如果此列不支持排序则不执行
                string CloExpression = grvQTRK.Columns[i].SortExpression.Trim();
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
    //绑定drop出库类型
    private void BinddrpCK()
    {
        try
        {
            DataSet ds = QTRKReport.GetCKLX();
            if (ds != null)
            {
                this.drpCKType.DataSource = ds;
                this.drpCKType.DataTextField = "flag";
                this.drpCKType.ToolTip = "请选择仓库类型";
                this.drpCKType.DataValueField = "flag";
                this.drpCKType.DataBind();
            }
            this.drpCKType.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错！");
            return;
        }
    }
    //牌号
    private void BinddrpPH()
    {
        try
        {

            DataSet ds = QTRKReport.GetCKPH();
            if (ds != null)
            {
                this.drpPH.DataSource = ds;
                this.drpPH.DataTextField = "PH";
                this.drpPH.ToolTip = "请选择牌号";
                this.drpPH.DataValueField = "PH";
                this.drpPH.DataBind();
            }
            this.drpPH.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错");
            return;
        }
    }
    //规格
    private void BinddrpGG()
    {
        try
        {
            DataSet ds = QTRKReport.GetCKGG();
            if (ds != null)
            {
                this.drpGG.DataSource = ds;
                this.drpGG.DataTextField = "GG";
                this.drpGG.ToolTip = "请选择规格";
                this.drpGG.DataValueField = "GG";
                this.drpGG.DataBind();
            }
            this.drpGG.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错");
            return;
        }
    }
    //仓库
    private void BindRKCK()
    {
        try
        {
            DataSet ds = QTRKReport.GetCKID();
            if (ds != null)
            {
                this.drpRKCK.DataSource = ds;
                this.drpRKCK.DataTextField = "CK";
                this.drpRKCK.ToolTip = "请选择仓库";
                this.drpRKCK.DataValueField = "CK";
                this.drpRKCK.DataBind();
            }
            this.drpRKCK.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("访问数据出错");
            return;
        }
    }
    //货位
    private void BindRKHW()
    {
        try
        {
            string ckid = this.drpRKCK.SelectedValue;
            if (ckid == "请选择")
            {
                ckid = "";
            }
            DataSet ds = QTRKReport.GetCKHW(ckid);
            if (ds != null)
            {
                this.drpRKHW.DataSource = ds;
                this.drpRKHW.DataTextField = "hwid";
                this.drpRKHW.ToolTip = "请选择货位";
                this.drpRKHW.DataValueField = "hwid";
                this.drpRKHW.DataBind();
            }
            this.drpRKHW.Items.Insert(0, "请选择");
            this.drpRKHW.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("访问数据出错");
            return;
        }
    }
    private string Getsqlstr()
    {
        string sqlstr = "";
        if(this.drpCKType.SelectedIndex!=0)
        {
            sqlstr+=" AND flag='"+this.drpCKType.SelectedValue+"'";
        }
        if (!string.IsNullOrEmpty(this.txtDJuHao.Text))
        {
            sqlstr += " AND fydh='" + this.txtDJuHao.Text.Trim().ToString()+"'";
        }
        if (!string.IsNullOrEmpty(txtPCH.Text))
        {
            sqlstr += " AND pch='" + this.txtPCH.Text.Trim().ToString()+"'";
        }
        if (!string.IsNullOrEmpty(txtWLH.Text))
        {
            sqlstr += " AND wlh='" + this.txtWLH.Text.Trim().ToString()+"'";
        }
        if (this.drpPH.SelectedIndex != 0)
        {
            sqlstr += " AND ph='" + this.drpPH.SelectedValue+"'";
        }
        if (this.drpGG.SelectedIndex != 0)
        {
            sqlstr += " AND gg='" + this.drpGG.SelectedValue+"'";
        }
        if (this.drpSX.SelectedValue != "0")
        {
            sqlstr += " AND sx='" + this.drpSX.SelectedValue+"'";
        }
        if (!string.IsNullOrEmpty(this.txtDJuanHao.Text))
        {
            sqlstr += " AND barcode='" + this.txtDJuanHao.Text.Trim().ToString()+"'";
        }
        return sqlstr;
    }
    //查询
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (this.drpCKType.SelectedIndex == 0)
        {
            this.PrintfError("请指定出库类型！");
            return;
        }
        //string sql = Getsqlstr();
        //Response.Write(sql);
        SetPageCountView();
        BindGridView();
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
            string sqlWhere = Getsqlstr();
            int outCount;
            int pageCount = QTRKReport.GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
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
            string sql = Getsqlstr();
            string sortEx = this.grvQTRK.Attributes["SortExpression"];
            string sortDirect = this.grvQTRK.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = QTRKReport.GetQueryYTRK(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvQTRK.DataSource = ds;
            this.grvQTRK.DataBind();

        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }

    protected void drpRKCK_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRKHW();
    }
    //入库
    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        int djzt = 0;
    //        if (grvQTRK.Rows.Count <= 0)
    //        {
    //            this.PrintfError("没有入库记录！");
    //            return;
    //        }
    //        if (hidTM.Value == "")
    //        {
    //            this.PrintfError("没有选定记录！");
    //            return;
    //        }
    //        int TMcount = QTRKReport.GetTM(this.hidTM.Value.ToString());
    //        if (TMcount >= 1)
    //        {
    //            this.PrintfError("该单卷已经在库中！");
    //            return;
    //        }
    //        if (drpRKCK.SelectedValue == "请选择")
    //        {
    //            this.PrintfError("请指定仓库！");
    //            return;
    //        }
    //        if (Convert.ToSingle(txtRKZL.Text) <= 0)
    //        {
    //            this.PrintfError("重量非法！");
    //            return;
    //        }
    //        djzt = 0;
    //        if (this.drpCKType.SelectedValue == "盘亏出库")
    //        {
    //            DataSet ds = QTRKReport.GetPKCK(this.hidFYDH.Value);
    //            if (ds != null)
    //            {
    //                if (ds.Tables[0].Columns[0].ToString() == "已盘")
    //                {
    //                    djzt = 1;
    //                }
    //                if (ds.Tables[0].Columns[0].ToString() == "已盘")
    //                {
    //                    djzt = 1;
    //                }
    //            }
    //        }
    //        if (this.drpCKType.SelectedValue == "销售出库")
    //        {
    //            DataSet ds = QTRKReport.GetXSCK(hidFYDH.Value);
    //            if (ds != null)
    //            {
    //                if (ds.Tables[0].Rows[0][0].ToString() == "3")
    //                {
    //                    djzt = 1;
    //                }
    //            }

    //        }
    //        if (this.drpCKType.SelectedValue == "转库出库")
    //        {
    //            DataSet ds = QTRKReport.GetZHCK(hidFYDH.Value);
    //            if (ds != null)
    //            {
    //                if (Convert.ToBoolean(ds.Tables[0].Rows[0][0].ToString()))
    //                {
    //                    djzt = 1;
    //                }
    //                else
    //                {
    //                    djzt = 0;
    //                }
    //            }

    //        }
    //        if (this.drpCKType.SelectedValue == "其它出库")
    //        {
    //            DataSet ds = QTRKReport.GetQTCK(hidFYDH.Value);
    //            if (ds != null)
    //            {
    //                //Response.Write(ds.Tables[0].Rows[0][0].ToString());
    //                if (ds.Tables[0].Rows[0][0].ToString() == "2")
    //                {
    //                    djzt = 1;
    //                }
    //                else
    //                {
    //                    djzt = 0;
    //                }
    //            }

    //        }
    //        if (this.drpCKType.SelectedValue == "期初出库")
    //        {
    //            djzt = 1;
    //        }
    //        if (djzt != 1)
    //        {
    //            this.PrintfError("单据状态不符合其他入库的要求，不能入库!");
    //            return;
    //        }
    //        QTRKReport qtrkreqort = new QTRKReport();
    //        int i = qtrkreqort.execQTRKHW(this.hidTM.Value, drpRKHW.SelectedValue, hidFYDH.Value);
    //        if (i == 0)
    //        {
    //            this.PrintfError("当前货位不可用！");
    //            return;
    //        }
    //        ACCTRUE.WMSBLL.Model.User user1 = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
    //        string userid = user1.UserID;
    //        string strdate = DateTime.Now.ToShortDateString();
    //        string str1 = "insert into WMS_Bms_Inv_Info (Barcode,WGDH,CK,HW,PCH,WLH,WLMC,SX,ZLDJ,PH,GG,BB,GH,ZL,BZ,RQ,RKType,RKRY,WeightRQ,CKCXH,ProduceData) select Barcode,RKDH," + this.drpRKCK.SelectedValue + "," + this.drpRKHW.SelectedValue + ",PCH,WLH,WLMC,SX,ZLDJ,PH,GG,BB,GH," + Convert.ToDouble(this.txtRKZL.Text) + ",BZ,'" + strdate + "','其他入库','" + userid + "',WeightRQ,CKCXH,ProduceData from WMS_Bms_Inv_OutInfo where barcode='" + this.hidTM.Value + "' and fydh='" + this.hidFYDH.Value + "'";

    //        string str2 = "insert into WMS_Rev_Doc(RKDH,CK,HW,RKType,PCH,WLH,WLMC,SX,PH,GG,SL,ZL,RKTime,CPH) select 'QTRK'+barcode,'" + this.drpRKCK.SelectedValue + "','" + this.drpRKHW.SelectedValue + "','其他入库',pch,wlh,wlmc,sx,ph,gg,1,zl,'" + strdate + "' from WMS_Bms_Inv_OutInfo where barcode='" + this.hidTM.Value + "'";
    //        string str3 = "delete from WMS_Bms_Inv_OutInfo where barcode='" + this.hidTM.Value + "' and fydh='" + this.hidFYDH.Value + "'";
    //        QTRKReport qtrkrep = new QTRKReport();
    //        qtrkrep.ModiQTRK(str1, str2, str3);
    //        Response.Write(str2);
    //        this.PrintfError("入库成功!");
    //    }
    //    catch
    //    {
    //        this.PrintfError("入库失败!");
    //        return;
    //    }
        
    //}
}
