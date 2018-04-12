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

public partial class SiteBll_SysMan_RoleSet :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoles();
        }
    }

    private void BindRoles()
    {
        try
        {
            List<SysRole> roleList = SysRole.GetRoleList();
            if (roleList != null && roleList.Count > 0)
            {
                this.grvRole.DataSource = roleList;
                this.grvRole.DataBind();
            }
        }
        catch
        {
            this.PrintfError("数据访问失败!");
            return;
        }
    }
    protected void btnSumbit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            bool isSucc = true;
            //新建
            if (this.btnSumbit.ImageUrl.IndexOf("imgNew1.gif") != -1)
            {
                isSucc=RoleEditControl1.AddNewRole();
                
                RoleEditControl1.ClearUI();
            }
            else//修改
            {
                isSucc = RoleEditControl1.UpdateRole();
                RoleEditControl1.ClearUI();
                this.btnSumbit.ImageUrl = "../../images/icon/imgNew1.gif";
            }
            if (isSucc == false)
                this.HidNewRole.Value = "block";
            else
                this.HidNewRole.Value = "none";
            BindRoles();
        }
        catch
        {
            this.PrintfError("数据访问失败！");
            return;
        }
    }
    protected void grvRole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgBtnMod = (ImageButton)e.Row.FindControl("imgBtnMod");
            string roleName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoleName").ToString());
            imgBtnMod.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            imgBtnMod.CommandArgument = roleName.Trim();

            ImageButton imgBtnDel = (ImageButton)e.Row.FindControl("imgBtnDel");
            imgBtnDel.Attributes.Add("onclick", "if(!confirm('您确定要进行此操作？')) return false");
            imgBtnDel.CommandArgument = roleName.Trim();
        }
    }
    protected void grvRole_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string roleName = (string)e.CommandArgument;
            if (e.CommandName == "imgBtnMod")
            {
                //修改
                this.btnSumbit.ImageUrl = "../../images/icon/img20.gif";
                SysRole oRole = SysRole.GetRole(roleName);
                RoleEditControl1.SetModifyUI(oRole);
                this.HidNewRole.Value = "block";
            }
            if (e.CommandName == "imgBtnDel")
            {
                SysRole role = new SysRole();
                role.RoleName = roleName;
                role.Delete();
                this.HidNewRole.Value = "none";
                BindRoles();
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
        RoleEditControl1.ClearUI();
        this.btnSumbit.ImageUrl = "../../images/icon/imgNew1.gif";
    }
    protected void grvRole_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
