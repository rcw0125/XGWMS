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
using ACCTRUE.WMSBLL;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["UN"]!=null)
            {
                string username = Request["UN"];
                RegeiteCardSystem(username);
            }
            this.txtUserName.Focus();
            string strHisSite = ConfigurationManager.AppSettings["HistorySite"];
            this.imgHistory.Attributes.Add("onClick", "OpenHistory()");
        }
    }
    protected void btnGO_Click(object sender, ImageClickEventArgs e)
    {
        tryLogin(this.txtUserName.Text, this.txtPassword.Text);
    }

    private void tryLogin(string UserName, string password)
    {
       // if (this.chkHistory.Checked)
       // {
         //   Common.IsOldData = true;
        //}
       // else
            Common.IsOldData = false;
        try
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                this.lblMessage.Text = "用户名密码不能为空！";
                this.lblMessage.Visible = true;
                return;
            }
            ACCTRUE.WMSBLL.Model.User user = ACCTRUE.WMSBLL.Model.User.GetUser(UserName);
            if (user == null)
            {
                this.lblMessage.Text = "不存在该用户,请重新输入！";
                this.lblMessage.Visible = true;
                this.txtUserName.Text = "";
                this.txtPassword.Text = "";
                this.txtUserName.Focus();
                return;
            }
            if (user.UserPass != password)
            {
                this.lblMessage.Text = "密码错误！";
                this.lblMessage.Visible = true;
                this.txtPassword.Focus();
                return;
            }
            //if (Application["ATLINEUSERS"] != null)
            //{
            //    Hashtable hs = (Hashtable)Application["ATLINEUSERS"];
            //    if (hs.Contains(user.UserID))
            //    {
            //        this.lblMessage.Text = "该用户已经登录系统！";
            //        this.lblMessage.Visible = true;
            //        return;
            //    }
            //}
            //if (Application["ATLINEUSERS"] != null)
            //{
            //    Hashtable hs = (Hashtable)Application["ATLINEUSERS"];
            //    hs.Add(user.UserID, Session.SessionID);
            //} 
            user.USERFUNCTION = Function.GetFunction(user.UserRole);
            user.WEIGTHQCFUNCTION = WeightQCFunction.GetWeightFunction(user.UserID);
            //是否有登录历史库的权限
            if (Common.IsOldData)
            {
                if (user.USERFUNCTION.Login_History == false)
                {
                    this.lblMessage.Text = "对不起您没有登录历史库的权限！";
                    this.lblMessage.Visible = true;
                    return;
                }
            }
            Session[Config.Curren_User] = user;
            Config.Curuserid = UserName;
            FormsAuthenticationTicket authTicket =
                    new FormsAuthenticationTicket(1, UserName, DateTime.Now, DateTime.Now.AddMinutes(60), false,"");
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            Page.RegisterStartupScript("StartUp", "<script language='javascript'>login();</script>");
        }
        catch
        {
            this.lblMessage.Text = "数据库连接错误，请重试！";
            this.lblMessage.Visible = true;
            return;
        }
    }

    private void RegeiteCardSystem(string username)
    {
        ACCTRUE.WMSBLL.Model.User user = ACCTRUE.WMSBLL.Model.User.GetUser(username);
        if (user == null)
        {
            return;
        }
        user.USERFUNCTION = Function.GetFunction(user.UserRole);
        user.WEIGTHQCFUNCTION = WeightQCFunction.GetWeightFunction(user.UserID);
        //是否有登录历史库的权限
        if (Common.IsOldData)
        {
            if (user.USERFUNCTION.Login_History == false)
            {
                this.lblMessage.Text = "对不起您没有登录历史库的权限！";
                this.lblMessage.Visible = true;
                return;
            }
        }
        Session[Config.Curren_User] = user;
        FormsAuthenticationTicket authTicket =
                new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(60), false, "");
        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        Response.Cookies.Add(authCookie);
        Response.Redirect("Default.aspx");
    }
}
