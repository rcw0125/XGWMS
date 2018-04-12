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
using ACCTRUE.WMSBLL.Model;
using ACCTRUE.WMSBLL;

public partial class UserControl_Header : AccCtrBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.Imagebutton1.Attributes.Add("onclick", "if(!confirm('您确定要退出？')) return false");
            initHeader();
        }
    }

    /// <summary>
    /// 按照权限组织页面按钮
    /// </summary>
    /// <param name="partId"></param>
    private void initHeader()
    {
        if (Session[Config.Curren_User] != null)
        {
            User c_User = (User)Session[Config.Curren_User];
            this.lblName.Text+=c_User.UserName;
            if (Common.IsOldData)
            {
                this.lblName.ForeColor = System.Drawing.Color.Red;
                this.lblName.Text += "  您当前登录的为历史库！";
            }
        }
        StringBuilder ss = new StringBuilder();
        ss.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        ss.Append("<tr>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"FirstPage.aspx\" target=\"frm\"  style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">系统首页</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\ICMan\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">IC卡管理</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\InDoor\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">进出门管理</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\CheckQu\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">质量检查</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\PDMan\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">盘点管理</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\FormMan\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">单据管理</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\StockMan\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">库存管理</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\Report\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">统计报表</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\DataOpern\\index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">数据处理</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"SiteBll\\SysMan\\Index.aspx\" target=\"frm\" style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">系统设置</A></b></td>");
        ss.Append("<td vAlign=\"middle\" align=\"center\"><b style=\"FONT-SIZE: 12px; COLOR: #213B52; FONT-FAMILY: 宋体\">┇</b></td>");

        ss.Append("<td vAlign=\"middle\" align=\"center\"><b><A href=\"Help/NewHelp.doc\" target=\"_blank\"  style=\"FONT-SIZE: 12px; FONT-FAMILY: 宋体\">系统帮助</A></b></td>");
        ss.Append("</tr>");
        ss.Append("</table>");
        this.litHeader.Text = ss.ToString();
    }
    protected void Imagebutton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[Config.Curren_User] != null)
        {
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            if (Application["ATLINEUSERS"] != null)
            {
                Hashtable hs = (Hashtable)Application["ATLINEUSERS"];
                if (hs.Contains(user.UserID))
                    hs.Remove(user.UserID);
            }
        }
        FormsAuthentication.SignOut();
        if (Common.IsOldData)
        {
            Response.Redirect("LoginHistory.aspx");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}
