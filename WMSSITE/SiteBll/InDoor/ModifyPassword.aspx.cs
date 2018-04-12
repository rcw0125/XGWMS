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
public partial class SiteBll_InDoor_ModifyPassword : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtICID.Focus();            
        }
    }
    protected void btnOK_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.txtICID.Text) && string.IsNullOrEmpty(this.txtICNumber.Text))
            {
                this.PrintfError("请输入IC卡ID或IC卡号！");
                this.txtICID.Focus();
                return;
            }
            else
            {
                InDoorParam indoor = new InDoorParam();
                bool hasIC = indoor.hasIC(this.txtICID.Text.Trim(), this.txtICNumber.Text.Trim());
                if (hasIC == false)
                {
                    this.PrintfError("没有该卡号!");
                    this.txtICID.Focus();
                    return;
                }
                else
                {
                    if (this.txtNewPassword1.Text.Trim() != this.txtNewPassword2.Text.Trim())
                    {
                        this.PrintfError("两次输入的新密码不一致！");
                        this.txtICID.Focus();
                        return;
                    }
                    else
                    {
                        bool passwordvalidate = indoor.PasswordValidate(this.txtICID.Text.Trim(), this.txtICNumber.Text.Trim(), this.txtOldPassword.Text.Trim());
                        if (passwordvalidate == false)
                        {
                            this.PrintfError("原密码错误！");
                            this.txtICID.Focus();
                            return;
                        }
                        else
                        {
                            indoor.ModifyPassword(this.txtICID.Text.Trim(), this.txtICNumber.Text.Trim(), this.txtNewPassword1.Text.Trim());
                            this.WriteClientJava("window.alert('密码修改成功！');window.close();");
                        }
                    }
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
}
