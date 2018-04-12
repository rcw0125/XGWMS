using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Acctrue.WM_WES.DataAccess;
using ACCTRUE.WMSBLL;

public partial class SiteBll_Report_CLHZSearch : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindScx();
            BindBc();
        }
    }
   
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindGridView);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
    }
    
    private void SelectPageSizeChange()
    {
        SetPageCountView();
        BindGridView();
        return;
    }
    
    /// <summary>
    /// 绑定班次
    /// </summary>
    private void BindBc()
    {
        try
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add();
            table.Columns.Add("bc");
            table.Rows.Add("甲班");
            table.Rows.Add("乙班");
            table.Rows.Add("丙班");
            table.Rows.Add("丁班");
            this.drpbc.DataSource = ds;
            this.drpbc.DataBind();
            this.drpbc.Items.Insert(0, new ListItem("请选择", "0"));
            drpbc.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    /// <summary>
    /// 绑定生产线
    /// </summary>
    private void BindScx()
    {
        try
        {
            DataSet ds = new DataSet();
            DataTable table = ds.Tables.Add();
            table.Columns.Add("scxid");
            table.Columns.Add("scx");
            table.Rows.Add("1", "1线");
            table.Rows.Add("2", "2线");
            table.Rows.Add("3", "3线");
            table.Rows.Add("4", "4线");
            table.Rows.Add("5", "5线");
            this.drpscx.DataSource = ds;
            this.drpscx.DataBind();
            this.drpscx.Items.Insert(0, new ListItem("请选择", "0"));
            drpscx.SelectedIndex = 0;
        }
        catch
        {
            this.PrintfError("数据访问错误！");
            return;
        }
    }

    private string GetSqlWhere()
    {
        string sqlWhere = "";

        //if (this.cbdysj.Checked)
        //{
        if (txtStartTime.Text != "")
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " scrq='" + txtStartTime.Text + "'";
            else sqlWhere += " AND scrq='" + txtStartTime.Text + "'";
        }

        /**
         * 至<asp:TextBox
                        ID="txtEndTime" runat="server" Width="100px"></asp:TextBox><img onclick="calendar(txtEndTime);"
                            src="../../Images/icon/calendar.gif" style="cursor: hand" />
        
        if (txtEndTime.Text != "")
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere += " scrq<='" + txtEndTime.Text + "'";
            else sqlWhere += " AND scrq<='" + txtEndTime.Text + "'";
        }
         //*/
        //}

        if (this.drpscx.SelectedValue != "0")
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " sccj =" + this.drpscx.SelectedValue;
            else
                sqlWhere += " AND sccj=" + this.drpscx.SelectedValue;
        }

        if (!string.IsNullOrEmpty(drpbc.Text))
        {
            if (string.IsNullOrEmpty(sqlWhere))
                sqlWhere = " scbb = '" + this.drpbc.Text + "'";
            else
                sqlWhere += " AND scbb = '" + this.drpbc.Text + "'";
        }
      
        return sqlWhere;
    }
    private void BindGridView()
    {
        try
        {
            string sql = GetSqlWhere();
            string sortEx = this.grvFYDList.Attributes["SortExpression"];
            string sortDirect = this.grvFYDList.Attributes["SortDirection"];
            string strSort = (!string.IsNullOrEmpty(sortEx)) ? sortEx + " " + sortDirect : "";
            DataSet ds = QueryCLHZ(sql, strSort, PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvFYDList.DataSource = ds;
            this.grvFYDList.DataBind();

            SubTotal();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }

    //汇总数据
    private void SubTotal()
    {
        GridViewRow footerRow = new GridViewRow(this.grvFYDList.Rows.Count, 0, DataControlRowType.Footer, DataControlRowState.Normal);
        footerRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeff");
        TableCell c1 = new TableCell();
        //c1.Attributes.Add("colspan", "2");
        c1.Attributes.Add("colspan", "3");
        c1.HorizontalAlign = HorizontalAlign.Right;
        c1.Text = "汇总";
        footerRow.Cells.Add(c1);
        //for (int i = 0; i < 18; i++)
        for (int i = 0; i < 16; i++)
        {
            double zs = 0;
            TableCell c2 = new TableCell();
            foreach (GridViewRow item in this.grvFYDList.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        //zs += Convert.ToDouble(item.Cells[i + 2].Text);
                        zs += Convert.ToDouble(item.Cells[i + 3].Text);
                    }
                    catch
                    {
                    }
                }
            }
            c2.Text = zs.ToString();
            footerRow.Cells.Add(c2);
        }

        this.grvFYDList.Controls[0].Controls.Add(footerRow);
    }
   
    protected void imgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        SetPageCountView();
        BindGridView();
        return;
    }
    private void SetPageCountView()
    {
        try
        {
            string sqlWhere = GetSqlWhere();
            int outCount;
            int pageCount = GetPageCount(sqlWhere, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    protected void grvFYDList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow rowHeader = e.Row;
            rowHeader.Cells.Clear();

         
           // rowHeader.BackColor = System.Drawing.ColorTranslator.FromHtml("#EDEDED");

            Literal newCells = new Literal();
//            newCells.Text = @"计划订单号</th>
//                 <th rowspan='2'>钢种</th>
//                 <th rowspan='2'>规格</th>
//                 <th colspan='2'>完成数量</th>
//                 <th colspan='2'>不合格数量</th>
//                 <th colspan='2'>协议品数量</th>
//               <th colspan='2'>零星加工材</th>
//                 <th colspan='2'>物料号改判</th>
//                 <th colspan='2'>自由项1改判</th>          
//                 <th colspan='2'>自由项2改判</th> 
//                 <th colspan='2'>自由项3改判</th> 
//                 <th colspan='2'>特殊信息改判</th>      
//                 </tr><tr style='background-color:#DCE8F4'> 
//
//                 <th>吨数</th>
//                 <th>件数</th>
//
//                 <th>吨数</th>
//                 <th>件数</th>
//
//                 <th>吨数</th>
//                 <th>件数</th>
//
//                 <th>吨数</th>
//                 <th>件数</th>
//
//                 <th>吨数</th>
//                 <th>件数</th>
//                 <th>吨数</th>
//                 <th>件数</th>
//                 <th>吨数</th>
//                 <th>件数</th>
//                 <th>吨数</th>
//                 <th>件数</th>
//                 <th>吨数</th>
//                 <th>件数";

            newCells.Text = @"计划订单号</th>
                 <th rowspan='2'>钢种</th>
                 <th rowspan='2'>规格</th>
                 <th colspan='2'>完成数量</th>
                 <th colspan='2'>不合格数量</th>
                 <th colspan='2'>协议品数量</th>
             
                 <th colspan='2'>物料号改判</th>
                 <th colspan='2'>自由项1改判</th>          
                 <th colspan='2'>自由项2改判</th> 
                 <th colspan='2'>自由项3改判</th> 
                 <th colspan='2'>特殊信息改判</th>      
                 </tr><tr style='background-color:#DCE8F4'> 

                 <th>吨数</th>
                 <th>件数</th>

                 <th>吨数</th>
                 <th>件数</th>

                 <th>吨数</th>
                 <th>件数</th>

               

                 <th>吨数</th>
                 <th>件数</th>
                 <th>吨数</th>
                 <th>件数</th>
                 <th>吨数</th>
                 <th>件数</th>
                 <th>吨数</th>
                 <th>件数</th>
                 <th>吨数</th>
                 <th>件数";

            TableHeaderCell headerCell = new TableHeaderCell();
            headerCell.RowSpan = 2;
            headerCell.Controls.Add(newCells);
            rowHeader.Cells.Add(headerCell);
           // rowHeader.Cells.Add(headerCell);
           // this.grvFYDList.Controls[0].Controls.AddAt(0, rowHeader);
        }
    }
    protected void grvFYDList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grvFYDList_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    public static DataSet QueryCLHZ(string strWhere, string orderKey, int pageSize, int pageNum)
    {
        string sWhere = " WHERE 1=1 ";
        string oKey = "t1.ph,t1.gg";
        int pSize = 20;
        int pNum = 1;
        //加入t1.jhddh 计划订单号
        //string sql1 = " select t1.jhddh,t1.ph,t1.gg,round(sum(t1.wczl),4) as wczl,round(sum(t1.wcsl),0) as wcsl,round(sum(t1.bhgzl),4) as bhgzl,round(sum(t1.bhgsl),0) as bhgsl,round(sum(t1.xyzl),4) as xyzl,round(sum(t1.xysl),0) as xysl,round(sum(t1.twczl),4) as twczl,round(sum(t1.twcsl),0) as twcsl,round(sum(t2.wlh_zl),4) as wlh_zl,round(sum(wlh_sl),4) as wlh_sl,round(sum(t2.vfree1_zl),4) as vfree1_zl,round(sum(t2.vfree1_sl),0) as vfree1_sl,round(sum(t2.vfree2_zl),4) as vfree2_zl,round(sum(t2.vfree2_sl),0) as vfree2_sl,round(sum(t2.vfree3_zl),4) as vfree3_zl,round(sum(t2.vfree3_sl),4) as vfree3_sl,round(sum(t2.pcinfo_zl),4) as pcinfo_zl,round(sum(t2.pcinfo_sl),0) as pcinfo_sl,";
        //string sql2 = " v_process_detail t1 left join v_gaipan_information t2 on t1.pch = t2.pch ";
        //string sql3 = "group by t1.ph,t1.gg,t1.jhddh";


       // string sql1 = " select t1.jhddh,t1.ph,t1.gg,round(sum(t1.wczl),4) as wczl,round(sum(t1.wcsl),0) as wcsl,round(sum(t1.bhgzl),4) as bhgzl,round(sum(t1.bhgsl),0) as bhgsl,round(sum(t1.xyzl),4) as xyzl,round(sum(t1.xysl),0) as xysl,round(sum(t1.twczl),4) as twczl,round(sum(t1.twcsl),0) as twcsl,round(sum(t1.wlh_zl),4) as wlh_zl,round(sum(wlh_sl),4) as wlh_sl,round(sum(t1.vfree1_zl),4) as vfree1_zl,round(sum(t1.vfree1_sl),0) as vfree1_sl,round(sum(t1.vfree2_zl),4) as vfree2_zl,round(sum(t1.vfree2_sl),0) as vfree2_sl,round(sum(t1.vfree3_zl),4) as vfree3_zl,round(sum(t1.vfree3_sl),4) as vfree3_sl,round(sum(t1.pcinfo_zl),4) as pcinfo_zl,round(sum(t1.pcinfo_sl),0) as pcinfo_sl,";
        string sql1 = " select t1.jhddh,t1.ph,t1.gg,round(sum(t1.wczl),4) as wczl,round(sum(t1.wcsl),0) as wcsl,round(sum(t1.bhgzl),4) as bhgzl,round(sum(t1.bhgsl),0) as bhgsl,round(sum(t1.xyzl),4) as xyzl,round(sum(t1.xysl),0) as xysl,round(sum(t1.wlh_zl),4) as wlh_zl,round(sum(wlh_sl),4) as wlh_sl,round(sum(t1.vfree1_zl),4) as vfree1_zl,round(sum(t1.vfree1_sl),0) as vfree1_sl,round(sum(t1.vfree2_zl),4) as vfree2_zl,round(sum(t1.vfree2_sl),0) as vfree2_sl,round(sum(t1.vfree3_zl),4) as vfree3_zl,round(sum(t1.vfree3_sl),4) as vfree3_sl,round(sum(t1.pcinfo_zl),4) as pcinfo_zl,round(sum(t1.pcinfo_sl),0) as pcinfo_sl,";
      
        string sql2 = " v_rod_yield  t1";
        string sql3 = "group by t1.ph,t1.gg,t1.jhddh";

        //参数0:排序条件 1：查询条件 2：第几条记录开始 3：第几条记录结束
        string pageSql = "WITH TempDB AS (" + sql1 +
            "row_number() OVER (ORDER BY {0}) AS RowNumber FROM " + sql2 + " {1} " + sql3 + ") SELECT * FROM TempDB WHERE RowNumber " +
            "BETWEEN {2} and {3}";
        if (!string.IsNullOrEmpty(strWhere))
        {
            sWhere += " AND " + strWhere;
        }
        if (!string.IsNullOrEmpty(orderKey))
            oKey = orderKey;
        if (pageSize > 0)
            pSize = pageSize;
        if (pageNum > 0)
            pNum = pageNum;
        try
        {
            string sqlStr = string.Format(pageSql, oKey, sWhere, pSize * pNum - pSize + 1, pSize * pNum);
            AdoHelper dataHelp = new SqlHelp();
            DataSet ds = dataHelp.ExecuteDataset(Common.GetConnectString(), CommandType.Text, sqlStr.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds;
            return null;
        }
        catch (System.Exception ex)
        {
            string msg = ex.Message;
            return null;
        }

    }
    public static int GetPageCount(string strWhere, int pageSize, out int allCount)
    {
        try {
            string sql2 = " v_rod_yield t1 ";
        string sqlWhere = "WHERE 1=1 ";
        string strSql = "with tempdb as (SELECT distinct t1.ph,t1.gg from " + sql2 + " {0} ) select count(1) from tempdb";
        if (!string.IsNullOrEmpty(strWhere))
        {
            sqlWhere += " AND " + strWhere;
        }
        strSql = string.Format(strSql, sqlWhere);
        AdoHelper dataHelp = new SqlHelp();
        Object result = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql);
        if (result != null)
        {
            double temp = Convert.ToDouble(result);
            allCount = Convert.ToInt32(temp);
            double pageCount = Math.Ceiling(temp / pageSize);
            return Convert.ToInt32(pageCount);
        }
     
        }
        catch (System.Exception ex)
          {
            string msg = ex.Message;
          } 
        allCount = 0;
        return 0;
    }

}
