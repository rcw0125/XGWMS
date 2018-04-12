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

public partial class SiteBll_SysMan_StoreSet : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }
    private void BindGridView()
    {
        DataSet ds = Store.GetList("");
        if (ds != null)
        {
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }
    }

    private bool CheckUI()
    {
        if (string.IsNullOrEmpty(this.txtCKID.Text.Trim()) || string.IsNullOrEmpty(this.txtCKName.Text.Trim()) || string.IsNullOrEmpty(this.txtNCID.Text))
            return false;
        return true;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgBtn = (ImageButton)e.Row.FindControl("imgBtnModify");
            string ckID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CKID").ToString());
            string ncCKID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CKNCID").ToString());
            string ckName=Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CKName").ToString());
            imgBtn.CommandArgument = ckID + "," + ncCKID + "," + ckName;

            ImageButton imgDel = (ImageButton)e.Row.FindControl("imgBtnDelete");
            imgDel.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            imgDel.CommandArgument = ckID + "," + ncCKID;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string ckInof = (string)e.CommandArgument;
            if (e.CommandName == "imgBtnModify")
            {
                string[] ckInfors = ckInof.Split(',');
                this.imgBtnSumbit.ImageUrl = "../../images/icon/img20.gif";
                this.txtCKID.Text = ckInfors[0];
                this.txtNCID.Text = ckInfors[1];
                this.txtCKName.Text = ckInfors[2];
                this.txtCKID.Enabled = false;
                this.txtNCID.Enabled = false;
            }
            if (e.CommandName == "imgBtnDelete")
            {
                string[] ckInfors = ckInof.Split(',');
                Store store = new Store(ckInfors[1], ckInfors[0], "");
                store.Delete();
                BindGridView();
            }
        }
        catch
        {
            this.PrintfError("数据访问失败，请重试！");
            return;
        }
    }

    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearUI();
    }
    protected void imgBtnSumbit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //新建
            if (this.imgBtnSumbit.ImageUrl.IndexOf("imgNew1.gif") != -1)
            {
                if (txtCKID.Text.Trim().ToString().Length > 3)
                {
                    this.PrintfError("仓库编码超出了范围，只能是3位！");
                    return;
                }
                if (!CheckUI())
                {
                    this.PrintfError("仓库信息不全！");
                    return;
                }
                Store stroe = new Store(this.txtNCID.Text.Trim(), this.txtCKID.Text.Trim(), this.txtCKName.Text.Trim());
                if (stroe.Exists())
                {
                    this.PrintfError("已经存在该仓库信息！");
                    return;
                }
                stroe.Add();
                ClearUI();
                BindGridView();
            }
            else//修改
            {
                if (!CheckUI())
                {
                    this.PrintfError("仓库信息不全！");
                    return;
                }
                Store stroe = new Store(this.txtNCID.Text.Trim(), this.txtCKID.Text.Trim(), this.txtCKName.Text.Trim());
                stroe.Update();
                ClearUI();
                BindGridView();
            }
        }
        catch
        {
            this.PrintfError("数据库错误，请重试！");
            return;
        }
    }
    //重置界面
    private void ClearUI()
    {
        this.txtCKID.Text = "";
        this.txtNCID.Text = "";
        this.txtCKName.Text = "";
        this.txtCKID.Enabled = true;
        this.txtNCID.Enabled = true;
        this.imgBtnSumbit.ImageUrl = "../../images/icon/imgNew1.gif";
    }
}
