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
using System.Collections.Generic;
/// <summary>
/// 柴艳亮
/// </summary>
public partial class SiteBll_FormMan_QXTZH :AccPageBase

{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.imgDelete.Attributes.Add("onClikc", "if(!confirm('是否要进行删除操作！') return false;");
        }

    }
    private string GetSqlStr()
    {
        string SqlStr = "";
        if(!string.IsNullOrEmpty(txtDanJu.Text.Trim().ToString()))
        {
            SqlStr+=" AND zhdh='"+txtDanJu.Text.Trim().ToString()+"'";
        }
        if(!string.IsNullOrEmpty(txtPiCiHao.Text.Trim().ToString()))
        {
            SqlStr+=" AND pch='"+txtPiCiHao.Text.Trim().ToString()+"'";
        }
        return SqlStr;
    }
    //绑定上面的gridview
    private void BindXTZHWL()
    {
        try
        {
            string sql = GetSqlStr();
            DataSet ds = XTZHQuery.GetXTZH(sql, "", PageControl1.GetPageSize(), PageControl1.GetCurrPage());
            this.grvXTZHWL.DataSource = ds;
            this.grvXTZHWL.DataBind();
            this.hidURL.Value = "";
        }
        catch
        {
            this.PrintfError("数据错误！");
            return;
        }
    }
    private void SelectPageSizeChange()
    {
        try
        {
            SetPageCountView();
            BindXTZHWL();
            return;
        }
        catch
        {
            this.PrintfError("数据访问失败!");
            return;
        }
    }
    protected override void OnPreInit(EventArgs e)
    {
        this.PageControl1.BindPageGrid = new UserControl_PageControl.DeleBindGridView(BindXTZHWL);
        this.PageControl1.PageSizeChange = new UserControl_PageControl.PageChangeDel(SelectPageSizeChange);
        //this.SetDisplayList1.SetDisplayList = new UserControl_SetDisplayList.SetGridDisplay(BindGridView);
    }
    //设置分页控件显示
    private void SetPageCountView()
    {
        try
        {
            string sql = GetSqlStr();
            int outCount;
            int pageCount = XTZHQuery.GetPageCount(sql, PageControl1.GetPageSize(), out outCount);
            PageControl1.SetInitView(pageCount, outCount);
        }
        catch
        {
            this.PrintfError("数据访问错误，请重试！");
            return;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SetPageCountView();
        BindXTZHWL();
        //BindXTCopywl();
        
    }
    protected void imgBtnChange_Click(object sender, ImageClickEventArgs e)
    {
        bool isChoose = false;
        bool ischoosed = false;
        int i = -2;
        string strStatus = "";
        string isAll = "";
        string strSX = "";
        string strZYDH = "";
        string strCK = "";
        string strckzkdh = "";
        foreach (GridViewRow row in this.grvXTZHWL.Rows)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)row.FindControl("chkRow");
            if (chk.Checked)
            {
                ischoosed = true;
                strckzkdh = row.Cells[1].Text.Trim();
                isAll = row.Cells[13].Text.Trim();
                break;

            }
        }
        if (!ischoosed)
        {
            this.PrintfError("请选择！");
            return;
        }
        if (isAll != "Y")
        {
            PrintfError("该单据不是整批转换");
            return;
        }
        int vv = XTZHQuery.Check_Zpzh(strckzkdh);
        switch (vv)
        {
            case 1:
                this.PrintfError("属于当前批次的所有转换单数量与库存数量不符！");
                return;
            //case 2:
            //    this.PrintfError("转换");
            //    break;
        }
        foreach (GridViewRow row in this.grvXTZHWL.Rows)
        {
            HtmlInputCheckBox chk = (HtmlInputCheckBox)row.FindControl("chkRow");
            
            
            if (chk.Checked)
            {
                isChoose = true;
                strStatus = row.Cells[15].Text.Trim();
                isAll = row.Cells[13].Text.Trim();
                strSX = row.Cells[8].Text.Trim();
                strZYDH=row.Cells[1].Text.Trim();
                strCK = row.Cells[2].Text.Trim();
                if (strStatus == "2")
                {
                    this.PrintfError("该单据已经被转换，不能再次被转换");
                    return;
                }
                if (isAll!= "Y")
                {
                    PrintfError("该单据不是整批转换");
                    return;
                }
                int operatFlag = 0;
                if (strSX == "DP")
                {
                    operatFlag = 1;
                }
                else
                {
                    operatFlag = 0;
                }
                try
                {
                    i = XTZHQuery.Exec_Xtzk(strZYDH, this.CUSER.UserID, operatFlag.ToString());
                }
                catch (Exception ex)
                {
                    this.PrintfError(ex.Message);
                    return;
                }
                
                switch (i)
                {
                    case -1:
                        this.PrintfError("执行过程发生异常错误");
                        return;
                    case 0:
                        XTZHQuery xtzh = new XTZHQuery();
                        xtzh.Insert_Xtzk(strZYDH, this.CUSER.UserID, strCK);
                        BindXTZHWL();
                        this.PrintfError("形态转换成功");
                        break;
                    case 1:
                        PrintfError("当前单据不是整批转换单");
                        return;
                    case 2:
                        PrintfError("当前单据已经被转换，不能重复转换");
                        return;
                    case 3:
                        PrintfError("应转数量不等于该批次库存数量，整批转换单需要对该批所有单卷进行转换");
                        return;
                    case 4:
                        PrintfError("转换单中每种属性的计划数量不满足转换条件");
                        return;
                    case 5:
                        PrintfError("转换单中每种属性的计划数量不满足转换条件");
                        return;
                    case 6:
                        PrintfError("该批次原物料号不唯一，不能进行整批转换");
                        return;
                    case 7:
                        PrintfError("转换后物料号不唯一，不能进行整批转换");
                        return;
                    case 8:
                        PrintfError("整批形态转换要求转换后该批次的拥有相同属性值");
                        return;
                }
            }
            //if (i == 0)
            //{

            //    XTZHQuery xtzh = new XTZHQuery();
            //    xtzh.Insert_Xtzk(strZYDH, this.CUSER.UserID, strCK);
            //    BindXTZHWL();
            //    this.PrintfError("形态转换成功");
            //    //break;
            //}
        }
        foreach (GridViewRow row in this.grvXTZHWL.Rows)
        {
            strStatus = row.Cells[15].Text.Trim();
            isAll = row.Cells[13].Text.Trim();
            strSX = row.Cells[8].Text.Trim();
            strZYDH = row.Cells[1].Text.Trim();
            strCK = row.Cells[2].Text.Trim();
            if (i == 0)
            {

                XTZHQuery xtzh1 = new XTZHQuery();
                xtzh1.Insert_Xtzk(strZYDH, this.CUSER.UserID, strCK);
                BindXTZHWL();
                //this.PrintfError("形态转换成功");
                //break;
            }
        }
        if (i == 0)
        {
            this.PrintfError("形态转换成功");
        }
        if (isChoose == false)
        {
            this.PrintfError("没有可选择的记录！");
            return;
        }
    }

    protected void imgDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!this.CUSER.USERFUNCTION.exe_delxtzhd)
            {
                this.PrintfError("对不起您没有删除单据的权利！");
                return;
            }
            bool isChoose = false;
            foreach (GridViewRow row in this.grvXTZHWL.Rows)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)row.FindControl("chkRow");
                if (chk.Checked)
                {
                    isChoose = true;
                    string strStatus = row.Cells[15].Text.Trim();
                    string isAll = row.Cells[13].Text.Trim();
                    string strSX = row.Cells[8].Text.Trim();
                    string strZYDH = row.Cells[1].Text.Trim();
                    DataSet ds = XTZHQuery.GetList(strZYDH);
                    if (ds != null)
                    {
                        string status = ds.Tables[0].Rows[0][0].ToString();
                        if (status != "0")
                        {
                            this.PrintfError("该单据状态不能删除!");
                            return;
                        }
                        int result = XTZHQuery.DeleteXTZH(strZYDH);
                        if (result != -1)
                        {
                            this.PrintfError("删除成功！");
                            BindXTZHWL();
                            return;
                        }
                        this.PrintfError("数据访问错误！");
                        return;
                    }
                }
            }
            if (isChoose == false)
            {
                this.PrintfError("没有要删除的记录！");
                return;
            }
        }
        catch
        {
            this.PrintfError("数据访问错误!");
            return;
        }
    }
}
