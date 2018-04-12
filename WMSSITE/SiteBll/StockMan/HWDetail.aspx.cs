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
using ACCTRUE.WMSBLL.QueryBll;
using System.Text;

public partial class SiteBll_StockMan_HWDetail :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DrawHWView();
        }
    }

    private void DrawHWView()
    {
        string store = (!String.IsNullOrEmpty(Request["STORE"])) ? Request["STORE"] : "";
        string strMinRow = (!String.IsNullOrEmpty(Request["MINROW"])) ? Request["MINROW"] : "0";
        string strMaxRow = (!String.IsNullOrEmpty(Request["MAXROW"])) ? Request["MAXROW"] : "0";
        string strMinCol = (!String.IsNullOrEmpty(Request["MINCOL"])) ? Request["MINCOL"] : "0";
        string strMaxCol = (!String.IsNullOrEmpty(Request["MAXCOL"])) ? Request["MAXCOL"] : "0";
        string strHeight = (!String.IsNullOrEmpty(Request["HEIGTH"])) ? Request["HEIGTH"] : "0";
        string strWeigth = (!String.IsNullOrEmpty(Request["WEIGHT"])) ? Request["WEIGHT"] : "0";
        try
        {
            DataSet ds = HWViewQuery.GetHWView(store, Convert.ToInt32(strMinRow), Convert.ToInt32(strMaxRow), Convert.ToInt32(strMinCol), Convert.ToInt32(strMaxCol));
            if (ds == null)
            {
                this.PrintfError("没有要查询的货位信息！");
                return;
            }
            int maxCol = Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["hwcolumn"]);
            DataRow[] rows = ds.Tables[0].Select("1=1", "hwrow");
            int maxRow = Convert.ToInt32(rows[rows.Length - 1]["hwrow"]);
            CreateView(ds, maxCol, maxRow,store,strHeight,strWeigth);
        }
        catch
        {
            this.PrintfError("数据错误！");
            return;
        }
    }
    //创建货位视图
    private void CreateView(DataSet ds, int maxCol, int maxRow,string store,string height,string weight)
    {
        StringBuilder outSb = new StringBuilder();
        outSb.Append("<html><head><LINK href=\"../../CSS/Input.css\" type=\"text/css\" rel=\"stylesheet\"></head><body bgcolor='#d4d0c8'>");
        outSb.Append("<table cellpadding=\"1\" cellspacing=\"1\">");
        for (int i = 1; i <= maxRow; i++)
        {
            outSb.Append("<tr>");
            for (int k = 1; k <= maxCol; k++)
            {
                outSb.Append("<td valign=\"top\" style=\"width:");
                outSb.Append(weight);
                outSb.Append("px;height:");
                outSb.Append(height);
                outSb.Append("px;\">");
                string hwID = store + string.Format("{0:d02}", i) + string.Format("{0:d02}", k);
                DataRow[] rows = ds.Tables[0].Select("hwid='"+hwID+"'");//找出货位上的所有货物
                if (rows.Length > 0)
                {
                    outSb.Append("<div style=\"overflow:auto;width:");
                    outSb.Append(weight);
                    outSb.Append("px;heigth:");
                    outSb.Append(height);
                    outSb.Append("px;\">");
                    outSb.Append("<table width=\"100%\"><tr><td colspan='2'>");
                    outSb.Append("货位：" + rows[0]["hwid"].ToString());
                    outSb.Append("</td></tr><tr><td><img src='");
                    if (rows.Length == 1 && string.IsNullOrEmpty(rows[0]["ph"].ToString()))//没有货物
                    {
                        outSb.Append("../../Images/icon/Empty.gif");//无货图片
                    }
                    else
                    {
                        outSb.Append("../../Images/icon/Fill.gif");//有货图片
                    }
                    outSb.Append("'/></td><td>行：");
                    outSb.Append(i.ToString());
                    outSb.Append("</br>列：");
                    outSb.Append(k.ToString());
                    outSb.Append("</td></tr>");
                    if (rows.Length == 1 && string.IsNullOrEmpty(rows[0]["ph"].ToString()))//没有货物
                    {
                        outSb.Append("<tr><td colspan='2'>物料：无</td></tr>");
                    }
                    else
                    {
                        foreach (DataRow mRow in rows)
                        {
                            string strFontColor = "";
                            if (!string.IsNullOrEmpty(mRow["kl"].ToString()) && Convert.ToInt32(mRow["kl"]) <= 30)
                            {
                                strFontColor = "style=\"color: green;\"";
                            }
                            if (!string.IsNullOrEmpty(mRow["kl"].ToString()) && Convert.ToInt32(mRow["kl"]) > 30)
                            {
                                strFontColor = "style=\"color:yellow;\"";
                            }
                            if (!string.IsNullOrEmpty(mRow["kl"].ToString()) && Convert.ToInt32(mRow["kl"]) > 60)
                            {
                                strFontColor = "style=\"color:red;\"";
                            }
                            outSb.Append("<tr><td colspan='2' ");
                            outSb.Append(strFontColor);
                            outSb.Append(" >");
                            outSb.Append("["+mRow["pch"].ToString()+"]");
                            outSb.Append("[" + mRow["sx"].ToString() + "]");
                            outSb.Append("[" + mRow["ph"].ToString() + "]");
                            outSb.Append("[" + mRow["gg"].ToString() + "]" + "卷数:");
                            outSb.Append(mRow["js"].ToString());
                            outSb.Append("</td></tr>");
                        }
                    }
                    outSb.Append("</table></div>");
                }
                outSb.Append("</td>");
            }
            outSb.Append("</tr>");
        }
        outSb.Append("</table></body></html>");
        Response.Write(outSb.ToString());
    }
}
