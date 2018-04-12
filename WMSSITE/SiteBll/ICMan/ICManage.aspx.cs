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
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.Model;
using System.Drawing;
using System.IO;
using System.Text;
//徐慧杰
public partial class SiteBll_ICMan_ICManage : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitRule();
            this.txtICNumber.Attributes.Add("onkeydown", "enterkey()");
            this.txtICID.Attributes.Add("onkeydown", "enterkey()");
            this.btnGS.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            this.btnSaveFK.Attributes.Add("onclick", "if(!confirm('是否保存？')) return false");
            this.btnHF.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            this.btnTK.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            this.btnCheckFYD.Attributes.Add("onclick", "FYDCheck()");
            this.btnPrint.Attributes.Add("onclick", "PrintIC()");
            InitICPassHid();
            BindSearchCPH();
            BindSearchProposer();
            BindProposer();
            BindICParam();
        }
    }

    #region 检查权限
    /// <summary>
    /// 检查权限
    /// </summary>
    private void InitRule()
    {
        try
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            if (user.USERFUNCTION.IC_FK == false && user.USERFUNCTION.IC_ZT == false && user.USERFUNCTION.IC_ZX == false)
            {
                //Response.Write("<script>window.alert('您没有任何权限进入此模块！')</script>");
                Response.Redirect("../../FirstPage.aspx");
            }
            else
            {
                if (!user.USERFUNCTION.IC_FK)
                {
                    this.btnICFK.Enabled = false;
                }
                if (!user.USERFUNCTION.IC_GS)
                {
                    this.btnGS.Enabled = false;
                    this.btnHF.Enabled = false;
                }
                if (!user.USERFUNCTION.IC_ZX)
                {
                    this.btnTK.Enabled = false;
                }
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

    #region 隐藏密码输入框以及使保存和取消按钮失效
    /// <summary>
    /// 隐藏密码输入框以及使保存和取消按钮失效
    /// </summary>
    private void InitICPassHid()
    {
        this.hidKHID.Value = null;
        this.hidCValue.Value = null;
        this.hidKHBM.Value = null;
        this.hidchild.Value = null;
        this.hidKHLB.Value = null;
        this.txtKHName.Text = "";
        this.txtICID.Text = "";
        this.txtICNumber.Text = "";
        this.txtCPH.Text = "";
        this.lblPassOne.Visible = false;
        this.lblPassTwo.Visible = false;
        this.txtPassOne.Visible = false;
        this.txtPassTwo.Visible = false;
        this.btnSaveFK.Enabled = false;
        this.btnCancelFK.Enabled = false;
    }
    #endregion

    #region 显示密码输入框、清空密码框的值、以及使保存和取消按钮激活
    /// <summary>
    /// 显示密码输入框、清空密码框的值、以及使保存和取消按钮激活
    /// </summary>
    private void InitICPassShow()
    {
        this.hidKHID.Value = null;
        this.txtKHName.Text = "";
        this.txtICID.Text = "";
        this.txtICNumber.Text = "";
        this.txtCPH.Text = "";
        this.lblPassOne.Visible = true;
        this.lblPassTwo.Visible = true;
        this.txtPassOne.Visible = true;
        this.txtPassOne.Text = "";
        this.txtPassTwo.Visible = true;
        this.txtPassTwo.Text = "";
        this.btnSaveFK.Enabled = true;
        this.btnCancelFK.Enabled = true;
    }
    #endregion

    #region 初始化页面时绑定IC管理主界面列表
    /// <summary>
    /// 初始化页面时绑定IC管理主界面列表
    /// </summary>
    private void BindICParam()
    {
        try
        {
            DataSet ds = ICParam.GetList("");
            if (ds != null)
            {
                int ICsum = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ICsum += 1;
                }
                this.lblICsum.Text = ICsum.ToString();
                this.grdInfo.DataSource = ds;
                this.grdInfo.DataBind();
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    #endregion

    #region 根据查询条件查询IC卡信息并绑定到主界面列表
    /// <summary>
    /// 根据查询条件查询IC卡信息并绑定到主界面列表
    /// </summary>
    private void BindICByEnter()
    {
        try
        {
            ICParam icpara = new ICParam(this.txtICIDSearch.Text, "", "", "", this.txtKHNameSearch.Text, "", this.DDlistSearchCPH.Text.Trim(), "", DateTime.MinValue, "", DateTime.MinValue, this.DDlistSearchProposer.SelectedValue);
            DataSet ds = icpara.GetICByEnter();
            if (ds != null)
            {
                int ICsum = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ICsum += 1;
                }
                this.lblICsum.Text = ICsum.ToString();
                this.grdInfo.DataSource = ds;
                this.grdInfo.DataBind();
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    #endregion

    #region 绑定查询申请人下拉列表
    /// <summary>
    /// 绑定查询申请人下拉列表
    /// </summary>
    private void BindSearchProposer()
    {
        try
        {
            DataSet ds = ICParam.GetSearchProposer("");
            if (ds != null)
            {
                this.DDlistSearchProposer.DataSource = ds;
                this.DDlistSearchProposer.DataTextField = "UserDesc";
                this.DDlistSearchProposer.ToolTip = "申请人";
                this.DDlistSearchProposer.DataValueField = "Proposer";
                this.DDlistSearchProposer.DataBind();
                this.DDlistSearchProposer.Items.Insert(0, "请选择");
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

    #region 绑定申请人下拉列表
    /// <summary>
    /// 绑定申请人下拉列表
    /// </summary>
    private void BindProposer()
    {
        try
        {
            DataSet ds = ACCTRUE.WMSBLL.Model.User.GetListByWhere("");
            if (ds != null)
            {
                this.DDListProposer.DataSource = ds;
                this.DDListProposer.DataTextField = "UserDesc";
                this.DDListProposer.ToolTip = "申请人";
                this.DDListProposer.DataValueField = "UserID";
                this.DDListProposer.DataBind();
                this.DDListProposer.Items.Insert(0, "请选择");
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

    #region 绑定查询车牌号下拉列表
    /// <summary>
    /// 绑定查询车牌号下拉列表
    /// </summary>
    private void BindSearchCPH()
    {
        try
        {
            DataSet ds = ICParam.GetSearchCPH("");
            if (ds != null)
            {
                this.DDlistSearchCPH.DataTextField = "CPH";
                this.DDlistSearchCPH.DataValueField = "CPH";
                this.DDlistSearchCPH.DataSource = ds;

                this.DDlistSearchCPH.ToolTip = "车牌号";

                this.DDlistSearchCPH.DataBind();
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

    #region 挂失IC卡
    /// <summary>
    /// 挂失IC卡
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGS_Click(object sender, ImageClickEventArgs e)
    { 
        try
        {
            if (string.IsNullOrEmpty(this.hidCValue.Value))
            {
                this.PrintfError("没有选择要修改的纪录！");
                return;
            }
            string icflag = ICParam.GetFlag(this.hidCValue.Value);
            if (icflag == "挂失")
            {
                this.PrintfError("此卡是挂失状态，不能重复挂失！");
                return;
            }
            else
            {
                ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
                ICParam parm = new ICParam(this.hidCValue.Value, this.hidCValue.Value, "", "", this.txtKHName.Text, "挂失", this.txtCPH.Text, "", DateTime.Now, user.UserID, DateTime.Now, "");
                parm.Update(this.hidCValue.Value, "挂失", user.UserID, DateTime.Now);
                InitICPassHid();
                BindICByEnter();
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

    #region 恢复IC卡
    /// <summary>
    /// 恢复IC卡
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHF_Click(object sender, ImageClickEventArgs e)
    {   
        try
        {
            if (string.IsNullOrEmpty(this.hidCValue.Value))
            {
                this.PrintfError("没有选择要修改的纪录！");
                return;
            }
            string icflag = ICParam.GetFlag(this.hidCValue.Value);
            if (icflag == "使用")
            {
                this.PrintfError("此卡是使用状态，不必恢复！");
                return;
            }
            else 
            {
                ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
                ICParam parm = new ICParam();
                parm.Update(this.hidCValue.Value, "使用", DBNull.Value.ToString(), DateTime.MinValue);
                InitICPassHid();
                BindICByEnter();
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

    #region 退卡
    /// <summary>
    /// 退卡
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTK_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidCValue.Value))
            {
                this.PrintfError("没有选择要修改的纪录！");
                this.txtICID.Text = "";
                this.txtKHName.Text = "";
                this.hidCValue.Value = "";
                return;
            }

            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
            ICParam parm = new ICParam(this.hidCValue.Value, "", "", "", "", "", "", "", DateTime.Now, "", DateTime.Now, "");
            parm.Delete();
            this.txtICID.Text = "";
            this.txtKHName.Text = "";
            this.hidCValue.Value = "";
            //BindICParam();
            BindICByEnter();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    #endregion

    #region 保存发卡信息提交数据库保存
    /// <summary>
    /// 保存发卡信息提交数据库保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveFK_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidKHID.Value))
            {
                this.PrintfError("请选择客户！");
                return;
            }
            else
                if (string.IsNullOrEmpty(this.txtICID.Text) || string.IsNullOrEmpty(this.txtICNumber.Text))
                {
                    this.PrintfError("IC卡ID和卡号不能为空！");
                    return;
                }
                else
                    if(ICParam.hasICID(this.txtICID.Text)==true)
                    {
                        this.PrintfError("本卡被重复使用！");
                        return;
                    }
                    else
                        if ((this.hidKHLB.Value.Trim()=="0")&&(string.IsNullOrEmpty(this.txtCPH.Text.Trim())==true))
                        {
                            this.PrintfError("邢钢内部车辆必须填写车牌号！");
                            return;
                        }
                        else
                            if ((this.DDListProposer.SelectedValue == "请选择") || (string.IsNullOrEmpty(this.DDListProposer.SelectedValue)))
                            {
                                this.PrintfError("选择申请人！");
                                return;
                            }
                            else
                                if (this.txtPassOne.Text.Trim() != this.txtPassTwo.Text.Trim())
                                {
                                    this.PrintfError("密码确认错误！");
                                    return;
                                }
                                else
                                    {
                                        ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
                                        ICParam parm = new ICParam(this.txtICID.Text.Trim(), this.txtICNumber.Text.Trim(), this.txtPassOne.Text.Trim(), this.hidKHID.Value.ToString().Trim(), this.txtKHName.Text.Trim(), "使用", this.txtCPH.Text.Trim(), user.UserID, DateTime.Now, "", DateTime.MinValue, this.DDListProposer.SelectedValue);
                                        bool b = parm.Add();
                                        if (b == false)
                                        {
                                            Response.Write("<script>window.alert('您修改过客户名！录入失败！')</script>");
                                            return;
                                        }
                                        else
                                        {
                                            InitICPassHid();
                                            BindICParam();
                                            this.btnGS.Enabled = true;
                                            this.btnHF.Enabled = true;
                                            this.btnICFK.Enabled = true;
                                            this.btnTK.Enabled = true;
                                            this.btnPrint.Enabled = true;
                                            this.btnCheckFYD.Enabled = true;
                                        }
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

    #region 点击发卡激活密码输入框和保存、取消按钮
    /// <summary>
    /// 点击发卡激活密码输入框和保存、取消按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnICFK_Click(object sender, ImageClickEventArgs e)
    {
        InitICPassShow();
        this.btnGS.Enabled = false;
        this.btnHF.Enabled = false;
        this.btnICFK.Enabled = false;
        this.btnTK.Enabled = false;
        this.btnPrint.Enabled = false;
        this.btnCheckFYD.Enabled = false;
    }
    #endregion

    #region 取消发卡
    /// <summary>
    /// 取消发卡
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelFK_Click(object sender, ImageClickEventArgs e)
    {
        InitICPassHid();
        this.btnGS.Enabled = true;
        this.btnHF.Enabled = true;
        this.btnICFK.Enabled = true;
        this.btnTK.Enabled = true;
        this.btnPrint.Enabled = true;
        this.btnCheckFYD.Enabled = true;
    }
    #endregion

    #region 查询IC卡信息
    /// <summary>
    /// 查询IC卡信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchIC_Click(object sender, ImageClickEventArgs e)
    {
        BindICByEnter();
        this.hidSICID.Value = this.txtICIDSearch.Text;
        this.hidSProposer.Value = this.DDlistSearchProposer.SelectedValue.ToString();
        this.hidSCPH.Value = this.DDlistSearchCPH.Text.Trim();
        this.hidSKHName.Value = this.txtKHNameSearch.Text;
    }
    #endregion

    #region 调用导出Excel方法
    /// <summary>
    /// 调用导出Excel方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExpToExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ICParam icpara = new ICParam(this.hidSICID.Value, "", "", "", this.hidSKHName.Value, "", this.hidSCPH.Value, "", DateTime.MinValue, "", DateTime.MinValue, this.hidSProposer.Value);
            DataSet ds = icpara.GetxlsDS();
            this.CreateExcel(ds.Tables[0], "IC.xls", ds.Tables[0].Rows.Count);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
    #endregion

    #region 导出Excel
    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="FileType"></param>
    /// <param name="FileName"></param>
    private void Export(string FileType, string FileName)
    {
        try
        {
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF7;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            Response.ContentType = FileType;
            this.EnableViewState = false;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            this.grdInfo.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
        }
    }
    #endregion

    //#region  规定页面加载时显示近几个月内发放的IC卡
    ///// <summary>
    ///// 规定页面加载时显示近几个月内发放的IC卡
    ///// </summary>
    ///// <param name="date"></param>
    ///// <returns></returns>
    //public static string GetBeginTime(System.DateTime date)
    //{
    //    int monthInterval = 0;
    //    try
    //    {
    //        monthInterval = 12;//规定页面加载时显示近12个月内发放的IC卡
    //    }
    //    catch (Exception e)
    //    {
    //        e.ToString();
    //    }
    //    return date.AddMonths(monthInterval * (-1)).ToString("yyyy-MM-dd");
    //}

    //public static string GetBeginTime()
    //{
    //    return GetBeginTime(DateTime.Now);
    //}
    //#endregion

    protected void grdInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdInfo.PageIndex = e.NewPageIndex;
        string sqlWhere = GetSqlWhereSort();
        if (string.IsNullOrEmpty(this.hidStrSort.Value))
        {            
            sqlWhere += " order by FK_Time desc";
        }
        else
        {
            sqlWhere += this.hidStrSort.Value;
        }
        DataSet ds = ICParam.GetDataSetsort(sqlWhere);
        this.grdInfo.DataSource = ds;
        this.grdInfo.DataBind();
    }

    private string GetSqlWhere()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(hidSICID.Value))
        {
            sqlWhere += "ICID like '%" + hidSICID.Value + "%' ";
        }
        if (!string.IsNullOrEmpty(hidSKHName.Value))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND KHName like '%" + hidSKHName.Value + "%'";
            }
            else
                sqlWhere += " KHName like '%" + hidSKHName.Value + "%'";
        }
        if ((!string.IsNullOrEmpty(hidSCPH.Value)) && (hidSCPH.Value.Trim() != "请选择"))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND CPH like '%" + hidSCPH.Value + "%'";
            }
            else
                sqlWhere += " CPH like '%" + hidSCPH.Value + "%'";
        }
        if ((!string.IsNullOrEmpty(hidSProposer.Value)) && (hidSProposer.Value.Trim() != "请选择"))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND Proposer like '%" + hidSProposer.Value + "%'";
            }
            else
                sqlWhere += " Proposer like '%" + hidSProposer.Value + "%'";
        }
        return sqlWhere;
    }
    //protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (this.grdInfo.Rows.Count < 1)
    //    {
    //        this.PrintfError("没有要打印的记录！");
    //        return;
    //    }
    //    string sql = GetSqlWhere();
    //    sql = Server.UrlEncode(sql);
    //    this.WriteClientJava("window.open(\"../../Print.aspx?TYPE=2&QUERYSQL=" + sql + "\")");
    //}




    private string GetSqlWhereSort()
    {
        string sqlWhere = "";
        if (!string.IsNullOrEmpty(hidSICID.Value))
        {
            sqlWhere += " where ICID like '%" + hidSICID.Value + "%' ";
        }
        if (!string.IsNullOrEmpty(hidSKHName.Value))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND KHName like '%" + hidSKHName.Value + "%'";
            }
            else
                sqlWhere += " where  KHName like '%" + hidSKHName.Value + "%'";
        }
        if ((!string.IsNullOrEmpty(hidSCPH.Value)) && (hidSCPH.Value.Trim() != "请选择"))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND CPH like '%" + hidSCPH.Value + "%'";
            }
            else
                sqlWhere += " where  CPH like '%" + hidSCPH.Value + "%'";
        }
        if ((!string.IsNullOrEmpty(hidSProposer.Value)) && (hidSProposer.Value.Trim() != "请选择"))
        {
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlWhere += " AND Proposer like '%" + hidSProposer.Value + "%'";
            }
            else
                sqlWhere += " where  Proposer like '%" + hidSProposer.Value + "%'";
        }
        return sqlWhere;
    }
    protected void grdInfo_Sorting(object sender, GridViewSortEventArgs e)
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
        string strSort = " order by " + sortField + " " + this.hidsort.Value;
        this.hidStrSort.Value = strSort;

        string sqlWhere = GetSqlWhereSort();

        sqlWhere += strSort;

        DataSet ds = ICParam.GetDataSetsort(sqlWhere);

        int ICsum = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ICsum += 1;
        }
        this.lblICsum.Text = ICsum.ToString();

        this.grdInfo.DataSource = ds;
        this.grdInfo.DataBind();
    }
    protected void grdInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick",
                        "SelectDataGridRow('grdInfo',this.rowIndex);");
        }
    }
    protected void imgCZ_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidCValue.Value))
            {
                this.PrintfError("没有选择要重置的纪录！");
                return;
            }
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
            ICParam parm = new ICParam();
            parm.UpdatePass(this.hidCValue.Value, "1", DBNull.Value.ToString(), DateTime.Now);
            InitICPassHid();
            BindICByEnter();
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }
}
