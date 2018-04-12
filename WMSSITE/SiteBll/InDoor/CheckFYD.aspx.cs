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
public partial class SiteBll_InDoor_CheckFYD : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //(CPH.value != '')||
            //this.drpFYDH.Attributes.Add("onchange", "ChangeFYDH()");
            //this.drpStatus.Attributes.Add("onchange", "ChangeStatus()");
            this.btnCancelInDoor.Attributes.Add("onclick", "if(!confirm('是否重置该发运单？')) return false");
            this.btnQueryFYD.Attributes.Add("onclick", "var CPH = document.getElementById('txtCPH');var RQStart =document.getElementById('txtRQStart');var RQEnd = document.getElementById('txtRQEnd');var drpUser = document.getElementById('drpCZ_User');var drpStatus=document.getElementById('drpStatus');var drpFYDH=document.getElementById('drpFYDH'); if((CPH.value == '')&&(drpFYDH.value=='请选择')&&(drpStatus.value=='请选择')&&(drpUser.value=='请选择')&&(RQStart.value=='')&&(RQEnd.value=='')) {if(!confirm('是否查询所有发运单？')) return false};else return");
            BindFYDH();
            BindCZ_User();
        }
    }



    #region 初始化页面时绑定发运单下拉列表，默认为前1000条
    private void BindFYDH()
    {
        try
        {
            DataSet ds = InDoorParam.GetFYDH();
            if (ds != null)
            {
                this.drpFYDH.DataSource = ds;
                this.drpFYDH.DataTextField = "FYDH";
                this.drpFYDH.ToolTip = "发运单号";
                this.drpFYDH.DataValueField = "FYDH";
                this.drpFYDH.DataBind();
                Bestcomy.Web.UI.WebControls.ComboItem value = new Bestcomy.Web.UI.WebControls.ComboItem("请选择");
                this.drpFYDH.Items.Insert(0, value);
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    #endregion

    #region 初始化页面时绑定操作人下拉列表
    private void BindCZ_User()
    {
        try
        {
            DataSet ds = InDoorParam.GetUser("");
            if (ds != null)
            {
                this.drpCZ_User.DataSource = ds;
                this.drpCZ_User.DataTextField = "UserID";
                this.drpCZ_User.ToolTip = "操作人";
                this.drpCZ_User.DataValueField = "UserID";
                this.drpCZ_User.DataBind();
                this.drpCZ_User.Items.Insert(0, "请选择");
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    #endregion

    #region 查询发运单
    protected void btnQueryFYD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            this.hidStatus.Value = this.drpStatus.SelectedValue;
            this.hidRQStart.Value = this.txtRQStart.Text.ToString();
            this.hidRQEnd.Value = this.txtRQEnd.Text.ToString();
            this.hidInOt.Value = this.RadioInOut.SelectedItem.Text;
            this.hidCZ_User.Value = this.drpCZ_User.SelectedValue;
            this.hidFYDH.Value = this.drpFYDH.Text.Trim();
            this.hidCPH.Value = this.txtCPH.Text.ToString();
            BindGridView();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    #endregion

    #region 绑定查询结果列表
    private void BindGridView()
    {
        if (CheckUI())
        {
            DataSet ds = InDoorParam.GetFYDInfo(QueryFYD());
            DataSet dsCount = InDoorParam.GetFYDInfoCount(QueryFYD());
            if (ds != null)
            {
                this.lblFYDsum.Text = dsCount.Tables[0].Rows[0]["HS"].ToString();
                this.lblJHSL.Text = dsCount.Tables[0].Rows[0]["HJJHSL"].ToString();
                this.lblSJSL.Text = dsCount.Tables[0].Rows[0]["HJSJSL"].ToString();
                this.lblJHZL.Text = dsCount.Tables[0].Rows[0]["HJJHZL"].ToString();
                this.lblSJZL.Text = dsCount.Tables[0].Rows[0]["HJSJZL"].ToString();
            }
            this.grdFYD.DataSource = ds;
            this.grdFYD.DataBind();
            this.hidCheckFYDSlc.Value = "";
        }
        else
        {
            this.PrintfError("时间格式有误，请重试！");
            return;
        }
    }
    #endregion

    #region 组成查询条件字符串
    /// <summary>
    /// 组成查询条件字符串
    /// </summary>
    /// <returns></returns>
    private string QueryFYD()
    {
        string sql = "";
        if ((!string.IsNullOrEmpty(this.drpFYDH.Text.Trim())) && (this.drpFYDH.Text.Trim() != "请选择"))
        {
            sql += "FYDH like '%" + this.drpFYDH.Text.Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(this.txtCPH.Text.ToString()))
        {
            if (!string.IsNullOrEmpty(sql))
            {
                sql += " AND CPH like '%" + this.txtCPH.Text.ToString().Trim() + "%'";
            }
            else
                sql += " CPH like '%" + this.txtCPH.Text.ToString() + "%'";
        }
        if ((!string.IsNullOrEmpty(this.drpCZ_User.SelectedValue)) && (this.drpCZ_User.SelectedValue != "请选择"))
        {
            if (!string.IsNullOrEmpty(sql))
            {
                switch (this.RadioInOut.SelectedItem.Text)
                {
                    case "进":
                        sql += " AND CZ_InUser= '" + this.drpCZ_User.SelectedValue + "'";
                        break;
                    case "出":
                        sql += " AND CZ_otUser= '" + this.drpCZ_User.SelectedValue + "'";
                        break;
                }
            }
            else
            {
                switch (this.RadioInOut.SelectedItem.Text)
                {
                    case "进":
                        sql += " CZ_InUser= '" + this.drpCZ_User.SelectedValue + "'";
                        break;
                    case "出":
                        sql += " CZ_otUser= '" + this.drpCZ_User.SelectedValue + "'";
                        break;
                }
            }
        }
        if (!string.IsNullOrEmpty(this.txtRQStart.Text.ToString()))
        {
            string RQStart = this.txtRQStart.Text.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(sql))
            {
                if ((!string.IsNullOrEmpty(this.drpStatus.SelectedItem.Text.Trim())) && (this.drpStatus.SelectedItem.Text != "请选择"))
                {
                    switch (this.drpStatus.SelectedValue)
                    {
                        case "0":
                            sql += " AND REVDATETIME >= '" + RQStart + "'";
                            break;
                        case "1":
                            sql += " AND CZ_InTime>= '" + RQStart + "'";
                            break;
                        case "2":
                            sql += " AND REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "3":
                            sql += " AND CZ_OtTime>= '" + RQStart + "'";
                            break;
                        case "4":
                            sql += " AND REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "5":
                            sql += " AND REVDATETIME>= '" + RQStart + "'";
                            break;
                    }
                }
                else
                {
                    sql += " AND REVDATETIME>= '" + RQStart + "'";
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(this.drpStatus.SelectedItem.Text.Trim())) && (this.drpStatus.SelectedItem.Text != "请选择"))
                {
                    switch (this.drpStatus.SelectedValue)
                    {
                        case "0":
                            sql += " REVDATETIME >= '" + RQStart + "'";
                            break;
                        case "1":
                            sql += " CZ_InTime>= '" + RQStart + "'";
                            break;
                        case "2":
                            sql += " REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "3":
                            sql += " CZ_OtTime>= '" + RQStart + "'";
                            break;
                        case "4":
                            sql += " REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "5":
                            sql += " REVDATETIME>= '" + RQStart + "'";
                            break;
                    }
                }
                else
                {
                    sql += " REVDATETIME>= '" + RQStart + "'";
                }
            }
        }
        if (!string.IsNullOrEmpty(this.txtRQEnd.Text.ToString()))
        {
            string RQEnd = this.txtRQEnd.Text.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(sql))
            {
                if ((!string.IsNullOrEmpty(this.drpStatus.SelectedItem.Text.Trim())) && (this.drpStatus.SelectedItem.Text != "请选择"))
                {
                    switch (this.drpStatus.SelectedValue)
                    {
                        case "0":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "1":
                            sql += " AND CZ_InTime<= '" + RQEnd + "'";
                            break;
                        case "2":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "3":
                            sql += " AND CZ_OtTime<= '" + RQEnd + "'";
                            break;
                        case "4":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "5":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                    }
                }
                else
                {
                    sql += " AND REVDATETIME<= '" + RQEnd + "'";
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(this.drpStatus.SelectedItem.Text.Trim())) && (this.drpStatus.SelectedItem.Text != "请选择"))
                {
                    switch (this.drpStatus.SelectedValue)
                    {
                        case "0":
                            sql += " REVDATETIME <= '" + RQEnd + "'";
                            break;
                        case "1":
                            sql += " CZ_InTime<= '" + RQEnd + "'";
                            break;
                        case "2":
                            sql += " REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "3":
                            sql += " CZ_OtTime<= '" + RQEnd + "'";
                            break;
                        case "4":
                            sql += " REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "5":
                            sql += " REVDATETIME<= '" + RQEnd + "'";
                            break;
                    }
                }
                else
                {
                    sql += " REVDATETIME<= '" + RQEnd + "'";
                }
            }
        }
        if ((!string.IsNullOrEmpty(this.drpStatus.SelectedItem.Text.Trim())) && (this.drpStatus.SelectedItem.Text != "请选择"))
        {
            if (!string.IsNullOrEmpty(sql))
            {
                sql += " AND Status = " + Int32.Parse(this.drpStatus.SelectedValue);
            }
            else
                sql += " Status = " + Int32.Parse(this.drpStatus.SelectedValue);
        }
        return sql;
    }
    #endregion

    #region 检查时间格式是否正确
    /// <summary>
    /// 检查时间格式是否正确
    /// </summary>
    /// <returns></returns>
    private bool CheckUI()
    {
        try
        {
            if (!string.IsNullOrEmpty(this.txtRQStart.Text.Trim()))
                Convert.ToDateTime(this.txtRQStart.Text.Trim());
            if (!string.IsNullOrEmpty(this.txtRQEnd.Text.Trim()))
                Convert.ToDateTime(this.txtRQEnd.Text.Trim());
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region 撤销进门
    protected void btnCancelInDoor_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidCheckFYDSlc.Value))
            {
                this.PrintfError("未选择发运单！");
                return;
            }
            else
            {
                DataSet statusCount = InDoorParam.StatusNo1DS(this.hidCheckFYDSlc.Value.Trim());
                if (statusCount.Tables[0].Rows.Count >= 1)
                {
                    this.PrintfError("不能重进门！");
                    return;
                }
                else
                {
                    InDoorParam indoor = new InDoorParam();
                    indoor.cancelInDoor(this.hidCheckFYDSlc.Value.Trim());
                    this.PrintfError("进门状态已改变，可以刷卡重新进门!");
                    BindGridView();
                    this.hidCheckFYDSlc.Value = "";
                }
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("撤销失败，请重试！");
            return;
        }
    }
    #endregion

    #region 打印所需字符串
    private string GetSqlWhere()
    {
        string sql = "";
        if ((!string.IsNullOrEmpty(this.hidFYDH.Value)) && (this.hidFYDH.Value.Trim() != "请选择"))
        {
            sql += "FYDH like '%" + this.hidFYDH.Value.Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(this.hidCPH.Value.Trim()))
        {
            if (!string.IsNullOrEmpty(sql))
            {
                sql += " AND CPH like '%" + this.hidCPH.Value.Trim() + "%'";
            }
            else
                sql += " CPH like '%" + this.hidCPH.Value.Trim() + "%'";
        }
        if ((!string.IsNullOrEmpty(this.hidCZ_User.Value)) && (this.hidCZ_User.Value.Trim() != "请选择"))
        {
            if (!string.IsNullOrEmpty(sql))
            {
                switch (this.hidInOt.Value.Trim())
                {
                    case "进":
                        sql += " AND CZ_InUser= '" + this.hidCZ_User.Value.Trim() + "'";
                        break;
                    case "出":
                        sql += " AND CZ_otUser= '" + this.hidCZ_User.Value.Trim() + "'";
                        break;
                }
            }
            else
            {
                switch (this.hidInOt.Value.Trim())
                {
                    case "进":
                        sql += " CZ_InUser= '" + this.hidCZ_User.Value.Trim() + "'";
                        break;
                    case "出":
                        sql += " CZ_otUser= '" + this.hidCZ_User.Value.Trim() + "'";
                        break;
                }
            }
        }
        if ((!string.IsNullOrEmpty(this.hidStatus.Value)) && (this.hidStatus.Value.Trim() != "请选择"))
        {
            if (!string.IsNullOrEmpty(sql))
            {
                sql += " AND Status = " + Int32.Parse(this.hidStatus.Value.Trim());
            }
            else
                sql += " Status = " + Int32.Parse(this.hidStatus.Value.Trim());
        }
        if (!string.IsNullOrEmpty(this.hidRQStart.Value.Trim()))
        {
            string RQStart = this.hidRQStart.Value.Trim() + " 00:00:00";
            if (!string.IsNullOrEmpty(sql))
            {
                if ((!string.IsNullOrEmpty(this.hidStatus.Value)) && (this.hidStatus.Value.Trim() != "请选择"))
                {
                    switch (this.hidStatus.Value.Trim())
                    {
                        case "0":
                            sql += " AND REVDATETIME >= '" + RQStart + "'";
                            break;
                        case "1":
                            sql += " AND CZ_InTime>= '" + RQStart + "'";
                            break;
                        case "2":
                            sql += " AND REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "3":
                            sql += " AND CZ_OtTime>= '" + RQStart + "'";
                            break;
                        case "4":
                            sql += " AND REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "5":
                            sql += " AND REVDATETIME>= '" + RQStart + "'";
                            break;
                    }
                }
                else
                {
                    sql += " AND REVDATETIME>= '" + RQStart + "'";
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(this.hidStatus.Value)) && (this.hidStatus.Value.Trim() != "请选择"))
                {
                    switch (this.hidStatus.Value.Trim())
                    {
                        case "0":
                            sql += " REVDATETIME >= '" + RQStart + "'";
                            break;
                        case "1":
                            sql += " CZ_InTime>= '" + RQStart + "'";
                            break;
                        case "2":
                            sql += " REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "3":
                            sql += " CZ_OtTime>= '" + RQStart + "'";
                            break;
                        case "4":
                            sql += " REVDATETIME>= '" + RQStart + "'";
                            break;
                        case "5":
                            sql += " REVDATETIME>= '" + RQStart + "'";
                            break;
                    }
                }
                else
                {
                    sql += " REVDATETIME>= '" + RQStart + "'";
                }
            }
        }
        if (!string.IsNullOrEmpty(this.hidRQEnd.Value.Trim()))
        {
            string RQEnd = this.hidRQEnd.Value.Trim() + " 23:59:59";
            if (!string.IsNullOrEmpty(sql))
            {
                if ((!string.IsNullOrEmpty(this.hidStatus.Value)) && (this.hidStatus.Value.Trim() != "请选择"))
                {
                    switch (this.hidStatus.Value.Trim())
                    {
                        case "0":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "1":
                            sql += " AND CZ_InTime<= '" + RQEnd + "'";
                            break;
                        case "2":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "3":
                            sql += " AND CZ_OtTime<= '" + RQEnd + "'";
                            break;
                        case "4":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "5":
                            sql += " AND REVDATETIME<= '" + RQEnd + "'";
                            break;
                    }
                }
                else
                {
                    sql += " AND REVDATETIME<= '" + RQEnd + "'";
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(this.hidStatus.Value)) && (this.hidStatus.Value.Trim() != "请选择"))
                {
                    switch (this.hidStatus.Value.Trim())
                    {
                        case "0":
                            sql += " REVDATETIME <= '" + RQEnd + "'";
                            break;
                        case "1":
                            sql += " CZ_InTime<= '" + RQEnd + "'";
                            break;
                        case "2":
                            sql += " REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "3":
                            sql += " CZ_OtTime<= '" + RQEnd + "'";
                            break;
                        case "4":
                            sql += " REVDATETIME<= '" + RQEnd + "'";
                            break;
                        case "5":
                            sql += " REVDATETIME<= '" + RQEnd + "'";
                            break;
                    }
                }
                else
                {
                    sql += " REVDATETIME<= '" + RQEnd + "'";
                }
            }
        }
        return sql;
    }
    #endregion

    #region 打印发运单列表
    //protected void btnPrintFYD_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        if (this.grdFYD.Rows.Count < 1)
    //        {
    //            this.PrintfError("没有要打印的记录！");
    //            return;
    //        }
    //        string sql = GetSqlWhere();
    //        sql = Server.UrlEncode(sql);
    //        this.WriteClientJava("window.open(\"../../Print.aspx?TYPE=3&QUERYSQL=" + sql + "\")");
    //    }
    //    catch (Exception ex)
    //    {
    //        String strEx = ex.Message;
    //        this.PrintfError("数据访问错误，请重试！");
    //        return;
    //    }
    //}
    #endregion

    protected void grdFYD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdFYD.PageIndex = e.NewPageIndex;
        string sqlWhere = GetSqlWhere();
        if (string.IsNullOrEmpty(this.hidStrSort.Value))
        {
            sqlWhere += " order by FYDH ";
        }
        else
        {
            sqlWhere += this.hidStrSort.Value;
        }
        DataSet ds = InDoorParam.GetFYDInfoSort(sqlWhere);
        this.grdFYD.DataSource = ds;
        this.grdFYD.DataBind();
    }
    protected void grdFYD_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (string.IsNullOrEmpty(this.hidsort.Value))
        {
            this.hidsort.Value = "DESC";
        }
        else
        {
            if (this.hidsort.Value.Trim() == "DESC")
            {
                this.hidsort.Value = "ASC";
            }
            else
            {
                this.hidsort.Value = "DESC";
            }
        }
        string sortField = e.SortExpression.ToString();
        string strsort = " order by " + sortField + "  " + this.hidsort.Value;
        this.hidStrSort.Value = strsort;

        string sqlWhere = GetSqlWhere();
        sqlWhere += strsort;

        DataSet ds = InDoorParam.GetFYDInfoSort(sqlWhere);
        this.grdFYD.DataSource = ds;
        this.grdFYD.DataBind();
    }
    protected void grdFYD_DataBound(object sender, EventArgs e)
    {
        //int h = int.Parse(this.grdFYD.Style.Keys("height"));
    }
}
