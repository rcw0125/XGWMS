using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// 基础控件
/// author ：张俊刚
/// company：北京爱创
/// creatDate ：2007-10-30
/// </summary>
public class AccCtrBase : System.Web.UI.UserControl
{
    public AccCtrBase()
    {
    }
    /// <summary>
    /// 弹出提示信息
    /// </summary>
    /// <param name="mess"></param>
    public virtual void PrintfError(string mess)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append("<script language=\"javascript\">");
        builder.Append("alert('" + mess + "');");
        builder.Append("</script>");
        this.Page.RegisterStartupScript("mess", builder.ToString());
    }
}
