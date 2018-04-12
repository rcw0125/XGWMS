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

public partial class SiteBll_FormMan_Index : System.Web.UI.Page
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
                if (TYPE.Trim() == "完工单查询")
                    RigthURL = "QWGD.aspx";
                if (TYPE.Trim() == "发运单查询")
                    RigthURL = "QFYD.aspx";
                if (TYPE.Trim() == "转库单查询")
                    RigthURL = "QZKD.aspx";
                if (TYPE.Trim() == "移位单查询")
                    RigthURL = "QYWD.aspx";
                if (TYPE.Trim() == "退货单查询")
                    RigthURL = "QTHD.aspx";
                if (TYPE.Trim() == "待判品查询")
                    RigthURL = "QDPP.aspx";
                if (TYPE.Trim() == "形态转换")
                    RigthURL = "QXTZH.aspx";
                if (TYPE.Trim() == "发运单监控查询")
                    RigthURL = "Fyd_QrSearch.aspx";
            }
        }
    }
}
