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

public partial class SiteBll_CheckQu_Index : System.Web.UI.Page
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
                if (TYPE.Trim() == "质检")
                    RigthURL = "QuMain.aspx";
                if (TYPE.Trim() == "质量原因")
                    RigthURL = "QuReason.aspx";
                if (TYPE.Trim() == "标准维护")
                    RigthURL = "QuStand.aspx";
                if (TYPE.Trim() == "质量原因")
                    RigthURL = "QuReason.aspx";
                if (TYPE.Trim() == "特殊信息")
                    RigthURL = "QuSpecial.aspx";
                if (TYPE.Trim() == "卷信息查询")
                    RigthURL = "QuBarcode.aspx";
                if (TYPE.Trim() == "签证装车确认")
                    RigthURL = "qufydqr.aspx";
            }
        }
    }
}
