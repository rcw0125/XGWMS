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
using System.Collections.Generic;
public partial class SiteBll_SysMan_HWset : AccPageBase
{
    public string column1;//货位列号
    public string row1;//货位行号
    public string hwid;//货位编码
    public string mincolumn;//货位最小列
    public string minrow;//货位最小行
    public string maxcolumn;//货位最大列
    public string maxrow;//货位最大行
    public int hwcount;//货位个数
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDiv();
            BindDrop();
            BindGridView();
            BindCKD();
            BinddrpDiv();
        }
    }
    private void BindDiv()
    {
        ArrayList al = new ArrayList();
        al.Add("单个录入");
        al.Add("成批录入");
        Rrfsdrop.DataSource = al;
        Rrfsdrop.DataBind();
        this.dgfangshi.Visible = true;
        this.cpfangshi.Visible = false;
    }
    private void BindCKD()
    {
        try
        {
            DataSet ds = Store.GetList("");
            if (ds != null)
            {
                this.ckdropdown.DataSource = ds;
                this.ckdropdown.DataTextField = "CKID";
                this.ckdropdown.DataValueField = "CKID";
                this.ckdropdown.DataBind();
                this.chkPrintDrp.DataSource = ds;
                this.chkPrintDrp.DataTextField = "CKID";
                this.chkPrintDrp.DataValueField = "CKID";
                this.chkPrintDrp.DataBind();
            }
            this.ckdropdown.Items.Insert(0, new ListItem("--全部仓库--", ""));
            this.chkPrintDrp.Items.Insert(0, new ListItem("--全部仓库--", ""));//绑定打印配置仓库
            //this.ckdropdown.Items.Insert(0, "--全部仓库--");
        }
        catch
        {
            this.PrintfError("仓库信息出错");
        }
    }
    protected void Rrfsdrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (Rrfsdrop.SelectedValue)
        {
            case "单个录入":
                this.dgfangshi.Visible = true;
                this.cpfangshi.Visible = false;
                break;
            case "成批录入":
                this.dgfangshi.Visible = false;
                this.cpfangshi.Visible = true;
                break;

        }
    }
    private void BindDrop()
    {
        try
        {

            DataSet ds = Store.GetList();
            ACCTRUE.WMSBLL.Model.User user = null;
            if (Session[Config.Curren_User] != null)
            {
                user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            }
            if (ds != null)
            {
                this.DropDownList1.DataSource = ds;
                this.DropDownList1.DataTextField = "CKCKName";
                this.DropDownList1.ToolTip = "请选择对应仓库";
                this.DropDownList1.DataValueField = "CKID";
                this.DropDownList1.DataBind();
            }
            if (user != null)
            {
                this.DropDownList1.SelectedValue = user.CK.Trim();
            }

            this.DropDownList1.Items.Insert(0, new ListItem("--全部仓库--",""));
           

        }
        catch
        {
            this.PrintfError("数据错");
            return;
        }
    }
    private void BindGridView()
    {
        string ckid = DropDownList1.SelectedValue.ToString();
        if (ckid.ToString()==null||ckid.ToString()=="")
        {
            ckid = "";
            DataSet ds = HWinfo.GetList(ckid);
            if (ds != null)
            {
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }
        else
        {

            DataSet ds = HWinfo.GetList(ckid);
            if (ds != null)
            {
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }
        HWinfo hwinfo = new HWinfo();
        hwcount = hwinfo.GetSumId(ckid);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindGridView();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGridView();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string HWID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HWID").ToString());
            string CK = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CK").ToString());
            ImageButton imgDel = (ImageButton)e.Row.FindControl("imgBtnDelete");
            imgDel.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            imgDel.CommandArgument =HWID+"|"+CK;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string ckInof = (string)e.CommandArgument;

            if (e.CommandName == "imgBtnDelete")
            {
                string[] ckInfors = ckInof.Split('|');
                HWinfo hwinfo = new HWinfo();
                hwinfo.Delete(ckInfors[1], ckInfors[0]);

                BindGridView();
                this.PrintfError("货位删除成功！");
            }
        }
        catch
        {
            this.PrintfError("数据操作有误！");
            return;
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

    protected void imgBtnSumbit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string ckid = this.ckdropdown.SelectedValue.ToString();
            if (ckid.ToString() == null || ckid.ToString() == "")
            {
                BindGridView();
                this.PrintfError("请选则仓库！");
                return;
            }
            if (Rrfsdrop.SelectedValue.ToString() == "单个录入")
            {
                if (HWrow1.Text.Trim().ToString() == "" || HWrow1.Text.Trim().ToString() == null)
                {
                    BindGridView();
                    this.PrintfError("请输入货位行号！(1-99)");
                    return;
                }
                if(HWrow1.Text.Length>2||!IsNumberic(HWrow1.Text.ToString())||HWrow1.Text=="0"||HWrow1.Text=="00")
                {
                    BindGridView();
                    this.PrintfError("请正确输入货位行号！(1-99)");
                    return;
                }

                if (HWcolumn1.Text.Trim().ToString() == "" || HWcolumn1.Text.Trim().ToString() == null)
                {
                    BindGridView();
                    this.PrintfError("请输入货位列号！(1-99)");
                    return;
                }
                if (HWcolumn1.Text.Length > 2 || !IsNumberic(HWcolumn1.Text.ToString())||HWcolumn1.Text=="0"||HWcolumn1.Text=="00")
                {
                    BindGridView();
                    this.PrintfError("请正确输入货位列号！(1-99)");
                    return;
                }
            }
            if (Rrfsdrop.SelectedValue.ToString() == "成批录入")
            {
                if (HWminrow.Text.Trim().ToString() == "" || HWminrow.Text.Trim().ToString() == null)
                {
                    BindGridView();
                    this.PrintfError("请输入最小行号!(1-99)");
                    return;
                }
                if (HWmaxrow.Text.Trim().ToString() == "" || HWmaxrow.Text.Trim().ToString() == null)
                {
                    BindGridView();
                    this.PrintfError("请输入最大行号!(1-99)");
                    return;
                }
                if (HWmincolumn.Text.Trim().ToString() == "" || HWmincolumn.Text.Trim().ToString() == null)
                {
                    BindGridView();
                    this.PrintfError("请输入最小列号!(1-99)");
                    return;
                }
                if (HWmaxcolumn.Text.Trim().ToString() == "" || HWmaxcolumn.Text.Trim().ToString() == null)
                {
                    BindGridView();
                    this.PrintfError("请输入最大列号!(1-99)");
                    return;
                }
                if (HWminrow.Text.Length > 2 || !IsNumberic(HWminrow.Text.Trim().ToString()) || HWmaxrow.Text.Length > 2 || !IsNumberic(HWmaxrow.Text.Trim()) || HWmaxcolumn.Text.Length > 2 || !IsNumberic(HWmaxcolumn.Text.Trim()) || HWmincolumn.Text.Length > 2 || !IsNumberic(HWmincolumn.Text.Trim()))
                {
                    BindGridView();
                    this.PrintfError("请正确输入行号列号！(1-99)");
                    return;
                }
                if (Convert.ToInt16(HWmaxcolumn.Text.Trim().ToString()) < Convert.ToInt16(HWmincolumn.Text.Trim()))
                {
                    BindGridView();
                    this.PrintfError("最大列号<最小列号！(1-99)");
                    return;
                }
                if (Convert.ToInt16(HWmaxrow.Text.Trim().ToString()) < Convert.ToInt16(HWminrow.Text.Trim().ToString()))
                {
                    BindGridView();
                    this.PrintfError("最大行号<最小行号！(1-99)");
                    return;
                }


            }
            //新建单个录入货位
            if (Rrfsdrop.SelectedValue.ToString() == "单个录入")
            {
                if (HWrow1.Text.Trim().ToString().Length == 1)
                {
                    row1 = "0" + HWrow1.Text.Trim().ToString();
                }
                else
                {
                    row1 = HWrow1.Text.Trim().ToString();
                }
                if (HWcolumn1.Text.Trim().ToString().Length == 1)
                {
                    column1 = "0" + HWcolumn1.Text.Trim().ToString();
                }
                else
                {
                    column1 = HWcolumn1.Text.Trim().ToString();
                }
                hwid = ckdropdown.SelectedValue.ToString() + row1.ToString() + column1.ToString();
                HWinfo hwinfo = new HWinfo(ckdropdown.SelectedValue.ToString(), hwid, Convert.ToInt16(column1.ToString()), Convert.ToInt16(row1.ToString()), HWmemo.Text.Trim().ToString());
                if (hwinfo.Exists(hwid))
                {
                    BindGridView();
                    this.PrintfError("该货位编码已存在！");
                    return;

                }
                hwinfo.Add();
                BindGridView();
            }
            //新建成批录入货位
            if (Rrfsdrop.SelectedValue.ToString() == "成批录入")
            {

                for (int i = Convert.ToInt16(HWminrow.Text.Trim().ToString()); i <= Convert.ToInt16(HWmaxrow.Text.Trim().ToString()); i++)
                {
                    for (int j = Convert.ToInt16(HWmincolumn.Text.Trim().ToString()); j <= Convert.ToInt16(HWmaxcolumn.Text.Trim().ToString()); j++)
                    {
                        if (i.ToString().Length == 1)
                        {
                            minrow = "0" + i.ToString();
                        }
                        else
                        {
                            minrow = i.ToString();
                        }
                        if (j.ToString().Length == 1)
                        {
                            mincolumn = "0" + j.ToString();
                        }
                        else
                        {
                            mincolumn = j.ToString();
                        }
                        hwid = ckdropdown.SelectedValue.ToString() + minrow.ToString() + mincolumn.ToString();
                        HWinfo hwinfo = new HWinfo(ckdropdown.SelectedValue.ToString(), hwid, Convert.ToInt16(mincolumn.ToString()), Convert.ToInt16(minrow.ToString()), HWmemo.Text.Trim().ToString());
                        if (hwinfo.Exists(hwid))
                        {
                            continue;
                        }
                        hwinfo.Add();
                    }
                }
                BindGridView();
            }
        }
        catch
        {
            this.PrintfError("数据插入有错，请重试！");
            return;
        }

    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearHW();

    }
    private void ClearHW()
    {
        HWmemo.Text = "";
        ckdropdown.SelectedIndex = 0;
        Rrfsdrop.SelectedValue = "单个录入";
        this.dgfangshi.Visible = true;
        this.cpfangshi.Visible = false;
        HWrow1.Text = "";
        HWcolumn1.Text = "";
        BindGridView();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string ckid = this.chkPrintDrp.SelectedValue.ToString(); 
        if (ckid.ToString() == null || ckid.ToString() == "")
        {
            this.PrintfError("请选则仓库！");
            return;
        }
        if (Drpprint.SelectedValue.ToString() == "单个打印")
        {
            if (txtROW1.Text.Trim().ToString() == "" || txtROW1.Text.Trim().ToString() == null)
            {
                BindGridView();
                this.PrintfError("请输入货位行号！(1-99)");
                return;
            }
            if (txtROW1.Text.Length > 2 || !IsNumberic(txtROW1.Text.ToString()) || txtROW1.Text == "0" || txtROW1.Text == "00")
            {
                BindGridView();
                this.PrintfError("请正确输入货位行号！(1-99)");
                return;
            }
            if (txtCOLUMN1.Text.Trim().ToString() == "" || txtCOLUMN1.Text.Trim().ToString() == null)
            {
                BindGridView();
                this.PrintfError("请输入货位列号！(1-99)");
                return;
            }
            if (txtCOLUMN1.Text.Length > 2 || !IsNumberic(txtCOLUMN1.Text.ToString()) || txtCOLUMN1.Text == "0" || txtCOLUMN1.Text == "00")
            {
                BindGridView();
                this.PrintfError("请正确输入货位列号！(1-99)");
                return;
            }
            BindGridView();
            string url;
            url = "../../PrintCode.aspx?STORE=" + ckid + "&SROW=" + txtROW1.Text.Trim().ToString() + "&TROW=0&SCOL=" + txtCOLUMN1.Text.Trim().ToString() + "&TCOL=0";
            //Response.Write(url);
            Response.Write("<script>window.open('"+url+"');</script>");
        }
        if (Drpprint.SelectedValue.ToString() == "批量打印")
        {
            if (txtminROW.Text.Trim().ToString() == "" || txtminROW.Text.Trim().ToString() == null)
            {
                BindGridView();
                this.PrintfError("请输入最小行号!(1-99)");
                return;
            }
            if (txtmaxROW.Text.Trim().ToString() == "" || txtmaxROW.Text.Trim().ToString() == null)
            {
                BindGridView();
                this.PrintfError("请输入最大行号!(1-99)");
                return;
            }
            if (txtminColumn.Text.Trim().ToString() == "" || txtminColumn.Text.Trim().ToString() == null)
            {
                BindGridView();
                this.PrintfError("请输入最小列号!(1-99)");
                return;
            }
            if (txtmaxColumn.Text.Trim().ToString() == "" || txtmaxColumn.Text.Trim().ToString() == null)
            {
                BindGridView();
                this.PrintfError("请输入最大列号!(1-99)");
                return;
            }
            if (txtminROW.Text.Length > 2 || !IsNumberic(txtminROW.Text.Trim().ToString()) || txtmaxROW.Text.Length > 2 || !IsNumberic(txtmaxROW.Text.Trim()) || txtmaxColumn.Text.Length > 2 || !IsNumberic(txtmaxColumn.Text.Trim()) || txtminColumn.Text.Length > 2 || !IsNumberic(txtminColumn.Text.Trim()))
            {
                BindGridView();
                this.PrintfError("请正确输入行号列号！(1-99)");
                return;
            }
            if (Convert.ToInt16(txtmaxColumn.Text.Trim().ToString()) <= Convert.ToInt16(txtminColumn.Text.Trim()))
            {
                BindGridView();
                this.PrintfError("最大列号<最小列号！(1-99)");
                return;
            }
            if (Convert.ToInt16(txtmaxROW.Text.Trim().ToString()) <= Convert.ToInt16(txtminROW.Text.Trim().ToString()))
            {
                BindGridView();
                this.PrintfError("最大行号<最小行号！(1-99)");
                return;
            }
            BindGridView();
            string url;
            url = "../../PrintCode.aspx?STORE=" + ckid + "&SROW=" + txtminROW.Text.Trim().ToString() + "&TROW=" + txtmaxROW.Text.Trim().ToString() + "&SCOL=" + txtminColumn.Text.Trim().ToString() + "&TCOL=" + txtmaxColumn.Text.Trim().ToString() + "";
            //Response.Write(url);
            Response.Write("<script>window.open('" + url + "');</script>");

        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        dataedit.Visible = true;
        Print1.Visible = false;
        BindGridView();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        dataedit.Visible = false;
        Print1.Visible = true;
        BindGridView();
    }
    
    
    private void BinddrpDiv()
    {
        ArrayList al = new ArrayList();
        al.Add("单个打印");
        al.Add("批量打印");
        Drpprint.DataSource = al;
        Drpprint.DataBind();
        this.Printdiv1.Visible = true;
        this.Printdiv2.Visible = false;
    }
    protected void Drpprint_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (Drpprint.SelectedValue)
        {
            case "单个打印":
                this.Printdiv1.Visible = true;
                this.Printdiv2.Visible = false;
                break;
            case "批量打印":
                this.Printdiv1.Visible = false;
                this.Printdiv2.Visible = true;
                break;

        }
    }
}

