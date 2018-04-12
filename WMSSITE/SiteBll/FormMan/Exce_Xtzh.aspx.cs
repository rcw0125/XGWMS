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
using ACCTRUE.WMSBLL.QueryBll;
using System.Collections.Generic;

public partial class SiteBll_FormMan_Exce_Xtzh :AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action=Request.QueryString["action"];
        switch (action)
        {
            case "modixtzh":
                string zkdh="";
                string operatFlag;
                string ck;
                zkdh=Request.QueryString["zkdh"];
                ck = Request.QueryString["ck"];
               operatFlag=Request.QueryString["flag"];
                if (CUSER.UserID == "")
                {
                    Response.Write("wronguser");
                }
                int i = XTZHQuery.Exec_Xtzk(zkdh, CUSER.UserID,operatFlag);
                switch (i)
                {
                    case -1:
                        Response.Write("yichong");
                        break;
                    case 0:
                        XTZHQuery xtzh = new XTZHQuery();
                        xtzh.Insert_Xtzk(zkdh, CUSER.UserID, ck);
                        Response.Write("success");
                        break;
                    case 1:
                        Response.Write("1");
                        break;
                    case 2:
                        Response.Write("2");
                        break;
                    case 3:
                        Response.Write("3");
                        break;
                    case 4:
                        Response.Write("4");
                        break;
                    case 5:
                        Response.Write("5");
                        break;
                    case 6:
                        Response.Write("6");
                        break;
                    case 7:
                        Response.Write("7");
                        break;
                    case 8:
                        Response.Write("8");
                        break;
                }
                break;
               
        }
    }
}
