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
using ACCTRUE.WMSBLL.QueryBll;

public partial class SiteBll_PDMan_ZYPDItem : AccPageBase
{   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request["PDDH"]))
            {
                string strFYDH = Request["PDDH"];
                try
                {
                    DataSet ds = ZYPdd.GetPDDItems(strFYDH);
                    this.grdGridList.DataSource = ds;
                    this.grdGridList.DataBind();
                }
                catch(Exception ex)
                {
                    this.PrintfError("数据访问失败！");
                    return;
                }
            }
        }
    }
}