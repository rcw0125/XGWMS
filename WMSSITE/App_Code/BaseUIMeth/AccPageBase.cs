using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using ACCTRUE.WMSBLL.Model;

/// <summary>
/// 页面可能用到的通用方法
/// author ：张俊刚
/// company：北京爱创
/// creatDate ：2007-10-30
/// </summary>
public class AccPageBase :System.Web.UI.Page
{
    public AccPageBase()
    {
    }
    /// <summary>
    /// 弹出提示窗口
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

    /// <summary>
    /// 写客户端脚本
    /// </summary>
    /// <param name="strJs"></param>
    public virtual void WriteClientJava(string strJs)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append("<script language=\"javascript\">");
        builder.Append(strJs);
        builder.Append("</script>");
        this.Page.RegisterStartupScript("mess", builder.ToString());
    }

    /// <summary>
    /// 通过流方式导出Excel
    /// </summary>
    /// <param name="dt">需要导出的表</param>
    /// <param name="fileName">文件名</param>
    /// <param name="recordCount">记录数</param>
    public void CreateExcel(DataTable dt, string fileName,int recordCount)
    {
        HttpResponse rep;
        rep = Page.Response;
        rep.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        rep.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);

        string colHeader = "";
        string ls_item = "";

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            colHeader += dt.Columns[i].Caption.ToString() + "\t";
        }
        colHeader += "\n";
        rep.Write(colHeader);
        foreach (DataRow myRow in dt.Rows)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string rowMsg = myRow[i].ToString().Replace("\t", "");
                rowMsg.Replace("\n", "");
                ls_item += rowMsg + "\t";
                //			ls_item+=myRow[i].ToString()+"\t";
            }
            ls_item += "\n";
            rep.Write(ls_item);
            ls_item = "";
        }
        rep.Write("\n");
        rep.Write("总计：\t");
        rep.Write(recordCount.ToString());
        rep.End();
    }

    /// <summary>
    /// 拼出要打印的表
    /// </summary>
    /// <param name="dt">要打印的表</param>
    /// <returns></returns>
    public string DGPrint(DataTable myDataTable)
    {
        //*************************************************************//

        int myRow = myDataTable.Rows.Count;
        int myCol = myDataTable.Columns.Count;

        StringBuilder sb = new StringBuilder();

        string colHeaders = "<html><head><LINK href=\"CSS/Input.css\" type=\"text/css\" rel=\"stylesheet\"></head><body>" +
            "<object ID='WebBrowser' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'VIEWASTEXT></object>"
            + "<table class='printTable'><tr>";

        for (int i = 0; i < myCol; i++)
        {
            colHeaders += "<td class='printTableHeader'>" + myDataTable.Columns[i].ColumnName.ToString() + "</td>";
        }
        colHeaders += "</tr>";
        sb.Append(colHeaders);

        for (int i = 0; i < myRow; i++)
        {
            sb.Append("<tr>");
            for (int j = 0; j < myCol; j++)
            {
                sb.Append("<td class='printTable'>");
                sb.Append(myDataTable.Rows[i][j].ToString().Trim());
                sb.Append("</td>");
            }
            sb.Append("</tr>");
        }

        sb.Append("</table></body></html>");
        colHeaders = sb.ToString();
        colHeaders += "<script languge='javascript'>WebBrowser.ExecWB(7,1); window.opener=null;window.close();</script>";
        //WebBrowser.ExecWB(6,1)打印 WebBrowser.ExecWB(8,1)打印设置 WebBrowser.ExecWB(7,1)打印预览 WebBrowser.ExecWB(6,6)直接打印
        return (colHeaders);
        //*************************************************************//

    }

    /// <summary>
    /// 当前用户
    /// </summary>
    public ACCTRUE.WMSBLL.Model.User CUSER
    {
        get
        {
            if (Session[Config.Curren_User] != null)
                return (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
            return null;
        }
    }
    /// <summary>
    /// 报表服务器地址
    /// </summary>
    public string ReportURL
    {
        get
        {
            string rReprtUrl=ConfigurationManager.AppSettings["ReportURL"];
            return rReprtUrl;
        }
    }
}
