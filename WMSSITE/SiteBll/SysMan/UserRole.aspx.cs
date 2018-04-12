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

public partial class SiteBll_SysMan_UserRole : AccPageBase
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDrop();
            BindGridView();
            ckBindDrop();
            BindRoles();
            bindSCX();
            binddoor();
            bindqzs();
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
               
                this.DropDownList1.Items.Insert(0, "--全部仓库--");

        }
        catch
        {
            this.PrintfError("数据错");
            return;
        }
    }
    private void ckBindDrop()
    {
        DataSet ds = Store.GetList();
        if (ds != null)
        {
            this.ckdropdown.DataSource = ds;
            this.ckdropdown.DataTextField = "CKCKName";
            this.ckdropdown.DataValueField = "CKID";
            this.ckdropdown.DataBind();
            this.ckdropdown.Items.Insert(0, "--请选择--");

        }

    }

    private void BindGridView()
    {
        string ckid = DropDownList1.SelectedValue.ToString();
        if (ckid.ToString() == "--全部仓库--")
        {
            ckid = "";
            DataSet ds = ACCTRUE.WMSBLL.Model.User.GetList(ckid);
            if (ds != null)
            {
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }
        else
        {

            DataSet ds = ACCTRUE.WMSBLL.Model.User.GetList(ckid);
            if (ds != null)
            {
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }
    }
    private void BindRoles()
    {
        try
        {
            List<SysRole> roleList = SysRole.GetRoleList();
            if (roleList != null)
            {
                this.drpRole.DataSource = roleList;
                this.drpRole.DataBind();
                this.drpRole.Items.Insert(0, "--请选择--");
            }
        }
        catch
        {
            this.PrintfError("数据错");
            return;

        }
    }
    private void bindSCX()
    {
        DataSet ds = SCX.GetList("");
            if (ds != null)
            {
                this.ScxDropdown.DataSource = ds;
                this.ScxDropdown.DataBind();
                this.ScxDropdown.Items.Insert(0, "--请选择--"); 
            }
    
    }
    private void binddoor()
    {
        DataSet ds = Door.getdoorlist();
        if (ds != null)
        {
            this.drpdoor.DataSource = ds;
            this.drpdoor.DataBind();
            this.drpdoor.Items.Insert(0, "--请选择--");
        }
    }
    private void bindqzs()
    {
        DataSet ds = QZS.getqzslist();
        if (ds != null)
        {
            this.drpqzs.DataSource = ds;
            this.drpqzs.DataBind();
            this.drpqzs.Items.Insert(0, "--请选择--");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        string ckid = DropDownList1.SelectedValue.ToString();
        if (ckid.ToString() == "--全部仓库--")
        {
            ckid = "";
            DataSet ds = ACCTRUE.WMSBLL.Model.User.GetList(ckid);  
            if (ds != null)
            {
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
            }
        }
        else
        {
            DataSet ds = ACCTRUE.WMSBLL.Model.User.GetList(ckid);
            if (ds != null)
            {
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
            //鼠标经过时，行背景色变 
            //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            //鼠标移出时，行背景色变 
            //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'"); 

            ImageButton imgBtn = (ImageButton)e.Row.FindControl("imgBtnModify");
            imgBtn.Attributes.Add("onclick", "if(!confirm('您确定要进行修改吗？')) return false");
            string UserID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserID").ToString());
            string UserName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserName").ToString());
            string RFSCX = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RFSCX").ToString());
            string UserDuty = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserDuty").ToString());
            string UserRole = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserRole").ToString());
            string CK = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CK").ToString());
            string UserPass = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserPass").ToString());
            string userDept=Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserDept").ToString());

            string doorno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "doorno").ToString());
            string qzs_no = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "qzs_no").ToString());

            imgBtn.CommandArgument = UserID + "," + UserName + "," + RFSCX + "," + UserDuty + "," + 
                UserRole + "," + CK + "," + UserPass + "," + userDept+","+doorno+","+qzs_no;

            ImageButton imgDel = (ImageButton)e.Row.FindControl("imgBtnDelete");
            imgDel.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            imgDel.CommandArgument = UserID;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
            string ckInof = (string)e.CommandArgument;
            if (e.CommandName == "imgBtnModify")
            {
                
                string[] ckInfors = ckInof.Split(',');
                this.imgBtnSumbit.ImageUrl = "../../images/icon/img20.gif";
                this.UserID.Text = ckInfors[0];
                this.UserName.Text = ckInfors[1];
                if (string.IsNullOrEmpty(ckInfors[7].ToString()))
                {
                    this.ScxDropdown.SelectedIndex = 0;
                }
                else
                {
                    this.ScxDropdown.SelectedValue = ckInfors[7];
                }

                if (string.IsNullOrEmpty(ckInfors[8].ToString()))
                {
                    this.drpdoor.SelectedIndex = 0;
                }
                else
                {
                    this.drpdoor.SelectedValue = ckInfors[8];
                }


                if (string.IsNullOrEmpty(ckInfors[9].ToString()))
                {
                    this.drpqzs.SelectedIndex = 0;
                }
                else
                {
                    this.drpqzs.SelectedValue = ckInfors[9];
                }


                this.UserDuty.Text = ckInfors[3];
                if (ckInfors[4] == null || string.IsNullOrEmpty(ckInfors[4]))
                {
                    this.drpRole.SelectedIndex =0;
                }
                else
                {
                    this.drpRole.SelectedValue = ckInfors[4];
                }
                //this.drpRole.SelectedValue= ckInfors[4];
                ckBindDrop();
                if (ckInfors[5] == null || string.IsNullOrEmpty(ckInfors[5]))
                {
                    this.ckdropdown.SelectedIndex = 0;
                }
                else
                {
                    this.ckdropdown.SelectedValue = ckInfors[5];
                }
                //this.ckdropdown.SelectedValue= ckInfors[5];
                this.UserPass.Text=ckInfors[6].ToString();
                this.hidPass.Value = this.UserPass.Text;
                this.DropDownList1.Enabled = false;
                this.GridView1.Enabled = false;
            }
            if (e.CommandName == "imgBtnDelete")
            {
                User user = new User();
                user.Delete(e.CommandArgument.ToString());
                BindGridView();
                this.PrintfError("用户权限删除成功");
            }
       
    }
    protected void imgBtnSumbit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //新建
            if (this.imgBtnSumbit.ImageUrl.IndexOf("imgNew1.gif") != -1)
            {
                if (!CheckUI())
                {
                    this.PrintfError("用户信息不全！");
                    return;
                }
                if (this.UserPass.Text.Trim() != this.EditUserPass.Text.Trim())
                {
                    this.PrintfError("两次密码输入的不一样！");
                    return;
                }
                string scxdropv="";
                string scxNCID="";
                if (this.ScxDropdown.SelectedIndex != 0)
                {
                    scxdropv = this.ScxDropdown.SelectedItem.Text.Trim();
                    scxNCID = this.ScxDropdown.SelectedValue.Trim();
                }
                string doorno = "";
                if (this.drpdoor.SelectedIndex!=0)
                {
                    doorno = this.drpdoor.SelectedItem.Value.Trim();
                }
                string qzs_no = "";
                if (this.drpqzs.SelectedIndex!=0)
                {
                    qzs_no = this.drpqzs.SelectedItem.Value.Trim();
                }
                string ckdropv = this.ckdropdown.SelectedIndex.ToString();
                if (ckdropv == "0" || this.ckdropdown.SelectedIndex.ToString() == "0")
                {
                    ckdropv = "";
                }
                else
                {
                    ckdropv = this.ckdropdown.SelectedValue.ToString();
                }
                string Roledropv = this.drpRole.SelectedValue.ToString();
                if (Roledropv == "0" || this.drpRole.SelectedIndex.ToString() == "0")
                {
                    Roledropv = "";
                }
                else
                {
                    Roledropv = this.drpRole.SelectedValue.ToString();
                }
                User user=new User(this.UserID.Text.Trim(), ckdropv, this.UserName.Text.Trim(),scxNCID, this.UserDuty.Text.Trim(), Roledropv, this.UserPass.Text.Trim(), scxdropv,doorno,qzs_no);
                if (user.Exists())
                {
                    this.PrintfError("已经存在该用户信息！");
                    return;
                }
                user.Add();
                ClearUI();
                BindGridView();
                this.PrintfError("用户权限添加成功");
                this.DropDownList1.Enabled = true;
                this.GridView1.Enabled = true;
            }
            else//修改
            {
                if (!CheckMUI())
                {
                    this.PrintfError("用户信息不全！");
                    return;
                }
                string scxdropv="";
                string scxNCID="";
                if (this.ScxDropdown.SelectedIndex!=0)
                {
                    scxdropv = this.ScxDropdown.SelectedItem.Text.Trim();
                    scxNCID = this.ScxDropdown.SelectedValue.Trim();
                }
                string doorno = "";
                if (this.drpdoor.SelectedIndex != 0)
                {
                    doorno = this.drpdoor.SelectedItem.Value.Trim();
                }
                string qzs_no = "";
                if (this.drpqzs.SelectedIndex != 0)
                {
                    qzs_no = this.drpqzs.SelectedItem.Value.Trim();
                }
                string ckdropv = this.ckdropdown.SelectedIndex.ToString();
                if (ckdropv == "0" || this.ckdropdown.SelectedIndex.ToString() == "0")
                {
                    ckdropv = "";
                }
                else
                {
                    ckdropv = this.ckdropdown.SelectedValue.ToString();
                }
                string Roledropv = this.drpRole.SelectedValue.ToString();
                if (Roledropv == "0" || this.drpRole.SelectedIndex.ToString() == "0")
                {
                    Roledropv = "";
                }
                else
                {
                    Roledropv = this.drpRole.SelectedValue.ToString();
                }
                string strPass = "";
                if (!string.IsNullOrEmpty(this.UserPass.Text))
                {
                    if (this.UserPass.Text.Trim() != this.EditUserPass.Text.Trim())
                    {
                        this.PrintfError("两次密码输入的不一样！");
                        return;
                    }
                    strPass = this.UserPass.Text;
                }
                else
                    strPass = this.hidPass.Value;
                User user = new User(this.UserID.Text.Trim(), ckdropv, this.UserName.Text.Trim(),scxNCID,this.UserDuty.Text.Trim(), Roledropv, strPass, scxdropv,doorno,qzs_no);
                user.Update();
                ClearUI();
                BindGridView();
                this.PrintfError("用户权限修改成功");
                this.DropDownList1.Enabled = true;
                this.GridView1.Enabled = true;
            }
        }
        catch
        {
            this.PrintfError("数据库错误，请重试！");
            return;
        }

    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearUI();

    }
    private bool CheckUI()
    {
        if (string.IsNullOrEmpty(this.UserID.Text.Trim()) || string.IsNullOrEmpty(this.UserName.Text.Trim())||string.IsNullOrEmpty(this.UserPass.Text.Trim()))
            return false;
        return true;
    }

    private bool CheckMUI()
    {
        if (string.IsNullOrEmpty(this.UserID.Text.Trim()) || string.IsNullOrEmpty(this.UserName.Text.Trim()))
            return false;
        return true;
    }
    //重置界面
    private void ClearUI()
    {
        this.UserID.Text ="";
        this.UserName.Text = "";
        this.UserDuty.Text = "";
        this.UserPass.Text = "";
        this.hidPass.Value = "";
        this.EditUserPass.Text = "";
        this.ckdropdown.SelectedIndex = 0;
        this.drpRole.SelectedIndex = 0;
        this.ScxDropdown.SelectedIndex = 0;
        this.ScxDropdown.SelectedItem.Text = "--请选择--";
        this.drpdoor.SelectedIndex = 0;
        this.drpdoor.SelectedItem.Text = "--请选择--";
        this.drpqzs.SelectedIndex = 0;
        this.drpqzs.SelectedItem.Text = "--请选择--";

        this.imgBtnSumbit.ImageUrl = "../../images/icon/imgNew1.gif";
        this.DropDownList1.Enabled = true;
        this.GridView1.Enabled = true;
    }
}
