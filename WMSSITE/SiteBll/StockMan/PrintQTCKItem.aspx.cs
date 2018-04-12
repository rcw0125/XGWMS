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
using ACCTRUE.WMSBLL.QueryBll;
public partial class SiteBll_StockMan_PrintQTCKItem : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string CKDH = Request["CKDH"];
            this.hidCKDH.Value = CKDH;
            if (!string.IsNullOrEmpty(CKDH))
            {
                BindItem(CKDH);
                BindDJMX(CKDH);
            }
        }
    }
    protected void DJlink_Click(object sender, EventArgs e)
    {
        grvQTCKMX.Visible = false;
        grvDJMX.Visible = true;
    }
    protected void QTCKlink_Click(object sender, EventArgs e)
    {
        grvQTCKMX.Visible = true;
        grvDJMX.Visible = false;
    }

    private void BindItem(string CKDH)
    {
        try
        {
            DataSet ds = QTCKQuery.GetPrintItem(CKDH);
            this.grvQTCKMX.DataSource = ds;
            this.grvQTCKMX.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }

    private void BindDJMX(string CKDH)
    {
        try
        {
            DataSet ds = QTCKQuery.GetPrintDJMX(CKDH);
            this.grvDJMX.DataSource = ds;
            this.grvDJMX.DataBind();
        }
        catch
        {
            this.PrintfError("数据访问错误");
            return;
        }
    }
}
