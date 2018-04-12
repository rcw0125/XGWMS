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
public partial class SiteBll_PDMan_CuPan : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.txtYSDH.Attributes.Add("onblur", "CheckYSDH()");
            //this.txtPDDH.Attributes.Add("onblur", "CheckPDDH('1')");
            this.btnPrintPDD.Attributes.Add("onclick", "OpenPrintCP()");
            if (!string.IsNullOrEmpty(Request["YSDH"]))
            {
                InitAllByYSDH();
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["PDDH"]))
                {
                    InitAll();
                }
            }
        }

    }

    #region 绑定明细Grid
    /// <summary>
    /// 绑定明细Grid
    /// </summary>
    /// <param name="strWhere">查询条件</param>
    private void BindPddDetailGrid(string PDDH)
    {
        try
        {
            DataSet dsPDDDetail = PDParam.getPddDetailDS(PDDH);
            this.grdInfo.DataSource = dsPDDDetail;
            this.grdInfo.DataBind();
        }
        catch
        {
            this.PrintfError("绑定明细列表时出现数据访问错误");
            return;
        }
    }
    #endregion

    #region 浏览状态绑定货位1
    /// <summary>
    /// 浏览状态绑定货位1
    /// </summary>
    /// <param name="strWhere">查询条件，用于得到原始单号和仓库号</param>
    private void BindHW1(string PDDH)
    {
        try
        {
            DataSet dsPDD = PDParam.GetList("PDDH = '" + PDDH + "'");
            if (dsPDD == null || dsPDD.Tables[0].Rows.Count < 1)
            {
                this.PrintfError("盘点单号不存在！");
                return;
            }
            string YSDH = dsPDD.Tables[0].Rows[0]["YSDH"].ToString();
            string CK = dsPDD.Tables[0].Rows[0]["CK"].ToString();

            DataSet dsHW1 = PDParam.getHW1DS(YSDH, CK);

            ListBox1.DataSource = dsHW1;
            ListBox1.DataTextField = "HW";
            ListBox1.DataValueField = "HW";

            ListBox1.DataBind();
        }
        catch
        {
            this.PrintfError("绑定未分配货位时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 浏览状态绑定货位2
    /// <summary>
    /// 浏览状态绑定货位2
    /// </summary>
    /// <param name="PDDH">盘点单号</param>
    private void BindHW2(string PDDH)
    {
        try
        {
            DataSet dsHW2 = PDParam.getHW2DS(PDDH);

            ListBox2.DataSource = dsHW2;
            ListBox2.DataTextField = "HW";
            ListBox2.DataValueField = "HW";
            ListBox2.DataBind();
        }
        catch
        {
            this.PrintfError("绑定已分配货位时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击新建盘点单
    protected void btnAddPDD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CUSER.USERFUNCTION.M_PDD==false)
            {
                this.PrintfError("您没有制单权限");
                return;
            }
            this.btnAddPDD.Enabled = false;
            this.btnDeletePDD.Enabled = false;
            this.btnModifyPDD.Enabled = false;
            this.btnPrintPDD.Enabled = false;
            this.btnShenhePDD.Enabled = false;
            this.btnSavePDD.Enabled = true;
            this.btnCancelPDD.Enabled = true;
            this.ListBox1.Items.Clear();
            this.ListBox2.Items.Clear();
            this.ListBox3.Items.Clear();
            this.grdInfo.DataSource = null;
            this.grdInfo.DataBind();

            this.txtPDDH.Text = PDParam.GetPDDH("粗盘");
            this.txtZDRQ.Text = PDParam.GetSysDate();
            this.txtDJZT.Text = "新建";
            this.txtZDRY.Text = this.CUSER.UserName;
            this.hidState.Value = "AddPDD";

            this.txtCK.Text = "";
            this.hidCKID.Value = "";
            this.txtYSDH.Text = "";
            this.txtSHRY.Text = "";
            this.txtSHRQ.Text = "";
            this.txtPDRQ.Text = "";
        }
        catch
        {
            this.PrintfError("新建盘点单时发生意外，请重试");
            return;
        }
    }
    #endregion

    #region 点击取消新建盘点单
    protected void btnCancelPDD_Click(object sender, ImageClickEventArgs e)
    {
        this.btnAddPDD.Enabled = true;
        this.btnDeletePDD.Enabled = true;
        this.btnModifyPDD.Enabled = true;
        this.btnPrintPDD.Enabled = true;
        this.btnShenhePDD.Enabled = true;
        this.btnSavePDD.Enabled = false;
        this.btnCancelPDD.Enabled = false;
        this.ListBox1.Items.Clear();
        this.ListBox2.Items.Clear();
        this.ListBox3.Items.Clear();
        this.grdInfo.DataSource = null;
        this.grdInfo.DataBind();
        this.txtPDDH.Text = "";
        this.txtZDRQ.Text = "";
        this.txtDJZT.Text = "";
        this.txtZDRY.Text = "";
        this.txtCK.Text = "";
        this.txtYSDH.Text = "";
        this.txtSHRY.Text = "";
        this.txtSHRQ.Text = "";
        this.txtPDRQ.Text = "";
        this.hidCKID.Value = "";
        this.hidState.Value = "";
        this.txtYSDH.ReadOnly = false;
        this.txtPDDH.ReadOnly = false;
    }
    #endregion

    #region 点击保存盘点单
    protected void btnSavePDD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string State = this.hidState.Value.Trim();
            if (this.ListBox2.Items.Count < 1)
            {
                this.PrintfError("未选择盘点货位！");
                return;
            }
            string HW2 = "";
            for (int i = 0; i < ListBox2.Items.Count; i++)
            {
                if (!string.IsNullOrEmpty(HW2))
                {
                    HW2 += ",'" + ListBox2.Items[i].Value+"'";
                }
                else
                {
                    HW2 = "'"+ListBox2.Items[i].Value+"'";
                }
            }

            if (State == "AddPDD")
            {
                string result = PDParam.AddCPD(this.txtYSDH.Text.Trim(), this.txtPDDH.Text.Trim(), this.hidCKID.Value.Trim(), this.txtPDRQ.Text.Trim(), this.txtZDRQ.Text.Trim(), this.txtZDRY.Text.Trim(), "卷", "吨", HW2);
                if (result == "success")
                {
                    this.PrintfError("保存成功");
                }
                else
                {
                    string strResult = result.Replace("'", "").Replace("\"", "").Replace("\r", "").Replace("\t", "").Replace("\n", "");
                    this.PrintfError(strResult);
                }
            }
            if (State == "ModifyPDD")
            {
                string result = PDParam.ModifyCPD(this.txtPDDH.Text.Trim(), this.hidCKID.Value.Trim(), HW2, "卷", "吨");
                if (result == "success")
                {
                    this.PrintfError("保存成功");
                }
                else
                {
                    string strResult = result.Replace("'", "").Replace("\"", "").Replace("\r", "").Replace("\t", "").Replace("\n", "");
                    this.PrintfError(strResult);
                }
            }

            this.hidState.Value = "";
            DataSet ds = PDParam.getPddDetailDS(this.txtPDDH.Text.Trim());
            this.grdInfo.DataSource = ds;
            this.grdInfo.DataBind();

            this.btnAddPDD.Enabled = true;
            this.btnDeletePDD.Enabled = true;
            this.btnModifyPDD.Enabled = true;
            this.btnPrintPDD.Enabled = true;
            this.btnShenhePDD.Enabled = true;
            this.btnSavePDD.Enabled = false;
            this.btnCancelPDD.Enabled = false;
            this.txtYSDH.ReadOnly = false;
            this.txtPDDH.ReadOnly = false;
        }
        catch
        {
            this.PrintfError("保存失败，请重试！");
            return;
        }
    }
    #endregion

    #region 点击确定查看已选择的货位的物料信息
    protected void btnGoOK_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidState.Value))
            {
                this.PrintfError("当前为浏览状态不能更改盘点范围！");
                return;
            }
            if (this.ListBox2.Items.Count < 1)
            {
                this.PrintfError("未选择盘点货位！");
                return;
            }
            else
            {
                string HW2 = "";
                for (int i = 0; i < ListBox2.Items.Count; i++)
                {
                    if (!string.IsNullOrEmpty(HW2))
                    {
                        HW2 += ",'" + ListBox2.Items[i].Value+"'";
                    }
                    else
                    {
                        HW2 = "'"+ListBox2.Items[i].Value+"'";
                    }
                }
                DataSet ds = PDParam.LookCPddDetail(this.txtPDDH.Text.Trim(), "卷", "吨", this.hidCKID.Value.Trim(), HW2);
                this.grdInfo.DataSource = ds;
                this.grdInfo.DataBind();
            }
        }
        catch
        {
            this.PrintfError("预览货位信息时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 将货位1的选中项移到货位2

     protected void btnGoRight_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidState.Value))
            {
                this.PrintfError("当前为浏览状态不能更改盘点范围！");
                return;
            }
            if (this.ListBox1.Items.Count < 1)
            {
                this.PrintfError("没有货位！");
                return;
            }
            else
            {
                if (this.ListBox1.SelectedIndex == -1)
                {
                    this.PrintfError("未选中任何未分配货位！");
                    return;
                }
                else
                {
                    string v = this.ListBox1.SelectedValue;
                    string t = this.ListBox1.SelectedItem.Text;
                    int seleInt = this.ListBox1.SelectedIndex - 1;
                    this.ListBox1.Items.Remove(this.ListBox1.SelectedItem);
                    if (seleInt != -1)
                        this.ListBox1.SelectedIndex = seleInt;
                    ListItem item = new ListItem(t, v);
                    this.ListBox2.Items.Add(item);
                }
            }
        }
        catch
        {
            this.PrintfError("货位移动时出现错误，请确保您选中了货位");
            return;
        }
    }

    #endregion

    #region 将货位2的选中项移到货位1
    protected void btnGoLeft_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.hidState.Value))
            {
                this.PrintfError("当前为浏览状态不能更改盘点范围！");
                return;
            }
            if (this.ListBox2.Items.Count < 1)
            {
                this.PrintfError("没有货位！");
                return;
            }
            else
            {
                if (this.ListBox2.SelectedItem == null || this.ListBox2.SelectedIndex == -1)
                {
                    this.PrintfError("未选中任何未分配货位！");
                    return;
                }
                else
                {
                    string v = this.ListBox2.SelectedValue;
                    string t = this.ListBox2.SelectedItem.Text;
                    int seleInt = this.ListBox2.SelectedIndex - 1;
                    this.ListBox2.Items.Remove(this.ListBox2.SelectedItem);
                    if (seleInt != -1)
                        this.ListBox2.SelectedIndex = seleInt;
                    ListItem item = new ListItem(t, v);
                    this.ListBox1.Items.Add(item);
                }
            }
        }
        catch
        {
            this.PrintfError("移动货位时出现错误，请确保您选中了货位");
            return;
        }
    }
    #endregion

    #region 点击修改盘点单
    protected void btnModifyPDD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CUSER.USERFUNCTION.M_PDD == false)
            {
                this.PrintfError("您没有制单权限");
                return;
            }
            string PDDH = this.txtPDDH.Text.Trim();
            if (string.IsNullOrEmpty(PDDH))
            {
                this.PrintfError("请选择盘点单号！");
                this.txtPDDH.Focus();
                return;
            }
            if (this.ListBox2.Items.Count < 1)
            {
                this.PrintfError("请先进行查询！");
                return;
            }
            string DJZT = PDParam.GetDJZT(PDDH);
            if (DJZT != "新建")
            {
                this.PrintfError("当前单据状态为：【" + DJZT + "】,不能修改单据!");
                return;
            }
            else
            {
                this.hidState.Value = "ModifyPDD";
                this.txtYSDH.ReadOnly = true;
                this.txtPDDH.ReadOnly = true;
                this.btnAddPDD.Enabled = false;
                this.btnModifyPDD.Enabled = false;
                this.btnDeletePDD.Enabled = false;
                this.btnPrintPDD.Enabled = false;
                this.btnShenhePDD.Enabled = false;
                this.btnSavePDD.Enabled = true;
                this.btnCancelPDD.Enabled = true;
            }
        }
        catch
        {
            this.PrintfError("试图修改单据时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击删除盘点单
    protected void btnDeletePDD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CUSER.USERFUNCTION.M_PDD == false)
            {
                this.PrintfError("您没有制单权限");
                return;
            }
            string PDDH = this.txtPDDH.Text.Trim();
            if (string.IsNullOrEmpty(PDDH))
            {
                this.PrintfError("请选择盘点单号！");
                this.txtPDDH.Focus();
                return;
            }
            string DJZT = PDParam.GetDJZT(PDDH);
            if (DJZT != "新建")
            {
                this.PrintfError("当前单据状态为：【" + DJZT + "】,不能修改单据!");
                return;
            }
            else
            {
                this.WriteClientJava("DeletePDD('" + PDDH + "');");
            }
        }
        catch
        {
            this.PrintfError("删除单据失败，请重试");
            return;
        }
    }
    #endregion

    #region 点击审核盘点单
    protected void btnShenhePDD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CUSER.USERFUNCTION.SH_PDD==false)
            {
                this.PrintfError("您没有审核权限");
                return;
            }
            string PDDH = this.txtPDDH.Text.Trim();
            if (string.IsNullOrEmpty(PDDH))
            {
                this.PrintfError("请选择盘点单号！");
                this.txtPDDH.Focus();
                return;
            }
            DataSet dsYSDH = PDParam.GetPDDbyPDDH(PDDH);
            if (dsYSDH == null || dsYSDH.Tables[0].Rows.Count < 1)
            {
                this.PrintfError("盘点单不存在！");
                return;
            }
            string YSDH = dsYSDH.Tables[0].Rows[0]["YSDH"].ToString();
            string DJZT = PDParam.GetDJZT(PDDH);
            if (DJZT != "已盘")
            {
                this.PrintfError("只有【已盘】状态的单据才能进行审核!");
                return;
            }
            else
            {
                DataSet UnEqualDS = PDParam.UnEqualDS(PDDH);
                if (UnEqualDS.Tables[0].Rows.Count > 0)
                {
                    this.PrintfError("存在帐存数量与盘点数量不相等的物料，导致无法确定盘点重量，请对相关物料进行抽盘!");
                    return;
                }
                else
                {
                    string result = PDParam.shenhePDD(YSDH, PDDH, this.CUSER.UserID);
                    if (result == "success")
                    {
                        this.txtDJZT.Text = "已审";
                        this.PrintfError("审核完毕");
                    }
                    else
                    {
                        string strResult = result.Replace("'", "").Replace("\"", "").Replace("\r", "").Replace("\t", "").Replace("\n", "");
                        this.PrintfError(strResult);
                    }
                }
            }
        }
        catch
        {
            this.PrintfError("审核盘点单时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击放开盘点单
    protected void btnFangkaiPDD_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string PDDH = this.txtPDDH.Text.Trim();
            if (string.IsNullOrEmpty(PDDH))
            {
                this.PrintfError("请选择盘点单号！");
                this.txtPDDH.Focus();
                return;
            }
            DataSet dsYSDH = PDParam.GetPDDbyPDDH(PDDH);
            if (dsYSDH == null || dsYSDH.Tables[0].Rows.Count < 1)
            {
                this.PrintfError("盘点单不存在！");
                return;
            }
            string DJZT = dsYSDH.Tables[0].Rows[0]["DJZT"].ToString();
            if (DJZT == "新建" || DJZT == "在盘")
            {
                this.PrintfError("没有完成，不用放开！");
                return;
            }
            if (DJZT == "已审")
            {
                this.PrintfError("已审，不能放开！");
                return;
            }
            if (DJZT == "已盘")
            {
                this.WriteClientJava("fangkaiPDD('" + PDDH + "');");
            }
        }
        catch
        {
            this.PrintfError("放开单据时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 选择盘点单时对页面进行初始化
    /// <summary>
    /// 选择盘点单时对页面进行初始化
    /// </summary>
    private void InitAll()
    {
        try
        {
            string State = Request["State"];
            this.hidState.Value = State;
            string PDDH = Request["PDDH"].ToString();
            BindPddDetailGrid(PDDH);
            BindHW1(PDDH);
            BindHW2(PDDH);
            BindText(PDDH);
            this.ListBox3.Items.Clear();
            DataSet ds = PDParam.GetList("YSDH = (select YSDH from WMS_Che_PDD where PDDH = '" + PDDH + "') and DJLX = '粗盘'");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string value = i.ToString();
                string text = ds.Tables[0].Rows[i]["PDDH"].ToString();
                ListItem item = new ListItem(text, value);
                this.ListBox3.Items.Add(item);
            }
            this.hidYSDH.Value = ds.Tables[0].Rows[0]["YSDH"].ToString();
            this.hidnum.Value = "0";
        }
        catch
        {
            this.PrintfError("选择盘点单号后，进行初始化页面时发生错误，请重试");
            return;
        }
    }
    #endregion

    #region 选择盘点单时给各个TextBox绑定信息
    /// <summary>
    /// 选择盘点单时给各个TextBox绑定信息
    /// </summary>
    /// <param name="PDDH"></param>
    private void BindText(string PDDH)
    {
        try
        {
            DataSet ds = PDParam.GetList("PDDH = '" + PDDH + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this.txtYSDH.Text = ds.Tables[0].Rows[0]["YSDH"].ToString();
                this.txtPDDH.Text = PDDH;
                this.hidCKID.Value = ds.Tables[0].Rows[0]["CK"].ToString();
                this.txtCK.Text = ds.Tables[0].Rows[0]["CKName"].ToString();
                this.txtPDRQ.Text = ds.Tables[0].Rows[0]["PDRQ"].ToString();
                this.txtZDRQ.Text = ds.Tables[0].Rows[0]["ZDRQ"].ToString();
                this.txtZDRY.Text = ds.Tables[0].Rows[0]["ZDUser"].ToString();
                this.txtSHRY.Text = ds.Tables[0].Rows[0]["SHUser"].ToString();
                this.txtSHRQ.Text = ds.Tables[0].Rows[0]["SHRQ"].ToString();
                this.txtDJZT.Text = ds.Tables[0].Rows[0]["DJZT"].ToString();
                this.hidDJLX.Value = ds.Tables[0].Rows[0]["DJLX"].ToString();
            }
        }
        catch
        {
            this.PrintfError("为文本框赋值出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 选择原始单号时对页面进行初始化
    private void InitAllByYSDH()
    {
        try
        {
            string State = Request["State"];
            this.hidState.Value = State;
            string YSDH = Request["YSDH"].ToString();
            this.hidYSDH.Value = YSDH;
            if (State == "AddPDD")
            {
                DataSet dsPDDNC = PDParam.GetPDDNC("YSDH = '" + YSDH + "'");
                string CKID = dsPDDNC.Tables[0].Rows[0]["CK"].ToString();
                this.txtPDDH.Text = Request["PDDH"];
                this.txtZDRY.Text = this.CUSER.UserName;
                this.txtZDRQ.Text = PDParam.GetSysDate();
                this.txtYSDH.Text = YSDH;
                this.hidCKID.Value = CKID;
                this.txtCK.Text = dsPDDNC.Tables[0].Rows[0]["CKName"].ToString();
                this.txtPDRQ.Text = dsPDDNC.Tables[0].Rows[0]["PDRQ"].ToString();
                this.txtDJZT.Text = "新建";
                DataSet dsHW1 = PDParam.getHW1DS(YSDH, CKID);
                ListBox1.DataSource = dsHW1;
                ListBox1.DataTextField = "HW";
                ListBox1.DataValueField = "HW";
                ListBox1.DataBind();
                this.btnAddPDD.Enabled = false;
                this.btnDeletePDD.Enabled = false;
                this.btnModifyPDD.Enabled = false;
                this.btnPrintPDD.Enabled = false;
                this.btnShenhePDD.Enabled = false;
                this.btnSavePDD.Enabled = true;
                this.btnCancelPDD.Enabled = true;
                this.ListBox2.Items.Clear();
                this.ListBox3.Items.Clear();
                this.grdInfo.DataSource = null;
                this.grdInfo.DataBind();

            }
            else
            {
                this.ListBox3.Items.Clear();
                DataSet ds = PDParam.GetList("YSDH = '" + YSDH + "' and DJLX = '粗盘'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string PDDHfirst = ds.Tables[0].Rows[0]["PDDH"].ToString();
                    BindPddDetailGrid(PDDHfirst);
                    BindHW1(PDDHfirst);
                    BindHW2(PDDHfirst);
                    BindText(PDDHfirst);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string value = i.ToString();
                        string text = ds.Tables[0].Rows[i]["PDDH"].ToString();
                        ListItem item = new ListItem(text, value);
                        this.ListBox3.Items.Add(item);
                    }
                    this.hidnum.Value = "0";
                }
            }
        }
        catch
        {
            this.PrintfError("选择原始单号后，页面初始化时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击显示下一条盘点单信息
    protected void btnnext_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if ((this.ListBox3.Rows < 1) || string.IsNullOrEmpty(this.hidnum.Value))
            {
                this.PrintfError("已经到最后一条了");
                return;
            }
            int num = Convert.ToInt32(this.hidnum.Value);
            if (num < this.ListBox3.Items.Count)
            {
                if (num < 0)
                {
                    num = 0;
                }
                string PDDH = this.ListBox3.Items[num].Text.ToString();
                BindPddDetailGrid(PDDH);
                BindHW1(PDDH);
                BindHW2(PDDH);
                BindText(PDDH);
                num++;
                this.hidnum.Value = num.ToString();
            }
            else
            {
                this.PrintfError("已经到最后一条了");
                return;
            }
        }
        catch
        {
            this.PrintfError("跳转到下一条盘点单时出现错误，请重试");
            return;
        }
    }
    #endregion

    #region 点击显示上一条盘点单信息
    protected void btnlast_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if ((this.ListBox3.Rows < 1) || string.IsNullOrEmpty(this.hidnum.Value))
            {
                this.PrintfError("已经到第一条了");
                return;
            }
            int num = Convert.ToInt32(this.hidnum.Value);
            if (num <= this.ListBox3.Items.Count && num > -1)
            {
                if (num == this.ListBox3.Items.Count)
                {
                    num = this.ListBox3.Items.Count - 1;
                }
                string PDDH = this.ListBox3.Items[num].Text.ToString();
                BindPddDetailGrid(PDDH);
                BindHW1(PDDH);
                BindHW2(PDDH);
                BindText(PDDH);
                num--;
                this.hidnum.Value = num.ToString();
            }
            else
            {
                this.PrintfError("已经到第一条了");
                return;
            }
        }
        catch
        {
            this.PrintfError("跳转到上一条盘点单时出现错误，请重试");
            return;
        }
    }
    #endregion
   
}
