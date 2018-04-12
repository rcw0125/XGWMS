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

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string errorCode = "";
            errorCode = Request["ErrorCode"];
            if (string.IsNullOrEmpty(errorCode))
            {
                lblMessge.Text = @"登陆超时或没有访问权限，请重新登陆或联系管理员!";
            }
            if (errorCode == "1")
            {
                lblMessge.Text = @"没有获得可用模块，请重新登陆或联系管理员!";
            }
            if(errorCode=="2")
            {
                lblMessge.Text = "当前登录的数据库为历史库，无法使用该功能！";
            }
            if (errorCode == "3")
            {
                lblMessge.Text = "当前登录的数据库为运行库，无法使用该功能！";
            }
            if (errorCode == "4")
            {
                lblMessge.Text = "系统错误，请您重试！";
            }
        }
    }
}
