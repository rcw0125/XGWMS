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
using ACCTRUE.WMSBLL;
using ACCTRUE.WMSBLL.Model;
//徐慧杰
public partial class SiteBll_InDoor_getICNumber : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["icid"].ToString().Trim()))
                {
                    string icid = Request.QueryString["icid"].ToString().Trim();
                    InDoorParam indoor = new InDoorParam();
                    DataSet dsicnumber = indoor.GetICNumber(icid);
                    if (dsicnumber != null)
                    {
                        Response.Write(dsicnumber.Tables[0].Rows[0]["ICNumber"].ToString()+","+dsicnumber.Tables[0].Rows[0]["CPH"].ToString()+","+dsicnumber.Tables[0].Rows[0]["KHLB"].ToString());
                       
                    }
                }
            }
            catch
            {
                this.PrintfError("数据错误！");
            }
        }
    }
}
