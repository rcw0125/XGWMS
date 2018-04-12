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

public partial class SiteBll_StockMan_Index : System.Web.UI.Page
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
                if (TYPE.Trim() == "入库账簿")
                    RigthURL = "RKZBView.aspx";
                if (TYPE.Trim() == "出库帐簿")
                    RigthURL = "CKZBView.aspx";
                if (TYPE.Trim() == "当前库存")
                    RigthURL = "KuCunQuery.aspx";
                if (TYPE.Trim() == "预约量查询")
                    RigthURL = "YYLQuery.aspx";
                if (TYPE.Trim() == "批次管理")
                    RigthURL = "PICIQuery.aspx";
                if (TYPE.Trim() == "货位视图")
                    RigthURL = "HWView.aspx";
                if (TYPE.Trim() == "其他入库")
                    RigthURL = "QTRKReport.aspx";
                if (TYPE.Trim() == "其他出库")
                    RigthURL = "QTCKDan.aspx";
                if (TYPE.Trim() == "库存结构")
                    RigthURL = "KCJG.aspx";
            }
        }
    }
}
