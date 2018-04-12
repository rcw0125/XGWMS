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
using ACCTRUE.WMSBLL.QueryBll;
using ACCTRUE.WMSBLL.Model;
using System.Text.RegularExpressions;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_StockMan_QTCKD_item :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["FHCK"]))//获得发货仓库，用来绑定批次号下拉列表
            {
                this.hidCK.Value = Request["FHCK"];
                //BindPCH((Request["FHCK"]));
            }
            if(!string.IsNullOrEmpty(Request["ZT"]))//判断父窗体状态，如果是浏览状态，则隐藏明细Grid的修改和删除两列
            {
                this.hidZT.Value = Request["ZT"];
                if (this.hidZT.Value == "Browse")
                {
                    this.grvCKZB.Columns[0].Visible = false;
                    this.grvCKZB.Columns[1].Visible = false;
                }
            }
            BindGrid();//绑定明细Grid
        }
    }
    #region 点击确定将明细修改框赋值给Session并重新绑定明细Grid
    protected void btnItemOK_Click1(object sender, ImageClickEventArgs e)
    {
        try
        {
            string patSL = @"^\d+$";
            Regex rg = new Regex(patSL);
            Match mh = rg.Match(this.txtJHSL.Text);
            if (!mh.Success)
            {
                this.PrintfError("计划数量框只许输入非负整数");
                txtJHSL.Text = "";
                return;
            }
            string patZL = @"^\d+(\.\d+)?$";
            Regex rgZL = new Regex(patZL);
            Match mhZL = rgZL.Match(this.txtJHZL.Text);
            if (!mhZL.Success)
            {
                this.PrintfError("计划重量框只许输入非负浮点数");
                this.txtJHZL.Text = "";
                return;
            }

            string MXZT = this.hidMXZT.Value.Trim();
            if (MXZT == "Add")
            {
                DataSet ds = (DataSet)Session["QTCKITEM"];
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string PCH = this.txtPCH.Text.Trim();
                    string SX = this.drpSX.SelectedValue;
                    string FREE1 = this.drpFree1.SelectedValue;
                    string FREE2 = this.drpFree2.SelectedValue;
                    string FREE3 = this.drpFree3.SelectedValue;
                    if (ds.Tables[0].Select("PCH = '" + PCH + "' and SX = '" + SX + "' AND VFREE1='"+FREE1+"' AND VFREE2='"+FREE2+"' AND VFREE3='"+FREE3+"'").Length > 0)
                    {
                        this.PrintfError("同一单据中不能出现同一批次属性自由项目的物料信息");
                        return;
                    }
                }
                DataRow row = ds.Tables[0].NewRow();
                row["CKDH"] = this.hidCKDH.Value.Trim();
                row["PCH"] = this.txtPCH.Text.Trim();
                row["SX"] = this.drpSX.SelectedValue;
                row["VFREE1"] = this.drpFree1.SelectedValue;
                row["VFREE2"] = this.drpFree2.SelectedValue;
                row["VFREE3"] = this.drpFree3.SelectedValue;
                row["WLH"] = this.txtWLH.Text.Trim();
                row["WLMC"] = this.txtWLMC.Text.Trim();
                row["PH"] = this.txtPH.Text.Trim();
                row["GG"] = this.txtGG.Text.Trim();
                row["JHSL"] = Convert.ToInt32(this.txtJHSL.Text.Trim());
                row["JHZL"] = Convert.ToDouble(this.txtJHZL.Text.Trim());
                row["SJSL"] = 0;
                row["SJZL"] = 0.000;
                row["SLDW"] = this.txtSLDW.Text.Trim();
                row["ZLDW"] = this.txtZLDW.Text.Trim();
                ds.Tables[0].Rows.Add(row);
                Session["QTCKITEM"] = ds;
                this.grvCKZB.DataSource = ds;
                this.grvCKZB.DataBind();
                this.hidMXZT.Value = "";
            }
            if (MXZT == "Modify")
            {
                DataSet ds = (DataSet)Session["QTCKITEM"];
                int RowIndex = Convert.ToInt32(this.hidRowIndex.Value.Trim());
                ds.Tables[0].Rows[RowIndex]["PCH"] = this.txtPCH.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["SX"] = this.drpSX.SelectedValue;
                ds.Tables[0].Rows[RowIndex]["VFREE1"] = this.drpFree1.SelectedValue;
                ds.Tables[0].Rows[RowIndex]["VFREE2"] = this.drpFree2.SelectedValue;
                ds.Tables[0].Rows[RowIndex]["VFREE3"] = this.drpFree3.SelectedValue;
                ds.Tables[0].Rows[RowIndex]["WLH"] = this.txtWLH.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["WLMC"] = this.txtWLMC.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["PH"] = this.txtPH.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["GG"] = this.txtGG.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["JHSL"] = this.txtJHSL.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["JHZL"] = this.txtJHZL.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["SLDW"] = this.txtSLDW.Text.Trim();
                ds.Tables[0].Rows[RowIndex]["ZLDW"] = this.txtZLDW.Text.Trim();
                Session["QTCKITEM"] = ds;
                this.grvCKZB.DataSource = ds;
                this.grvCKZB.DataBind();
                this.hidMXZT.Value = "";
            }
            this.txtPCH.Text = "";
            this.drpSX.Items.Clear();
            this.drpFree1.Items.Clear();
            this.drpFree2.Items.Clear();
            this.drpFree3.Items.Clear();
            this.txtWLH.Text = "";
            this.txtWLMC.Text = "";
            this.txtPH.Text = "";
            this.txtGG.Text = "";
            this.txtJHSL.Text = "";
            this.txtJHZL.Text = "";
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    #endregion

    //#region 绑定批次号下拉列表
    // <summary>
    // 绑定批次号下拉列表
    // </summary>
    // <param name="CK"></param>
    //private void BindPCH(string CK)
    //{
    //    try
    //    {
    //        DataSet ds = QTCKQuery.GetPCHbyCK(CK);
    //        if (ds != null)
    //        {
    //            this.drpPCH.DataSource = ds;
    //            this.drpPCH.DataTextField = "PCH";
    //            this.drpPCH.ToolTip = "批次号";
    //            this.drpPCH.DataValueField = "PCH";
    //            this.drpPCH.DataBind();
    //            this.drpPCH.Items.Insert(0, "请选择");
    //        }
    //    }
    //    catch
    //    {
    //        this.PrintfError("数据访问错误");
    //        return;
    //    }
    //}
    //#endregion

    #region 从Session绑定明细Grid
    /// <summary>
    /// 从Session绑定明细Grid
    /// </summary>
    private void BindGrid()
    {
        try
        {
            if (Session["QTCKITEM"] != null)
            {
                DataSet ds = (DataSet)Session["QTCKITEM"];
                this.grvCKZB.DataSource = ds;
                this.grvCKZB.DataBind();
            }
            else
            {
                this.grvCKZB.DataSource = null;
                this.grvCKZB.DataBind();
            }
        }
        catch(Exception exx)
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    #endregion

    #region 绑定属性下拉列表
    /// <summary>
    /// 绑定属性及自由项下拉列表
    /// </summary>
    /// <param name="PCH"></param>
    /// <param name="CK"></param>
    private void BindSX(string PCH,string CK)
    {
        try
        {
            DataSet ds = QTCKQuery.GetSXbyPCH(PCH, CK);
            if (ds != null)
            {
                this.drpSX.DataSource = ds;
                this.drpSX.DataTextField = "SX";
                this.drpSX.ToolTip = "属性";
                this.drpSX.DataValueField = "SX";
                this.drpSX.DataBind();

                this.drpFree1.DataSource = ds;
                this.drpFree1.DataTextField = "Vfree1";
                this.drpFree1.ToolTip = "自由项1";
                this.drpFree1.DataValueField = "Vfree1";
                this.drpFree1.DataBind();

                this.drpFree2.DataSource = ds;
                this.drpFree2.DataTextField = "Vfree2";
                this.drpFree2.ToolTip = "自由项2";
                this.drpFree2.DataValueField = "Vfree2";
                this.drpFree2.DataBind();

                this.drpFree3.DataSource = ds;
                this.drpFree3.DataTextField = "Vfree3";
                this.drpFree3.ToolTip = "自由项3";
                this.drpFree3.DataValueField = "Vfree3";
                this.drpFree3.DataBind();
            }
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    #endregion

    //#region 批次号下拉列表改变时绑定属性下拉列表
    //protected void drpPCH_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(this.drpPCH.SelectedValue))
    //        {
    //            string CK = this.hidCK.Value.Trim();
    //            string PCH = this.drpPCH.SelectedValue;
    //            DataSet ds = QTCKQuery.GetSXbyPCH(PCH, CK);
    //            if (ds != null)
    //            {
    //                this.drpSX.DataSource = ds;
    //                this.drpSX.DataTextField = "SX";
    //                this.drpSX.ToolTip = "属性";
    //                this.drpSX.DataValueField = "SX";
    //                this.drpSX.DataBind();

    //                this.txtWLH.Text = ds.Tables[0].Rows[0]["WLH"].ToString();
    //                this.txtWLMC.Text = ds.Tables[0].Rows[0]["WLMC"].ToString();
    //                this.txtPH.Text = ds.Tables[0].Rows[0]["PH"].ToString();
    //                this.txtGG.Text = ds.Tables[0].Rows[0]["GG"].ToString();
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        this.PrintfError("数据访问错误");
    //        return;
    //    }
    //}
    //#endregion

    #region 属性下拉列表改变时给规格等几个文本框赋值
    protected void drpSX_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(this.drpSX.SelectedValue))
            {
                string CK = this.hidCK.Value.Trim();
                //string PCH = this.drpPCH.SelectedValue;
                string PCH = this.txtPCH.Text.Trim();
                string SX = this.drpSX.SelectedValue;
                DataSet ds = QTCKQuery.GetWLHbySX(SX, PCH, CK);
                if (ds != null)
                {
                    this.drpFree1.DataSource = ds;
                    this.drpFree1.DataTextField = "vfree1";
                    this.drpFree1.ToolTip = "自由项1";
                    this.drpFree1.DataValueField = "vfree1";
                    this.drpFree1.DataBind();

                    this.drpFree2.DataSource = ds;
                    this.drpFree2.DataTextField = "vfree2";
                    this.drpFree2.ToolTip = "自由项2";
                    this.drpFree2.DataValueField = "vfree2";
                    this.drpFree2.DataBind();

                    this.drpFree3.DataSource = ds;
                    this.drpFree3.DataTextField = "vfree3";
                    this.drpFree3.ToolTip = "自由项3";
                    this.drpFree3.DataValueField = "vfree3";
                    this.drpFree3.DataBind();

                    this.txtWLH.Text = ds.Tables[0].Rows[0]["WLH"].ToString();
                    this.txtWLMC.Text = ds.Tables[0].Rows[0]["WLMC"].ToString();
                    this.txtPH.Text = ds.Tables[0].Rows[0]["PH"].ToString();
                    this.txtGG.Text = ds.Tables[0].Rows[0]["GG"].ToString();
                }
            }
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    #endregion

    #region 绑定明细Grid时给修改和删除按钮的CommandArgument赋值，主要是获得按钮所属行的行号
    protected void grvCKZB_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string RowIndex = e.Row.RowIndex.ToString();
                ImageButton imgBtn = (ImageButton)e.Row.FindControl("imgBtnModify");
                string PCH = DataBinder.Eval(e.Row.DataItem, "PCH").ToString();
                string SX = DataBinder.Eval(e.Row.DataItem, "SX").ToString();
                string FREE1 = DataBinder.Eval(e.Row.DataItem, "VFREE1").ToString();
                string FREE2 = DataBinder.Eval(e.Row.DataItem, "VFREE2").ToString();
                string FREE3 = DataBinder.Eval(e.Row.DataItem, "VFREE3").ToString();

                string WLH = DataBinder.Eval(e.Row.DataItem, "WLH").ToString();
                string WLMC = DataBinder.Eval(e.Row.DataItem, "WLMC").ToString();
                string PH = DataBinder.Eval(e.Row.DataItem, "PH").ToString();
                string GG = DataBinder.Eval(e.Row.DataItem, "GG").ToString();
                string JHSL = DataBinder.Eval(e.Row.DataItem, "JHSL").ToString();
                string JHZL = DataBinder.Eval(e.Row.DataItem, "JHZL").ToString();
                string SJSL = DataBinder.Eval(e.Row.DataItem, "SJSL").ToString();
                string SJZL = DataBinder.Eval(e.Row.DataItem, "SJZL").ToString();
                string SLDW = DataBinder.Eval(e.Row.DataItem, "SLDW").ToString();
                string ZLDW = DataBinder.Eval(e.Row.DataItem, "ZLDW").ToString();
                imgBtn.CommandArgument = RowIndex + "," + PCH + "," + SX + ","+FREE1+","+FREE2+","+FREE3+"," + WLH + "," + PH + "," + GG + "," + JHSL + "," + JHZL + "," + SJSL + "," + SJZL + "," + SLDW + "," + ZLDW;

                ImageButton imgDel = (ImageButton)e.Row.FindControl("imgBtnDelete");
                imgDel.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
                imgDel.CommandArgument = RowIndex + "," + PCH + "," + SX + "," + FREE1 + "," + FREE2 + "," + FREE3 ;
            }
        }
        catch(Exception ex)
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
    #endregion

    #region 在Grid中，点击修改时从Session中取值给明细修改框赋值；点击删除时删除Session中该行
    protected void grvCKZB_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string MXInfo = (string)e.CommandArgument;
            if (e.CommandName == "imgBtnModify")
            {
                this.hidMXZT.Value = "Modify";
                string[] MXInfos = MXInfo.Split(',');
                int RowIndex = Convert.ToInt32(MXInfos[0]);
                this.hidRowIndex.Value = RowIndex.ToString();
                DataSet ds = (DataSet)Session["QTCKITEM"];
                this.txtPCH.Text = ds.Tables[0].Rows[RowIndex]["PCH"].ToString();
                BindSX(ds.Tables[0].Rows[RowIndex]["PCH"].ToString(), this.hidCK.Value.Trim());
                
                this.drpSX.Text = ds.Tables[0].Rows[RowIndex]["SX"].ToString();
                this.drpFree1.Text = ds.Tables[0].Rows[RowIndex]["VFREE1"].ToString();
                this.drpFree2.Text = ds.Tables[0].Rows[RowIndex]["VFREE2"].ToString();
                this.drpFree3.Text = ds.Tables[0].Rows[RowIndex]["VFREE3"].ToString();

                this.txtWLH.Text = ds.Tables[0].Rows[RowIndex]["WLH"].ToString();
                this.txtWLMC.Text = ds.Tables[0].Rows[RowIndex]["WLMC"].ToString();
                this.txtPH.Text = ds.Tables[0].Rows[RowIndex]["PH"].ToString();
                this.txtGG.Text = ds.Tables[0].Rows[RowIndex]["GG"].ToString();
                this.txtJHSL.Text = ds.Tables[0].Rows[RowIndex]["JHSL"].ToString();
                this.txtJHZL.Text = ds.Tables[0].Rows[RowIndex]["JHZL"].ToString();
                this.txtSLDW.Text = ds.Tables[0].Rows[RowIndex]["SLDW"].ToString();
                this.txtZLDW.Text = ds.Tables[0].Rows[RowIndex]["ZLDW"].ToString();
            }
            if (e.CommandName == "imgBtnDelete")
            {
                string[] MXInfos = MXInfo.Split(',');
                int RowIndex = Convert.ToInt32(MXInfos[0]);
                DataSet ds = (DataSet)Session["QTCKITEM"];
                ds.Tables[0].Rows[RowIndex].Delete();
                Session["QTCKITEM"] = ds;
                this.grvCKZB.DataSource = ds;
                this.grvCKZB.DataBind();
            }
        }
        catch
        {
            this.PrintfError("数据访问失败，请重试！");
            return;
        }
    }
    #endregion

    protected void txtPCH_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string CK = this.hidCK.Value.Trim();
            string PCH = this.txtPCH.Text.Trim();
            if (!string.IsNullOrEmpty(PCH))
            {
                DataSet ds = QTCKQuery.GetSXbyPCH(PCH, CK);
                DataSet dsSX = QTCKQuery.GetSXbyPCHNEW(PCH, CK);
                if (dsSX != null && dsSX.Tables[0].Rows.Count > 0)
                {
                    this.drpSX.DataSource = dsSX;
                    this.drpSX.DataTextField = "SX";
                    this.drpSX.ToolTip = "属性";
                    this.drpSX.DataValueField = "SX";
                    this.drpSX.DataBind();

                    DataSet dsFree1 = QTCKQuery.GetFree1BySX(this.drpSX.SelectedValue, PCH, CK);
                    this.drpFree1.DataSource = dsFree1;
                    this.drpFree1.DataTextField = "vfree1";
                    this.drpFree1.ToolTip = "自由项1";
                    this.drpFree1.DataValueField = "vfree1";
                    this.drpFree1.DataBind();

                    DataSet dsFree2 = QTCKQuery.GetFree2BySX(this.drpSX.SelectedValue, PCH, CK);
                    this.drpFree2.DataSource = dsFree2;
                    this.drpFree2.DataTextField = "vfree2";
                    this.drpFree2.ToolTip = "自由项2";
                    this.drpFree2.DataValueField = "vfree2";
                    this.drpFree2.DataBind();

                    DataSet dsFree3 = QTCKQuery.GetFree3BySX(this.drpSX.SelectedValue, PCH, CK);
                    this.drpFree3.DataSource = dsFree3;
                    this.drpFree3.DataTextField = "vfree3";
                    this.drpFree3.ToolTip = "自由项3";
                    this.drpFree3.DataValueField = "vfree3";
                    this.drpFree3.DataBind();


                    this.txtWLH.Text = ds.Tables[0].Rows[0]["WLH"].ToString();
                    this.txtWLMC.Text = ds.Tables[0].Rows[0]["WLMC"].ToString();
                    this.txtPH.Text = ds.Tables[0].Rows[0]["PH"].ToString();
                    this.txtGG.Text = ds.Tables[0].Rows[0]["GG"].ToString();
                }
                else
                {
                    this.drpSX.Items.Clear();
                    this.drpFree1.Items.Clear();
                    this.drpFree2.Items.Clear();
                    this.drpFree3.Items.Clear();

                    this.txtWLH.Text = "";
                    this.txtWLMC.Text = "";
                    this.txtPH.Text = "";
                    this.txtGG.Text = "";
                    this.txtJHSL.Text = "";
                    this.txtJHZL.Text = "";
                }
            }
        }
        catch(Exception ex)
        {
            this.PrintfError(ex.Message);
            return;
        }
    }
}
   