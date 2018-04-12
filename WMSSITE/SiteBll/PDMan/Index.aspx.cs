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

public partial class SiteBll_PDMan_Index : System.Web.UI.Page
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
                if (TYPE.Trim() == "盘点粗盘单")
                    RigthURL = "CuPan.aspx";
                if (TYPE.Trim() == "盘点抽盘单")
                    RigthURL = "ChouPan.aspx";
                if (TYPE.Trim() == "盘点数据上传")
                    RigthURL = "PDData.aspx";
                if (TYPE.Trim() == "自由盘点")
                    RigthURL = "ZYPDData.aspx";
                if (TYPE.Trim() == "盘点参考")
                    RigthURL = "PDCKSearch.aspx";
            }
        }
    }
}
