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
public partial class SiteBll_PDMan_TestYSDH : AccPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["YSDH"].ToString().Trim()))
                {
                    string YSDH = Request.QueryString["YSDH"].ToString().Trim();
                    DataSet ds = PDParam.TestYSDH(YSDH);
                    if ((ds == null) || (ds.Tables[0].Rows.Count < 1))
                    {
                        Response.Write("no");
                    }
                    else
                    {
                        Response.Write(ds.Tables[0].Rows[0]["CK"].ToString() + "," + ds.Tables[0].Rows[0]["CKName"].ToString() + "," + ds.Tables[0].Rows[0]["PDRQ"].ToString());
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
