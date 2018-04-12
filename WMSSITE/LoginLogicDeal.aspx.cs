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

public partial class LoginLogicDeal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request["TYPE"]))
        {
            string strType=Request["Type"];
            if (strType == "LOGINOUT")
            {
                if (Session[Config.Curren_User] != null)
                {
                    ACCTRUE.WMSBLL.Model.User c_User = (ACCTRUE.WMSBLL.Model.User)Session[Config.Curren_User];
                    c_User.SetUserLoginOut();
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }
            }
        }
    }
}
