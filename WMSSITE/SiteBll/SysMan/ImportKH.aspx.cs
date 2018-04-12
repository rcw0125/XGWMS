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

public partial class SiteBll_SysMan_ImportKH : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDiv();
            BindCKD();
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
            }
            this.ckdropdown.Items.Insert(0, new ListItem("--全部仓库--", ""));
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
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string ckid = this.ckdropdown.SelectedValue.ToString();
        if (ckid.ToString() == null || ckid.ToString() == "")
        {
            this.PrintfError("请选则仓库！");
            return;
        }
        if (Rrfsdrop.SelectedValue.ToString() == "单个录入")
        {
            if (HWrow1.Text.Trim().ToString() == "" || HWrow1.Text.Trim().ToString() == null)
            {
               
                this.PrintfError("请输入货位行号！");
                return;
            }
            if (HWcolumn1.Text.Trim().ToString() == "" || HWcolumn1.Text.Trim().ToString() == null)
            {
                this.PrintfError("请输入货位列号！");
                return;
            }
        string url;
        url = "../../PrintCode.aspx?STORE="+ckid+"&SROW="+HWrow1.Text.Trim().ToString()+"&TROW=0&SCOL="+HWcolumn1.Text.Trim().ToString()+"&TCOL=0";
        //Response.Write(url);
        Response.Redirect(url);
        }
        if (Rrfsdrop.SelectedValue.ToString() == "成批录入")
        {
            if (HWminrow.Text.Trim().ToString() == "" || HWminrow.Text.Trim().ToString() == null)
            {
               
                this.PrintfError("请输入最小行号");
                return;
            }
            if (HWmaxrow.Text.Trim().ToString() == "" || HWmaxrow.Text.Trim().ToString() == null)
            {
               
                this.PrintfError("请输入最大行号");
                return;
            }
            if (HWmincolumn.Text.Trim().ToString() == "" || HWmincolumn.Text.Trim().ToString() == null)
            {
               
                this.PrintfError("请输入最小列号");
                return;
            }
            if (HWmaxcolumn.Text.Trim().ToString() == "" || HWmaxcolumn.Text.Trim().ToString() == null)
            {
               
                this.PrintfError("请输入最大列号");
                return;
            }
            if (HWminrow.Text.Length > 2 || !IsNumberic(HWminrow.Text.Trim().ToString()) || HWmaxrow.Text.Length > 2 || !IsNumberic(HWmaxrow.Text.Trim()) || HWmaxcolumn.Text.Length > 2 || !IsNumberic(HWmaxcolumn.Text.Trim()) || HWmincolumn.Text.Length > 2 || !IsNumberic(HWmincolumn.Text.Trim()))
            {
               
                this.PrintfError("请正确输入行号列号！");
                return;
            }
            if (Convert.ToInt16(HWmaxcolumn.Text.Trim().ToString()) <= Convert.ToInt16(HWmincolumn.Text.Trim()))
            {
               
                this.PrintfError("最大列号<最小列号！");
                return;
            }
            if (Convert.ToInt16(HWmaxrow.Text.Trim().ToString()) <= Convert.ToInt16(HWminrow.Text.Trim().ToString()))
            {
               
                this.PrintfError("最大行号<最小行号！");
                return;
            }
            string url;
            url = "../../PrintCode.aspx?STORE=" + ckid + "&SROW=" + HWminrow.Text.Trim().ToString() + "&TROW=" + HWmaxrow.Text.Trim().ToString() + "&SCOL=" + HWmincolumn.Text.Trim().ToString() + "&TCOL=" + HWmaxcolumn.Text.Trim().ToString() + "";
            //Response.Write(url);
            Response.Redirect(url);

        }

        
    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        ckdropdown.SelectedIndex = 0;
        Rrfsdrop.SelectedValue = "单个录入";
        this.dgfangshi.Visible = true;
        this.cpfangshi.Visible = false;
        HWrow1.Text = "";
        HWcolumn1.Text = "";
    }
}
