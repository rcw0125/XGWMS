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

public partial class SiteBll_DataOpern_Index : System.Web.UI.Page
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
                if (TYPE.Trim() == "迁移日志浏览")
                    RigthURL = "DataMoveBrowse.aspx";
                if (TYPE.Trim() == "数据回迁")
                    RigthURL = "DataReturn.aspx";
                if (TYPE.Trim() == "传输日志")
                    RigthURL = "DataTraLog.aspx";
                if (TYPE.Trim() == "日志删除")
                    RigthURL = "LogDelete.aspx";
            }
        }
    }
}
