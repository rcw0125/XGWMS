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
//徐慧杰
public partial class SiteBll_InDoor_Index : System.Web.UI.Page
{
    public string TYPE;
    public string RigthURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["TYPE"]))
            {
                TYPE = Request["TYPE"].Trim();
                if (TYPE.Trim() == "进门管理")
                    RigthURL = "InDoor.aspx";
                if (TYPE.Trim() == "出门管理")
                    RigthURL = "OutDoor.aspx";
            }
        }
    }
}
