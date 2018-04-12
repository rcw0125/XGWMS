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
public partial class SiteBll_InDoor_OutDoorOK : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOK_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            InDoorParam indoor = new InDoorParam();
            ACCTRUE.WMSBLL.Model.User user = (ACCTRUE.WMSBLL.Model.User)(Session[Config.Curren_User]);
            if (indoor.Update2(Request["FYDH"], 3, Config.Curuserid, DateTime.Now))
            {
                this.WriteClientJava("window.alert('该发运单现在可以出门了！');window.close();");
                indoor.setICIDoutdoor(Request["ICID"], Request["FYDH"]);
            }
        }
        catch (Exception ex)
        {
            String strEx = ex.Message;
            this.PrintfError("第三种情况出现错误，请重试！");
            return;
        }
    }
}
