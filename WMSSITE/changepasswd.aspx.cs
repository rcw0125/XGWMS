using System;
using System.Drawing;
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
using ACCTRUE.WMSBLL;

public partial class changepasswd : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[Config.Curren_User] != null)
            {
                ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
                this.lblName.Text = user.UserName;
            }
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Session[Config.Curren_User] != null)
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            if (user.UserID == "test")
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "修改口令失败：test 用户口令不能被修改！";
                return;
            }
            if (user.UserPass != this.txtOldPass.Text)
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "修改口令失败：数据的旧口令无效！";
                return;
            }

            try
            {
                user.ChangePass(this.txtPassword.Text);
                user.UserPass = this.txtPassword.Text;
                Session[Config.Curren_User] = user;
                this.lblResult.ForeColor = Color.Navy;
                string strJs = "window.alert('口令修改成功！');window.close();";
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                builder.Append("<script language=\"javascript\">");
                builder.Append(strJs);
                builder.Append("</script>");
                this.Page.RegisterStartupScript("mess", builder.ToString());

                //this.WriteClientJava("window.alert('口令修改成功！');window.close();");
            }
            catch
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "修改口令失败:数据访问失败！";
            }
        }

    }
}
