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
using ACCTRUE.WMSBLL.QueryBll;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_StockMan_QTCKDan :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strdate = DateTime.Now.ToShortDateString();
            txtFYRQ.Text = strdate; 
            BinddrpCK();//页面初始化时绑定仓库下拉列表
            BinddrpCKLX();//页面初始化时绑定出库类型下拉列表
            BinddrpCYS();//页面初始化时绑定承运商下拉列表
            BinddrpSHDW();//页面初始化时绑定收货单位下拉列表
            imgCancel.Attributes.Add("onclick", "if(!confirm('确实要取消对该单据的操作吗？')) return false");
            this.ImgDeleteCKD.Attributes.Add("onclick", "if(!confirm('确实要删除此出库单吗?')) return false");
            this.ImgCZDJbtn.Attributes.Add("onclick", "if(!confirm('重置单据将删除正在装车的装车信息，确实要重置该单据吗？')) return false");
            this.ImgQXWCbtn.Attributes.Add("onclick", "if(!confirm('此操作将会把已完成的单据重新打开，确实要执行该操作吗？')) return false");
            if (!string.IsNullOrEmpty(Request["CKDH"]))//根据是否有查询页面传来的出库单号赋值给页面
            {
                InitAllByCKDH(Request["CKDH"]);
            }
            else
            {
                Session["QTCKITEM"] = null;
            }
        }
    }

    #region 根据出库单号查询其它出库单概要及明细并赋值给Session,并给各个文本框赋值，并向子页面发送当前状态是浏览状态的信息，子页面会获得Session并绑定明细Grid
    /// <summary>
    /// 根据出库单号查询其它出库单概要及明细并赋值给Session,并给各个文本框赋值，并向子页面发送当前状态是浏览状态的信息，子页面会获得Session并绑定明细Grid
    /// </summary>
    private void InitAllByCKDH(string CKDH)
    {
        try
        {
            this.txtCKDH.Text = CKDH;
            DataSet ds = QTCKQuery.GetItem(CKDH);
            Session["QTCKITEM"] = ds;
            this.frameItem.Attributes["src"] = "QTCKD_item.aspx?ZT=Browse";
            if (ds != null && ds.Tables[1].Rows.Count > 0)
            {
                this.drpFHCK.SelectedValue = ds.Tables[1].Rows[0]["CK"].ToString();
                if (ds.Tables[1].Rows[0]["CPH"] != null)
                {
                    this.txtCPH.Text = ds.Tables[1].Rows[0]["CPH"].ToString();
                }
                if (ds.Tables[1].Rows[0]["AimAdress"] != null)
                {
                    this.txtMDD.Text = ds.Tables[1].Rows[0]["AimAdress"].ToString();
                }
                if (ds.Tables[1].Rows[0]["ZDR"] != null)
                {
                    this.txtZDR.Text = ds.Tables[1].Rows[0]["ZDR"].ToString();
                }
                if (ds.Tables[1].Rows[0]["ZDRQ"] != null)
                {
                    this.txtZDRQ.Text = ds.Tables[1].Rows[0]["ZDRQ"].ToString();
                }
                if (ds.Tables[1].Rows[0]["statusName"] != null)
                {
                    this.txtStatus.Text = ds.Tables[1].Rows[0]["statusName"].ToString();
                }
                if (ds.Tables[1].Rows[0]["CKLX"] != null)
                {
                    this.drpCKLX.Text = ds.Tables[1].Rows[0]["CKLX"].ToString();
                }
                if (ds.Tables[1].Rows[0]["NCDJ"] != null)
                {
                    this.txtNCDJ.Text = ds.Tables[1].Rows[0]["NCDJ"].ToString();
                }
                if (ds.Tables[1].Rows[0]["CYS"] != null)
                {
                    this.drpCYS.SelectedValue = ds.Tables[1].Rows[0]["CYS"].ToString();
                }
                if (ds.Tables[1].Rows[0]["FYSJ"] != null)
                {
                    this.txtFYRQ.Text = ds.Tables[1].Rows[0]["FYSJ"].ToString();
                }
                if (ds.Tables[1].Rows[0]["SHDW"] != null)
                {
                    this.drpSHDW.Text = ds.Tables[1].Rows[0]["SHDW"].ToString();
                }
            }
        }
        catch
        {
            this.PrintfError("查询后给父窗体赋值时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击新建单据，并初始化各个输入框，并将表结构赋给Session
    protected void ImgNewButton_Click(object sender, ImageClickEventArgs e)
    {
        ChangeStatus();
        this.hidZT.Value = "Add";
        string CKDH = GetCKDJH();
        txtCKDH.Text = CKDH;
        txtZDR.Text = CUSER.UserID;
        string strdate = DateTime.Now.ToShortDateString();
        txtZDRQ.Text = strdate;
        txtFYRQ.Text = strdate;
        this.drpFHCK.SelectedValue = "请选择";
        this.drpCYS.SelectedValue = "请选择";
        this.drpCKLX.SelectedValue = "请选择";
        this.drpSHDW.SelectedValue = "请选择";
        this.txtCPH.Text = "";
        this.txtMDD.Text = "";
        this.txtNCDJ.Text = "";
        this.txtStatus.Text = "新建";
        try
        {
            DataSet ds = QTCKQuery.GetItemJieGou();
            Session["QTCKITEM"] = ds;
        }
        catch
        {
            this.PrintfError("新建时获得表结构出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 获得出库单据号
    /// <summary>
    /// 获得出库单据号
    /// </summary>
    /// <returns></returns>
    private string GetCKDJH()
    {
        string str = "";
        DataSet ds = QTCKQuery.execQCDH();
        if (ds != null)
        {
            string str1 = ds.Tables[0].Rows[0][0].ToString();
            string str2 = ds.Tables[0].Rows[0][1].ToString();
            str = "CK" + str1 + Convert.ToDouble(str2).ToString("000");
            return str;
        }
        return str;
    }
    #endregion

    #region 设置按钮和输入框为可用
    /// <summary>
    /// 设置按钮和输入框为可用
    /// </summary>
    private void ChangeStatus()
    {
        //查询条件
        drpFHCK.Enabled = true;
        txtCPH.ReadOnly = false;
        drpCKLX.Enabled = true;
        txtNCDJ.ReadOnly = false;
        txtFYRQ.ReadOnly = false;
        txtMDD.ReadOnly = false;
        drpCYS.Enabled = true;
        drpSHDW.Enabled = true;
        //按钮
        ImgNewButton.Enabled = false;
        this.ImgModifybtn.Enabled = false;
        this.ImgDeleteCKD.Enabled = false;
        this.ImgCZDJbtn.Enabled = false;
        this.ImgQXWCbtn.Enabled = false;
        this.imgSave.Enabled = true;
        imgCancel.Enabled = true;
    }
#endregion

    #region 页面加载时绑定发货仓库
    /// <summary>
    /// 页面加载时绑定发货仓库
    /// </summary>
    private void BinddrpCK()
    {
        try
        {
            DataSet ds = QTCKQuery.GetCKID();
            if (ds != null)
            {
                this.drpFHCK.DataSource = ds;
                this.drpFHCK.DataTextField = "CKID";
                this.drpFHCK.ToolTip = "请选择仓库类型";
                this.drpFHCK.DataValueField = "CKID";
                this.drpFHCK.DataBind();
            }
            this.drpFHCK.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("加载仓库信息时出错");
            return;
        }
    }
    #endregion

    #region 页面加载时绑定出库类型
    /// <summary>
    /// 页面加载时绑定出库类型
    /// </summary>
    private void BinddrpCKLX()
    {
        try
        {
            DataSet ds1 = QTCKQuery.GetCHE_QTCK("cklx", "");
            if (ds1 != null)
            {
                this.drpCKLX.DataSource = ds1;
                this.drpCKLX.DataTextField = "cklx";
                this.drpCKLX.DataValueField = "cklx";
                this.drpCKLX.DataBind();
                Bestcomy.Web.UI.WebControls.ComboItem value = new Bestcomy.Web.UI.WebControls.ComboItem("请选择");
                this.drpCKLX.Items.Insert(0, value);
            }
        }
        catch
        {
            this.PrintfError("加载出库类型时出错");
            return;
        }
    }
    #endregion

    #region 页面加载时绑定承运商
    /// <summary>
    /// 页面加载时绑定承运商
    /// </summary>
    private void BinddrpCYS()
    {
        try
        {
            DataSet ds2 = QTCKQuery.GetCHE_QTCK("cys", "cys");
            if (ds2 != null)
            {
                this.drpCYS.DataSource = ds2;
                this.drpCYS.DataTextField = "cys";
                this.drpCYS.DataValueField = "cys";
                this.drpCYS.DataBind();
            }
            this.drpCYS.Items.Insert(0, "请选择");
        }
        catch
        {
            this.PrintfError("加载承运商信息时出错");
            return;

        }
    }
    #endregion

    #region 页面加载时收货单位
    /// <summary>
    /// 页面加载时收货单位
    /// </summary>
    private void BinddrpSHDW()
    {
        try
        {
            DataSet ds3 = QTCKQuery.GetCHE_QTCK("shdw", "shdw");
            if (ds3 != null)
            {
                this.drpSHDW.DataSource = ds3;
                this.drpSHDW.DataTextField = "shdw";
                this.drpSHDW.DataValueField = "shdw";
                this.drpSHDW.DataBind();
                Bestcomy.Web.UI.WebControls.ComboItem value = new Bestcomy.Web.UI.WebControls.ComboItem("请选择");
                this.drpSHDW.Items.Insert(0, value);
            }
        }
        catch
        {
            this.PrintfError("加载收货单位时出错");
            return;
        }
    }
    #endregion

    #region 点击后开始修改单据
    protected void imgMDButton_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtCKDH.Text))
            {
                this.PrintfError("请先选择要修改单据");
                return;
            }
            DataSet ds = QTCKQuery.GetQTCKstatus("ckdh", this.txtCKDH.Text);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.PrintfError("该单据已经执行，不能修改");
                    return;
                }
            }
        }
        catch
        {
            this.PrintfError("获得单据状态时出错");
            return;
        }
    }
    #endregion
    
    #region 检查输入框填写是否符合要求
    /// <summary>
    /// 检查输入框填写是否符合要求
    /// </summary>
    /// <returns></returns>
    private Boolean CheckInfo()
    {
        Boolean result = false;
        if (drpFHCK.SelectedValue == "请选择")
        {
            this.PrintfError("请正确选择仓库信息");
            return result;
        }
        if (drpCKLX.Text == "请选择"||string.IsNullOrEmpty(drpCKLX.Text))
        {
            this.PrintfError("请输入出库类型");
            return result;
        }
        if (string.IsNullOrEmpty(txtNCDJ.Text))
        {
            this.PrintfError("请输入NC单据号");
            return result;
        }
        result = true;
        return result;
    }
    #endregion

    #region 点击取消后放弃对当前单据的操作，并清空页面
    protected void imgCancel_Click(object sender, ImageClickEventArgs e)
    {
        if (!string.IsNullOrEmpty(this.hidZT.Value))
        {
            txtCKDH.Text = "";
            this.hidZT.Value = "";
            ReturnStatus();
            this.drpFHCK.SelectedIndex = -1;
            this.txtCPH.Text = "";
            this.drpCKLX.Text = "";
            this.txtNCDJ.Text = "";
            this.txtFYRQ.Text = "";
            this.txtMDD.Text = "";
            this.drpCYS.SelectedIndex = -1;
            this.drpSHDW.Text = "";
            this.txtStatus.Text = "";
            this.txtZDR.Text = "";
            this.txtZDRQ.Text = "";
            Session["QTCKITEM"] = null;
            this.frameItem.Attributes["src"] = "QTCKD_item.aspx";            
        }
    }
    #endregion

    #region 发货仓库下拉列表改变时向子页面发送当前选中的仓库
    protected void drpFHCK_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CK = this.drpFHCK.SelectedValue;
        this.frameItem.Attributes["src"] = "QTCKD_item.aspx?FHCK="+CK;
    }
    #endregion

    #region 设置按钮和输入框为可用
    /// <summary>
    /// 设置按钮和输入框为可用
    /// </summary>
    private void ReturnStatus()
    {
        //查询条件
        drpFHCK.Enabled = false;
        txtCPH.ReadOnly = true;
        drpCKLX.Enabled = false;
        txtNCDJ.ReadOnly = true;
        txtFYRQ.ReadOnly = true;
        txtMDD.ReadOnly = true;
        drpCYS.Enabled = false;
        drpSHDW.Enabled = false;
        txtStatus.ReadOnly = true;
        //按钮
        ImgNewButton.Enabled = true;
        this.ImgModifybtn.Enabled = true;
        this.ImgDeleteCKD.Enabled = true;
        this.ImgCZDJbtn.Enabled = true;
        this.ImgQXWCbtn.Enabled = true;
        this.imgSave.Enabled = false;
        imgCancel.Enabled = false;
    }
    #endregion

    #region 点击保存按钮，若当前状态为新建，则将各个文本框的值赋给Session的概要信息;若为修改状态，则更新概要信息，提交时会将明细信息一起更新；更新完毕，向子页面发送当前状态为浏览状态
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!CheckInfo())
            {
                return;
            }
            int i = QTCKQuery.GetRecordCount(this.txtCKDH.Text);
            if (i > 0)
            {
                this.PrintfError("该单据已经执行，不能修改");
                return;
            }
            string DJZT = this.hidZT.Value.Trim();
            if (DJZT == "Add")//保存新建的单据
            {
                DataSet ds = (DataSet)Session["QTCKITEM"];
                if (ds == null || ds.Tables[0].Rows.Count < 1)
                {
                    this.PrintfError("未添加任何明细，请进行添加！");
                    return;
                }
                string CKDH = this.txtCKDH.Text.Trim();
                string CK = this.drpFHCK.SelectedValue;
                string CPH = this.txtCPH.Text.Trim();
                string MDD = this.txtMDD.Text.Trim();
                string ZDR = this.txtZDR.Text.Trim();
                string ZDRQ = this.txtZDRQ.Text.Trim();
                string CKLX = this.drpCKLX.Text.Trim();
                string NCDJ = this.txtNCDJ.Text.Trim();
                string CYS = this.drpCYS.SelectedValue;
                string FYSJ = this.txtFYRQ.Text.Trim();
                string SHDW = this.drpSHDW.Text.Trim();
                DataRow row = ds.Tables[1].NewRow();//CKDH,CK,CKLX,NCDJ
                row["CKDH"] = CKDH;
                row["CK"] = CK;
                row["CPH"] = CPH;
                row["AimAdress"] = MDD;
                row["ZDR"] = ZDR;
                row["ZDRQ"] = DateTime.Now;
                row["STATUS"] = "0";
                row["CKLX"] = CKLX;
                row["NCDJ"] = NCDJ;
                if (CYS != "请选择")
                {
                    row["CYS"] = CYS;
                }
                row["FYSJ"] = Convert.ToDateTime(FYSJ);
                if (SHDW != "请选择" || !string.IsNullOrEmpty(SHDW))
                {
                    row["SHDW"] = SHDW;
                }
                ds.Tables[1].Rows.Add(row);

                QTCKQuery.AddQTCKD(ds);
                this.hidZT.Value = "";
                ReturnStatus();
            }
            if (DJZT == "Modify")//保存修改的单据
            {
                DataSet ds = (DataSet)Session["QTCKITEM"];
                if (ds == null || ds.Tables[0].Rows.Count < 1)
                {
                    this.PrintfError("未添加任何明细，请进行添加！");
                    return;
                }
                string CKDH = this.txtCKDH.Text.Trim();
                string CK = this.drpFHCK.SelectedValue;
                string CPH = this.txtCPH.Text.Trim();
                string MDD = this.txtMDD.Text.Trim();
                string ZDR = this.txtZDR.Text.Trim();
                string ZDRQ = this.txtZDRQ.Text.Trim();
                string CKLX = this.drpCKLX.Text.Trim();
                string NCDJ = this.txtNCDJ.Text.Trim();
                string CYS = this.drpCYS.SelectedValue;
                string FYSJ = this.txtFYRQ.Text.Trim();
                string SHDW = this.drpSHDW.Text.Trim();
                ds.Tables[1].Rows[0]["CK"] = CK;
                ds.Tables[1].Rows[0]["CPH"] = CPH;
                ds.Tables[1].Rows[0]["AimAdress"] = MDD;
                ds.Tables[1].Rows[0]["ZDR"] = ZDR;
                ds.Tables[1].Rows[0]["ZDRQ"] = ZDRQ;
                ds.Tables[1].Rows[0]["CKLX"] = CKLX;
                ds.Tables[1].Rows[0]["NCDJ"] = NCDJ;
                ds.Tables[1].Rows[0]["CYS"] = CYS;
                ds.Tables[1].Rows[0]["FYSJ"] = FYSJ;
                ds.Tables[1].Rows[0]["SHDW"] = SHDW;

                QTCKQuery.AddQTCKD(ds);
                this.hidZT.Value = "";
                ReturnStatus();
            }
            this.frameItem.Attributes["src"] = "QTCKD_item.aspx?ZT=Browse";
        }
        catch
        {
            this.PrintfError("保存过程出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击修改按钮，获得当前出库单号的概要和明细赋值给Session,并向子页面发送当前出库单的仓库号
    protected void ImgModifybtn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string CKDH = this.txtCKDH.Text.Trim();
            string CK = this.drpFHCK.SelectedValue;
            if (string.IsNullOrEmpty(CKDH))
            {
                this.PrintfError("请选择要修改的单据");
                return;
            }
            int status = QTCKQuery.GetStatus(CKDH);
            if (status > 0)
            {
                this.PrintfError("该单据已经执行，不能修改");
                return;
            }
            this.hidZT.Value = "Modify";
            ChangeStatus();
            DataSet ds = QTCKQuery.GetItem(CKDH);
            Session["QTCKITEM"] = null;
            Session["QTCKITEM"] = ds;
            this.frameItem.Attributes["src"] = "QTCKD_item.aspx?FHCK=" + CK;
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    #endregion

    #region 点击删除出库单
    protected void ImgDeleteCKD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string CKDH = this.txtCKDH.Text.Trim();
            if (string.IsNullOrEmpty(CKDH))
            {
                this.PrintfError("请选择要修改的单据");
                return;
            }
            int status = QTCKQuery.GetStatus(CKDH);
            if (status > 0)
            {
                this.PrintfError("该单据已经执行，不能删除");
                return;
            }
            string result = QTCKQuery.DeleteCKD(CKDH);
            if (result != "success")
            {
                this.PrintfError("删除过程中发生异常");
                return;
            }
            txtCKDH.Text = "";
            this.hidZT.Value = "";
            ReturnStatus();
            this.drpFHCK.SelectedIndex = -1;
            this.txtCPH.Text = "";
            this.drpCKLX.Text = "";
            this.txtNCDJ.Text = "";
            this.txtFYRQ.Text = "";
            this.txtMDD.Text = "";
            this.drpCYS.SelectedIndex = -1;
            this.drpSHDW.Text = "";
            this.txtStatus.Text = "";
            this.txtZDR.Text = "";
            this.txtZDRQ.Text = "";
            Session["QTCKITEM"] = null;
            this.frameItem.Attributes["src"] = "QTCKD_item.aspx";
        }
        catch
        {
            this.PrintfError("删除过程出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击重置出库单
    protected void ImgCZDJbtn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string CKDH = this.txtCKDH.Text.Trim();
            if (string.IsNullOrEmpty(CKDH))
            {
                this.PrintfError("请选择要重置的单据");
                return;
            }
            int status = QTCKQuery.GetStatus(CKDH);
            if (status > 1)
            {
                this.PrintfError("该单据已经执行完成，不能重置");
                return;
            }
            if (status == 0)
            {
                this.PrintfError("不用重置");
                return;
            }
            string result = QTCKQuery.CZDJ(CKDH);
            if (result != "success")
            {
                this.PrintfError("重置过程出现异常，请重试");
                return;
            }
            this.txtStatus.Text = "新建";
        }
        catch
        {
            this.PrintfError("重置过程出现异常，请重试");
            return;
        }
    }
    #endregion

    #region 点击取消完成出库单
    protected void ImgQXWCbtn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string CKDH = this.txtCKDH.Text.Trim();
            string CK = this.drpFHCK.SelectedValue;
            if (string.IsNullOrEmpty(CKDH))
            {
                this.PrintfError("请选择要重置的单据");
                return;
            }
            int status = QTCKQuery.GetStatus(CKDH);
            if (status < 2)
            {
                this.PrintfError("不用取消");
                return;
            }
            if (status == 2)
            {
                int result = QTCKQuery.QXWC(CKDH, CK, this.CUSER.UserID);
                if (result == 1)
                {
                    this.txtStatus.Text = "正在执行";
                }
            }
        }
        catch
        {
            this.PrintfError("取消完成过程出现错误，请重试");
            return;
        }
    }
    #endregion

}
