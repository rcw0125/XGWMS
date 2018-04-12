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

public partial class SiteBll_SysMan_HelperAffiche_colorselect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        int onrow = 1;
        int oncol = 1;
        int count = 1;
        string s = "";
        string set1 = "";
        string set2 = "";
        for (int r = 5; r >= 0; r--)
        {
            for (int g = 5; g >= 0; g--)
            {
                for (int b = 5; b >= 0; b--)
                {
                    if (oncol == 1) s += "<tr>\n";
                    s += "\t<td onmouseover=\"colorOver(this);\" onclick=\"colorClick(this);\" style=\"background-color:" + ReturnHex(r) + ReturnHex(g) + ReturnHex(b) + ";\" style=\"WIDTH: 10px; HEIGHT: 8px\"></td>\n";
                    oncol++;
                    if (oncol >= 19)
                    {
                        s += "</tr>\n";
                        oncol = 1;

                        if (onrow % 2 == 0)
                        {
                            set2 += s;
                        }
                        else
                        {
                            set1 += s;
                        }
                        s = "";
                        onrow++;
                    }
                    count++;
                }
            }
        }
        Colors.Text = "<table cellpadding=0 cellspacing=1 style=\"background-color:ffffff;\" border=0 >" + set1 + set2 + "</table>";
    }

    string ReturnHex(int i)
    {
        switch (i)
        {
            default:
            case 0:
                return "00";
            case 1:
                return "33";
            case 2:
                return "66";
            case 3:
                return "99";
            case 4:
                return "CC";
            case 5:
                return "FF";
        }
    }
}
